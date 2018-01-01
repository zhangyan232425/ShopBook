using System;
using System.ComponentModel.DataAnnotations;

namespace ShopBook.Models
{
    public class List
    {
        public Guid ListId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ListDate { get; set; }
        public string ProductName { get; set; }
    }
}
