﻿using System;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Console;
using System.Xml.Linq;

namespace LinqWithEFCore
{
    class Program
    {
        static void FilterAndSort()
        {
            using (var db = new Northwind())
            {
                var query = db.Products
                    .ProcessSequence()
                    .Where(product => product.UnitPrice < 10M )
                    .OrderByDescending(product => product.UnitPrice)
                    .Select(product => new
                    {
                        product.ProductID,
                        product.ProductName,
                        product.UnitPrice
                    });
                WriteLine("Products that cost less than $10");
                foreach (var item in query)
                {
                    WriteLine("{0} : {1} cost {2:$#,##0.00}",
                        item.ProductID,item.ProductName,item.UnitPrice);
                }
                WriteLine();
            }
        }

        //连接和分组序列
        static void JoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                var queryJoin = db.Categories.Join(
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c,p) => new {c.CategoryName,p.ProductName,p.ProductID}
                ).OrderBy(cp => cp.ProductID);

                foreach (var item in queryJoin)
                {
                    WriteLine("{0} : {1} is in {2}",
                        arg0: item.ProductID,
                        arg1: item.ProductName,
                        arg2: item.CategoryName);
                }
            }
        }

        static void GroupJoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                var queryGroup = db.Categories.AsEnumerable().GroupJoin( //如果没有调用AsEnumerable方法，就会抛出异常
                    /*
                     * 为了从IQeryable<T>转换为IEnumerable<T>，可以调用AsEnumerable方法
                     */
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryID,
                    innerKeySelector: product => product.CategoryID,
                    resultSelector: (c,matchingProducts) => new
                    {
                        c.CategoryName,
                        Products = matchingProducts.OrderBy(p => p.ProductName)
                    }
                );

                foreach (var item in queryGroup)
                {
                    WriteLine("{0} has {1} products.",
                        arg0: item.CategoryName,
                        arg1: item.Products.Count());

                    foreach (var product in item.Products)
                    {
                        WriteLine($" {product.ProductName}");
                    }
                }
            }
        }

        static void AggregateProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0,-25} {1,10}",
                    arg0: "Product count:",
                    arg1: db.Products.Count());
                
                WriteLine("{0,-25} {1,10:$#,##0.00}",
                    arg0: "Higest product price: ",
                    arg1: db.Products.Max(p => p.UnitPrice));
                WriteLine("{0,-25} {1,10:N0}",
                    arg0: "Sum of units in stock:",
                    arg1: db.Products.Sum(p => p.UnitsInStock));
                WriteLine("{0,-25} {1,10:N0}",
                    arg0: "Sum of units on order:",
                    arg1: db.Products.Sum(p => p.UnitsOnOrder));
                WriteLine("{0,-25} {1,10:$#,##0.00}",
                    arg0: "Average unit price:",
                    arg1: db.Products.Average(p => p.UnitPrice));
                WriteLine("{0,-25} {1,10:$#,##0.00}",
                    arg0: "value of units in stock:",
                    arg1: db.Products.AsEnumerable()
                        .Sum(p => p.UnitPrice * p.UnitsInStock));
            }
        }

        //自定义Linq扩展方法
        static void CustomExtensionMethod()
        {
            using (var db = new Northwind())
            {
                WriteLine("Mean units in stock: {0:N0}",
                    db.Products.Average(p => p.UnitsInStock));
                
                WriteLine("Mean units in stock : {0:$#,##0.00}",
                    db.Products.Average(p => p.UnitPrice));
                
                WriteLine("Median units in stock: {0:N0}",
                    db.Products.Median(p => p.UnitsInStock));
                
                WriteLine("Median unit price : {0:$#,##0.00}",
                    db.Products.Median(p => p.UnitPrice));
                
                WriteLine("Mode units in stock: {0:N0}",
                    db.Products.Mode(p => p.UnitsInStock));
                
                WriteLine("Mode unit price : {0:$#,##0.00}",
                    db.Products.Mode(p => p.UnitPrice));
                
            }
        }

        static void OutputProductsAsXml()
        {
            using (var db = new Northwind())
            {
                var productsForXml = db.Products.ToArray();

                var xml = new XElement("products",
                    from p in productsForXml
                    select new XElement("product",
                        new XAttribute("id", p.ProductID),
                        new XAttribute("price", p.UnitPrice),
                        new XElement("name", p.ProductName)));
                
                WriteLine(xml.ToString());
            }
        }

        static void ProcessSettings()
        {
            XDocument doc = XDocument.Load("settings.xml");
            var appSettings = doc.Descendants("appSettings")
                .Descendants("add")
                .Select(node => new
                {
                    Key = node.Attribute("key").Value,
                    Value = node.Attribute("value").Value
                }).ToArray();
            foreach (var item in appSettings)
            {
                WriteLine($"{item.Key} : {item.Value}");
            }
        }
        static void Main(string[] args)
        {
            FilterAndSort();
            //JoinCategoriesAndProducts();
            //GroupJoinCategoriesAndProducts();
            //AggregateProducts();
            //CustomExtensionMethod();
            //OutputProductsAsXml();
            //ProcessSettings();
        }
        
    }
}