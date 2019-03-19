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
    public class EditTestatorController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: EditTestator
        public ActionResult EditTestatorIndex()
        {
            return View("~/Views/EditTestator/EditTestatorPageContent.cshtml");
        }


        public string BindTestatorFormData()
        {
            con.Open();
            string query = "select * from TestatorDetails ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                             
                                + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";

                }
            }

            return data;
        }

        public string DeleteTestatorFormRecords(TestatorFormModel TFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDTestatorDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@tId", index);
            cmd.Parameters.AddWithValue("@First_Name", "");
            cmd.Parameters.AddWithValue("@Last_Name", "");
            cmd.Parameters.AddWithValue("@Middle_Name", "");
            cmd.Parameters.AddWithValue("@DOB", "");
            cmd.Parameters.AddWithValue("@Occupation", "");
            cmd.Parameters.AddWithValue("@Mobile", "");
            cmd.Parameters.AddWithValue("@Email", "");
            cmd.Parameters.AddWithValue("@maritalStatus", "");
            cmd.Parameters.AddWithValue("@Religion", "");
            cmd.Parameters.AddWithValue("@Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Identity_proof_Value", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_Value", "");
            cmd.Parameters.AddWithValue("@Gender", "");
            cmd.Parameters.AddWithValue("@Address1", "");
            cmd.Parameters.AddWithValue("@Address2", "");
            cmd.Parameters.AddWithValue("@Address3", "");
            cmd.Parameters.AddWithValue("@City", "");
            cmd.Parameters.AddWithValue("@State", "");
            cmd.Parameters.AddWithValue("@Country", "");
            cmd.Parameters.AddWithValue("@Pin", "");
            cmd.Parameters.AddWithValue("@active", "");
            cmd.Parameters.AddWithValue("@Contact_Verification", "");
            cmd.Parameters.AddWithValue("@Email_Verification", "");
            cmd.Parameters.AddWithValue("@Mobile_Verification_Status", "");
            cmd.Parameters.AddWithValue("@Email_OTP", "");
            cmd.Parameters.AddWithValue("@Mobile_OTP", "");
            cmd.Parameters.AddWithValue("@uid", "");
            cmd.ExecuteNonQuery();
            con.Close();


            con.Open();
            string query = "select * from TestatorDetails";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Gender"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Country"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Contact_Verification"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Email_Verification"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Mobile_Verification_Status"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";

                }
            }
            

           

            return data;
        }





        public int UpdateTestatorForm()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }



    }
}