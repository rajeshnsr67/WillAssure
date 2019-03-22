using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class RoleAssignModel
    {

        public int RoleId { get; set; }

        public int Rid { get; set; }

        public string pagelinkId { get; set; }


        public int ddlroleid { get; set; }
        public string ddlroletxt { get; set; }


        public int ddlpageid { get; set; }
        public string ddlpagetxt { get; set; }


    }
}