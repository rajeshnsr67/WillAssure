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
using System.Net.Mail;
using System.Net;


namespace WillAssure.Controllers
{
    public class EmailVerificationController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        public string Epassword = "admin@1234";
        // GET: EmailVerification
        public ActionResult EmailVerificationIndex(string v2)
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
            string OTP = Eramake.eCryptography.Decrypt(v2);
            Session["OTP"] = OTP;
            return View("~/Views/EmailVerification/EmailVerificationPageContent.cshtml");
        }

        public ActionResult CheckOTP(string v2 , EmailVerificationModel EVM)
        {
            // roleassignment
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


            //end


            string OTP = Session["OTP"].ToString();

            if (OTP == EVM.txtOTP)
            {
                con.Open();
                string query = "update TestatorDetails set Contact_Verification =1 , Email_Verification = 1 , Mobile_Verification_Status = 1 where Email_OTP = '"+OTP+"'";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                string query2 = "select * from TestatorDetails where Email_OTP = '" + OTP + "'";
                SqlDataAdapter da = new SqlDataAdapter(query2,con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                string PanNumber = "";
                string Password =  "";

                Password = String.Empty;
                string[] saAllowedCharacters = { "a" , "b" ,"c","d","e","f","g","h","i","j","k" , "l" , "m" ,"o" ,"p" , "q" ,"r" , "s" ,"t" ,"u" ,"v" ,"w" ,"x" , "y" , "z" , "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                int iOTPLength = 5;

                string sTempChars = String.Empty;
                Random rand = new Random();

                for (int i = 0; i < iOTPLength; i++)

                {

                    int p = rand.Next(0, saAllowedCharacters.Length);

                    sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                    Password += sTempChars;

                }


                if (dt.Rows.Count > 0)
                {

                  

                    if (dt.Rows[0]["Identity_Proof"].ToString() == "4")
                    {
                         PanNumber = dt.Rows[0]["Identity_Proof_Value"].ToString();



                    }



                    //generate Mail
                    string mailto = "";
                    string userid = "";
                  
                    mailto = Session["mailto"].ToString();
                    userid = Session["userid"].ToString();
                    string subject = "Will Assure Login Credentials";

                    string text = "<font color='Green' style='font-size=3em;'>Your UserId And Password For Logging In Is <br> UserID : " + userid + " <br> Password : " + Password + "</font>";
                    string body = "<font color='red'>" + text + "</font>";


                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("info@drinco.in");
                    msg.To.Add(mailto);
                    msg.Subject = subject;
                    msg.Body = body;

                    msg.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
                    smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                    smtp.EnableSsl = false;
                    smtp.Send(msg);
                    smtp.Dispose();


                    //end


                    // new mail code
           
                   
               


                    //end

                }





                ViewBag.Message = "Verified";
            }
            else
            {
                con.Open();
                string query = "update TestatorDetails set Contact_Verification =2 , Email_Verification = 2 , Mobile_Verification_Status = 2 where Email_OTP = '" +OTP+ "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

                ViewBag.Message = "Failed";
            }


           

            return View("~/Views/EmailVerification/EmailVerificationPageContent.cshtml");
        }



    }
}