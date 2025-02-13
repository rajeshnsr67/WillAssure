﻿using System;
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
      public string Dob  { get; set;}
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
        public int rid { get; set; }



        // alternate appointees

        public int altid { get; set; }
        public int altapId { get; set; }
        public int altdocumentId { get; set; }
        public string altType { get; set; }
        public string altsubType { get; set; }
        public string altName { get; set; }
        public string altmiddleName { get; set; }
        public string altSurname { get; set; }
        public string altIdentity_Proof { get; set; }
        public string altIdentity_Proof_Value { get; set; }
        public string altAlt_Identity_Proof { get; set; }
        public string altAlt_Identity_Proof_Value { get; set; }
        public string altDob { get; set; }
        public string altGender { get; set; }
        public string altOccupation { get; set; }

        public string altRelationship { get; set; }
        public int altRelationshipId { get; set; }
        public string altRelationshipTxt { get; set; }

        public string altAddress1 { get; set; }
        public string altAddress2 { get; set; }
        public string altAddress3 { get; set; }

        public string altCity { get; set; }
        public int altcityid { get; set; }
        public string altcitytext { get; set; }

        public string altState { get; set; }
        public int altstateid { get; set; }
        public string altstatetext { get; set; }

        public string altPin { get; set; }




        //end

        public int ddltid { get; set; }
        public string ddltestatorname { get; set; }


        public string check { get; set; }


        public string altguardian { get; set; }
        public string altexecutor { get; set; }


    }
}