using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class TestatorFamilyModel
    {

        public int fId { get; set;}
      public string First_Name{ get; set; }
      public string Last_Name{ get; set; }
      public string Middle_Name{ get; set; }
      public string Dob{ get; set; }
      public string Marital_Status{ get; set; }
      public string Religion{ get; set; }
      public string Relationship{ get; set; }
      public string Address1{ get; set; }
      public string Address2{ get; set; }
      public string Address3{ get; set; }

        public string City{ get; set; }
        public int City_id { get; set; }
        public string City_txt { get; set; }


        public string State{ get; set; }
        public int State_id { get; set; }
        public string State_txt { get; set; }


        public int RelationshipId { get; set; }
        public string RelationshipTxt { get; set; }

      public string Pin{ get; set; }
      public int tId{ get; set; }
      public string active{ get; set; }
      public string Identity_Proof{ get; set; }
      public string Identity_Proof_Value{ get; set; }
      public string Alt_Identity_Proof{ get; set; }
      public string Alt_Identity_Proof_Value{ get; set; }
      public string Is_Informed_Person{ get; set; }



        public int ddltid { get; set; }

        public string ddltestatorname { get; set; }



        public string chek { get; set; }


    };
};