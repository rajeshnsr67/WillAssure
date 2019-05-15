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
using System.Net.Mail;
using System.Net;
using System.Collections;

namespace WillAssure.Controllers
{
    public class CodocilController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: Codocil
        public ActionResult CodocilIndex()
        {
            ViewBag.collapse = "true";
            ViewBag.cod = "true";


            return View("~/Views/Codocil/CodocilPageContent.cshtml");
        }


        public ActionResult InsertCodocilData()
        {
            ViewBag.collapse = "true";

            string response = Request["send"];
          
            ArrayList result = new ArrayList(response.Split('~'));

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].ToString() != "")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(result[i].ToString(), con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }



            return View("~/Views/Codocil/CodocilPageContent.cshtml");
        }



    }
}