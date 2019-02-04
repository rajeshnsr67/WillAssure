using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class EditBeneficiaryController : Controller
    {
        // GET: EditBeneficiary
        public ActionResult EditBeneficiaryIndex()
        {
            return View("~/Views/EditBeneficiary/EditBeneficiaryPageContent.cshtml");
        }
    }
}