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


    public class FrontendController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: Frontend
        public ActionResult Index()
        {
            if (Session["displayname"] != null)
            {
                if (Session["displayname"].ToString() != "")
                {
                    ViewBag.enableMultipleSelect = "true";
                }
            }
            
            return View("~/Views/Frontend/Index.cshtml");
        }


        public ActionResult AboutUsIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Aboutus.cshtml");
        }


        public ActionResult ContactUsIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/ContactUs.cshtml");
        }



        public ActionResult DisclaimerIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Disclaimer.cshtml");
        }


        public ActionResult DocumentIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }

            

            return View("~/Views/Frontend/Document.cshtml");
        }


        public ActionResult FaqIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Faq.cshtml");
        }



        public ActionResult HowweworkIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Howwework.cshtml");
        }



        public ActionResult PrivacyPolicyIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Privacypolicy.cshtml");
        }


        public ActionResult RegnIndex()
        {
            if (Session["displayname"] != null)
            {
                if (Session["displayname"].ToString() != "")
                {
                    ViewBag.enableMultipleSelect = "true";
                }
            }

            
            return View("~/Views/Frontend/Regn.cshtml");
        }


        public ActionResult ServicesIndex()
        {
            if (Session["displayname"].ToString() != "")
            {
                ViewBag.enableMultipleSelect = "true";
            }
            return View("~/Views/Frontend/Services.cshtml");
        }


        public ActionResult checkpaymentstatus()
        {
        

            if (Session["displayname"].ToString() != "")
            {

                // document amount cal

                int total = 0;
                int willamt = 0;
                int Codocilamt = 0;
                int POAamt = 0;
                int Giftdeedsamt = 0;
                int LivingWillamt = 0;
                con.Open();
                string qry312 = "select Will , Codocil , POA , Giftdeeds , LivingWill from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlDataAdapter daa23 = new SqlDataAdapter(qry312, con);
                DataTable dtt43 = new DataTable();
                daa23.Fill(dtt43);
                if (dtt43.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtt43.Rows[0]["Will"]) == 1)
                    {

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'Will' ";
                        SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                        DataTable daat = new DataTable();
                        daa1.Fill(daat);
                        if (daat.Rows.Count > 0)
                        {
                            willamt = Convert.ToInt32(daat.Rows[0]["Document_Price"]);
                        }

                    }
                    if (Convert.ToInt32(dtt43.Rows[0]["Codocil"]) == 1)
                    {

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'Codocil' ";
                        SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                        DataTable daat = new DataTable();
                        daa1.Fill(daat);
                        if (daat.Rows.Count > 0)
                        {
                            Codocilamt += Convert.ToInt32(daat.Rows[0]["Document_Price"]);
                        }

                    }
                    if (Convert.ToInt32(dtt43.Rows[0]["POA"]) == 1)
                    {

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'POA' ";
                        SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                        DataTable daat = new DataTable();
                        daa1.Fill(daat);
                        if (daat.Rows.Count > 0)
                        {
                            POAamt += Convert.ToInt32(daat.Rows[0]["Document_Price"]);
                        }

                    }
                    if (Convert.ToInt32(dtt43.Rows[0]["Giftdeeds"]) == 1)
                    {

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'Giftdeeds' ";
                        SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                        DataTable daat = new DataTable();
                        daa1.Fill(daat);
                        if (daat.Rows.Count > 0)
                        {
                            Giftdeedsamt += Convert.ToInt32(daat.Rows[0]["Document_Price"]);
                        }

                    }
                    if (Convert.ToInt32(dtt43.Rows[0]["LivingWill"]) == 1)
                    {

                        string quer1 = "select Document_Price from documentpricing  where Document_Name = 'LivingWill' ";
                        SqlDataAdapter daa1 = new SqlDataAdapter(quer1, con);
                        DataTable daat = new DataTable();
                        daa1.Fill(daat);
                        if (daat.Rows.Count > 0)
                        {
                            LivingWillamt += Convert.ToInt32(daat.Rows[0]["Document_Price"]);
                        }

                    }
                }
                con.Close();

                total = willamt + Codocilamt + POAamt + Giftdeedsamt + LivingWillamt;

                Session["documentamount"] = total;

                //end








                ViewBag.enableMultipleSelect = "true";

                con.Open();
                string qq222 = "select PaymentStatus from testatordetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                SqlDataAdapter daa22 = new SqlDataAdapter(qq222, con);
                DataTable paydtt = new DataTable();
                daa22.Fill(paydtt);
                con.Close();

                if (Convert.ToInt32(paydtt.Rows[0]["PaymentStatus"]) == 1)
                {


                    // check will status
                    con.Open();
                    string qry1 = "select Will , Designation  from users where Will = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                    DataTable dtt1 = new DataTable();
                    daa1.Fill(dtt1);
                    if (dtt1.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtt1.Rows[0]["Will"]) == 1 && Convert.ToInt32(dtt1.Rows[0]["Designation"]) == 1)
                        {
                            ViewBag.documentbtn1 = "true";
                        }

                    }
                    con.Close();
                    //end


                    // check codocil status
                    con.Open();
                    string qry2 = "select Codocil , Designation  from users where Codocil = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                    DataTable dtt2 = new DataTable();
                    daa2.Fill(dtt2);
                    if (dtt2.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtt2.Rows[0]["Codocil"]) == 1 && Convert.ToInt32(dtt2.Rows[0]["Designation"]) == 1)
                        {
                            ViewBag.documentbtn2 = "true";
                        }
                    }
                    con.Close();

                    //end


                    // check Poa status
                    con.Open();
                    string qry4 = "select POA  , Designation  from users where POA = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                    DataTable dtt4 = new DataTable();
                    daa4.Fill(dtt4);
                    if (dtt4.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtt4.Rows[0]["POA"]) == 1 && Convert.ToInt32(dtt4.Rows[0]["Designation"]) == 1)
                        {

                            ViewBag.documentbtn3 = "true";
                        }
                    }
                    con.Close();
                    //end


                    // check gift deeds status
                    con.Open();
                    string qry3 = "select Giftdeeds , Designation  from users where Giftdeeds = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                    DataTable dtt3 = new DataTable();
                    daa3.Fill(dtt3);
                    if (dtt3.Rows.Count > 0)
                    {
                        if (dtt3.Rows[0]["Giftdeeds"] != null)
                        {
                            if (Convert.ToInt32(dtt3.Rows[0]["Giftdeeds"]) == 1 && Convert.ToInt32(dtt3.Rows[0]["Designation"]) == 1)
                            {
                                ViewBag.documentbtn4 = "true";
                            }
                        }

                    }
                    con.Close();
                    //end


                    // check Living Will status
                    con.Open();
                    string qry3122 = "select LivingWill , Designation  from users where LivingWill = 1 and Designation = 1 and uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa233 = new SqlDataAdapter(qry3122, con);
                    DataTable dtt433 = new DataTable();
                    daa233.Fill(dtt433);
                    if (dtt433.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtt433.Rows[0]["LivingWill"]) == 1 && Convert.ToInt32(dtt433.Rows[0]["Designation"]) == 1)
                        {
                            ViewBag.documentbtn5 = "true";
                        }
                    }
                    con.Close();
                    //end

                    ViewBag.create = "true";

                }
                else
                {
                  
                            ViewBag.PaymentLink = "true";
                       
                    
                }



            }
            return View("~/Views/Frontend/Document.cshtml");



        }




        public ActionResult insertDocumentDetails(TestatorFormModel TFM)
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


            //generate Password OTP
            TFM.userPassword = String.Empty;
            string[] saAllowedCharacters3 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            int iOTPLength3 = 5;

            string sTempChars3 = String.Empty;
            Random rand3 = new Random();

            for (int i = 0; i < iOTPLength3; i++)

            {

                int p = rand3.Next(0, saAllowedCharacters3.Length);

                sTempChars3 = saAllowedCharacters3[rand3.Next(0, saAllowedCharacters3.Length)];

                TFM.userPassword += sTempChars3;

            }
            //END




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


            // update password for the users

            con.Open();
            string qtt = "update users set userPwd = " + TFM.userPassword + " where uId = " + distid + " ";
            SqlCommand cmd = new SqlCommand(qtt, con);
            cmd.ExecuteNonQuery();
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
            if (TFM.documenttype == "WillCodocilPOA")
            {
                typeid = "1,2,3";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();

            }
            if (TFM.documenttype == "Codocil")
            {
                typeid = "2";



                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();


            }
            if (TFM.documenttype == "POA")
            {
                typeid = "3";

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "Will")
            {
                typeid = "1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillCodocil")
            {
                typeid = "1,2";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillPOA")
            {
                typeid = "1,3";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilPOA")
            {
                typeid = "2,3";

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilWill")
            {
                typeid = "2,1";

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "Giftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "GiftdeedsCodocil")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftdeedsWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftdeedsPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' ,  Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilGiftdeedsWill")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilGiftdeedsWillPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilWillGiftdeedsPOA")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillCodocilPOAGiftdeeds")
            {
                typeid = "3,1";
                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillCodocilPOAGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='0' , LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillWillCodocilPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "CodocilGiftdeedsLivingWillWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "POALivingWillWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAGiftdeedsWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POAWillCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='0', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "POALivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "GiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillCodocilPOAGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "POAGiftDeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillGiftDeedsPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftDeedsLivingWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "LivingWillGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }


            if (TFM.documenttype == "WillGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "GiftdeedsPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "LivingWillPOA")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '0' , POA = '1' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillGiftdeedsCodocil")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }

            if (TFM.documenttype == "WillGiftdeedsLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='1', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "CodocilPOAGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '0' , Codocil = '1' , POA = '1' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillCodocilGiftdeeds")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '1' , POA = '0' , Giftdeeds='1', LivingWill='0' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "WillLivingWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
                SqlCommand cc1 = new SqlCommand(qq1, con);
                cc1.ExecuteNonQuery();
                con.Close();
            }
            if (TFM.documenttype == "LivingWillWill")
            {

                con.Open();
                string qq1 = "update users set Will = '1' , Codocil = '0' , POA = '0' , Giftdeeds='0', LivingWill='1' where uId = " + distid + " ";
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
            string q2 = "insert into documentRules (documentType,category,guardian , executors_category , AlternateBenficiaries , AlternateGaurdian , AlternateExecutors , tid) values ('" + TFM.documenttype + "' , " + typecat + "  ,  0  , 0 , 0 , 0 , 0 , " + testatorid + " )";
            SqlCommand c1 = new SqlCommand(q2, con);
            c1.ExecuteNonQuery();
            con.Close();



            //


            if (Session["distidbal"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }


            //1st condition
            if (TFM.Amt_Paid_By == "Distributor" && TFM.Document_Created_By == "Distributor")
            {
                int cal = 0;
                con.Open();
                string qq1 = "select Balance_Count from  allotmentDistributor";
                SqlDataAdapter qq1da = new SqlDataAdapter(qq1, con);
                DataTable qq1dt = new DataTable();
                qq1da.Fill(qq1dt);
                int bal = 0;
                if (qq1dt.Rows.Count > 0)
                {
                    bal = Convert.ToInt32(qq1dt.Rows[0]["Balance_Count"]);
                }
                con.Close();

                cal = bal - 1;

                Response.Write("<script>alert('Balance Document For Distributor is :" + cal + "')</script>");
                con.Open();
                string qqchk = "update allotmentDistributor set Balance_Count = " + cal + " where uId = " + Convert.ToInt32(Session["distidbal"]) + "  ";
                SqlCommand cccm = new SqlCommand(qqchk, con);
                cccm.ExecuteNonQuery();
                con.Close();

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

                int cal = 0;
                con.Open();
                string qq1 = "select Balance_Count from  allotmentDistributor";
                SqlDataAdapter qq1da = new SqlDataAdapter(qq1, con);
                DataTable qq1dt = new DataTable();
                qq1da.Fill(qq1dt);
                int bal = 0;
                if (qq1dt.Rows.Count > 0)
                {
                    bal = Convert.ToInt32(qq1dt.Rows[0]["Balance_Count"]);
                }
                con.Close();

                cal = bal - 1;

                con.Open();
                string qqchk = "update allotmentDistributor set Balance_Count = " + cal + " where uId = " + Convert.ToInt32(Session["distidbal"]) + "  ";
                SqlCommand cccm = new SqlCommand(qqchk, con);
                cccm.ExecuteNonQuery();
                con.Close();


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
                //string mailto = TFM.Email;
                //string Userid = TFM.Identity_proof_Value;
                //mailto = Email;

                //string subject = "Will Assure Link For Payment";
                //string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



                //MailMessage msg = new MailMessage();
                //msg.From = new MailAddress("info@drinco.in");
                //msg.To.Add(mailto);
                //msg.Subject = subject;
                //msg.Body = body;

                //msg.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
                //smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                //smtp.EnableSsl = false;
                //smtp.Send(msg);
                //smtp.Dispose();



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
                ViewBag.msg = "true";
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By + "' , " + distid + " , '" + TFM.Amt_Paid_By + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query3, con);
                cmd2.ExecuteNonQuery();
                con.Close();




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




                // new mail code
                string mailto = Email;
                string Userid = Email;
                mailto = Session["TestatorEmail"].ToString();
                Session["userid"] = Userid;
                string subject1 = "Testing Mail Sending";
                string OTP1 = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
                string text1 = "Your OTP for Verification Is " + OTP1 + "";
                string body1 = "<font color='red'>" + text1 + "</font>";


                MailMessage msg1 = new MailMessage();
                msg1.From = new MailAddress("info@drinco.in");
                msg1.To.Add(mailto);
                msg1.Subject = subject1;
                msg1.Body = body1;

                msg1.IsBodyHtml = true;
                SmtpClient smtp1 = new SmtpClient("216.10.240.149", 25);
                smtp1.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                smtp1.EnableSsl = false;
                smtp1.Send(msg1);
                smtp1.Dispose();



                //end




                // mobile OTP

                //HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("http://167.86.89.78:7412/api/mt/SendSMS?user=rnarvadeempire&password=microlan@123&senderid=RNDEVE&channel=Trans&DCS=0&flashsms=0&number=" + TFM.Mobile + "&text=OTP for Will Assure Verification is : " + TFM.MobileOTP + "+sms&route=1051");
                //HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();
                //System.IO.StreamReader respStreamReader = new System.IO.StreamReader(Resp.GetResponseStream());
                //string responseString = respStreamReader.ReadToEnd();
                //respStreamReader.Close();
                //Resp.Close();






                //END














                //generate Mail
                string mailto2 = Email;
                string userlogin = Email;


                string subject = "Will Assure Login Credentials";

                string text = "<font color='Green' style='font-size=3em;'>Your UserId And Password For Logging In Is <br> UserID : " + userlogin + " <br> Password : " + TFM.userPassword + "</font>";
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



                // update otp for email and mobile

                con.Open();
                string qq = "update TestatorDetails set Contact_Verification = 0 ,Email_Verification = 0 , Mobile_Verification_Status = 0 , Email_OTP = '" + TFM.EmailOTP + "' , Mobile_OTP = '" + TFM.MobileOTP + "' where  tId = " + testatorid + " ";
                SqlCommand cmddd = new SqlCommand(qq, con);
                cmddd.ExecuteNonQuery();
                con.Close();





                //end





                // new mail code
                //string mailto = TFM.Email;
                //string Userid = TFM.Identity_proof_Value;
                //mailto = Email;
                //string subject = "Will Assure Link For Payment";
                //string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



                //MailMessage msg = new MailMessage();
                //msg.From = new MailAddress("info@drinco.in");
                //msg.To.Add(mailto);
                //msg.Subject = subject;
                //msg.Body = body;

                //msg.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
                //smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                //smtp.EnableSsl = false;
                //smtp.Send(msg);
                //smtp.Dispose();



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
                ViewBag.msg = "true";
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query3 = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By + "' , " + distid + " , '" + TFM.Amt_Paid_By + "' , " + testatorid + "  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query3, con);
                cmd2.ExecuteNonQuery();
                con.Close();




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




                // new mail code
                string mailto = Email;
                string Userid = Email;
                mailto = Session["TestatorEmail"].ToString();
                Session["userid"] = Userid;
                string subject1 = "Testing Mail Sending";
                string OTP1 = "<font color='Green' style='font-size=3em;'>" + TFM.EmailOTP + "</font>";
                string text1 = "Your OTP for Verification Is " + OTP1 + "";
                string body1 = "<font color='red'>" + text1 + "</font>";


                MailMessage msg1 = new MailMessage();
                msg1.From = new MailAddress("info@drinco.in");
                msg1.To.Add(mailto);
                msg1.Subject = subject1;
                msg1.Body = body1;

                msg1.IsBodyHtml = true;
                SmtpClient smtp1 = new SmtpClient("216.10.240.149", 25);
                smtp1.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                smtp1.EnableSsl = false;
                smtp1.Send(msg1);
                smtp1.Dispose();



                //end




                // mobile OTP

                //HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("http://167.86.89.78:7412/api/mt/SendSMS?user=rnarvadeempire&password=microlan@123&senderid=RNDEVE&channel=Trans&DCS=0&flashsms=0&number=" + TFM.Mobile + "&text=OTP for Will Assure Verification is : " + TFM.MobileOTP + "+sms&route=1051");
                //HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();
                //System.IO.StreamReader respStreamReader = new System.IO.StreamReader(Resp.GetResponseStream());
                //string responseString = respStreamReader.ReadToEnd();
                //respStreamReader.Close();
                //Resp.Close();






                //END












                //generate Mail
                string mailto2 = Email;
                string userlogin = Email;


                string subject = "Will Assure Login Credentials";

                string text = "<font color='Green' style='font-size=3em;'>Your UserId And Password For Logging In Is <br> UserID : " + userlogin + " <br> Password : " + TFM.userPassword + "</font>";
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



                // update otp for email and mobile

                con.Open();
                string qq = "update TestatorDetails set Contact_Verification = 0 ,Email_Verification = 0 , Mobile_Verification_Status = 0 , Email_OTP = '" + TFM.EmailOTP + "' , Mobile_OTP = '" + TFM.MobileOTP + "' where  tId = " + testatorid + " ";
                SqlCommand cmddd = new SqlCommand(qq, con);
                cmddd.ExecuteNonQuery();
                con.Close();





                //end





                // new mail code
                //string mailto = TFM.Email;
                //string Userid = TFM.Identity_proof_Value;
                //mailto = Email;
                //string subject = "Will Assure Link For Payment";
                //string body = "<font color='Green' style='font-size=3em;'> Click the Link To Make A Payment For The Document :</font> <a href='https://razorpay.com/'>Payment</a> ";



                //MailMessage msg = new MailMessage();
                //msg.From = new MailAddress("info@drinco.in");
                //msg.To.Add(mailto);
                //msg.Subject = subject;
                //msg.Body = body;

                //msg.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
                //smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                //smtp.EnableSsl = false;
                //smtp.Send(msg);
                //smtp.Dispose();



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





            ViewBag.collapse = "true";


            ModelState.Clear();




            //end





            return View("~/Views/Frontend/Document.cshtml");

        }


        public string checkwilldocument()
        {
            int NestId = 0;
            string status = "";
            int getid = Convert.ToInt32(Session["uuid"]);


            con.Open();
            string identifydoc = "select Will from users where Will = 1 and uId = "+ getid + " ";
            SqlDataAdapter da = new SqlDataAdapter(identifydoc,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["Will"]) == 1)
                {


                   
                    string qq26 = "select tId from TestatorDetails where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter daa26 = new SqlDataAdapter(qq26, con);
                    DataTable dtt26 = new DataTable();
                    daa26.Fill(dtt26);
                    if (dtt26.Rows.Count > 0)
                    {
                        NestId = Convert.ToInt32(dtt26.Rows[0]["tId"]);
                    }
                 


                    // check which document is active
                    // for testator family
                   
                    string qchk001 = "select a.fId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Marital_Status , a.Religion , a.Relationship , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.tId , a.active , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Is_Informed_Person from testatorFamily a inner join TestatorDetails b on a.tId=b.tId where b.tId =   " + NestId + " ";
                    SqlDataAdapter chk001da = new SqlDataAdapter(qchk001, con);
                    DataTable chk001dt = new DataTable();
                    chk001da.Fill(chk001dt);
                

                    if (chk001dt.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        status = "false";
                    }
                    //end


                    // for beneficiary
                 
                    string qchk002 = "select a.bpId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_proof , a.Identity_proof_value , a.Alt_Identity_proof , a.Alt_Identity_proof_value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.beneficiary_type from BeneficiaryDetails a inner join TestatorDetails b on a.tId=b.tId where b.tId = " + NestId + "";
                    SqlDataAdapter chk002da = new SqlDataAdapter(qchk002, con);
                    DataTable chk002dt = new DataTable();
                    chk002da.Fill(chk002dt);
                    con.Close();
                    if (chk002dt.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        status = "false";
                    }
                    //end




                    // for assetinformation
                   
                    string qchk003 = "select a.aiid , a.atId , a.amId , a.tid , a.docid , a.Json from AssetInformation a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + NestId + "   ";
                    SqlDataAdapter chk003da = new SqlDataAdapter(qchk003, con);
                    DataTable chk003dt = new DataTable();
                    chk003da.Fill(chk003dt);
                    con.Close();
                    if (chk003dt.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        status = "false";
                    }

                    //end



                    // for liabilities

                   
                    string qchk004 = "select * from Liabilities where tid = " + NestId + "   ";
                    SqlDataAdapter chk004da = new SqlDataAdapter(qchk004, con);
                    DataTable chk004dt = new DataTable();
                    chk004da.Fill(chk004dt);
                    con.Close();

                    if (chk004dt.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        status = "false";
                    }

                    //end




                    // for petcare

                 
                    string qchk005 = "select * from PetCare where tid = " + NestId + "   ";
                    SqlDataAdapter chk005da = new SqlDataAdapter(qchk005, con);
                    DataTable chk005dt = new DataTable();
                    chk005da.Fill(chk005dt);
                    con.Close();

                    if (chk005dt.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        status = "false";
                    }

                    //end





                    // for asset mapping 

                   
                    string qchk006 = "select a.Beneficiary_Asset_ID , a.AssetType_ID , a.AssetCategory_ID , a.SchemeName , a.InstrumentName , a.Beneficiary_ID , a.Proportion , a.tid from BeneficiaryAssets a inner join TestatorDetails b on a.tid=b.tId where b.tId = " + NestId + "";
                    SqlDataAdapter chk006da = new SqlDataAdapter(qchk006, con);
                    DataTable chk006dt = new DataTable();
                    chk006da.Fill(chk006dt);
                    con.Close();

                    if (chk006dt.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        status = "false";
                    }

                    //end






                    // for nominee


                   
                    string qchk007 = " select a.nId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.Relationship , a.Marital_Status , a.Religion , a.Identity_Proof , a.Identity_Proof_Value , a.Alt_Identity_Proof , a.Alt_Identity_Proof_Value , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.aiid , a.tId , a.dateCreated , a.createdBy , a.documentId , a.Description_of_Assets from Nominee a inner join TestatorDetails b on a.tId=b.tId where b.tId = " + NestId + " ";
                    SqlDataAdapter chk007da = new SqlDataAdapter(qchk007, con);
                    DataTable chk007dt = new DataTable();
                    chk007da.Fill(chk007dt);
                    con.Close();

                    if (chk007dt.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        status = "false";
                    }

                    //end





                    // for appointees 

                 
                    string qchk008 = "select * from Appointees where tid = " + NestId + " ";
                    SqlDataAdapter chk008da = new SqlDataAdapter(qchk008, con);
                    DataTable chk008dt = new DataTable();
                    chk008da.Fill(chk008dt);
                    con.Close();

                    if (chk008dt.Rows.Count > 0)
                    {

                    }
                    else
                    {
                        status = "false";
                    }

                    //end






                    //end







                }
            }

            con.Close();




           
            




            return status;
        }



    }
}