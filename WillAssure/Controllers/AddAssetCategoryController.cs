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
    public class AddAssetCategoryController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: AddAssetCategory
        public ActionResult AddAssetCategoryIndex()
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
            return View("~/Views/AddAssetCategory/AddAssetCategoryPageContent.cshtml");
        }


        public ActionResult InsertAssetCategoryFormData(AssetCategoryModel ACM)
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
            string query1 = "select count(*) from assetscategory  where AssetsCategory = '" + ACM.assetcategory + "' and assetsCode = '"+ ACM.assetcode + "'";
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
                SqlCommand cmd = new SqlCommand("SP_AssetsCategoryCRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@atid", ACM.assettypeid);
                cmd.Parameters.AddWithValue("@assetcategory", ACM.assetcategory);
                cmd.Parameters.AddWithValue("@assetcode", ACM.assetcode);
                cmd.ExecuteNonQuery();
                con.Close();


                con.Open();
                string query = "select top 1 * from AssetsCategory order by amId desc";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (Session["amId"] == null)
                {
                    RedirectToAction("LoginPageIndex", "LoginPage");
                }
                if (dt.Rows.Count > 0)
                {
                    string i = dt.Rows[0]["atId"].ToString();
                    string j = dt.Rows[0]["assetsCode"].ToString();
                    Session["assetCodes"] = j;
                    Session["amId"] = i;
                }


                con.Close();
                ModelState.Clear();
                ViewBag.Message = "Verified";

            }










           

            return View("~/Views/AddAssetCategory/AddAssetCategoryPageContent.cshtml");
        }


        public String BindAssetTypeDDL()
        {

            con.Open();
            string query = "select * from AssetsType";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["atId"].ToString() + " >" + dt.Rows[i]["AssetsType"].ToString() + "</option> ";



                }



            }

            return data;

        }



    }
}