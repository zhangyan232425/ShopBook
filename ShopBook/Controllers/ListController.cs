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
        private ProductDbContext context;
        public ListController(ProductDbContext context)
        {
            this.context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewProduct vm = new ViewProduct()
            {
                Products = context.Products.ToList()
            }; 
            return View(vm);
        }

        public async Task<IActionResult> Add(ViewProduct vm)
        {
            
            vm.NewProduct.ProductId = Guid.NewGuid();
            vm.NewProduct.ProductDate = DateTime.Today;
            context.Products.Add(vm.NewProduct);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
