using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class LivingWillController : Controller
    {
        // GET: LivingWill
        public ActionResult LivingWillIndex()
        {




            return View("~/Views/LivingWill/LivingWillPageContent.cshtml");
        }
    }
}