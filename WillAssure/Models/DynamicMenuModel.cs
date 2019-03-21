using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class DynamicMenuModel
    {
        public int PageId { get; set; }

        public string ParentMenu { get; set; }

        public int parentid { get; set; }
        public string parenttxt { get; set; }

        public string ChildMenu { get; set; }
        public string ChildUrl { get; set; }
    }
}