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
using System.Net.Mail;
using System.Net;

namespace WillAssure.Controllers
{
    public class VerifyVisitorController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: VerifyVisitor
        public ActionResult VerifyVisitorIndex(int NestId)
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




            VisitorModel Vm = new VisitorModel();


            con.Open();
            string query = "select * from visitorinfo where vid = " + NestId + "";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();







            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Vm.vid = Convert.ToInt32(dt.Rows[i]["vid"]);
                    Vm.First_Name = dt.Rows[i]["First_Name"].ToString();
                    Vm.Middle_Name = dt.Rows[i]["Middle_Name"].ToString();
                    Vm.Last_Name = dt.Rows[i]["Last_Name"].ToString();
                    Vm.Mobile = dt.Rows[i]["Mobile"].ToString();
                    Vm.Email = dt.Rows[i]["Email"].ToString();
                    Vm.RefDist = dt.Rows[i]["RefDist"].ToString();
                    Vm.DocumentType = dt.Rows[i]["DocumentType"].ToString();

                }








            }







            return View("~/Views/VerifyVisitor/VerifyVisitorPageContent.cshtml",Vm);
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




        public ActionResult VerifyVistor(VisitorModel VM)
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









            con.Open();
            string query = "update visitorinfo set RefDist = "+VM.distributor_id + " where vid = "+VM.vid+" ";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();


            //generate Password OTP
            VM.userPassword = String.Empty;
            string[] saAllowedCharacters3 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            int iOTPLength3 = 5;

            string sTempChars3 = String.Empty;
            Random rand3 = new Random();

            for (int i = 0; i < iOTPLength3; i++)

            {

                int p = rand3.Next(0, saAllowedCharacters3.Length);

                sTempChars3 = saAllowedCharacters3[rand3.Next(0, saAllowedCharacters3.Length)];

                VM.userPassword += sTempChars3;

            }
            //END



            con.Open();
            string query2 = "insert into users (First_Name , Last_Name , Middle_Name , eMail , Mobile , userID , userPwd , Type , active, rId , compId , Linked_user) values ('" + VM.First_Name + "' , '" + VM.Last_Name + "' , '" + VM.Middle_Name + "' , '" + VM.Email + "' , '" + VM.Mobile + "' , '" + VM.Email + "' , "+VM.userPassword+ " , 'Testator','Active' , 5 , 0 , "+ VM.distributor_id + ")    ";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.ExecuteNonQuery();
            con.Close();


            con.Open();
            string getuid = "select top 1 uId from users order by uId desc";
            SqlDataAdapter datuid = new SqlDataAdapter(getuid, con);
            DataTable dtuid = new DataTable();
            datuid.Fill(dtuid);
            int userid = 0;
            if (dtuid.Rows.Count > 0)
            {
                userid = Convert.ToInt32(dtuid.Rows[0]["uId"]);
            }
            con.Close();




            if (VM.DocumentType == "WillCodocilPOA")
            {
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' where uId = "+ userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "Codocil")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();

            }
            if (VM.DocumentType == "POA")
            {
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "Will")
            {
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "WillCodocil")
            {
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "WillPOA")
            {
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "CodocilPOA")
            {
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "CodocilWill")
            {
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "POAWill")
            {
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }









            con.Open();
            string query3 = "insert into TestatorDetails (First_Name,Middle_Name,Last_Name,Mobile,Email,uid) values ('"+VM.First_Name+"' , '"+VM.Middle_Name+"' , '"+VM.Last_Name+"' , '"+VM.Mobile+"' , '"+VM.Email+"' , "+VM.distributor_id + ")    ";
            SqlCommand cmd3 = new SqlCommand(query3,con);
            cmd3.ExecuteNonQuery();
            con.Close();

         






            




            //generate MOBILE OTP
            VM.MobileOTP = String.Empty;
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            int iOTPLength = 5;

            string sTempChars = String.Empty;
            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                VM.MobileOTP += sTempChars;

            }
            //END




            //generate EMAIL OTP
            VM.EmailOTP = String.Empty;
            string[] saAllowedCharacters2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            int iOTPLength2 = 5;

            string sTempChars2 = String.Empty;
            Random rand2 = new Random();

            for (int i = 0; i < iOTPLength2; i++)

            {

                int p = rand.Next(0, saAllowedCharacters2.Length);

                sTempChars2 = saAllowedCharacters2[rand.Next(0, saAllowedCharacters2.Length)];

                VM.EmailOTP += sTempChars2;

            }
            //END



            if (VM.Email != "")
            {
                // new mail code
                string mailto = VM.Email;
                string Userid = VM.Email;
               
                Session["userid"] = Userid;
                string subject = "Testing Mail Sending";
                string OTP = "<font color='Green' style='font-size=3em;'>" + VM.EmailOTP + "</font>";
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



            int testatorid = 0;



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









            if (VM.Email != "")
            {
                //generate Mail
                string mailto2 = VM.Email;
                string userlogin = VM.Email;


                string subject = "Will Assure Login Credentials";

                string text = "<font color='Green' style='font-size=3em;'>Your UserId And Password For Logging In Is <br> UserID : " + userlogin + " <br> Password : " + VM.userPassword + "</font>";
                string body = "<font color='red'>" + text + "</font>";


                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("info@drinco.in");
                msg.To.Add(mailto2);
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


            int ruleid = 0;

            con.Open();
            string getrule = "select top 1 wdId from documentRules order by wdId desc";
            SqlDataAdapter daruleid = new SqlDataAdapter(getrule, con);
            DataTable dtruleid = new DataTable();
            daruleid.Fill(dtruleid);
            if (dtruleid.Rows.Count > 0)
            {
                ruleid = Convert.ToInt32(dtruleid.Rows[0]["wdId"]);
            }
            con.Close();


            con.Open();
            string qq2 = "update documentRules set tid ="+testatorid+ " where wdId="+ruleid+"  ";
            SqlCommand cmddd2 = new SqlCommand(qq2, con);
            cmddd2.ExecuteNonQuery();
            con.Close();



            // update otp for email and mobile

            con.Open();
            string qq = "update TestatorDetails set Contact_Verification = 0 ,Email_Verification = 0 , Mobile_Verification_Status = 0 , Email_OTP = '" + VM.EmailOTP + "' , Mobile_OTP = '" + VM.MobileOTP + "' where  tId = " + testatorid + " ";
            SqlCommand cmddd = new SqlCommand(qq, con);
            cmddd.ExecuteNonQuery();
            con.Close();





            //end




       
            return View("~/Views/VerifyVisitor/VerifyVisitorPageContent.cshtml");
        }





    }
}