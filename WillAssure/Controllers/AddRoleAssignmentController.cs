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
using System.Net.Mail;
using System.Net;


namespace WillAssure.Controllers
{
    public class AddRoleAssignmentController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddRoleAssignment
        public ActionResult AddRoleAssignmentIndex()
        {
            return View("~/Views/AddRoleAssignment/AddRoleAssignmentPageContent.cshtml");
        }



        public ActionResult insertAssignRole(RoleAssignModel RAM)
        {
            con.Open();
            string query = "insert into RolesAssignment (rId,pagelinkId) Values ("+RAM.ddlroleid+","+RAM.ddlpageid+")";
            
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();


            con.Close();
            return View("~/Views/AddRoleAssignment/AddRoleAssignmentPageContent.cshtml");
        }


        public string BindRoleddl()
        {

            string data = "";
            con.Open();
            string query = "select * from roles";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<option value=" + Convert.ToInt32(dt.Rows[i]["rId"]) + ">" + dt.Rows[i]["Role"].ToString() + "</option>";
                }

                


            }


           



            return data;
        }






        public string BindPageDDl()
        {

            string data = "";
            con.Open();
            string query = "select PageId , ParentMenu from dynamicmenu";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<option value=" + Convert.ToInt32(dt.Rows[i]["PageId"]) + ">" + dt.Rows[i]["ParentMenu"].ToString() + "</option>";
                }




            }






            return data;
        }
    }
}