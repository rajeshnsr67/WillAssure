using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Models
{
    public class UserFormModel
    {
        public int uid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Dob { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string citytext { get; set; }
        public int cityid { get; set; }
        public string statetext { get; set; }
        public int stateid { get; set; }
        public string Pin { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
        public int LinkedUser { get; set; }
        public string Designation { get; set; }
        public string Active { get; set; }
        public int CompId { get; set; }
        public string CompIdtext { get; set; }
        public string data { get; set; }
        public int rid { get; set; }
        public string rtext { get; set; }
        public int UserRole { get; set; }

       


    }



   

}