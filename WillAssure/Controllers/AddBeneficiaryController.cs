using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class AddBeneficiaryController : Controller
    {
        // GET: AddBeneficiary
        public ActionResult AddBeneficiaryIndex()
        {
            return View("~/Views/AddBeneficiary/AddBeneficiaryPageContent.cshtml");
        }
    }
}