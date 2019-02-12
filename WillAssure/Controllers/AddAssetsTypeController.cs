using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class AddAssetsTypeController : Controller
    {
        // GET: AddAssetsType
        public ActionResult AddAssetsTypeIndex()
        {
            return View("~/Views/AddAssetsType/AddAssetsTypePageContent.cshtml");
        }
    }
}