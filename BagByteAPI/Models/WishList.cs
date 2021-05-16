using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BagByteAPI.Models
{
    public class WishList
    {
        public long WishList { get; set; }
        public long ProductID{get; set;}
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public string ProductCatName { get; set; }
        public decimal Price { get; set; }
    }
}