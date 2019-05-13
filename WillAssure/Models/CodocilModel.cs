using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class CodocilModel
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string selection { get; set; }

        public string data { get; set; }
        public string value { get; set; }

        public string olddetails { get; set; }


        public string newdetails { get; set; }


        public string conditions { get; set; }

        public string treatmentdecline { get; set; }


        public int livingwillid { get; set; }






    }
}