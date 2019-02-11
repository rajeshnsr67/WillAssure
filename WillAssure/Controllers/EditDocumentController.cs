using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class EditDocumentController : Controller
    {
        // GET: EditDocument
        public ActionResult EditDocumentIndex()
        {
            return View("~/Views/EditDocument/EditDocumentPageContent.cshtml");
        }
    }
}