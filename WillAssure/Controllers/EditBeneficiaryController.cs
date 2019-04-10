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
    public class EditBeneficiaryController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditBeneficiary
        public ActionResult EditBeneficiaryIndex()
        {
            if (Session.SessionID == null)
            {

                return RedirectToAction("LoginPageIndex", "LoginPage");

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
            return View("~/Views/EditBeneficiary/EditBeneficiaryPageContent.cshtml");
        }


        public string BindBeneficiaryFormData()
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
                testString = Lmlist[12].Action;

            }



            con.Open();
            string query = "select a.bpId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_proof , a.Identity_proof_value , a.Alt_Identity_proof , a.Alt_Identity_proof_value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.beneficiary_type from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId inner join users c on b.uId = c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["bpId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_value"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["beneficiary_type"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["bpId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["bpId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_value"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["beneficiary_type"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["bpId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["bpId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_value"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["beneficiary_type"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["bpId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["bpId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["bpId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_value"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["beneficiary_type"].ToString() + "</td>";
                                    

                    }
                }



              
            }

            return data;
        }



        public string DeleteBeneficiaryRecords()
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDBeneficiaryDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@bpId", index);
            cmd.Parameters.AddWithValue("@First_Name ", "");
            cmd.Parameters.AddWithValue("@Last_Name","");
            cmd.Parameters.AddWithValue("@Middle_Name","");
            cmd.Parameters.AddWithValue("@DOB","");
            cmd.Parameters.AddWithValue("@Mobile","");
            cmd.Parameters.AddWithValue("@Relationship","");
            cmd.Parameters.AddWithValue("@Marital_Status","");
            cmd.Parameters.AddWithValue("@Religion","");
            cmd.Parameters.AddWithValue("@Identity_proof","");
            cmd.Parameters.AddWithValue("@Identity_proof_value","");
            cmd.Parameters.AddWithValue("@Alt_Identity_proof","");
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_value","");
            cmd.Parameters.AddWithValue("@Address1","");
            cmd.Parameters.AddWithValue("@Address2","");
            cmd.Parameters.AddWithValue("@Address3","");
            cmd.Parameters.AddWithValue("@City","");
            cmd.Parameters.AddWithValue("@State","");
            cmd.Parameters.AddWithValue("@Pin","");
            cmd.Parameters.AddWithValue("@aid", "");
            cmd.Parameters.AddWithValue("@tid", "");
            cmd.Parameters.AddWithValue("@beneficiary_type","");
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
                testString = Lmlist[12].Action;

            }



            con.Open();
            string query = "select a.bpId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_proof , a.Identity_proof_value , a.Alt_Identity_proof , a.Alt_Identity_proof_value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.beneficiary_type from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId inner join users c on b.uId = c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["bpId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                   + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_value"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["beneficiary_type"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["bpId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["bpId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_value"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["beneficiary_type"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["bpId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["bpId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                  + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_value"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["beneficiary_type"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["bpId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["bpId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["bpId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                     + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Relationship"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Marital_Status"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Religion"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Identity_proof_value"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["Alt_Identity_proof_value"].ToString() + "</td>"
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
                                    + "<td>" + dt.Rows[i]["beneficiary_type"].ToString() + "</td>";


                    }
                }




            }

            return data;
        }




        public int UpdateBeneficiaryForm()
        {
            int index = Convert.ToInt32(Request["send"]);


            con.Open();
            string query = "select bpId from alternate_Beneficiary where bpId = "+index+" ";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["upbeneficiaryid"] = Convert.ToInt32(dt.Rows[0]["bpId"]);
            }
            con.Close();



            


            return index;
        }






    }
}