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
            ViewBag.collapse = "true";

            ViewBag.enablelivingwill = "true";




            return View("~/Views/LivingWill/LivingWillPageContent.cshtml");
        }


        public ActionResult InsertWillData(CodocilModel CM)
        {
            ViewBag.collapse = "true";
            ViewBag.enablelivingwill = "true";

            con.Open();
            string query = "insert into living_Will (Conditions,TreatmentDecline,uId) values ('"+CM.conditions+"' , '"+CM.treatmentdecline+"' , "+Convert.ToInt32(Session["uuid"])+"   )";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();


            con.Close();


            ModelState.Clear();
            ViewBag.Message = "Verified";

            return View("~/Views/LivingWill/LivingWillPageContent.cshtml");
        }


    }
}