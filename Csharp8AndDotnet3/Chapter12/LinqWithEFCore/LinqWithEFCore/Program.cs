using System;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Console;

namespace LinqWithEFCore
{
    class Program
    {
        static void FilterAndSort()
        {
            using (var db = new Northwind())
            {
                var query = db.Products
                    .Where(product => product.UnitPrice < 10M )
                    .OrderByDescending(product => product.UnitPrice);
                WriteLine("Products that cost less than $10");
                foreach (var item in query)
                {
                    WriteLine("{0} : {1} cost {2:$#,##0.00}",
                        item.ProductID,item.ProductName,item.UnitPrice);
                }
                WriteLine();
            }
        }
        static void Main(string[] args)
        {
            FilterAndSort();
        }
        
    }
}