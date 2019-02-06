using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WillAssure.Models;

namespace System.Web.Mvc
{
    
        public static class Admin
        {
            public static int GetUserRole(this HtmlHelper html)
            {
                UserFormModel UFM = new UserFormModel();

                int CurrentUserRole = UFM.UserRole;
                return CurrentUserRole;
            }
        }
    
}