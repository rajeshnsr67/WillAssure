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
    public class LoginPageController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: LoginPage
        public ActionResult LoginPageIndex()
        {
            return View("~/Views/LoginPage/LoginPageContent.cshtml");
        }


        public ActionResult LoginPageData(LoginModel LM)
        {
            con.Open();
            string query = "select * from users where userID = '"+LM.UserID+"' and userPwd = '"+LM.Password+"' and active = 1";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                Session["rId"] = Convert.ToInt32(dt.Rows[0]["rId"]);
                Session["uid"] = Convert.ToInt32(dt.Rows[0]["uid"]);
              
                Session["ComparerrId"] = Convert.ToInt32(dt.Rows[0]["rId"]);
                con.Open();
               string query2 = "select * from roles where rId = "+ Session["rId"] + " ";
               SqlDataAdapter da2 = new SqlDataAdapter(query2,con);
               DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    Session["Role"] = dt2.Rows[0]["Role"].ToString();
                }
                con.Close();

                ViewBag.Message = "SUCCESS";
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                ViewBag.Message = "FAILED";
                return View("~/Views/LoginPage/LoginPageContent.cshtml");
            }

            

            

            
        }



        public ActionResult Logout()
        {
            Session["rId"] = "";
            Session["uid"] = "";
            Session["compid"] = "";
            Session["ComparerrId"] = "";
            return View("~/Views/LoginPage/LoginPageContent.cshtml");
        }


    }
}