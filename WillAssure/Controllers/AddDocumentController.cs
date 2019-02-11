using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class AddDocumentController : Controller
    {
        // GET: AddDocument
        public ActionResult AddDocumentIndex()
        {
            return View("~/Views/AddDocument/AddDocumentPageContent.cshtml");
        }
    }
}