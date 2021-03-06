﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using ShopBook.Context;
using ShopBook.Models;

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

        public async Task<IActionResult> Index(string filter,int page =1,string sortExpression = "Name")
        {
            var product = _context.Products.Where(p=> p.Store!= null && p.Store!="").AsNoTracking();
            if (!string.IsNullOrEmpty(filter)){
                product = product.Where(p=>p.Name.Contains(filter));
            }
            var model = await PagingList.CreateAsync(product,5,page,sortExpression,"Name");
            model.RouteValue = new RouteValueDictionary {
                { "filter", filter}
            };
            return View(model);
        }   
    }
}
