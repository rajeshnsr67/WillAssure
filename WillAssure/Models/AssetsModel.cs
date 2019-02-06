using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class AssetsModel
    {
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

        public int documentId { get; set; }

        public int tId { get; set; }

        public string Identity_Proof { get; set; }

        public string Identity_Proof_Value { get; set; }

        public string Alt_Identity_Proof  { get; set; }

        public string Alt_Identity_Proof_Value { get; set; }
    }
}