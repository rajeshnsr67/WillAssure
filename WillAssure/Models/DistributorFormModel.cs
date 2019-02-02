using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class DistributorFormModel
    {

        public int compId { get; set; }

        public string companyName { get; set; }

        public string ownerName { get; set; }

        public string ownerMobileNo { get; set; }


        public string Address1 { get; set; }

        public string Address2 { get; set; }


        public string City { get; set; }


        public string State { get; set; }


        public string Pin { get; set; }

        public string GST_NO { get; set; }

        public string Identity_Proof { get; set; }


        public string Identity_Proof_Value { get; set; }

        public string Alt_Identity_Proof { get; set; }

        public string Alt_Identity_Proof_Value { get; set; }


        public string contactPerson { get; set; }

        public string contactMobileNo { get; set; }

        public string contactMailId { get; set; }

        public string bankName { get; set; }

        public string Branch { get; set; }

        public string accountNumber { get; set; }

        public string IFSC_Code { get; set; }

        public string accountName { get; set; }

        public string Referred_By { get; set; }

        public string leadgeneratedBy { get; set; }

        public string leadconvertedBy { get; set; }

        public string relationshipManager { get; set; }

        public string leadStatus { get; set; }

        public string leadRemark { get; set; }



    }
}