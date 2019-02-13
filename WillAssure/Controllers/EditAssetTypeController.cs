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
    public class EditAssetTypeController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: EditAssetType
        public ActionResult EditAssetTypeIndex()
        {
            return View("~/Views/EditAssetType/EditAssetTypePageContent.cshtml");
        }

        public string BindAssetTypeFormData()
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
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["atid"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"
                              
                                + "<td><button type='button'   id='" + dt.Rows[i]["atid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["atid"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";

                }
            }

            return data;
        }



        public string DeleteAssetTypeRecords(AssetTypeModel ATM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AssetsTypeCRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@atid", index); 
            cmd.Parameters.AddWithValue("@assettype", "");

            cmd.ExecuteNonQuery();
            con.Close();


            con.Open();
            string query = "select * from BeneficiaryDetails";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["bpId"].ToString() + "</td>"
                               + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
                             
                               + "<td><button type='button'   id='" + dt.Rows[i]["bpId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["bpId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";


                }
            }
            Response.Write("<script>alert('Your Records Have Been Deleted...!')</script>");
            return data;
        }




        public int UpdateAssetTypeForm()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }


    }
}