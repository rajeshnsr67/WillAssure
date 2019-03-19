using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class AppointeesModel
    {

      public int apId { get; set;}
      public int documentId { get; set;}
      public string Type  { get; set;}
        public int TypeId { get; set; }
        public string Typetxt { get; set; }
        public string subType  { get; set;}
        public int subTypeId { get; set; }
        public string subTypetxt { get; set; }
        public string Name  { get; set;}
      public string middleName  { get; set;}
      public string Surname  { get; set;}
      public string Identity_Proof  { get; set;}
      public string Identity_Proof_Value  { get; set;}
      public string Alt_Identity_Proof  { get; set;}
      public string Alt_Identity_Proof_Value  { get; set;}
      public DateTime DOB  { get; set;}
      public string Gender  { get; set;}
      public string Occupation  { get; set;}

      public string Relationship  { get; set;}
      public int RelationshipId { get; set; }
      public string RelationshipTxt { get; set; }

        public string Address1  { get; set;}
      public string Address2  { get; set;}
      public string Address3  { get; set;}

      public string City  { get; set;}
      public int cityid { get; set; }
      public string citytext { get; set; }

        public string State  { get; set;}
      public int stateid { get; set; }
      public string statetext { get; set; }

        public string Pin  { get; set;}


    }
}