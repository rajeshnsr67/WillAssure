using System.Linq;
using System.Web;
using System.Web.Mvc;
using WillAssure.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System;

namespace WillAssure.Controllers
{
    public class AssetTypeController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: AssetType
        public ActionResult AssetTypeIndex()
        {
            if (Session.SessionID == null)
            {

                return RedirectToAction("LoginPageIndex", "LoginPage");

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
            return View("~/Views/AssetType/AddAssetTypePageContent.cshtml");
        }


        public ActionResult InsertAssetFormData(AssetTypeModel ATM)
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


            //main Roles

            con.Open();
            string query1 = "select count(*) from assetstype  where AssetsType = '" + ATM.AssetsType + "'";
            SqlCommand cmd2 = new SqlCommand(query1, con);
            int count = (int)cmd2.ExecuteScalar();
            con.Close();
            if (count > 0)
            {
                ViewBag.Message = "Duplicate";
            }
           
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_AssetsTypeCRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@assettype", ATM.AssetsType);

                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                string query = "select top 1 * from AssetsType order by atId desc";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string i = dt.Rows[0]["atId"].ToString();

                    Session["atId"] = i;
                }


                con.Close();


                ViewBag.Message = "Verified";
            }

            ModelState.Clear();


            return View("~/Views/AssetType/AddAssetTypePageContent.cshtml");
        }



      
    }
}