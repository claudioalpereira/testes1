using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripRqst.Models
{
    public class PdfExample
    {
        public string Heading { get; set; }
        public IEnumerable<BasketItem> Items { get; set; }
    }

    public class BasketItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}