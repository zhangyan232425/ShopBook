using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBook.Context;
using ShopBook.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBook.Controllers
{
    public class ShoppingListController : Controller
    {
        private ProductDbContext _context;
        public ShoppingListController(ProductDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = from p in _context.Products
                       where p.Store ==null
                           select p;


            ViewProduct vp = new ViewProduct()
            {
                Products = products.ToList()
            }; 
            return View(vp);
        }

        public async Task<IActionResult> Add(ViewProduct vp)
        {            
            vp.NewProduct.ProductDate = DateTime.Today;
            _context.Products.Add(vp.NewProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
