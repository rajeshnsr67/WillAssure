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

        public ActionResult DynamicMenu()
        {
            return View("~/Views/LoginPage/DynamicMenuPageContent.cshtml");
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
            Session["apId"] = "";
            Session["rId"] = "";
            Session["uid"] = "";
            Session["compId"] = "";
            Session["ComparerrId"] = "";
            Session["amId"] = "";
            Session["assetsCode"] = "";
            Session["aiid"] = "";
            Session["bpId"] = "";
            Session["tid"] = "";
            Session["Document_Created_By"] = "";
            return View("~/Views/LoginPage/LoginPageContent.cshtml");
        }




        public ActionResult InsertParentMenu(DynamicMenuModel DMM)
        {

            con.Open();
            string query = "insert into parentmenu (ParentName) values ('"+DMM.ParentMenu+"') ";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();




          return  View("~/Views/LoginPage/DynamicMenuPageContent.cshtml");
        }



        public string BindParent()
        {
            string data = "";
            con.Open();
            string query = "select * from parentmenu";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<option value=" + Convert.ToInt32(dt.Rows[i]["ParentId"]) + ">"+ dt.Rows[i]["ParentName"].ToString() + "</option>";
                }
                
            }


            return data;
        }




        public ActionResult InsertChildmenu(DynamicMenuModel DMM)
        {


            con.Open();
            string query = "insert into dynamicmenu (ParentMenu,ChildMenu,ChildUrl) values ('" + DMM.parenttxt + "' , '"+DMM.ChildMenu+"' , '"+DMM.ChildUrl+"') ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();


            return View("~/Views/LoginPage/DynamicMenuPageContent.cshtml");
        }






    }
}