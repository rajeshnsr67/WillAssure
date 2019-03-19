using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class AlternateBeneficiaryModel
    {
      public int lnk_bd_id { get; set; }
      public int bpId {  get;  set;  }
      public string First_Name {  get;  set;  }
      public string Last_Name {  get;  set;  }
      public string Middle_Name {  get;  set;  }
      public DateTime DOB {  get;  set;  }
      public string Mobile {  get;  set;  }
      public string Relationship {  get;  set;  }
      public string Marital_Status {  get;  set;  }
      public string Religion {  get;  set;  }
      public string Identity_Proof {  get;  set;  }
      public string Identity_Proof_Value {  get;  set;  }
      public string Alt_Identity_Proof {  get;  set;  }
      public string Alt_Identity_Proof_Value {  get;  set;  }
      public string Address1 {  get;  set;  }
      public string Address2 {  get;  set;  }
      public string Address3 {  get;  set;  }
      public string City {  get;  set;  }
      public string State {  get;  set;  }
      public string Pin {  get;  set;  }

      public int RelationshipId { get; set; }
      public int RelationshipTxt { get; set; }
     

     public int stateid { get; set; }
     public string statetext { get; set; }

        public int cityid { get; set; }
        public string citytext { get; set; }


        public int Marital_Status_Id { get; set; }
        public string Marital_Status_Txt { get; set; }


        public int Religion_ID { get; set; }
        public string Religion_TXT { get; set; }

    }
}