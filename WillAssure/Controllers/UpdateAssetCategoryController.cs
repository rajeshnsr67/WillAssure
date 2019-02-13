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



        public ActionResult UpdatingAssetTypes(AssetTypeModel ATM)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_Roles", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@atId ", ATM.atId);
            cmd.Parameters.AddWithValue("@AssetsType ", ATM.AssetsType);
            cmd.ExecuteNonQuery();
            con.Close();


            return View("~/Views/UpdateAssetType/UpdateAssetTypePageContent.cshtml");
        }


    }
}