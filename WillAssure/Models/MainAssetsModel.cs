using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class MainAssetsModel
    {
       public string assetsCode { get; set; }
       public string dueDate { get; set; }
       public string currentStatus { get; set; }
       public string issuedBy { get; set; }
       public string Location { get; set; }
       public string assetsValue { get; set; }
       public string certificateNumber { get; set; }
       public string propertyDescription { get; set; }
       public string Qty { get; set; }
       public string Weight { get; set; }
       public string ownerShip { get; set; }
       public string nId { get; set; }
       public string Remark { get; set; }
       public string documentId { get; set; }
       public string tId { get; set; }
       public string Identity_Proof { get; set; }
       public string Identity_Proof_Value { get; set; }
       public string Alt_Identity_Proof { get; set; }
       public string Alt_Identity_Proof_Value { get; set; }


       public string assettxt { get; set; }
       public string assetid { get; set; }

       public string column { get; set; }
       public string text { get; set; }


        public string assetcattxt { get; set; }
        public int assetcatid { get; set; }

    }
}