using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBook.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Store { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal Price { get; set; }

        public decimal Weight { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal UnitPrice { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ProductDate { get; set; } 
        public UnitEnum WeightUnit{ get; set;}
    }

}
