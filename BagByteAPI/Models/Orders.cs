using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BagByteAPI.Models
{
    public class Orders
    {
        public long OrderID { get; set; }
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public long UserID { get; set; }
        public string ProductImage { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
    }
}