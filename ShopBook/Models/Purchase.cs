using System;
namespace ShopBook.Models
{
    public class Purchase
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string Store { get; set; }
    }
}
