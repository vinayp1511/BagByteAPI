using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BagByteAPI.Models
{
    public class Productcategory
    {
        public long ProductID { get; set; }
        public string ProCatName { get; set; }
        //public byte[] ProImage { get; set; }
        public string ImageName { get; set; }
        public string ImageLocation { get; set; }

    }

    public class Product
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProCatName { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        //public byte[] ProImage { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageName { get; set; }
        public string ImageLocation { get; set; }

    }
}