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
using System.Collections;

namespace WillAssure.Controllers
{
    public class UpdateMainAssetsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateMainAssets
        public ActionResult UpdateMainAssetsIndex(int NestId)
        {
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
            MainAssetsModel mam = new MainAssetsModel();
            mam.aiid = NestId;
            return View("~/Views/UpdateMainAssets/UpdateMainAssetsPageContent.cshtml", mam);
        }


        public ActionResult UpdatingMainAsset(RoleFormModel RFM)
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


            ViewBag.Message = "Verified";
            return View("~/Views/UpdateMainAssets/UpdateMainAssetsPageContent.cshtml");
        }

        public string getdynamicfields()
        {
            string response = Request["send"].ToString();
            string structure = "";

            if (response != "")
            {
                con.Open();
                string query = "select b.aiid , a.AssetsType , c.AssetsCategory , b.Json from AssetsType a inner join  AssetInformation b on a.atId = b.atId inner join AssetsCategory  c on b.amId = c.amId  where b.aiid = " + response + " order by b.aiid asc  ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {




                        structure = structure + "<div class='col-sm-6'>  <label>Assets Type</label>       <input type='text' class='form-control' value=" + dt.Rows[i]["AssetsType"].ToString() + " />     </div>";
                        structure = structure + "<div class='col-sm-6'>  <label>Category Type</label>   <input type='text' class='form-control' value=" + dt.Rows[i]["AssetsCategory"].ToString() + " /> </div>";
                        string getjson = dt.Rows[i]["Json"].ToString();

                        var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);

                        foreach (var kv in dict)
                        {
                            var k = kv.Key;
                            ArrayList va = new ArrayList(k.Split('~'));
                            for (int j = 0; j < va.Count; j++)
                            {
                                if (va.ToString() != "")
                                {


                                    structure = structure + "<div class='col-sm-6'>  <label>" + va[i].ToString() + "</label>  <input type='text' class='form-control' value=" + kv.Value + " />   </div>  ";
                                    break;
                                }
                            }


                            
                        }
                    }



                }
            }
            

            


            return structure;
        }


    }
}