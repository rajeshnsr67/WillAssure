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
            ViewBag.collapse = "true";
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
            //if (Session["tid"]== null)
            //{
            //    ViewBag.message = "link";
            //}


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
                ViewBag.showtitle = "true";
                ViewBag.documentlink = "true";

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
            string query2 = "insert into users (First_Name , Last_Name , Middle_Name , eMail , Mobile , userID , userPwd , Type , active, rId , compId , Linked_user , Designation , Address1 , Address2 , Address3 , City , State , Pin , DOB) values ('" + VM.First_Name + "' , '" + VM.Last_Name + "' , '" + VM.Middle_Name + "' , '" + VM.Email + "' , '" + VM.Mobile + "' , '" + VM.Email + "' , "+VM.userPassword+ " , 'Testator','Active' , 5 , 0 , "+ VM.distributor_id + " , 1 , 'none' , 'none' , 'none' , 'none', 'none' , 'none' , GETDATE()  )";
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
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' where uId = " + userid + " ";
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
            if (VM.DocumentType == "Giftdeeds")
            {
               
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '0' , Giftdeeds='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "GiftdeedsCodocil")
            {
           
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "GiftdeedsWill")
            {
                
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "GiftdeedsPOA")
            {
                
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (VM.DocumentType == "WillGiftdeeds")
            {
                
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' ,  Giftdeeds='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "POAGiftdeeds")
            {
                
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "CodocilGiftdeeds")
            {
               
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "CodocilGiftdeedsWill")
            {
            
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "CodocilGiftdeedsWillPOA")
            {
              
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "CodocilWillGiftdeedsPOA")
            {
                
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "WillCodocilPOAGiftdeeds")
            {
             
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "WillCodocilPOAGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "LivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='0' , LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "LivingWillWillCodocilPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "CodocilGiftdeedsLivingWillWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "LivingWillWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "POALivingWillWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "LivingWillPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "POAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "POAGiftdeedsWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "POAWillCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='0', LivingWill='0' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "CodocilLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "CodocilGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "POALivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (VM.DocumentType == "GiftDeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (VM.DocumentType == "WillCodocilPOAGiftDeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + userid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            con.Open();
            string query3 = "insert into TestatorDetails (First_Name,Middle_Name,Last_Name,Mobile,Email,uid ,DOB,Occupation,maritalStatus,RelationShip,Religion,Identity_Proof,Identity_proof_Value,Alt_Identity_Proof,Alt_Identity_proof_Value,Gender,Address1,Address2,Address3,City ,State,Country ,Pin,active) values ('" + VM.First_Name+"' , '"+VM.Middle_Name+"' , '"+VM.Last_Name+"' , '"+VM.Mobile+"' , '"+VM.Email+"' , "+ userid + " , GETDATE() ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'none' ,'no' )    ";
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

            VisitorModel Vm = new VisitorModel();


            con.Open();
            string query22 = "select * from visitorinfo where vid = " + VM.vid + "";
            SqlDataAdapter da = new SqlDataAdapter(query22, con);
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




            con.Open();
            string qq22 = "insert into documentRules (tid,documentType) values ("+testatorid+" , '"+Vm.DocumentType+"')";
            SqlCommand cmddd22 = new SqlCommand(qq22, con);
            cmddd22.ExecuteNonQuery();
            con.Close();



            ViewBag.Type = "create";



            return View("~/Views/VerifyVisitor/VerifyVisitorPageContent.cshtml", Vm);
        }



        public ActionResult insertDocumentDetails(VisitorModel TFM)
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
















            int testatorid = 0;
            int templateid = 0;
            int distid = 0;
            string testatortype = "";
            string Email = "";


            // get testator id and dist id from lastest inserted

            con.Open();
            string gettid = "select max(tId) as tid , max(uId) as uid from testatordetails";
            SqlDataAdapter tida = new SqlDataAdapter(gettid, con);
            DataTable tidt = new DataTable();
            tida.Fill(tidt);
            if (tidt.Rows.Count > 0)
            {
                testatorid = Convert.ToInt32(tidt.Rows[0]["tid"]);
                distid = Convert.ToInt32(tidt.Rows[0]["uId"]);

            }
            con.Close();





            //end










            // identitfy email of testator

            con.Open();
            string tquery = "select Email from testatordetails where tId = " + testatorid + " ";
            SqlDataAdapter tda = new SqlDataAdapter(tquery, con);
            DataTable tdt = new DataTable();
            tda.Fill(tdt);
            if (tdt.Rows.Count > 0)
            {
                Email = tdt.Rows[0]["Email"].ToString();

            }
            con.Close();




            //end

















            // get coupon id
            con.Open();
            string query5 = "select a.couponId  from couponAllotment a inner join users b on a.uId=b.uId where b.uId = " + distid + "";
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
            string q1 = "insert into documentMaster (tId,templateId,IsUpdatetable,uId,pId,created_by,testator_type,couponId,adminVerification) values (" + testatorid + " , " + templateid + " ,  'Yes' ,   " + distid + " , 1 , '" + TFM.Document_Created_By + "' , '" + testatortype + "' , " + couponsid + "  , 2)";
            SqlCommand c = new SqlCommand(q1, con);
            c.ExecuteNonQuery();
            con.Close();



            //end



            // DOCUMENT RULES
            string typeid = "";
            int typecat = 0;
            if (TFM.documenttype11 == "WillCodocilPOA")
            {
                typeid = "1,2,3";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();

            }
            if (TFM.documenttype11 == "Codocil")
            {
                typeid = "2";



                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();


            }
            if (TFM.documenttype11 == "POA")
            {
                typeid = "3";

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "Will")
            {
                typeid = "1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "WillCodocil")
            {
                typeid = "1,2";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "WillPOA")
            {
                typeid = "1,3";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "CodocilPOA")
            {
                typeid = "2,3";

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "CodocilWill")
            {
                typeid = "2,1";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "POAWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "Giftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "GiftdeedsCodocil")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "GiftdeedsWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "GiftdeedsPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype11 == "WillGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' ,  Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "POAGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "CodocilGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "CodocilGiftdeedsWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "CodocilGiftdeedsWillPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "CodocilWillGiftdeedsPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "WillCodocilPOAGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "WillCodocilPOAGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "LivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='0' , LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "LivingWillWillCodocilPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "CodocilGiftdeedsLivingWillWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "LivingWillWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "POALivingWillWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype11 == "LivingWillPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "POAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "POAGiftdeedsWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "POAWillCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='0', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "CodocilLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "CodocilGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "POALivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype11 == "GiftDeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
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
            string q2 = "insert into documentRules (documentType,category,guardian , executors_category , AlternateBenficiaries , AlternateGaurdian , AlternateExecutors , tid) values ('" + TFM.documenttype11 + "' , " + typecat + "  ,  0  , 0 , 0 , 0 , 0 , " + testatorid + " )";
            SqlCommand c1 = new SqlCommand(q2, con);
            c1.ExecuteNonQuery();
            con.Close();



            //

            //1st condition
            if (TFM.Amt_Paid_By == "Distributor" && TFM.Document_Created_By == "Distributor")
            {
                TFM.Authentication_Required = 0;
                TFM.Link_Required = 0;
                TFM.Login_Required = 0;

                con.Open();
                string query1 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , " + distid + " , '" + TFM.Amt_Paid_By_txt + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query1, con);
                cmd2.ExecuteNonQuery();
                con.Close();
                ModelState.Clear();
                return View("~/Views/AddTestatorsForm/AddTestatorPageContent.cshtml");
            }
            //end
            //2nd condition 
            if (TFM.Amt_Paid_By == "Distributor" && TFM.Document_Created_By == "Testator")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By + "' , " + distid + " , '" + TFM.Amt_Paid_By + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query3, con);
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
                mailto = Email;

                string subject = "Will Assure Link For Payment";
                string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



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

                // payment status for testator details table
                con.Open();
                string paymentquery2 = "update TestatorDetails set PaymentStatus = 1 where tId = " + testatorid + " ";
                SqlCommand paymentcmd2 = new SqlCommand(paymentquery2, con);
                paymentcmd2.ExecuteNonQuery();
                con.Close();
                //end


                // payment info
                con.Open();
                string paymentquery = "insert into PaymentInfo (uId,tId,transactionStatus) values (" + distid + " , " + testatorid + " , 1)  ";
                SqlCommand paymentcmd = new SqlCommand(paymentquery, con);
                paymentcmd.ExecuteNonQuery();
                con.Close();
                //end

                ViewBag.PaymentLink = "true";
            }
            //end
            // 3rd condtion
            if (TFM.Amt_Paid_By == "Testator" && TFM.Document_Created_By == "Distributor")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By + "' , " + distid + " , '" + TFM.Amt_Paid_By + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query3, con);
                cmd2.ExecuteNonQuery();
                con.Close();









                // new mail code
                string mailto = TFM.Email;
                string Userid = TFM.Identity_proof_Value;
                mailto = Email;
                string subject = "Will Assure Link For Payment";
                string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



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

                // payment status for testator details table
                con.Open();
                string paymentquery2 = "update TestatorDetails set PaymentStatus = 1 where tId = " + testatorid + " ";
                SqlCommand paymentcmd2 = new SqlCommand(paymentquery2, con);
                paymentcmd2.ExecuteNonQuery();
                con.Close();
                //end

                // payment info
                con.Open();
                string paymentquery = "insert into PaymentInfo (uId,tId,transactionStatus) values (" + distid + " , " + testatorid + " , 1)  ";
                SqlCommand paymentcmd = new SqlCommand(paymentquery, con);
                paymentcmd.ExecuteNonQuery();
                con.Close();
                //end

                ViewBag.PaymentLink = "true";
            }
            //end
            //4th condition
            if (TFM.Amt_Paid_By == "Testator" && TFM.Document_Created_By == "Testator")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By + "' , " + distid + " , '" + TFM.Amt_Paid_By + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query3, con);
                cmd2.ExecuteNonQuery();
                con.Close();





                // new mail code
                string mailto = TFM.Email;
                string Userid = TFM.Identity_proof_Value;
                mailto = Email;
                string subject = "Will Assure Link For Payment";
                string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



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


                // payment status for testator details table
                con.Open();
                string paymentquery2 = "update TestatorDetails set PaymentStatus = 1 where tId = " + testatorid + " ";
                SqlCommand paymentcmd2 = new SqlCommand(paymentquery2, con);
                paymentcmd2.ExecuteNonQuery();
                con.Close();
                //end






                // payment info
                con.Open();
                string paymentquery = "insert into PaymentInfo (uId,tId,transactionStatus) values (" + distid + " , " + testatorid + " , 1)  ";
                SqlCommand paymentcmd = new SqlCommand(paymentquery, con);
                paymentcmd.ExecuteNonQuery();
                con.Close();
                //end
                ViewBag.PaymentLink = "true";
            }
            //end







            ModelState.Clear();




            //end


            ViewBag.collapse = "true";


            return View("~/Views/EditVisitor/EditVisitorPageContent.cshtml");

        }





    }
}