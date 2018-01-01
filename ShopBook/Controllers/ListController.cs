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
    public class ListController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        private ProductDbContext context;
        public ListController(ProductDbContext context)
        {
            this.context = context;
        }

        public IActionResult AddList()
        {
            return View();
        }

        public async Task<IActionResult> Add(Product NewProduct)
        {
            
            NewProduct.ProductId = Guid.NewGuid();
            NewProduct.ProductDate = DateTime.Today;
            context.Product.Add(NewProduct);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
