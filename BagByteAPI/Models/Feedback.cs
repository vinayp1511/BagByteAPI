using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BagByteAPI.Models
{
    public class Feedback
    {
        public long FeedbackID { get; set; }
        public long UserID { get; set; }
        public long ProductID { get; set; }
        public string Description { get; set; }
        public DateTime FeedbackDate { get; set; }
        public string Reply { get; set; }
    }
}