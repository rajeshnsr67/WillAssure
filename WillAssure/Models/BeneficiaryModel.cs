using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class BeneficiaryModel
    {
        public int bpId { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string Middle_Name { get; set; }

        public string Dob { get; set; }

        public string Mobile { get; set; }

        public string Relationship { get; set; }
        public int RelationshipId { get; set; }
        public string RelationshipTxt { get; set; }

        public string Marital_Status { get; set; }
        public string Marital_Status_TXT { get; set; }
        public int Marital_Status_ID { get; set; }

        public string Religion { get; set; }
        public string Religion_txt { get; set; }
        public int Religion_id { get; set; }

        public string Identity_proof { get; set; }
        public string Identity_proof_txt { get; set; }
        public int Identity_proof_id { get; set; }


        public string Identity_proof_value { get; set; }

        public string Alt_Identity_proof { get; set; }

        public string Alt_Identity_proof_value { get; set;}

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }


        public string City { get; set; }
        public string City_txt { get; set; }
        public int City_id { get; set; }



        public string State { get; set; }
        public string State_txt { get; set; }
        public int State_id { get; set; }




        public string Pin { get; set; }

        public int aid { get; set; }

        public int tid { get; set; }

        public string dateCreated { get; set; }

        public int createdBy  { get; set; }
        public string createdBy_txt { get; set; }
        public int createdBy_id { get; set; }

        public int documentId { get; set; }

        public string beneficiary_type { get; set; }
        public string beneficiary_type_txt { get; set; }
        public int beneficiary_type_id { get; set; }



        public int ddltid { get; set; }
        public string ddltestatorname { get; set; }

    }
}