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
    public class EditUserFormController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        public ActionResult EditUserFormIndex()
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

            return View("~/Views/EditUserForm/EditUserFormPageContent.cshtml");
        }


        public string BindUserForm()
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

            string testString = "";
            string willemployee = "";
            string distributoremployee = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[11].Action;
                willemployee = Lmlist[10].Action;
                distributoremployee = Lmlist[12].Action;

            }


            con.Open();
            string query = "select a.uId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.eMail , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.userID , a.userPwd , a.Linked_user , a.Designation , b.Role , a.dateCreated , a.active , a.compId from users a inner join Roles b on a.rId=b.rId where a.Linked_user = "+Convert.ToInt32(Session["uuid"])+ " and a.Type = 'DistributorAdmin'   ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            string Role = "";
            string a = "";
            if (dt.Rows.Count > 0)
            {

             
                    if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                        }
                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                          + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }
                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }

                    }


                    if (testString == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                        + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>";



                        }
                    }
                

                








                //// for distributor employee

                //if (Convert.ToInt32(Session["rId"]) == 2)
                //{
                //    if (distributoremployee == "1,2,0" || distributoremployee == "0,2,0" || distributoremployee == "0,2,3" || distributoremployee == "0,2,3" || distributoremployee == "0,2,0")
                //    {
                //        for (int i = 0; i < dt.Rows.Count; i++)
                //        {
                //            string Status= dt.Rows[i]["active"].ToString();



                //            if (Status == "Active")
                //            {
                //                a = "Active";
                //            }
                //            else
                //            {
                //                a = "InActive";
                //            }




                //            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                //                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                //                        + "<td>" + a + "</td>"
                //                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"

                //                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                //        }
                //    }

                //    if (distributoremployee == "1,0,3" || distributoremployee == "0,0,3" || distributoremployee == "0,2,3" || distributoremployee == "1,0,3" || distributoremployee == "0,0,3")
                //    {
                //        for (int i = 0; i < dt.Rows.Count; i++)
                //        {
                //            string Status= dt.Rows[i]["active"].ToString();



                //            if (Status == "Active")
                //            {
                //                a = "Active";
                //            }
                //            else
                //            {
                //                a = "InActive";
                //            }




                //            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                //                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                //                        + "<td>" + a + "</td>"
                //                          + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                //                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                //        }
                //    }


                //    if (distributoremployee == "1,2,3" || distributoremployee == "0,2,3")
                //    {
                //        for (int i = 0; i < dt.Rows.Count; i++)
                //        {
                //            string Status= dt.Rows[i]["active"].ToString();



                //            if (Status == "Active")
                //            {
                //                a = "Active";
                //            }
                //            else
                //            {
                //                a = "InActive";
                //            }




                //            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                //                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                //                        + "<td>" + a + "</td>"
                //                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                //                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                //        }

                //    }


                //    if (distributoremployee == "0,0,0")
                //    {
                //        for (int i = 0; i < dt.Rows.Count; i++)
                //        {
                //            string Status= dt.Rows[i]["active"].ToString();



                //            if (Status == "Active")
                //            {
                //                a = "Active";
                //            }
                //            else
                //            {
                //                a = "InActive";
                //            }




                //            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                //                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                //                        + "<td>" + a + "</td>"
                //                        + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>";



                //        }
                //    }

                //}



                ////end






                ////for will assure employee

                //if (Convert.ToInt32(Session["rId"]) == 3)
                //{
                //    if (willemployee == "1,2,0" || willemployee == "0,2,0" || willemployee == "0,2,3" || willemployee == "0,2,3" || willemployee == "0,2,0")
                //    {
                //        for (int i = 0; i < dt.Rows.Count; i++)
                //        {
                //            string Status= dt.Rows[i]["active"].ToString();



                //            if (Status == "Active")
                //            {
                //                a = "Active";
                //            }
                //            else
                //            {
                //                a = "InActive";
                //            }




                //            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                //                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                //                        + "<td>" + a + "</td>"
                //                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"

                //                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                //        }
                //    }

                //    if (willemployee == "1,0,3" || willemployee == "0,0,3" || willemployee == "0,2,3" || willemployee == "1,0,3" || willemployee == "0,0,3")
                //    {
                //        for (int i = 0; i < dt.Rows.Count; i++)
                //        {
                //            string Status= dt.Rows[i]["active"].ToString();



                //            if (Status == "Active")
                //            {
                //                a = "Active";
                //            }
                //            else
                //            {
                //                a = "InActive";
                //            }




                //            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                //                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                //                        + "<td>" + a + "</td>"
                //                          + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                //                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                //        }
                //    }


                //    if (willemployee == "1,2,3" || willemployee == "0,2,3")
                //    {
                //        for (int i = 0; i < dt.Rows.Count; i++)
                //        {
                //            string Status= dt.Rows[i]["active"].ToString();



                //            if (Status == "Active")
                //            {
                //                a = "Active";
                //            }
                //            else
                //            {
                //                a = "InActive";
                //            }




                //            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                //                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                //                        + "<td>" + a + "</td>"
                //                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                //                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                //        }

                //    }


                //    if (willemployee == "0,0,0")
                //    {
                //        for (int i = 0; i < dt.Rows.Count; i++)
                //        {
                //            string Status= dt.Rows[i]["active"].ToString();



                //            if (Status == "Active")
                //            {
                //                a = "Active";
                //            }
                //            else
                //            {
                //                a = "InActive";
                //            }




                //            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                //                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                //                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                //                        + "<td>" + a + "</td>"
                //                        + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>";



                //        }
                //    }
                //}







                ////end

        







            }

                    return data;
        }



        public string DeleteEditFormRecords()
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
            SqlCommand cmd = new SqlCommand("SP_Users", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@uid", index);
            cmd.Parameters.AddWithValue("@FirstName", "");
            cmd.Parameters.AddWithValue("@LastName","");
            cmd.Parameters.AddWithValue("@MiddleName","");
            cmd.Parameters.AddWithValue("@Dob","");
            cmd.Parameters.AddWithValue("@Mobile", "");
            cmd.Parameters.AddWithValue("@Email", "");
            cmd.Parameters.AddWithValue("@Address1", "");
            cmd.Parameters.AddWithValue("@Address2","");
            cmd.Parameters.AddWithValue("@Address3", "");
            cmd.Parameters.AddWithValue("@City","");
            cmd.Parameters.AddWithValue("@State ", "");
            cmd.Parameters.AddWithValue("@Pin", "");
            cmd.Parameters.AddWithValue("@UserId","");
            cmd.Parameters.AddWithValue("@UserPassword", "");
           
            cmd.Parameters.AddWithValue("@Designation", "");
            cmd.Parameters.AddWithValue("@Active", "");
            cmd.Parameters.AddWithValue("@compId", "");
            cmd.Parameters.AddWithValue("@Linked_user", "");
            cmd.Parameters.AddWithValue("@rid", "");
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
            string willemployee = "";
            string distributoremployee = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[10].Action;
                willemployee = Lmlist[9].Action;
                distributoremployee = Lmlist[11].Action;

            }


            con.Open();
            string query = "select a.uId , a.First_Name , a.Last_Name , a.Middle_Name , a.DOB , a.Mobile , a.eMail , a.Address1 , a.Address2 , a.Address3 , a.City , a.State , a.Pin , a.userID , a.userPwd , a.Linked_user , a.Designation , b.Role , a.dateCreated , a.active , a.compId from users a inner join Roles b on a.rId=b.rId where a.Linked_user = " + Convert.ToInt32(Session["uuid"]) + " and a.Type = 'DistributorAdmin'    ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
            string Role = "";
            string a = "";
            if (dt.Rows.Count > 0)
            {

                if (Convert.ToInt32(Session["rId"]) == 1)
                {
                    if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                        }
                    }

                    if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                          + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }
                    }


                    if (testString == "1,2,3" || testString == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }

                    }


                    if (testString == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                        + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>";



                        }
                    }
                }










                // for distributor employee

                if (Convert.ToInt32(Session["rId"]) == 2)
                {
                    if (distributoremployee == "1,2,0" || distributoremployee == "0,2,0" || distributoremployee == "0,2,3" || distributoremployee == "0,2,3" || distributoremployee == "0,2,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                        }
                    }

                    if (distributoremployee == "1,0,3" || distributoremployee == "0,0,3" || distributoremployee == "0,2,3" || distributoremployee == "1,0,3" || distributoremployee == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                          + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }
                    }


                    if (distributoremployee == "1,2,3" || distributoremployee == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }

                    }


                    if (distributoremployee == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                        + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>";



                        }
                    }

                }



                //end






                //for will assure employee

                if (Convert.ToInt32(Session["rId"]) == 3)
                {
                    if (willemployee == "1,2,0" || willemployee == "0,2,0" || willemployee == "0,2,3" || willemployee == "0,2,3" || willemployee == "0,2,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"

                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                        }
                    }

                    if (willemployee == "1,0,3" || willemployee == "0,0,3" || willemployee == "0,2,3" || willemployee == "1,0,3" || willemployee == "0,0,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                          + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }
                    }


                    if (willemployee == "1,2,3" || willemployee == "0,2,3")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                         + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>"
                                        + "<td><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["uId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                        }

                    }


                    if (willemployee == "0,0,0")
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string Status= dt.Rows[i]["active"].ToString();



                            if (Status == "Active")
                            {
                                a = "Active";
                            }
                            else
                            {
                                a = "InActive";
                            }




                            data = data + "<tr class='nr'><td>" + dt.Rows[i]["uId"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Last_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Middle_Name"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["DOB"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["eMail"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Address3"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userID"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["userPwd"].ToString() + "</td>"

                                        + "<td>" + dt.Rows[i]["Designation"].ToString() + "</td>"
                                        + "<td>" + dt.Rows[i]["Role"].ToString() + "</td>"
                                        + "<td>" + a + "</td>"
                                        + "<td>" + Convert.ToInt32(dt.Rows[i]["compId"]) + "</td>";



                        }
                    }
                }







                //end









            }

            return data;
        }




        public int UpdateEditForm()
        {
            int index = Convert.ToInt32(Request["send"]);
            if (Session["upcompanyid"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }
            con.Open();
            string query = "select compId from users where uid = " + index + "";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int compid = 0;
            if (dt.Rows.Count > 0)
            {

               
                    compid = Convert.ToInt32(dt.Rows[0]["compId"]);
                    Session["upcompanyid"] = compid;
                   
                


            }

            con.Close();


            return index;
        }







    }
}