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
    public class EditAlternateAppointeesController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: EditAlternateAppointees
        public ActionResult EditAlternateAppointeesIndex()
        {
            return View("~/Views/EditAlternateAppointees/EditAlternateAppointeesPageContent.cshtml");
        }

        public string BindAppointeesFormData()
        {
            con.Open();
            string query = "select * from alternate_Appointees";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["id"].ToString() + "</td>"
                              
                                + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                

                                + "<td><button type='button'   id='" + dt.Rows[i]["id"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["id"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button></td>    </tr>";

                }
            }

            return data;
        }



        public string DeleteAppointeesRecords(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDAlternateAppointees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@id", index);
            cmd.Parameters.AddWithValue("@apId", "");
            cmd.Parameters.AddWithValue("@Name", "");
            cmd.Parameters.AddWithValue("@middleName", "");
            cmd.Parameters.AddWithValue("@Surname", "");
            cmd.Parameters.AddWithValue("@Identity_proof", "");
            cmd.Parameters.AddWithValue("@Identity_proof_value", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_proof", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", "");
            cmd.Parameters.AddWithValue("@DOB", "");
            cmd.Parameters.AddWithValue("@Gender", "");
            cmd.Parameters.AddWithValue("@Occupation", "");
            cmd.Parameters.AddWithValue("@Relationship", "");
            cmd.Parameters.AddWithValue("@Address1", "");
            cmd.Parameters.AddWithValue("@Address2", "");
            cmd.Parameters.AddWithValue("@Address3", "");
            cmd.Parameters.AddWithValue("@City", "");
            cmd.Parameters.AddWithValue("@State", "");
            cmd.Parameters.AddWithValue("@Pin", "");
            cmd.ExecuteNonQuery();
            con.Close();




            con.Open();
            string query = "select * from alternate_Appointees";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["id"].ToString() + "</td>"
                            
                                + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["middleName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Surname"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                

                                + "<td><button type='button'   id='" + dt.Rows[i]["id"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["id"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button></td>    </tr>";

                }
            }

            return data;
        }





        public int UpdateAppointees()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }


    }
}
