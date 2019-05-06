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
    public class AddVisitorPageContentController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddVisitorPageContent
        public ActionResult AddVisitorPageContentIndex()
        {

            List<LoginModel> Lmlist = new List<LoginModel>();
            con.Open();
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




            }

            con.Close();


            return View("~/Views/AddVisitorPageContent/AddVisitorPageContentPage.cshtml");
        }



        public ActionResult InsertVisitorData(VisitorModel VM)
        {

            List<LoginModel> Lmlist = new List<LoginModel>();
            con.Open();
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




            }

            con.Close();


            //if (VM.First_Name != "" || VM.Last_Name != "" || VM.Middle_Name != "" || VM.Mobile != "" || VM.Email != "" || ,)
            //{

            //}

            con.Open();
            string query = "insert into visitorinfo (First_Name,Middle_Name,Last_Name,Mobile,Email,RefDist,DocumentType) values ('"+VM.First_Name+"' , '"+VM.Middle_Name+"' , '"+VM.Last_Name+"' , '"+VM.Mobile+"' , '"+VM.Email+"' , '"+VM.RefDist+"','"+VM.DocumentType + "')";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();



            string typeid = "";

            if (VM.DocumentType == "WillCodocilPOA")
            {
                typeid = "1,2,3";
            }
            if (VM.DocumentType == "Codocil")
            {
                typeid = "2";
            }
            if (VM.DocumentType == "POA")
            {
                typeid = "3";
            }
            if (VM.DocumentType == "Will")
            {
                typeid = "1";
            }
            if (VM.DocumentType == "WillCodocil")
            {
                typeid = "1,2";
            }
            if (VM.DocumentType == "WillPOA")
            {
                typeid = "1,3";
            }
            if (VM.DocumentType == "CodocilPOA")
            {
                typeid = "2,3";
            }
            if (VM.DocumentType == "CodocilWill")
            {
                typeid = "2,1";
            }
            if (VM.DocumentType == "POAWill")
            {
                typeid = "3,1";
            }



            con.Open();
            string q2 = "insert into documentRules (documentType,category) values ('" + typeid + "' ,  1 )";
            SqlCommand c1 = new SqlCommand(q2, con);
            c1.ExecuteNonQuery();
            con.Close();




            ViewBag.Message = "Verified";
            ModelState.Clear();


            return View("~/Views/AddVisitorPageContent/AddVisitorPageContentPage.cshtml");
        }



    }
}