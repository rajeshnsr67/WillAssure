using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class DesingnationModel
    {
        public string Designation { get; set; }

        public bool chkAdd { get; set; }

        public bool chkEdit { get; set; }

        public bool chkDelete { get; set; }

        public bool chkView { get; set; }


        public string Add { get; set; }

        public string Edit { get; set; }

        public string Delete { get; set; }

        public string View { get; set; }

        public string Action { get; set; }
    }
}