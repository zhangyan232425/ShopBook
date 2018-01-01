using System;
using Microsoft.EntityFrameworkCore;
using ShopBook.Models;

namespace ShopBook.Context
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public virtual DbSet<Product> Product { get; set; }
    }
}
