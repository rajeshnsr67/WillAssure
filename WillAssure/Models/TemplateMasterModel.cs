using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class TemplateMasterModel
    {
        public string templatetxt { get; set; }
        public int templateid { get; set; }

        public string value { get; set; }

        public int testator_typeid { get; set; }
        public string testator_typetxt { get; set; }

    }
}