using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using Packt.Shared;

namespace NorthwindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        public IEnumerable<string> Suppliers { get; set; }
        
        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            Suppliers = db.Suppliers.Select(s => s.CompanyName);
            // Suppliers = new[]
            // {
            //     "Alpha Go", "Beta Limited", "Gamma Corp"
            // };
        }

        private Northwind db;

        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }
        
        [BindProperty] 
        public Supplier Supplier { get; set; }
        //通过使用[BindProperty]特性修饰Supplier属性，就可以轻松地将Web页面上地元素与Supplier类中地属性连接起来
        
        public IActionResult onPost()
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }

            return Page();
        }
    }
}