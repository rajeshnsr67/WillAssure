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
    public class EditRoleController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditRole
        public ActionResult EditRoleIndex()
        {
            return View("~/Views/EditRole/EditRolePageContent.cshtml");
        }

        public string BindRolesFormData()
        {
            con.Open();
            string query = "select * from Roles";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["rId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["rId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button></td> <td> <button type='button' class='btnRoleDeleteSUCCESS'  style='display: ; ' class='btnpopup btn btn - primary shadow - primary px - 5'><i class='icon -lock'></i></button> </td>   </tr>";

                }
            }

            return data;
        }



        public string DeleteRolesRecords(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Roles", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@roleid", index);
            cmd.Parameters.AddWithValue("@Role", "");
            cmd.ExecuteNonQuery();
            con.Close();

           


            con.Open();
            string query = "select * from Roles";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["rId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["rId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button> <td> <button type='button' class='btnRoleDeleteSUCCESS'  style='display: ; ' class='btnpopup btn btn - primary shadow - primary px - 5'><i class='icon -lock'></i></button> </td> </td></tr>";

                }
            }
            
            return data;
        }





        public int UpdateRoles()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }




    }
}