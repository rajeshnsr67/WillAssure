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
using Newtonsoft.Json;

namespace WillAssure.Controllers
{
    public class EditMainAssetsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: EditMainAssets
        public ActionResult EditMainAssetsIndex()
        {
            return View("~/Views/EditMainAssets/EditMainAssetsPageContent.cshtml");
        }



        public string BindMappedFormData()
        {
       
            string final = "";
            con.Open();
            string query = "select b.aiid , a.AssetsType , c.AssetsCategory , b.Json from AssetsType a inner join  AssetInformation b on a.atId = b.atId inner join AssetsCategory  c on b.amId = c.amId order by b.aiid asc";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string getjson = dt.Rows[i]["Json"].ToString();


                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                foreach (var kv in dict)
                {
                    final = final + "<td>" + kv.Key + ":" + kv.Value + "</td>";
                }

                data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                data += "<td>" + final + "</td>";
                data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button>  </td></tr>";

            }










        
    

            return data;
        }



        public string DeleteMappedRecords(RoleFormModel RFM)
        {
            string final = "";
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            string query1 = "delete from AssetInformation where aiid = "+index+" ";
            SqlCommand cmd = new SqlCommand(query1,con);
            cmd.ExecuteNonQuery();
            con.Close();


            string query = "select b.aiid , a.AssetsType , c.AssetsCategory , b.Json from AssetsType a inner join  AssetInformation b on a.atId = b.atId inner join AssetsCategory  c on b.amId = c.amId order by b.aiid asc";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string getjson = dt.Rows[i]["Json"].ToString();


                var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                foreach (var kv in dict)
                {
                    final = final + "<td>" + kv.Key + ":" + kv.Value + "</td>";
                }

                data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiid"].ToString() + "</td>";
                data += "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";
                data += "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>";
                data += "<td>" + final + "</td>";
                data += "<td><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["aiid"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button>  </td></tr>";

            }

            return data;
        }





        public int UpdateMappedData()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }
    }
}