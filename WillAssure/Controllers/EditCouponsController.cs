using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class EditCouponsController : Controller
    {
        // GET: EditCoupons
        public ActionResult EditCouponsIndex()
        {
            if (Session.SessionID == null)
            {
                return View("~/Views/LoginPage/LoginPageContent.cshtml");
            }
            return View("~/Views/EditCoupons/EditCouponsPageContent.cshtml");
        }
    }
}