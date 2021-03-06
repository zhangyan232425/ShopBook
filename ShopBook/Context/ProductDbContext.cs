﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using ShopBook.Models;

namespace ShopBook.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         //   builder.Entity<Product>()
          //  .Property(p=>p.UnitPrice)
           // .HasComputedColumnSql([Price]/[Weight]);
        }

    }
}