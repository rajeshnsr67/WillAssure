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
    public class EditNomineeController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditNominee
        public ActionResult EditNomineeIndex()
        {
            if (Session["rId"] == null || Session["uuid"] == null)
            {

               RedirectToAction("LoginPageIndex", "LoginPage");

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
            return View("~/Views/EditNominee/EditNomineePageContent.cshtml");
        }


        public string BindNomineeFormData(int value)
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
                testString = Lmlist[17].Action;

            }


            con.Open();
            string query = "select a.nId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.Description_of_Assets from Nominee a inner join TestatorDetails b on a.tId=b.tId where a.tId = " +value+ "";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>";

                                   

                    }
                }



               
            }

            return data;
        }



        public string DeleteNomineeRecords(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDNominee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@nId",index);
            cmd.Parameters.AddWithValue("@First_Name", "");
            cmd.Parameters.AddWithValue("@Last_Name", "");
            cmd.Parameters.AddWithValue("@Middle_Name", "");
            cmd.Parameters.AddWithValue("@DOB", "");
            cmd.Parameters.AddWithValue("@Mobile","");
            cmd.Parameters.AddWithValue("@Relationship", "");
            cmd.Parameters.AddWithValue("@Marital_Status", "");
            cmd.Parameters.AddWithValue("@Religion", "");
            cmd.Parameters.AddWithValue("@Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Identity_Proof_Value", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", "");
            cmd.Parameters.AddWithValue("@Address1", "");
            cmd.Parameters.AddWithValue("@Address2", "");
            cmd.Parameters.AddWithValue("@Address3", "");
            cmd.Parameters.AddWithValue("@City", "");
            cmd.Parameters.AddWithValue("@State", "");
            cmd.Parameters.AddWithValue("@Pin","");
            cmd.Parameters.AddWithValue("@aid", "");
            cmd.Parameters.AddWithValue("@tId", "");
            cmd.Parameters.AddWithValue("@createdBy", "");
            cmd.Parameters.AddWithValue("@documentId", "");
            cmd.Parameters.AddWithValue("@Description_of_Assets", "");
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
                testString = Lmlist[17].Action;

            }


            con.Open();
            string query = "select a.nId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.Description_of_Assets from Nominee a inner join TestatorDetails b on a.tId=b.tId inner join users c on b.uId=c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }
                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>";



                    }
                }




            }

            return data;
        }





        public int UpdateNominee()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }

        public string LoadData()
        {// check roles
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
                testString = Lmlist[17].Action;

            }

            con.Open();
            string checkuid = "select tId from TestatorDetails  where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter checkda = new SqlDataAdapter(checkuid, con);
            DataTable checkdt = new DataTable();
            checkda.Fill(checkdt);
            int chktid = 0;
            if (checkdt.Rows.Count > 0)
            {
                chktid = Convert.ToInt32(checkdt.Rows[0]["tId"]);
            }
            con.Close();


            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                con.Open();
                string query = "select a.nId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.Description_of_Assets from Nominee a inner join TestatorDetails b on a.tId=b.tId  where b.tId = " + chktid + " ";
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
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                        }
                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }
                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }

                    }


                    if (testString == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>";



                        }
                    }




                }

                return data;
            }
            else
            {
                con.Open();
                string query = "select a.nId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.Description_of_Assets from Nominee a inner join TestatorDetails b on a.tId=b.tId ";
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
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                        }
                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }
                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["nId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                        }

                    }


                    if (testString == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["nId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                         + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["aiid"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["tId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["dateCreated"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["createdBy"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["documentId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Description_of_Assets"].ToString() + "</td>";



                        }
                    }




                }

                return data;
            }


           
        }



        public string BindTestatorDDL()
        {

            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                string ck = "select type from users where uId =" + Convert.ToInt32(Session["uuid"]) + "";
                SqlDataAdapter cda = new SqlDataAdapter(ck, con);
                DataTable cdt = new DataTable();
                cda.Fill(cdt);
                string type = "";
                if (cdt.Rows.Count > 0)
                {
                    type = cdt.Rows[0]["type"].ToString();

                }

                if (type != "Testator")
                {
                    con.Open();
                    string query = "select * from TestatorDetails a   inner join users b on a.uId = b.uId  where b.Linked_user = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    string data = "<option value='' >--Select--</option>";




                    if (dt.Rows.Count > 0)
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {




                            data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                        }




                    }

                    return data;
                }
                else
                {
                    con.Open();
                    string query = "select * from TestatorDetails a   inner join users b on a.uId = b.uId  where b.uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    string data = "";




                    if (dt.Rows.Count > 0)
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {




                            data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                        }




                    }

                    return data;


                }



            }
            else
            {
                con.Open();
                string query = "select * from TestatorDetails";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                string data = "<option value='' >--Select--</option>";




                if (dt.Rows.Count > 0)
                {


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {




                        data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                    }




                }

                return data;

            }


        }






    }
}