using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using WillAssure.Models;

namespace WillAssure.Controllers
{
    public class UpdateDiscountController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateDiscount
        public ActionResult UpdateDiscountIndex(int NestId)
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



            CouponsModel CP = new CouponsModel();


            con.Open();
            string query = "select * from discountCoupons where Id = '" + NestId + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                CP.Id = NestId;
                CP.Coupon_Number = Convert.ToInt32(dt.Rows[0]["Coupon_Number"]);
                CP.Discount_Percentge = Convert.ToInt32(dt.Rows[0]["Discount_Percentge"]);
                CP.Description = dt.Rows[0]["Description"].ToString();
                CP.status = dt.Rows[0]["status"].ToString();



            }



            return View("~/Views/UpdateDiscount/UpdateDiscountPageContent.cshtml", CP);
        }


        public ActionResult UpdateDiscountData(CouponsModel CP)
        {

            if (Session["rId"] == null || Session["uuid"] == null)
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


            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDdiscountpercentage", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@Id", CP.Id);
            cmd.Parameters.AddWithValue("@Coupon_Number", CP.Coupon_Number);
            cmd.Parameters.AddWithValue("@Discount_Percentge", CP.Discount_Percentge);
            cmd.Parameters.AddWithValue("@Description", CP.Description);
            cmd.Parameters.AddWithValue("@status", CP.status);
            cmd.ExecuteNonQuery();
            con.Close();


            ViewBag.Message = "Updated";
            ModelState.Clear();


            return View("~/Views/UpdateDiscount/UpdateDiscountPageContent.cshtml");
        }


    }
}