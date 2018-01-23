using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBook.Context;
using ShopBook.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBook.Controllers
{
    public class SpendingDiaryController : Controller
    {
        private readonly ProductDbContext _context;
        public SpendingDiaryController(ProductDbContext context)
        {
            _context = context;
        }

        // Index page
        public IActionResult Index(Product Product)
        {
            //get total spending
            List<Product> ProductList = new List<Product>();
            ViewBag.TotalSpend = "$"+_context.Products.Sum(p => p.Price).ToString("#0.00");
            
            //get the list of store 
            var StoreName = _context.Products
                                    .Select(p => p.Store)
                                    .Distinct();
            ViewBag.StoreName = StoreName;
            // get the select store  
            ViewBag.SelectStore = Product.Store;

            //get start date

            DateTime startdate = Product.ProductDate.Date;
            ViewBag.day = startdate;
          
            return View();

        }



       // Add new diary
       static List<Product> NewAddProducts = new List<Product>();
        public IActionResult AddReceipt(Product NewItem)
       {
            
            NewAddProducts.Add(NewItem);

            ViewProduct vp = new ViewProduct
            {
                Products = NewAddProducts
            };

            return View(vp);
       }
   

        public async Task<IActionResult>Add(ViewProduct vp)
        {
            vp.NewProduct.ProductDate = DateTime.Today;
            _context.Products.Add(vp.NewProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("AddReceipt",vp.NewProduct);
        }



    }
}
