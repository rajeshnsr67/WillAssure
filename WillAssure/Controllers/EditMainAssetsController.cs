using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class EditMainAssetsController : Controller
    {
        // GET: EditMainAssets
        public ActionResult EditMainAssetsIndex()
        {
            return View("~/Views/EditMainAssets/EditMainAssetsPageContent.cshtml");
        }
    }
}