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
using System.Globalization;

namespace WillAssure.Controllers
{
    public class EditAppointeesController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: EditAppointees
        public ActionResult EditAppointeesIndex()
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
            return View("~/Views/EditAppointees/EditAppointeesPageContent.cshtml");
        }


        public string BindAppointeesFormData()
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
                testString = Lmlist[14].Action;

            }



            con.Open();
            string query = "select * from Appointees a inner join  TestatorDetails b on a.tid=b.tid where b.uId = " + Convert.ToInt32(Session["uid"]) + "";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                      + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>";



                    }
                }



               
            }

            return data;
        }



        public string DeleteAppointeesRecords(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDAppointees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@apId",index);
            cmd.Parameters.AddWithValue("@documentId", "");
            cmd.Parameters.AddWithValue("@Type", "");
            cmd.Parameters.AddWithValue("@subType", "");
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
            cmd.Parameters.AddWithValue("@tid", "");
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
                testString = Lmlist[14].Action;

            }



            con.Open();
            string query = "select * from Appointees a inner join  TestatorDetails b on a.tid=b.tid where b.uId = " + Convert.ToInt32(Session["uid"]) + "";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification '>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["apId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["apId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Type"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["subType"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tid"].ToString() + "</td>";


                    }
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