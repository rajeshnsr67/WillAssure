using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class CouponAllotementModel
    {

        public int couponId { get; set; }

        public int Coupon_Number_id { get; set; }
        public int Coupon_Number_txt { get; set; }


        public int distributor_id { get; set; }
        public string distributor_txt { get; set; }


        public string fromdate { get; set; }
        public string todate { get; set; }


        public int document_id { get; set; }
        public string  document_txt { get; set; }

        public string documenttype { get; set; }




    }
}