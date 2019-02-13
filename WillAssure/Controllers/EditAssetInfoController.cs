using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class EditAssetInfoController : Controller
    {
        // GET: EditAssetInfo
        public ActionResult EditAssetInfoIndex()
        {
            return View("~/Views/EditAssetInfo/EditAssetInfoPageContent.cshtml");
        }
    }
}