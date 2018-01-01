using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ShopBook.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProductDate { get; set; }
        public string Name { get; set; }
    }

    public class ProductModel
    {
        public List<Product> ProductList { get; set; }
    }
}
