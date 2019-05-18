using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class VisitorModel
    {
        public int vid { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string RefDist { get; set; }
  
        public int uid { get; set; }


        public int Document_Created_By_ID { get; set; }
        public string Document_Created_By_txt { get; set; }

        public string documenttypec { get; set; }
        public string documentcategory { get; set; }


        public int distributor_id { get; set; }
        public string distributor_txt { get; set; }


        public string userPassword { get; set; }
        public string MobileOTP { get; set; }
        public string EmailOTP { get; set; }



        public string txtCoupon { get; set; }

        public string Amt_Paid_By_txt { get; set; }

        public string Amt_Paid_By_By_ID { get; set; }


        public string Amt_Paid_By { get; set; }

        public string Document_Created_By { get; set; }


        public int tId { get; set; }
        public string DocumentType { get; set; }


        public int Authentication_Required { get; set; }

        public int Link_Required { get; set; }


        public int Login_Required { get; set; }


        public string Identity_proof_Value { get; set; }
        public string documenttype11 { get; set; }
    }
}