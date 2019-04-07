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
    public class AddDocumentAllotmentController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddDocumentAllotment
        public ActionResult AddDocumentAllotmentIndex()
        {
            if (Session.SessionID == null)
            {

                return RedirectToAction("LoginPageIndex", "LoginPage");

            }
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

            return View("~/Views/AddDocumentAllotment/AddDocumentAllotmentPageContent.cshtml");
        }




        public String BindCompanyDDL()
        {
            string data = "<option value=''>--Select --</option>";
          
                con.Open();
                string query = "select uId , First_Name from users where Type = 'DistributorAdmin'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                if (dt.Rows.Count > 0)
                {


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                       



                        data = data + "<option value=" + dt.Rows[i]["uId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                    }




                }

                return data;

            
          



        }


        public ActionResult InsertAllotmentDocument(PaymentModel PM)
        {

            if (Session.SessionID == null)
            {
                return View("~/Views/LoginPage/LoginPageContent.cshtml");
            }
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

            con.Open();
            string query = "insert into allotmentDistributor (uId,status,Document_Type,compId,Balance_Count) values (" + Convert.ToInt32(Session["uuid"])+" , '"+PM.status+"', '"+PM.documenttxt+"', " + Convert.ToInt32(Session["compId"]) + " , "+PM.NumberofDocument+" )   ";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();


            ModelState.Clear();

            ViewBag.Message = "Verified";
            return View("~/Views/AddDocumentAllotment/AddDocumentAllotmentPageContent.cshtml");
        }



    }
}