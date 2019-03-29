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
    public class UpdateAssetCategoryController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateAssetCategory
        public ActionResult UpdateAssetCategoryIndex(int NestId)
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
            AssetCategoryModel ATM = new AssetCategoryModel();


            con.Open();
            string query = "select * from AssetsCategory where amId = '" + NestId + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                ATM.amid = NestId;
                ATM.assetcategory = dt.Rows[0]["AssetsCategory"].ToString();
                ATM.assetcode = dt.Rows[0]["assetscode"].ToString();



            }



            return View("~/Views/UpdateAssetCategory/UpdateAssetCategoryPageContent.cshtml",ATM);
        }



        public ActionResult UpdatingAssetTypes(AssetCategoryModel ACM)
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

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AssetsCategoryCRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@amId", ACM.amid);
            cmd.Parameters.AddWithValue("@assetcategory", ACM.assetcategory);
            cmd.Parameters.AddWithValue("@assetcode", ACM.assetcode);
            cmd.Parameters.AddWithValue("@atid", "");
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.Message = "Verified"; 
            return View("~/Views/UpdateAssetCategory/UpdateAssetCategoryPageContent.cshtml");
        }


    }
}