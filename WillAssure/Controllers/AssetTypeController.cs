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
    public class AssetTypeController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: AssetType
        public ActionResult AssetTypeIndex()
        {
            return View("~/Views/AssetType/AddAssetTypePageContent.cshtml");
        }


        public ActionResult InsertAssetFormData(AssetTypeModel ATM)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AssetsTypeCRUD",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "insert");
            cmd.Parameters.AddWithValue("@assettype", ATM.AssetsType);
            
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            string query = "select top 1 * from AssetsType order by atId desc";
            
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                string i = dt.Rows[0]["atId"].ToString();
                Session["amId"] = "";
                Session["assetsCode"] = "";
                Session["atId"] = "";
                Session["atId"] = i;
            }


            con.Close();


            ViewBag.Message = "Verified";

            return View("~/Views/AssetType/AddAssetTypePageContent.cshtml");
        }



      
    }
}