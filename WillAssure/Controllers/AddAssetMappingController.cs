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
using System.Web.Script.Serialization;

namespace WillAssure.Controllers
{
    public class AddAssetMappingController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddAssetMapping
        public ActionResult AddAssetMappingIndex()
        {
            return View("~/Views/AddAssetMapping/AddAssetMappingPageContent.cshtml");
        }


        public string GenerateColumn()
        {
            string ddlbeneficiary = "";
            string ddlassettype = "";
            string ddlassetcat = "";
            string final="";
          


            con.Open();
            string query1 = "select aid, bpId , First_Name from BeneficiaryDetails";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();


            if (dt1.Rows.Count > 0)
            {

                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    ddlbeneficiary = ddlbeneficiary + "<option value=" + dt1.Rows[i]["aid"] + ">" + dt1.Rows[i]["First_Name"] + "</option>";

                }

            }




            con.Open();
            string query2 = "select * from AssetsType";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();


            if (dt2.Rows.Count > 0)
            {

                for (int i = 0; i < dt2.Rows.Count; i++)
                {

                    ddlassettype = ddlassettype + "<option value=" + dt2.Rows[i]["atId"] + ">" + dt2.Rows[i]["AssetsType"] + "</option>";

                }

            }



            con.Open();
            string query3 = "select * from AssetsCategory";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Close();


            if (dt3.Rows.Count > 0)
            {

                for (int i = 0; i < dt3.Rows.Count; i++)
                {

                    ddlassetcat = ddlassetcat + "<option value=" + dt3.Rows[i]["amId"] + ">" + dt3.Rows[i]["AssetsCategory"] + "</option>";

                }

            }




            final = "<div class='col-sm-3'> <div class='form-group'> <label for='input-1'>Beneficiary</label> <select id='ddlcity' class='form-control'>  <option value='0'>--Select Beneficiary--</option> "+ddlbeneficiary+"</select> </div></div>";
            final +="<div class='col-sm-3'> <div class='form-group'> <label for='input-1'>Assets</label> <select id='ddlcity' class='form-control'>  <option value='0'>--Select Assets--</option> "+ddlassettype+"  </select> </div></div>";
            final +="<div class='col-sm-3'> <div class='form-group'> <label for='input-1'>Assets</label> <select id='ddlcity' class='form-control'>  <option value='0'>--Select Assets--</option> "+ddlassetcat + "  </select> </div></div>";
            final +="<div class='col-sm-3'> <div class='form-group'> <label for='input-1'>Values</label> <input type='text' class='form-control'  /></div></div>";


            return final;
        }


    }
}