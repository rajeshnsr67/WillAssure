using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WillAssure.Controllers
{
    public class FrontendController : Controller
    {
        // GET: Frontend
        public ActionResult Index()
        {
            if (Session["displayname"].ToString() != "" )
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Index.cshtml");
        }


        public ActionResult AboutUsIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Aboutus.cshtml");
        }


        public ActionResult ContactUsIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/ContactUs.cshtml");
        }



        public ActionResult DisclaimerIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Disclaimer.cshtml");
        }


        public ActionResult DocumentIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }

            

            return View("~/Views/Frontend/Document.cshtml");
        }


        public ActionResult FaqIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Faq.cshtml");
        }



        public ActionResult HowweworkIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Howwework.cshtml");
        }



        public ActionResult PrivacyPolicyIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Privacypolicy.cshtml");
        }


        public ActionResult RegnIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Regn.cshtml");
        }


        public ActionResult ServicesIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Services.cshtml");
        }



    }
}