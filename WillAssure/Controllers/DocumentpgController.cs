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
using System.Globalization;


namespace WillAssure.Controllers
{
    public class DocumentpgController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: Documentpg
        public ActionResult DocumentpgIndex()
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



            return View("~/Views/Documentpg/DocumentPgPageContent.cshtml");
        }



        public ActionResult insertDocumentDetails(TestatorFormModel TFM)
        {

            int testatorid = 0;
            int templateid = 0;
            string testatortype = "";


            //generate MOBILE OTP
            TFM.MobileOTP = String.Empty;
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            int iOTPLength = 5;

            string sTempChars = String.Empty;
            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                TFM.MobileOTP += sTempChars;

            }
            //END




            //generate EMAIL OTP
            TFM.EmailOTP = String.Empty;
            string[] saAllowedCharacters2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            int iOTPLength2 = 5;

            string sTempChars2 = String.Empty;
            Random rand2 = new Random();

            for (int i = 0; i < iOTPLength2; i++)

            {

                int p = rand.Next(0, saAllowedCharacters2.Length);

                sTempChars2 = saAllowedCharacters2[rand.Next(0, saAllowedCharacters2.Length)];

                TFM.EmailOTP += sTempChars2;

            }
            //END




            // coupon status
            if (TFM.txtCoupon != null)
            {
                con.Open();
                string checkcoupon = "select * from couponAllotment where Coupon_Number = " + TFM.txtCoupon + " and  Status = 'Active' ";
                SqlDataAdapter da = new SqlDataAdapter(checkcoupon, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    string upcoupon = "update couponAllotment set Status = 'Inactive' ,    Tid=" + testatorid + " ";
                    SqlCommand cmd2 = new SqlCommand(upcoupon, con);
                    cmd2.ExecuteNonQuery();




                    string upcoupon2 = "update discountCoupons set status = 'Inactive' ,    Coupon_Number=" + TFM.txtCoupon + " ";
                    SqlCommand cmd22 = new SqlCommand(upcoupon2, con);
                    cmd22.ExecuteNonQuery();




                }
                else
                {
                    ViewBag.Message = "checkCoupon";
                }
                con.Close();
            }


            //end

            // get coupon id
            con.Open();
            string query5 = "select a.couponId  from couponAllotment a inner join users b on a.uId=b.uId where b.uId = " + TFM.distributor_id + "";
            SqlDataAdapter da4 = new SqlDataAdapter(query5, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            int couponsid = 0;
            if (dt4.Rows.Count > 0)
            {
                couponsid = Convert.ToInt32(dt4.Rows[0]["couponId"]);
            }
            con.Close();
            //end


            con.Open();
            string gettid = "select top 1 tId from TestatorDetails order by tId desc";
            SqlDataAdapter datid = new SqlDataAdapter(gettid, con);
            DataTable dttid = new DataTable();
            datid.Fill(dttid);
            if (dttid.Rows.Count > 0)
            {
                testatorid = Convert.ToInt32(dttid.Rows[0]["tId"]);
            }
            con.Close();



            // update otp for email and mobile

            con.Open();
            string qq = "update TestatorDetails set Contact_Verification = 0 ,Email_Verification = 0 , Mobile_Verification_Status = 0 , Email_OTP = '"+TFM.EmailOTP+"' , Mobile_OTP = '"+TFM.MobileOTP+"' where  tId = "+testatorid+" ";
            SqlCommand cmddd = new SqlCommand(qq,con);
            cmddd.ExecuteNonQuery();
            con.Close();





            //end





            con.Open();
            string q = "insert into documentMaster (tId,templateId,IsUpdatetable,uId,pId,created_by,testator_type,couponId,adminVerification) values (" + testatorid + " , " + templateid + " ,  'Yes' ,   " + TFM.distributor_id + " , 1 , '" + TFM.Document_Created_By_txt + "' , '" + testatortype + "' , "+couponsid+"  , 2)";
            SqlCommand c = new SqlCommand(q, con);
            c.ExecuteNonQuery();
            con.Close();



            //end



            // DOCUMENT RULES
            int typeid = 0;
            int typecat = 0;

            if (TFM.documenttype == "Will")
            {
                typeid = 1;
            }
            if (TFM.documentcategory == "Quick")
            {
                typecat = 1;
            }
            if (TFM.documentcategory == "Detailed")
            {
                typecat = 2;
            }


            con.Open();
            string q1 = "insert into documentRules (documentType,category,tid) values (" + typeid + " , " + typecat + "  , " + testatorid + " )";
            SqlCommand c1 = new SqlCommand(q1, con);
            c1.ExecuteNonQuery();
            con.Close();



            //

            //1st condition
            if (TFM.Amt_Paid_By_txt == "Distributor" && TFM.Document_Created_By_txt == "Distributor")
            {
                TFM.Authentication_Required = 0;
                TFM.Link_Required = 0;
                TFM.Login_Required = 0;

                con.Open();
                string query1 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query1, con);
                cmd2.ExecuteNonQuery();
                con.Close();
                ModelState.Clear();
                return View("~/Views/AddTestatorsForm/AddTestatorPageContent.cshtml");
            }
            //end
            //2nd condition 
            if (TFM.Amt_Paid_By_txt == "Distributor" && TFM.Document_Created_By_txt == "Testator")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query2 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.ExecuteNonQuery();
                con.Close();



                if (Session["mailto"] == null)
                {
                    RedirectToAction("LoginPageIndex", "LoginPage");
                }
                if (Session["userid"] == null)
                {
                    RedirectToAction("LoginPageIndex", "LoginPage");
                }
                // new mail code
                string mailto = TFM.Email;
                string Userid = TFM.Identity_proof_Value;
                mailto = Session["TestatorEmail"].ToString();
                Session["userid"] = Userid;
                string subject = "Testing Mail Sending";
                string OTP = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
                string text = "Your OTP for Verification Is " + OTP + "";
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



            }
            //end
            // 3rd condtion
            if (TFM.Amt_Paid_By_txt == "Testator" && TFM.Document_Created_By_txt == "Distributor")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query3, con);
                cmd2.ExecuteNonQuery();
                con.Close();









                // new mail code
                string mailto = TFM.Email;
                string Userid = TFM.Identity_proof_Value;
                mailto = Session["TestatorEmail"].ToString();
                Session["userid"] = Userid;
                string subject = "Testing Mail Sending";
                string OTP = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
                string text = "Your OTP for Verification Is " + OTP + "";
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




            }
            //end
            //4th condition
            if (TFM.Amt_Paid_By_txt == "Testator" && TFM.Document_Created_By_txt == "Testator")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query4 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query4, con);
                cmd2.ExecuteNonQuery();
                con.Close();






                // new mail code
                string mailto = TFM.Email;
                string Userid = TFM.Identity_proof_Value;
                mailto = Session["TestatorEmail"].ToString();
                Session["userid"] = Userid;
                string subject = "Testing Mail Sending";
                string OTP = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
                string text = "Your OTP for Verification Is " + OTP + "";
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

            }
            //end








            string v1 = Eramake.eCryptography.Encrypt(TFM.EmailOTP);



            return View("~/Views/Documentpg/DocumentPgPageContent.cshtml");

        }


        public string BindDistributorDDL()
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
            string data = "<option value=''>--Select Distributor--</option>";
            con.Open();
            string query = "select uId , First_Name from users where Linked_user = " + Convert.ToInt32(Session["uuid"]) + "   and Type = 'DistributorAdmin'   ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["uId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                }




            }
            else
            {

                con.Open();
                string query2 = "select uId , First_Name from users where uId = " + Convert.ToInt32(Session["uuid"]) + "  ";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                con.Close();


                if (dt2.Rows.Count > 0)
                {


                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {




                        data = data + "<option value=" + dt2.Rows[i]["uId"].ToString() + " >" + dt2.Rows[i]["First_Name"].ToString() + "</option>";



                    }
                }

            }

            return data;
        }


    }
}