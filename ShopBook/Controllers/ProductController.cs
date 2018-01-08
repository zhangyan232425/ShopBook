﻿using System;
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
        
        public async Task<IActionResult> Index(string sort,string search)
        {
            ViewData["NameSortParm"] = sort=="name_asc"?"name_desc":"name_asc";
            ViewData["PriceSortParm" ]= sort== "price_asc" ? "price_desc":"price_asc";
            ViewData["DateSortParm"] = sort=="date_asc" ? "date_desc":"date_asc";
            
            var product  = from item  in _context.Products
                            select item;
            if (!String.IsNullOrEmpty(search))
            {
                product = product.Where(p=>p.Name.Contains(search));
            }
            
            switch(sort)
            {
                case "name_desc":
                    product = product.OrderByDescending(p => p.Name);
                    break;
                case "name_asc":
                    product = product.OrderBy(p => p.Name);

                    break;
                case "price_desc":
                    product = product.OrderByDescending(p=>p.Price);
                    break;
                case "price_asc":
                    product = product.OrderBy(p => p.Price);
                    break;
                case "date_desc":
                    product = product.OrderByDescending(p=>p.ProductDate);
                    break;
                case "date_asc":
                    product = product.OrderBy(p => p.ProductDate);
                    break;
                

            }
            return View(await product.AsNoTracking().ToListAsync());
        }
    }
}
