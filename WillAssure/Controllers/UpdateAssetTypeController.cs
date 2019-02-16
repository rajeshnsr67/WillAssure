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
    public class UpdateAssetTypeController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: UpdateAssetType
        public ActionResult UpdateAssetTypeIndex(int NestId)
        {

            AssetTypeModel ATM = new AssetTypeModel();


            con.Open();
            string query = "select * from AssetsType where atId = '" + NestId + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                ATM.atId = NestId;
                ATM.AssetsType = dt.Rows[0]["AssetsType"].ToString();




            }



            return View("~/Views/UpdateAssetType/UpdateAssetTypePageContent.cshtml", ATM);
        }


        public ActionResult UpdatingAssetTypes(AssetTypeModel ATM)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AssetsTypeCRUD", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@atId ", ATM.atId);
            cmd.Parameters.AddWithValue("@assettype ", ATM.AssetsType);
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.Message = "Verified";
            return View("~/Views/UpdateAssetType/UpdateAssetTypePageContent.cshtml");
        }
    }
}