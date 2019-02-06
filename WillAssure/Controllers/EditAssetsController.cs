using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class EditAssetsController : Controller
    {
        // GET: EditAssets
        public ActionResult EditAssetsIndex()
        {
            return View("~/Views/EditBeneficiary/EditBeneficiaryPageContent.cshtml");
        }
    }
}