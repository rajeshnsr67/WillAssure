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
using System.Collections;
namespace WillAssure.Controllers
{
    public class UpdateBeneficiaryMappingController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: UpdateBeneficiaryMapping
        public ActionResult UpdateBeneficiaryMappingIndex()
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

            MainAssetsModel MAM = new MainAssetsModel();

            con.Open();
            string query = "select a.Beneficiary_Asset_ID , c.AssetsType , b.AssetsCategory , a.SchemeName , a.InstrumentName , a.Proportion from BeneficiaryAssets a inner join AssetsCategory b on a.AssetCategory_ID=b.amId inner join AssetsType c on b.atId = c.atId inner join TestatorDetails d on a.tid = d.tId";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            


           


            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   MAM.Beneficiary_Asset_ID = Convert.ToInt32(dt.Rows[i]["Beneficiary_Asset_ID"]);
                   MAM.AssetsType = dt.Rows[i]["AssetsType"].ToString();
                   MAM.AssetsCategory = dt.Rows[i]["AssetsCategory"].ToString();
                   MAM.SchemeName = dt.Rows[i]["SchemeName"].ToString();
                   MAM.InstrumentName = dt.Rows[i]["InstrumentName"].ToString();
                   MAM.Proportion = dt.Rows[i]["Proportion"].ToString();
                 

                }





            }





            return View("~/Views/UpdateBeneficiaryMapping/UpdateBeneficiaryMappingPageContent.cshtml", MAM);
        }




        public ActionResult UpdateBeneficiaryMapping(MainAssetsModel MAM)
        {
            con.Open();
            string update = "update BeneficiaryAssets set AssetType_ID = "+MAM.AssetsType+ " , AssetCategory_ID ="+MAM.AssetsCategory+ " , SchemeName = "+MAM.SchemeName+ "  , InstrumentName = "+MAM.InstrumentName+ "  ,Proportion ="+MAM.Proportion+ " where Beneficiary_Asset_ID = "+MAM.Beneficiary_Asset_ID+" ";
            SqlCommand cmd = new SqlCommand(update,con);
            cmd.ExecuteNonQuery();

            con.Close();



            return View("~/Views/UpdateBeneficiaryMapping/UpdateBeneficiaryMappingPageContent.cshtml");
        }



        public String BindAssetTypeDDL()
        {

            con.Open();
            string query = "select * from AssetsType";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["atId"].ToString() + " >" + dt.Rows[i]["AssetsType"].ToString() + "</option> ";



                }



            }

            return data;

        }

        public string bindassetcatDDL()
        {
            int response = Convert.ToInt32(Request["send"]);
            string ddlassetcat = "<option value=''>--Select--</option>";
            con.Open();
            string query3 = "select * from AssetsCategory where atId = " + response + " ";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Close();


            if (dt3.Rows.Count > 0)
            {

                for (int i = 0; i < dt3.Rows.Count; i++)
                {

                    ddlassetcat = ddlassetcat + "<option value=" + dt3.Rows[i]["amId"] + "  onchange='getassetcatid(this.value)'  >" + dt3.Rows[i]["AssetsCategory"] + "</option>";

                }

            }

            return ddlassetcat;
        }



    }
}