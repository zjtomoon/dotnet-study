using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Storage;

namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //QueryingCategories();
            //QueryingProducts();
            //QueryingWithLike();
            if (AddProduct(6,"Bob's Burgers",500M))
            {
                WriteLine("Add product successful");
            }
            ListProducts(); 
            /*if (IncreaseProductPrice("Bob", 20M))
            {
                WriteLine("Update product price successful.");
            }
            ListProducts();*/
            int deleted = DeleteProducts("Bob");
            WriteLine($"{deleted} product(s) where deleted.");
            ListProducts();
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Categories and how many products they have:");
                //IQueryable<Category> cats = db.Categories.Include(c => c.Products);//立即加载模式
                //IQueryable<Category> cats = db.Categories; //延迟加载
                
                //显式加载实体
                IQueryable<Category> cats;
                db.ChangeTracker.LazyLoadingEnabled = false;
                Write("Enable eager loading? (Y/N): ");
                bool eagerloading = (ReadKey().Key == ConsoleKey.Y);
                bool explicitloading = false;
                WriteLine();
                if (eagerloading)
                {
                    cats = db.Categories.Include(c => c.Products);
                }
                else
                {
                    cats = db.Categories;
                    Write("Enable explicit loading? (Y/N): ");
                    explicitloading = (ReadKey().Key == ConsoleKey.Y);
                    WriteLine();
                }
                foreach (Category c in cats)
                {
                    if (explicitloading)
                    {
                        Write($"Explicitly load products for {c.CategoryName}? (Y/N):");
                        ConsoleKeyInfo key = ReadKey();
                        WriteLine();

                        if (key.Key == ConsoleKey.Y)
                        {
                            var products = db.Entry(c).Collection(c2 => c2.Products);
                            if (!products.IsLoaded)
                            {
                                products.Load();
                            }
                        }
                    }
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }

        static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                WriteLine("Products that cost more than a price,highest at top.");
                string input;
                decimal price;
                do
                {
                    Write("Enter a product price: ");
                    input = ReadLine();
                } while (!decimal.TryParse(input,out price));

                IOrderedEnumerable<Product> prods = db.Products
                    .AsEnumerable()
                    .Where(product => product.Cost > price)
                    .OrderByDescending(product => product.Cost);

                foreach (Product item in prods)
                {
                    WriteLine("{0} : {1} costs {2:$#,##0.00} and has {3} in stock.",
                        item.ProductID,item.ProductName,item.Cost,item.Stock);
                }
            }
        }

        //模糊搜索
        static void QueryingWithLike()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());
                Write("Enter part of a product name:");
                string input = ReadLine();

                IQueryable<Product> prods = db.Products
                    .Where(p => EF.Functions.Like(p.ProductName, $"%{input}"));

                foreach (Product item in prods)
                {
                    WriteLine("{0} has {1} units in stock. Discontinued ? {2}",
                        item.ProductName,item.Stock,item.Discontinued);
                }
            }
        }

        static bool AddProduct(int categoryID, string productName, decimal? price)
        {
            using (var db = new Northwind())
            {
                var newProduct = new Product
                {
                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price
                };

                db.Products.Add(newProduct);

                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}",
                    "ID","Product Name","Cost","Stock","Disc.");

                foreach (var item in db.Products/*.OrderByDescending(p => p.Cost)*/) 
                {
                    /*
                     SQLite cannot order by expressions of type 'decimal'. Convert the values to 
                     a supported type or use LINQ to Objects to order the results
                    */
                    WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
                        item.ProductID,item.ProductName,item.Cost,
                        item.Stock,item.Discontinued);
                }
            }
        }

        static bool IncreaseProductPrice(string name, decimal amount)
        {
            using (var db = new Northwind())
            {
                Product updateProduct = db.Products.First(
                    p => p.ProductName.StartsWith(name));

                updateProduct.Cost += amount;

                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        static int DeleteProducts(string name)
        {
            using (var db = new Northwind())
            {
                /*IEnumerable<Product> products = db.Products.Where(p => p.ProductName.StartsWith(name));
                db.Products.RemoveRange(products);
                int affected = db.SaveChanges();
                return affected;*/
                //定义显式事务
                //添加语句以启动显式事务并输出隔离级别
                using (IDbContextTransaction t = db.Database.BeginTransaction())
                {
                    WriteLine("Transaction isolation level: {0}",
                        t.GetDbTransaction().IsolationLevel);
                    var products = db.Products.Where(
                        p => p.ProductName.StartsWith(name));
                    db.Products.RemoveRange(products);
                    int affected = db.SaveChanges();
                    t.Commit();
                    return affected;
                }
            }
        }
        
    }
}