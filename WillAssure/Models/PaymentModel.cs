using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class PaymentModel
    {

        public int distributorid { get; set; }
        public string distributortxt { get; set; }

        public int documentid { get; set; }
        public string documenttxt { get; set; }

       
        public int NumberofDocument { get; set; }

        public string status { get; set; }

    }
}