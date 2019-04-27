using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WillAssure.Models
{
    public class PetCareModel
    {
        public int petid { get; set; }
        public string  petname { get;  set;  }
       public string  petage { get;  set;  }
       public string  typeofpet { get;  set;  }
       public string  amtforpet { get;  set;  }
       public string  amtfromwhichasset { get;  set;  }
       public string  responsibelpersonforpet { get;  set;  }
       public int  tid { get;  set;  }


        public int ddltid { get; set; }

        public string ddltestatorname { get; set; }

    }
}