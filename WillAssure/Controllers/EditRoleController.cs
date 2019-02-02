using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class EditRoleController : Controller
    {
        // GET: EditRole
        public ActionResult EditRoleIndex()
        {
            return View("~/Views/EditRole/EditRolePageContent.cshtml");
        }
    }
}