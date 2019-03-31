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
using System.Collections;
using System.Globalization;

namespace WillAssure.Controllers
{
    public class EditTestatorController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: EditTestator
        public ActionResult EditTestatorIndex()
        {
            if (Session.SessionID == null)
            {
                return View("~/Views/LoginPage/LoginPageContent.cshtml");
            }
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
            return View("~/Views/EditTestator/EditTestatorPageContent.cshtml");
        }


        public string BindTestatorFormData()
        {

            // check roles
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








            }

            con.Close();





            //end


            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[4].Action;

            }


            con.Open();
            string query = "select * from TestatorDetails where uId = "+ Convert.ToInt32(Session["uid"]) + " ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {
                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                    + "<td>" +  DateTime.ParseExact(dt.Rows[i]["DOB"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture)+ "</td>"
                                    + "<td>" + dt.Rows[i]["Occupation"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Email"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["maritalStatus"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
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

                                    + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
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
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
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

                                    + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
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
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
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

                                    + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary '>Edit</button><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }

                }


                if (testString == "0,0,0")
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
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>";

                                  

                    }
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
            cmd.Parameters.AddWithValue("@Relationship", "");
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


            // check roles
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








            }

            con.Close();





            //end


            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[4].Action;

            }


            con.Open();
            string query = "select * from TestatorDetails where uId = " + Convert.ToInt32(Session["uid"]) + " ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {
                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
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
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
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

                                    + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
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
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
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

                                    + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
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
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
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

                                    + "<td><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["tId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }

                }


                if (testString == "0,0,0")
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
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["active"].ToString() + "</td>";



                    }
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