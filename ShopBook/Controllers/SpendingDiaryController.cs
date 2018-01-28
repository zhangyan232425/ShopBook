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
        public IActionResult Index(string StoreFilter,DateTime StartDate, DateTime? EndDate =null)
        {
            //get the list of store
            var StoreName = _context.Products
                                    .Where(p=>p.Store!=" " && p.Store!= null)
                                    .Select(p => p.Store)
                                    .Distinct().ToList();
            StoreName.Insert(0," ");
            ViewBag.StoreName = StoreName;

            //get show data
            var data = _context.Products.Where(p => p.Store != " " && p.Store != null);
            if(!String.IsNullOrEmpty(StoreFilter))
            {
                data = data.Where(p => p.Store.Contains(StoreFilter));
            }
            if(!EndDate.HasValue)
            {
                EndDate = DateTime.Today;
            }
            data  = data.Where(p=>p.ProductDate>=StartDate && p.ProductDate<=EndDate).OrderByDescending(p=>p.ProductDate);
            ViewBag.TotalSpend = "$"+data.Sum(p => p.Price).ToString("#0.00");          
            return View(data);

        }



       // Add new diary
       public static List<Product> NewAddProducts = new List<Product>();
        public IActionResult AddReceipt(Product NewItem)
       {
            
            NewAddProducts.Add(NewItem);

            ViewProduct vp = new ViewProduct
            {
                Products = NewAddProducts
            };

            return View(vp);
       }
   

        public async Task<IActionResult>AddAsync(ViewProduct vp)
        {
            vp.NewProduct.ProductDate = DateTime.Today;
            _context.Products.Add(vp.NewProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("AddReceipt",vp.NewProduct);
        }



    }
}
