using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        public ActionResult ChangePasswordIndex()
        {


            return View("~/Views/ChangePassword/ChangePasswordPageContent.cshtml");
        }
    }
}