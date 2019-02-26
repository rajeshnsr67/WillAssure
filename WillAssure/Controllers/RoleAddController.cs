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
            return View("~/Views/RoleAdd/AddRoleContentPage.cshtml");
        }

        public ActionResult InsertRoleFormData(RoleFormModel RFM)
        {
            int roles = 0;
            roles = Convert.ToInt32(Session["rId"]); 
            if (roles != 1)
            {
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
                    cmd2.ExecuteNonQuery();
                    

                    ViewBag.Message = "Verified";
                }


              
            }
            else
            {
                //Sub Roles

                
                string query = "select count(*) from Role  where Role = '" + RFM.Role + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    ViewBag.Message = "Duplicate";
                }
                else
                {
                    
                    string query2 = "insert into subroles (SubRolesName,Rid) values ('" + RFM.Role + "' , '" + roles + "')";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                    
                    ViewBag.Message = "Verified";
                }
               
            





           
                
                con.Close();
               
            }

            
            return View("~/Views/RoleAdd/AddRoleContentPage.cshtml");
        }


    }
}