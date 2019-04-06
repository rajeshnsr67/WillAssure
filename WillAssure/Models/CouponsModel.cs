using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class CouponsModel
    {
        public int Id { get; set; }
        public int Coupon_Number { get; set; }
        public int Discount_Percentge { get; set; }
        public string Description { get; set; }
        public string status { get; set; }


    }
}