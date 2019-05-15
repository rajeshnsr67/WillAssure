using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class LiabilitiesModel
    {
        public int libid { get; set; }
          public int  documentId { get; set;  }
       public int  Amount { get; set;  }
       public string  Type { get; set;  }
       public string  Name1 { get; set;  }
       public string  address { get; set;  }
       public string  city { get; set;  }
       public string  state { get; set;  }
       public string  pin { get; set;  }
       public string  Mobile { get; set;  }
       public string  Details { get; set;  }
       
       public int  tid { get; set;  }


        public int stateid { get; set; }
        public string statetext { get; set; }


        public int cityid { get; set; }
        public string citytext { get; set; }

        public int ddltid { get; set; }
        public string ddltestatorname { get; set; }


        public int assettypeid { get; set; }
        public string assettypetext { get; set; }


        public int assetCategoryid { get; set; }
        public string assetCategorytext { get; set; }

        public int Proportion { get; set; }

        public int amId { get; set; }



    }
}