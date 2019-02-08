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
    public class EditUserFormController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        public ActionResult EditUserFormIndex()
        {

            return View("~/Views/EditUserForm/EditUserFormPageContent.cshtml");
        }


        public string BindUserForm()
        {

            con.Open();
            string query = "select * from users";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            string Role = "";
            string a = "";
            if (dt.Rows.Count > 0)
            {
                

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int Status = Convert.ToInt32(dt.Rows[i]["active"]);

                  

                    if(Status == 1)
                    {
                        a = "Active";
                    }
                    else
                    {
                        a = "InActive";
                    }

                  


                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"
                               
                                + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                + "<td>" + a + "</td>"
                               
                                + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";
                                
                }
            }

                    return data;
        }



        public string DeleteEditFormRecords()
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Users", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@uid", index);
            cmd.Parameters.AddWithValue("@FirstName", "");
            cmd.Parameters.AddWithValue("@LastName","");
            cmd.Parameters.AddWithValue("@MiddleName","");
            cmd.Parameters.AddWithValue("@Dob","");
            cmd.Parameters.AddWithValue("@Mobile", "");
            cmd.Parameters.AddWithValue("@Email", "");
            cmd.Parameters.AddWithValue("@Address1", "");
            cmd.Parameters.AddWithValue("@Address2","");
            cmd.Parameters.AddWithValue("@Address3", "");
            cmd.Parameters.AddWithValue("@City","");
            cmd.Parameters.AddWithValue("@State ", "");
            cmd.Parameters.AddWithValue("@Pin", "");
            cmd.Parameters.AddWithValue("@UserId","");
            cmd.Parameters.AddWithValue("@UserPassword", "");
           
            cmd.Parameters.AddWithValue("@Designation", "");
            cmd.Parameters.AddWithValue("@Active", "");
            cmd.Parameters.AddWithValue("@compId", "");
            cmd.Parameters.AddWithValue("@Linked_user", "");
            cmd.Parameters.AddWithValue("@rid", "");
            cmd.ExecuteNonQuery();
            con.Close();


            con.Open();
            string query = "select * from users";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Linked_user"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["active"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";

                }
            }
            Response.Write("<script>alert('Your Records Have Been Deleted...!')</script>");
            return data;
        }




        public int UpdateEditForm()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }







    }
}