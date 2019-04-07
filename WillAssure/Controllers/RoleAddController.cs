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
    public class RoleAddController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: RoleAdd
        public ActionResult RoleAddIndex()
        {
            if (Session.SessionID == null)
            {

                return RedirectToAction("LoginPageIndex", "LoginPage");

            }
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
            return View("~/Views/RoleAdd/AddRoleContentPage.cshtml");
        }

        public ActionResult InsertRoleFormData(RoleFormModel RFM)
        {

            // roleassignment
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


            //end



            int roles = 0;
            roles = Convert.ToInt32(Session["rId"]); 
         
                //main Roles

                con.Open();
                string query = "select count(*) from Roles  where Role = '" + RFM.Role + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    ViewBag.Message = "Duplicate";
                }
                else
                {
                    
                    SqlCommand cmd2 = new SqlCommand("SP_Roles", con);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@condition", "insert");
                    cmd2.Parameters.AddWithValue("@role ", RFM.Role);
                    cmd2.Parameters.AddWithValue("@pid ", Convert.ToInt32(Session["uuid"]));
                    cmd2.ExecuteNonQuery();
                    

                    ViewBag.Message = "Verified";
                }

                con.Close();

            
          
            





           
                
               
               
            

            
            return View("~/Views/RoleAdd/AddRoleContentPage.cshtml");
        }


    }
}