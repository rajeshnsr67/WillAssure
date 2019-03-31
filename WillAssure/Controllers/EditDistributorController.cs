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

namespace WillAssure.Controllers
{
    public class EditDistributorController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditDistributor
        public ActionResult EditDistributorIndex()
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
            return View("~/Views/EditDistributor/EditDistributorPageContent.cshtml");
        }

        public string BindDistributorFormData()
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
                testString = Lmlist[2].Action;

            }


            con.Open();
            string query = "select a.compId , a.companyName , a.ownerName , a.ownerMobileNo , a.Address1 , a.Address2 , a.City , a.State , a.Pin , a.GST_NO ,a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.contactPerson , a.contactMobileNo , a.contactMailId , a.bankName , a.Branch , a.accountNumber , a.IFSC_Code , a.accountName , a.Referred_By , a.leadgeneratedBy , a.leadconvertedBy , a.relationshipManager , a.leadStatus , a.leadRemark from companyDetails a inner join users b on a.compId = b.compId  where b.rId =  "+ Convert.ToInt32(Session["rId"]) + "  ";
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



                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["companyName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["GST_NO"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactPerson"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMailId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["bankName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Branch"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountNumber"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IFSC_Code"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Referred_By"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadgeneratedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadconvertedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["relationshipManager"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadRemark"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";
                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {



                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["companyName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["GST_NO"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactPerson"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMailId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["bankName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Branch"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountNumber"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IFSC_Code"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Referred_By"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadgeneratedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadconvertedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["relationshipManager"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadRemark"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {



                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["companyName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["GST_NO"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactPerson"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMailId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["bankName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Branch"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountNumber"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IFSC_Code"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Referred_By"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadgeneratedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadconvertedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["relationshipManager"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadRemark"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }
                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {



                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["companyName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["GST_NO"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactPerson"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMailId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["bankName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Branch"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountNumber"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IFSC_Code"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Referred_By"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadgeneratedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadconvertedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["relationshipManager"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadRemark"].ToString() + "</td>";
                               
                    }
                }




               



                   
                   





                
            }

            return data;
        }



        public string DeleteDistributorFormRecords(DistributorFormModel DFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CrudcompanyDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@compId ", index);
            cmd.Parameters.AddWithValue("@companyName ", "");
            cmd.Parameters.AddWithValue("@ownerName", "");
            cmd.Parameters.AddWithValue("@ownerMobileNo", "");
            cmd.Parameters.AddWithValue("@Address1", "");
            cmd.Parameters.AddWithValue("@Address2", "");
            cmd.Parameters.AddWithValue("@City", "");
            cmd.Parameters.AddWithValue("@State", "");
            cmd.Parameters.AddWithValue("@Pin", "");
            cmd.Parameters.AddWithValue("@GST_NO", "");
            cmd.Parameters.AddWithValue("@Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Identity_Proof_Value", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", "");
            cmd.Parameters.AddWithValue("@contactPerson", "");
            cmd.Parameters.AddWithValue("@contactMobileNo", "");
            cmd.Parameters.AddWithValue("@contactMailId", "");
            cmd.Parameters.AddWithValue("@bankName", "");
            cmd.Parameters.AddWithValue("@Branch", "");
            cmd.Parameters.AddWithValue("@accountNumber", "");
            cmd.Parameters.AddWithValue("@IFSC_Code", "");
            cmd.Parameters.AddWithValue("@accountName", "");
            cmd.Parameters.AddWithValue("@Referred_By","");
            cmd.Parameters.AddWithValue("@leadgeneratedBy","");
            cmd.Parameters.AddWithValue("@leadconvertedBy", "");
            cmd.Parameters.AddWithValue("@relationshipManager", "");
            cmd.Parameters.AddWithValue("@leadStatus", "");
            cmd.Parameters.AddWithValue("@leadRemark", "");
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
                testString = Lmlist[0].Action;

            }


            con.Open();
            string query = "select a.compId , a.companyName , a.ownerName , a.ownerMobileNo , a.Address1 , a.Address2 , a.City , a.State , a.Pin , a.GST_NO ,a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.contactPerson , a.contactMobileNo , a.contactMailId , a.bankName , a.Branch , a.accountNumber , a.IFSC_Code , a.accountName , a.Referred_By , a.leadgeneratedBy , a.leadconvertedBy , a.relationshipManager , a.leadStatus , a.leadRemark from companyDetails a inner join users b on a.compId = b.compId  where b.rId =  " + Convert.ToInt32(Session["rId"]) + "  ";
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



                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["companyName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["GST_NO"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactPerson"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMailId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["bankName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Branch"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountNumber"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IFSC_Code"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Referred_By"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadgeneratedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadconvertedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["relationshipManager"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadRemark"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";
                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {



                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["companyName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["GST_NO"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactPerson"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMailId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["bankName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Branch"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountNumber"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IFSC_Code"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Referred_By"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadgeneratedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadconvertedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["relationshipManager"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadRemark"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {



                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["companyName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["GST_NO"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactPerson"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMailId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["bankName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Branch"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountNumber"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IFSC_Code"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Referred_By"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadgeneratedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadconvertedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["relationshipManager"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadRemark"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }
                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {



                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["companyName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["GST_NO"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactPerson"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMailId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["bankName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Branch"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountNumber"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IFSC_Code"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Referred_By"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadgeneratedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadconvertedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["relationshipManager"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadRemark"].ToString() + "</td>";

                    }
                }
















            }

            return data;
        }





        public int UpdateDistributorForm()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }


    }
}