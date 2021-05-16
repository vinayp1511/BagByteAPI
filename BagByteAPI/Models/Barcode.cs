using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BagByteAPI.Models
{
    public class Barcode
    {
        public long BarcodeID { get; set; }
        public long OrderID { get; set; }
        public string ImageLocation { get; set; }
        public string ImageName { get; set; }
    }
}