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
    public class SpendingDiaryController : Controller
    {
        private readonly ProductDbContext _context;
        public SpendingDiaryController(ProductDbContext context)
        {
            _context = context;
        }

        // Index page
        public IActionResult Index()
        {
            ViewProduct vp = new ViewProduct()
            {
                Products = _context.Products.ToList()
            };

            return View(vp);
        }



       // Add new diary
        public async Task<IActionResult>Add(ViewProduct vp)
        {
            vp.NewProduct.ProductDate = DateTime.Today;
            _context.Products.Add(vp.NewProduct);
            await _context.SaveChangesAsync();
            return View(vp);
        }
       

       //Edit Product

    }
}
