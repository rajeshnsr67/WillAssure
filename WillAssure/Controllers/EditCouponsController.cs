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
    public class EditCouponsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditCoupons
        public ActionResult EditCouponsIndex()
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
            return View("~/Views/EditCoupons/EditCouponsPageContent.cshtml");
        }



        public string BindCouponsFormData()
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



            con.Open();
            string query = "select * from discountCoupons";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["Id"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Coupon_Number"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Discount_Percentge"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Description"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["status"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt.Rows[i]["Id"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";
                    }
                }


                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["id"].ToString() + "</td>"
                          + "<td>" + dt.Rows[i]["Coupon_Number"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Discount_Percentge"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Description"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["status"].ToString() + "</td>"
                        + "<td><button type='button'   id=" + dt.Rows[i]["Id"].ToString() + "    class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }
                }



                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["id"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["Coupon_Number"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Discount_Percentge"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Description"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["status"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt.Rows[i]["Id"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id=" + dt.Rows[i]["Id"].ToString() + "     class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }

                }



                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                          + "<td>" + dt.Rows[i]["Coupon_Number"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Discount_Percentge"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Description"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["status"].ToString() + "</td>";

                    }



                }





            }

            return data;
        }



        public string DeleteCouponsDataRecords(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDdiscountpercentage", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@id", index);
            cmd.Parameters.AddWithValue("@Coupon_Number", "");
            cmd.Parameters.AddWithValue("@Discount_Percentge", "");
            cmd.Parameters.AddWithValue("@Description", "");
            cmd.Parameters.AddWithValue("@status", "");
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
            string query = "select * from discountCoupons";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["Id"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Coupon_Number"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Discount_Percentge"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Description"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["status"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt.Rows[i]["Id"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";
                    }
                }


                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["id"].ToString() + "</td>"
                          + "<td>" + dt.Rows[i]["Coupon_Number"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Discount_Percentge"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Description"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["status"].ToString() + "</td>"
                        + "<td><button type='button'   id=" + dt.Rows[i]["Id"].ToString() + "    class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }
                }



                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["id"].ToString() + "</td>"
                         + "<td>" + dt.Rows[i]["Coupon_Number"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Discount_Percentge"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Description"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["status"].ToString() + "</td>"
                        + "<td> <button type='button'   id='" + dt.Rows[i]["Id"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id=" + dt.Rows[i]["Id"].ToString() + "     class='btn btn-danger deletenotification'>Delete</button></td></tr>";
                    }

                }



                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["rId"].ToString() + "</td>"
                          + "<td>" + dt.Rows[i]["Coupon_Number"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Discount_Percentge"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["Description"].ToString() + "</td>"
                        + "<td>" + dt.Rows[i]["status"].ToString() + "</td>";

                    }



                }





            }

            return data;
        }





        public int UpdateCoupons()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }
    }
}