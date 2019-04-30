using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class LoginModel
    {

        public string UserID { get; set; }

        public string Password{ get; set; }



        public string PageStatus { get; set; }
        public string Action { get; set; }
        public string PageName { get; set; }
        public string Nav1 { get; set; }
        public string Nav2 { get; set; }

        public string EmailID { get; set; }

        [Required(ErrorMessage = "OTP is Required")]
        public string OTP { get; set; }


    }
}