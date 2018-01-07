using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBook.Context;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopBook.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;
        public ProductController(ProductDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder)?"name_desc":"";
            ViewData["PriceSortParm" ]= sortOrder== "Price" ? "price_desc":"Price";
            ViewData["DataSortParm"] = sortOrder=="Date"?"date_desc" :"Date";
            
            var product  = from item  in _context.Products
                            select item;
            
            switch(sortOrder)
            {
                case "name_desc":
                    product = product.OrderByDescending(p=>p.Name);
                    break;
                case "price_desc":
                    product = product.OrderByDescending(p=>p.Price);
                    break;
                case "date_desc":
                    product = product.OrderByDescending(p=>p.ProductDate);
                    break;

            }
            return View(await product.AsNoTracking().ToListAsync());
        }
    }
}
