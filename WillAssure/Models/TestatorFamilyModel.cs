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




        // beneficiary property



        public int benebpId { get; set; }

        public string beneFirst_Name { get; set; }

        public string beneLast_Name { get; set; }

        public string beneMiddle_Name { get; set; }

        public string beneDob { get; set; }

        public string beneMobile { get; set; }

        public string beneRelationship { get; set; }
        public int beneRelationshipId { get; set; }
        public string beneRelationshipTxt { get; set; }

        public string beneMarital_Status { get; set; }
        public string beneMarital_Status_TXT { get; set; }
        public int beneMarital_Status_ID { get; set; }

        public string beneReligion { get; set; }
        public string beneReligion_txt { get; set; }
        public int beneReligion_id { get; set; }

        public string beneIdentity_proof { get; set; }
        public string beneIdentity_proof_txt { get; set; }
        public int beneIdentity_proof_id { get; set; }


        public string beneIdentity_proof_value { get; set; }

        public string beneAlt_Identity_proof { get; set; }

        public string beneAlt_Identity_proof_value { get; set; }

        public string beneAddress1 { get; set; }

        public string beneAddress2 { get; set; }

        public string beneAddress3 { get; set; }


        public string beneCity { get; set; }
        public string beneCity_txt { get; set; }
        public int beneCity_id { get; set; }



        public string beneState { get; set; }
        public string beneState_txt { get; set; }
        public int beneState_id { get; set; }




        public string benePin { get; set; }

        public int beneaid { get; set; }

        public int benetid { get; set; }

        public string benedateCreated { get; set; }

        public int benecreatedBy { get; set; }
        public string benecreatedBy_txt { get; set; }
        public int benecreatedBy_id { get; set; }

        public int benedocumentId { get; set; }

        public string benebeneficiary_type { get; set; }
        public string benebeneficiary_type_txt { get; set; }
        public int benebeneficiary_type_id { get; set; }



        public int beneddltid { get; set; }
        public string beneddltestatorname { get; set; }






    };
};