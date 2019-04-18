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


        public int companyid { get; set; }
        public string companytxt { get; set; }


        public int NumberofDocument { get; set; }

        public string status { get; set; }



        public string PageName { get; set; }
        public string action { get; set; }
        public string actinsert { get; set; }
        public string actupdate { get; set; }
        public string actdelete { get; set; }


        public int tid { get; set; }
        public string ddtemptxt { get; set; }
        public int ddtempid { get; set; }

    }
}