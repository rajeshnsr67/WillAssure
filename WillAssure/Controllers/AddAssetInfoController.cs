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
    public class AddAssetInfoController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddAssetInfo
        public ActionResult AddAssetInfoIndex()
        {
            if (Session["rId"] == null || Session["uuid"] == null)
            {

               RedirectToAction("LoginPageIndex", "LoginPage");

            }


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
                ViewBag.showtitle = "true";
                ViewBag.documentlink = "true";

            }


            return View("~/Views/AddAssetInfo/AddAssetInfoPageContent.cshtml");
        }

        public ActionResult AddAssetInfoData(AssetsModel AM)
        {

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
                ViewBag.showtitle = "true";
                ViewBag.documentlink = "true";

            }


            if (Session["amId"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

            if (Session["amId"] != null)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_AssetsInfoCRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@amId", Session["amId"]);
                cmd.Parameters.AddWithValue("@assetsCode", AM.assetsCode);
                cmd.Parameters.AddWithValue("@DueDate", AM.dueDate);
                cmd.Parameters.AddWithValue("@CurrentStatus", AM.CurrentStatus);
                cmd.Parameters.AddWithValue("@IssuedBy", AM.IssuedBy);
                cmd.Parameters.AddWithValue("@Location", AM.Location);
                cmd.Parameters.AddWithValue("@Identifier", AM.Identifier);
                cmd.Parameters.AddWithValue("@assetsValue", AM.assetsValue);
                cmd.Parameters.AddWithValue("@CertificateNumber", AM.CertificateNumber);
                cmd.Parameters.AddWithValue("@PropertyDescription", AM.PropertyDescription);
                cmd.Parameters.AddWithValue("@Qty", AM.Qty);
                cmd.Parameters.AddWithValue("@Weight", AM.Weight);
                cmd.Parameters.AddWithValue("@OwnerShip", AM.OwnerShip);
                cmd.Parameters.AddWithValue("@Remark", AM.Remark);
                cmd.Parameters.AddWithValue("@Nomination", AM.Nomination);
                cmd.Parameters.AddWithValue("@NomineeDetails", AM.NomineeDetails);
                cmd.Parameters.AddWithValue("@Name", AM.Name);
                cmd.Parameters.AddWithValue("@RegisteredAddress", AM.RegisteredAddress);
                cmd.Parameters.AddWithValue("@PermanentAddress", AM.PermanentAddress);
                cmd.Parameters.AddWithValue("@Identity_proof", AM.Identity_proof);
                cmd.Parameters.AddWithValue("@Identity_proof_value", AM.Identity_proof_value);
                cmd.Parameters.AddWithValue("@Alt_Identity_proof", AM.Alt_Identity_proof);
                cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.Alt_Identity_proof_value);
                cmd.Parameters.AddWithValue("@Phone", AM.Phone);
                cmd.Parameters.AddWithValue("@Mobile", AM.Mobile);
                cmd.Parameters.AddWithValue("@Amount", AM.Amount);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            else
            {
                Response.Write("<script>alert('Add Asset Category First')</script>");
            }


           


            return View("~/Views/AddAssetInfo/AddAssetInfoPageContent.cshtml");
        }


    }
}