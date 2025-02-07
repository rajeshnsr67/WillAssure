﻿using System;
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
    public class EditCompanyDetailsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditCompanyDetails
        public ActionResult EditCompanyDetailsIndex()
        {


            // check type 
            string typ5 = "";
            con.Open();
            string qq15 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa5 = new SqlDataAdapter(qq15, con);
            DataTable dtt5 = new DataTable();
            daa5.Fill(dtt5);
            con.Close();

            if (dtt5.Rows.Count > 0)
            {
                typ5 = dtt5.Rows[0]["Type"].ToString();
            }



            //end



            if (typ5 == "Testator")
            {

                con.Open();
                string qq12 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " and designation = 1 ";
                SqlDataAdapter da42 = new SqlDataAdapter(qq12, con);
                DataTable d4t2 = new DataTable();
                da42.Fill(d4t2);
                con.Close();

                if (d4t2.Rows.Count > 0)
                {
                    ViewBag.documentlink = "true";
                }


                // check will status
                con.Open();
                string qry1 = "select Will  from users where Will = 1 ";
                SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                DataTable dtt1 = new DataTable();
                daa1.Fill(dtt1);
                if (dtt1.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
                con.Close();
                //end


                // check codocil status
                con.Open();
                string qry2 = "select Codocil  from users where Codocil = 1 ";
                SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                DataTable dtt2 = new DataTable();
                daa2.Fill(dtt2);
                if (dtt2.Rows.Count > 0)
                {
                    ViewBag.documentbtn2 = "true";
                }
                con.Close();

                //end


                // check Poa status
                con.Open();
                string qry4 = "select POA  from users where POA = 1 ";
                SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                DataTable dtt4 = new DataTable();
                daa4.Fill(dtt4);
                if (dtt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }
                con.Close();
                //end


                // check gift deeds status
                con.Open();
                string qry3 = "select Giftdeeds  from users where Giftdeeds = 1 ";
                SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                DataTable dtt3 = new DataTable();
                daa3.Fill(dtt3);
                if (dtt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }
                con.Close();
                //end
            }
            else
            {
                ViewBag.showtitle = "true";
                ViewBag.documentlink = "true";

            }
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
            return View("~/Views/EditCompanyDetails/EditCompanyPageContent.cshtml");



        }




        public string BindCompanyFormData()
        {
            // check type 
            string typ5 = "";
            con.Open();
            string qq15 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa5 = new SqlDataAdapter(qq15, con);
            DataTable dtt5 = new DataTable();
            daa5.Fill(dtt5);
            con.Close();

            if (dtt5.Rows.Count > 0)
            {
                typ5 = dtt5.Rows[0]["Type"].ToString();
            }



            //end



            if (typ5 == "Testator")
            {
                // check will status
                con.Open();
                string qry1 = "select Will  from users where Will = 1 ";
                SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                DataTable dtt1 = new DataTable();
                daa1.Fill(dtt1);
                if (dtt1.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
                con.Close();
                //end


                // check codocil status
                con.Open();
                string qry2 = "select Codocil  from users where Codocil = 1 ";
                SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                DataTable dtt2 = new DataTable();
                daa2.Fill(dtt2);
                if (dtt2.Rows.Count > 0)
                {
                    ViewBag.documentbtn2 = "true";
                }
                con.Close();

                //end


                // check Poa status
                con.Open();
                string qry4 = "select POA  from users where POA = 1 ";
                SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                DataTable dtt4 = new DataTable();
                daa4.Fill(dtt4);
                if (dtt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }
                con.Close();
                //end


                // check gift deeds status
                con.Open();
                string qry3 = "select Giftdeeds  from users where Giftdeeds = 1 ";
                SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                DataTable dtt3 = new DataTable();
                daa3.Fill(dtt3);
                if (dtt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }
                con.Close();
                //end
            }
            else
            {

                ViewBag.documentlink = "true";

            }
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



            con.Open();
            string query = "select * from companyDetails";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[0].Action;

            }



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
                        + "<td> <button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";
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
                        + "<td><button type='button'   id=" + dt.Rows[i]["compId"].ToString() + "    class='btn btn-danger deletenotification'>Delete</button></td></tr>";
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
                        + "<td> <button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id=" + dt.Rows[i]["compId"].ToString() + "     class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }

                }



                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["compId"].ToString() + "</td>";

                    }



                }





            }

            return data;
        }



        public string DeleteCompanyRecords(RoleFormModel RFM)
        {

            // check type 
            string typ5 = "";
            con.Open();
            string qq15 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa5 = new SqlDataAdapter(qq15, con);
            DataTable dtt5 = new DataTable();
            daa5.Fill(dtt5);
            con.Close();

            if (dtt5.Rows.Count > 0)
            {
                typ5 = dtt5.Rows[0]["Type"].ToString();
            }



            //end



            if (typ5 == "Testator")
            {
                // check will status
                con.Open();
                string qry1 = "select Will  from users where Will = 1 ";
                SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                DataTable dtt1 = new DataTable();
                daa1.Fill(dtt1);
                if (dtt1.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
                con.Close();
                //end


                // check codocil status
                con.Open();
                string qry2 = "select Codocil  from users where Codocil = 1 ";
                SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                DataTable dtt2 = new DataTable();
                daa2.Fill(dtt2);
                if (dtt2.Rows.Count > 0)
                {
                    ViewBag.documentbtn2 = "true";
                }
                con.Close();

                //end


                // check Poa status
                con.Open();
                string qry4 = "select POA  from users where POA = 1 ";
                SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                DataTable dtt4 = new DataTable();
                daa4.Fill(dtt4);
                if (dtt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }
                con.Close();
                //end


                // check gift deeds status
                con.Open();
                string qry3 = "select Giftdeeds  from users where Giftdeeds = 1 ";
                SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                DataTable dtt3 = new DataTable();
                daa3.Fill(dtt3);
                if (dtt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }
                con.Close();
                //end
            }
            else
            {

                ViewBag.documentlink = "true";

            }
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Roles", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@roleid", index);
            cmd.Parameters.AddWithValue("@Role", "");
            cmd.Parameters.AddWithValue("@pid", "");
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


            con.Open();
            string query = "select * from companyDetails";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[0].Action;

            }



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
                        + "<td> <button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";
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
                        + "<td><button type='button'   id=" + dt.Rows[i]["compId"].ToString() + "    class='btn btn-danger deletenotification'>Delete</button></td></tr>";
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
                        + "<td> <button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id=" + dt.Rows[i]["compId"].ToString() + "     class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }

                }



                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["compId"].ToString() + "</td>";

                    }



                }





            }

            return data;
        }





        public int UpdateCompany()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }





    }
}