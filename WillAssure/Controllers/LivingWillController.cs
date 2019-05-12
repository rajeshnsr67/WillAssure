using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WillAssure.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace WillAssure.Controllers
{
    public class LivingWillController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: LivingWill
        public ActionResult LivingWillIndex()
        {


            ViewBag.enablelivingwill = "true";


            return View("~/Views/LivingWill/LivingWillPageContent.cshtml");
        }
    }
}