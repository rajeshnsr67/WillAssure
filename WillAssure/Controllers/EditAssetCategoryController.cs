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
    public class EditAssetCategoryController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditAssetCategory
        public ActionResult EditAssetCategoryIndex()
        {
            return View("~/Views/EditAssetCategory/EditAssetCategoryPageContent.cshtml");
        }

        public string BindAssetCategoryFormData()
        {
            con.Open();
            string query = "select * from AssetsCategory";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["amId"].ToString() + "</td>"
                               
                                + "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["assetsCode"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button></td>    </tr>";

                }
            }

            return data;
        }



        public string DeleteAssetCategoryData(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AssetsCategoryCRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@amId", index);
            cmd.Parameters.AddWithValue("@atid", "");
            cmd.Parameters.AddWithValue("@assetcategory", "");
            cmd.Parameters.AddWithValue("@assetcode", "");

            cmd.ExecuteNonQuery();
            con.Close();




            con.Open();
            string query = "select * from AssetsCategory";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["amId"].ToString() + "</td>"

                              + "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>"
                              + "<td>" + dt.Rows[i]["assetsCode"].ToString() + "</td>"
                              + "<td><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button></td>    </tr>";

                }
            }

            return data;
        }





        public int UpdateAssetCategoryData()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }


    }
}