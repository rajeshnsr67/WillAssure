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
    public class DashBoardController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: DashBoard
        public ActionResult DashBoardIndex()
        {



            string OTP = "";
            if (Session["LoginOTP"] != null)
            {
                OTP = Session["LoginOTP"].ToString();
                //Session["LoginOTP"] = Eramake.eCryptography.Decrypt(OTP);
                Session["enteredOTP"] = OTP;
            }
            else
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

            if (Session["enteredOTP"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

            con.Open();
            string query = "select Designation  from users where uId = " + Convert.ToInt32(Session["uuid"])+"  ";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string type = "";

            if (dt.Rows.Count > 0)
            {
               type =  dt.Rows[0]["Designation"].ToString();
            }
            con.Close();


            if (type != "2")
            {
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






            }
            else
            {

                ViewBag.Testatorpopup = "true";

            }




            // total count Dashboard

            string q1 = "select count(*) as TotalDistributorAdmin from users  where Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and Type = 'DistributorAdmin'";
            SqlDataAdapter da1 = new SqlDataAdapter(q1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            ViewBag.TotalDistributorAdmin = Convert.ToInt32(dt1.Rows[0]["TotalDistributorAdmin"]);




            string q2 = "select count(*) as TotalWillEmployee from users  where Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and Type = 'WillEmployee'";
            SqlDataAdapter da22 = new SqlDataAdapter(q2, con);
            DataTable dt22 = new DataTable();
            da22.Fill(dt22);
            ViewBag.TotalWillEmployee = Convert.ToInt32(dt22.Rows[0]["TotalWillEmployee"]);



            string q4 = "select count(*) as TotalDistributorEmployee from users  where Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and Type = 'DistributorEmployee'";
            SqlDataAdapter da4 = new SqlDataAdapter(q4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            ViewBag.TotalDistributorEmployee = Convert.ToInt32(dt4.Rows[0]["TotalDistributorEmployee"]);



            string q5 = "select count(*) as TotalTestator  from TestatorDetails a inner join users b on a.uId=b.uId where b.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da5 = new SqlDataAdapter(q5, con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            ViewBag.TotalTestator = Convert.ToInt32(dt5.Rows[0]["TotalTestator"]);



            string q6 = "select count(*) as TotalWillEmployee from users  where Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and Type = 'WillEmployee'";
            SqlDataAdapter da6 = new SqlDataAdapter(q6, con);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);
            ViewBag.TotalWillEmployee = Convert.ToInt32(dt6.Rows[0]["TotalWillEmployee"]);




            string q7 = "select count(*) as TotalFamily from testatorFamily a inner join TestatorDetails b on a.tId=b.tId inner join users c on b.uId = c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da7 = new SqlDataAdapter(q7, con);
            DataTable dt7 = new DataTable();
            da7.Fill(dt7);
            ViewBag.TotalFamily = Convert.ToInt32(dt7.Rows[0]["TotalFamily"]);



            string q8 = "select count(*) as TotalAssetInformation from AssetInformation a  inner join TestatorDetails b on a.tid=b.tId inner join AssetsType c on a.atId = c.atId inner join AssetsCategory d on a.amId=d.amId inner join users e on e.uId=b.uId  where e.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da8 = new SqlDataAdapter(q8, con);
            DataTable dt8 = new DataTable();
            da8.Fill(dt8);
            ViewBag.TotalAssetInformation = Convert.ToInt32(dt8.Rows[0]["TotalAssetInformation"]);



            string q9 = "select count(*) as TotalBeneficiary from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId inner join users c on b.uId = c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da9 = new SqlDataAdapter(q9, con);
            DataTable dt9 = new DataTable();
            da9.Fill(dt9);
            ViewBag.TotalBeneficiary = Convert.ToInt32(dt9.Rows[0]["TotalBeneficiary"]);



            string q10 = "select count(*) as TotalNominee from Nominee a inner join TestatorDetails b on a.tId=b.tId inner join users c on b.uId=c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da10 = new SqlDataAdapter(q10, con);
            DataTable dt10 = new DataTable();
            da10.Fill(dt10);
            ViewBag.TotalNominee = Convert.ToInt32(dt10.Rows[0]["TotalNominee"]);




            string q11 = "select count(*) as TotalAppointees  from Appointees a inner join  TestatorDetails b on a.tid=b.tid inner join users c on b.uId=c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da11 = new SqlDataAdapter(q11, con);
            DataTable dt11 = new DataTable();
            da11.Fill(dt11);
            ViewBag.TotalAppointees = Convert.ToInt32(dt11.Rows[0]["TotalAppointees"]);





            con.Close();




            //end



            // check type 
            string typ = "";
            con.Open();
            string qq1 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa = new SqlDataAdapter(qq1, con);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            con.Close();

            if (dtt.Rows.Count > 0)
            {
                typ = dtt.Rows[0]["Type"].ToString();
            }



            //end



            if (typ == "Testator")
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
       

        


            return View("~/Views/DashBoard/DashBoardPageContent.cshtml");
        }


        public ActionResult EnableDocumentLinks()
        {

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


            ViewBag.enabledocumentlink = "true";



            return View("~/Views/DashBoard/DashBoardPageContent.cshtml");
        }




        public ActionResult CodocilMasterindex()
        {

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


            return View("~/Views/Shared/CodocilMaster.cshtml");

        }




        public ActionResult VerifyOTP(LoginModel EVM)
        {
            if (Session["enteredOTP"] != null)
            {
                if (Session["enteredOTP"].ToString() == EVM.OTP)
                {
                    con.Open();
                    string query = "update TestatorDetails set Contact_Verification =1 , Email_Verification = 1 , Mobile_Verification_Status = 1 where Email_OTP = '" + ViewBag.OTP + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();




                    con.Open();
                    string updateotp = "update users set Designation = 1 where uid = " + Convert.ToInt32(Session["uuid"]) + "  ";
                    SqlCommand cmdot = new SqlCommand(updateotp, con);
                    cmdot.ExecuteNonQuery();
                    con.Close();


                    con.Open();

                    string qq = "select a.Amt_Paid_By from Authorization_Rules a inner join TestatorDetails b on  a.Testator_Id=b.tId where b.Email_OTP = " + Session["enteredOTP"].ToString() + " ";
                    SqlDataAdapter dda = new SqlDataAdapter(qq,con);
                    DataTable ddt = new DataTable();
                    dda.Fill(ddt);
                    string amtpaidby = "";
                    if (ddt.Rows.Count > 0)
                    {
                       amtpaidby = ddt.Rows[0]["Amt_Paid_By"].ToString();
                    }
                    con.Close();

                    if (amtpaidby == "Testator")
                    {
                        ViewBag.PaymentLink = "true";
                    }
                    else
                    {
                      return  RedirectToAction("DashBoardIndex", "DashBoard");
                    }




                    ViewBag.Message = "Verified";
                }
                else
                {
                    con.Open();
                    string query = "update TestatorDetails set Contact_Verification =2 , Email_Verification = 2 , Mobile_Verification_Status = 2 where Email_OTP = '" + Session["enteredOTP"].ToString() + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ViewBag.Testatorpopup = "true";
                    ViewBag.Message = "Failed";
                }


               






            }












            return View("~/Views/DashBoard/DashBoardPageContent.cshtml");

        }



    }
}