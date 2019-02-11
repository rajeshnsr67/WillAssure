using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class AddCouponsController : Controller
    {
        // GET: AddCoupons
        public ActionResult AddCouponsIndex()
        {
            return View("~/Views/AddCoupons/AddCouponsPageContent.cshtml");
        }
    }
}