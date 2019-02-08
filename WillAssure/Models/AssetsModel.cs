using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class AssetsModel
    {
        public int amId { get; set; }
        public int aId { get; set; }

        public string assetsCode { get; set; }

        public string dueDate { get; set; }

        public string currentStatus { get; set; }

        public string issuedBy { get; set; }

        public string Location { get; set; }

        public string assetsValue { get; set; }

        public string certificateNumber { get; set; }

        public string propertyDescription { get; set; }

        public int Qty { get; set; }

        public int Weight { get; set; }

        public string ownerShip { get; set; }

        public int nId { get; set; }

        public string Remark { get; set; }

        public string Nomination { get; set; }

        public string NomineeDetails { get; set; }

        public string Name { get; set; }

        public string RegisteredAddress { get; set; }

        public string  PermanentAddress  { get; set; }

        public string Identity_proof { get; set; }

        public string Identity_proof_value { get; set; }


        public string Alt_Identity_proof { get; set; }

        public string Alt_Identity_proof_value { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Amount { get; set; }


        public string identifier { get; set; } 


        public string assettypetext { get; set; }
        public int assettypeid { get; set; }


        public string assetCategorytext { get; set; }
        public int assetCategoryid { get; set; }


    }
}