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
    public class EditRelationController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditRelation
        public ActionResult EditRelationIndex()
        {
            return View("~/Views/EditRelation/EditRelationPageContent.cshtml");
        }


        public string BindRelationFormData()
        {
            con.Open();
            string query = "select * from relationship";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["Rid"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["MemberName"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["Rid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["Rid"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button></td>    </tr>";

                }
            }

            return data;
        }



        public string DeleteRelationRecords(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_RelationShipCRUD", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@Rid", index);
            cmd.Parameters.AddWithValue("@MemberName", "");
            cmd.ExecuteNonQuery();
            con.Close();




            con.Open();
            string query = "select * from relationship";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["Rid"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["MemberName"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["Rid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["Rid"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button></td>    </tr>";

                }


            }

            return data;
        }





        public int UpdateRelation()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }


    }
}