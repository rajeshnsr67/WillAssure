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
    public class AddMainAssetsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddMainAssets
        public ActionResult AddMainAssetsIndex()
        {
            return View("~/Views/AddMainAssets/AddMainAssetsPageContent.cshtml");
        }

        public string BindAssetColumn()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AssetColumns", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {







                data = data + "<option value='0'>--Select--</option><option value='1' >" + dt.Rows[0]["DueDate"].ToString() + "</option>" +
                data + "<option value='2' >" + dt.Rows[0]["CurrentStatus"].ToString() + "</option>" +
                data + "<option value='3' >" + dt.Rows[0]["IssuedBy"].ToString() + "</option>" +
                data + "<option value='4' >" + dt.Rows[0]["Location"].ToString() + "</option>" +
                data + "<option value='5' >" + dt.Rows[0]["Identifier"].ToString() + "</option>" +
                data + "<option value='6' >" + dt.Rows[0]["assetsValue"].ToString() + "</option>" +
                data + "<option value='7' >" + dt.Rows[0]["CertificateNumber"].ToString() + "</option>" +
                data + "<option value='8' >" + dt.Rows[0]["PropertyDescription"].ToString() + "</option>" +
                data + "<option value='9' >" + dt.Rows[0]["Qty"].ToString() + "</option>" +
                data + "<option value='10' >" + dt.Rows[0]["Weight"].ToString() + "</option>" +
                data + "<option value='11' >" + dt.Rows[0]["OwnerShip"].ToString() + "</option>" +
                data + "<option value='12' >" + dt.Rows[0]["Remark"].ToString() + "</option>" +
                data + "<option value='13' >" + dt.Rows[0]["Nomination"].ToString() + "</option>" +
                data + "<option value='14' >" + dt.Rows[0]["NomineeDetails"].ToString() + "</option>" +
                data + "<option value='15' >" + dt.Rows[0]["Name"].ToString() + "</option>" +
                data + "<option value='16' >" + dt.Rows[0]["RegisteredAddress"].ToString() + "</option>" +
                data + "<option value='17' >" + dt.Rows[0]["PermanentAddress"].ToString() + "</option>" +
                data + "<option value='18' >" + dt.Rows[0]["Identity_proof"].ToString() + "</option>" +
                data + "<option value='19' >" + dt.Rows[0]["Identity_proof_value"].ToString() + "</option>" +
                data + "<option value='20' >" + dt.Rows[0]["Alt_Identity_proof"].ToString() + "</option>" +
                data + "<option value='21' >" + dt.Rows[0]["Alt_Identity_proof_value"].ToString() + "</option>" +
                data + "<option value='22' >" + dt.Rows[0]["Phone"].ToString() + "</option>" +
                data + "<option value='23' >" + dt.Rows[0]["Mobile"].ToString() + "</option>" +
                data + "<option value='24' >" + dt.Rows[0]["Amount"].ToString() + "</option>";







            }

            return data;
        }




        public string GenerateColumns()
        {
            string final = "";

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AssetColumns", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {







                data = data + "<option value='0'>--Select--</option><option value='1' >" + dt.Rows[0]["DueDate"].ToString() + "</option>" +
                data + "<option value='2' >" + dt.Rows[0]["CurrentStatus"].ToString() + "</option>" +
                data + "<option value='3' >" + dt.Rows[0]["IssuedBy"].ToString() + "</option>" +
                data + "<option value='4' >" + dt.Rows[0]["Location"].ToString() + "</option>" +
                data + "<option value='5' >" + dt.Rows[0]["Identifier"].ToString() + "</option>" +
                data + "<option value='6' >" + dt.Rows[0]["assetsValue"].ToString() + "</option>" +
                data + "<option value='7' >" + dt.Rows[0]["CertificateNumber"].ToString() + "</option>" +
                data + "<option value='8' >" + dt.Rows[0]["PropertyDescription"].ToString() + "</option>" +
                data + "<option value='9' >" + dt.Rows[0]["Qty"].ToString() + "</option>" +
                data + "<option value='10' >" + dt.Rows[0]["Weight"].ToString() + "</option>" +
                data + "<option value='11' >" + dt.Rows[0]["OwnerShip"].ToString() + "</option>" +
                data + "<option value='12' >" + dt.Rows[0]["Remark"].ToString() + "</option>" +
                data + "<option value='13' >" + dt.Rows[0]["Nomination"].ToString() + "</option>" +
                data + "<option value='14' >" + dt.Rows[0]["NomineeDetails"].ToString() + "</option>" +
                data + "<option value='15' >" + dt.Rows[0]["Name"].ToString() + "</option>" +
                data + "<option value='16' >" + dt.Rows[0]["RegisteredAddress"].ToString() + "</option>" +
                data + "<option value='17' >" + dt.Rows[0]["PermanentAddress"].ToString() + "</option>" +
                data + "<option value='18' >" + dt.Rows[0]["Identity_proof"].ToString() + "</option>" +
                data + "<option value='19' >" + dt.Rows[0]["Identity_proof_value"].ToString() + "</option>" +
                data + "<option value='20' >" + dt.Rows[0]["Alt_Identity_proof"].ToString() + "</option>" +
                data + "<option value='21' >" + dt.Rows[0]["Alt_Identity_proof_value"].ToString() + "</option>" +
                data + "<option value='22' >" + dt.Rows[0]["Phone"].ToString() + "</option>" +
                data + "<option value='23' >" + dt.Rows[0]["Mobile"].ToString() + "</option>" +
                data + "<option value='24' >" + dt.Rows[0]["Amount"].ToString() + "</option>";







            }





            con.Open();
            string query = "select * from AssetsCategory";
            SqlDataAdapter da2 = new SqlDataAdapter(query, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            con.Close();
            string data2 = "";

            if (dt2.Rows.Count > 0)
            {







                for (int i = 0; i < dt2.Rows.Count; i++)
                {




                    data2 = data2 + "<option value=" + dt2.Rows[i]["amId"].ToString() + " >" + dt2.Rows[i]["AssetsCategory"].ToString() + "</option>";



                }







            }







            final = "<div class='col-sm-4'><div class='form-group'><label for='input-1'>Asset Category</label><select id='ddlasset' class='form-control'  onChange='getassetcat(this.value)'><option value='0' >--Select--</option>" + data2 + "</select></div></div>           <div class='col-sm-4'><div class='form-group'><label for='input-1'>Select Asset</label><select id='ddlasset' class='form-control'  onChange='getassetcolumntext(this.options[this.selectedIndex].innerHTML)'><option value='0' >--Select--</option>" + data + "</select></div></div>   <div class='col-sm-4'><div class='form-group'><label for='input-1'>Values</label><input type='text' class='form-control'  onchange=bar2(this.value)  placeholder='Enter Value For Your Asset'/></div></div>";




            return final;
        }

        public String BindAssetCategoryDDL()
        {

            con.Open();
            string query = "select * from AssetsCategory";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value='0' >--Select--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["amId"].ToString() + " >" + dt.Rows[i]["AssetsCategory"].ToString() + "</option>";



                }




            }

            return data;

        }


        public ActionResult InsertMainAssetFormData(MainAssetsModel MAM)
        {
            int acid = MAM.assetcatid;
            string cv = MAM.column.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
            string column = cv.Substring(0, cv.Length - 1);

            string vv = MAM.text.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
            string value = vv.Substring(0, vv.Length - 1);



            return View("~/Views/AddMainAssets/AddMainAssetsPageContent.cshtml");
        }




    }
}