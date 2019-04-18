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

namespace WillAssure.Controllers
{
    public class ChangeTemplateController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: ChangeTemplate
        public ActionResult ChangeTemplateIndex(int tempid)
        {
            PaymentModel p = new PaymentModel();
            p.tid = tempid;
            // roleassignment
            List<LoginModel> Lmlist = new List<LoginModel>();
            string q = "select * from Assignment_Roles where RoleId = " + Convert.ToInt32(Session["rId"]) + "";
            SqlDataAdapter da3 = new SqlDataAdapter(q, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    LoginModel lm = new LoginModel();
                    lm.PageName = dt3.Rows[i]["PageName"].ToString();
                    lm.PageStatus = dt3.Rows[i]["PageStatus"].ToString();
                    lm.Action = dt3.Rows[i]["Action"].ToString();
                    lm.Nav1 = dt3.Rows[i]["Nav1"].ToString();
                    lm.Nav2 = dt3.Rows[i]["Nav2"].ToString();


                    Lmlist.Add(lm);
                }



                ViewBag.PageName = Lmlist;
                //end



            }



            return View("~/Views/ChangeTemplate/ChangeTemplatePageContent.cshtml", p);
        }



        public ActionResult ChangeTemplateData(PaymentModel pm)
        {

            // roleassignment
            List<LoginModel> Lmlist = new List<LoginModel>();
            string q = "select * from Assignment_Roles where RoleId = " + Convert.ToInt32(Session["rId"]) + "";
            SqlDataAdapter da3 = new SqlDataAdapter(q, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    LoginModel lm = new LoginModel();
                    lm.PageName = dt3.Rows[i]["PageName"].ToString();
                    lm.PageStatus = dt3.Rows[i]["PageStatus"].ToString();
                    lm.Action = dt3.Rows[i]["Action"].ToString();
                    lm.Nav1 = dt3.Rows[i]["Nav1"].ToString();
                    lm.Nav2 = dt3.Rows[i]["Nav2"].ToString();


                    Lmlist.Add(lm);
                }



                ViewBag.PageName = Lmlist;
                //end



            }




            con.Open();
            string query = "update documentMaster set templateId = " + pm.ddtempid + " where Tid= " + pm.tid + "  ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            ViewBag.Message = "Verified";
            return View("~/Views/ChangeTemplate/ChangeTemplatePageContent.cshtml");

        }


    }
}