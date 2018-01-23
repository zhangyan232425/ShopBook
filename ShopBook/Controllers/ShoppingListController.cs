using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        
        public IActionResult Index()
        {
            //get the item whose store is null or empty
            var products = _context.Products.Where(p => p.Store == " " || p.Store == null);
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

        public async Task<IActionResult> Delete(int id)
        {
            
            var product = await _context.Products.AsNoTracking()
            .SingleOrDefaultAsync(p => p.ID == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }




    }
}
