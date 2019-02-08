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
    public class UpdateRolesController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateRoles
        public ActionResult UpdateRolesIndex(int NestId)
        {
            RoleFormModel RFM = new RoleFormModel();


            con.Open();
            string query = "select * from Roles where rid = '" + NestId + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                RFM.RoleID = NestId;
                RFM.Role = dt.Rows[0]["Role"].ToString();
             



            }




            return View("~/Views/UpdateRoles/UpdateRolesPageContent.cshtml",RFM);
        }


        public ActionResult UpdatingRoles(RoleFormModel RFM)
        {
         
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Roles", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@roleid ", RFM.RoleID);
            cmd.Parameters.AddWithValue("@role ", RFM.Role);
            cmd.ExecuteNonQuery();
            con.Close();


            return View("~/Views/UpdateRoles/UpdateRolesPageContent.cshtml");
        }




    }
}