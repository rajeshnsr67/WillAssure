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
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WillAssure.Controllers
{
    public class AddAssetMappingController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddAssetMapping
        public ActionResult AddAssetMappingIndex()
        {
            if (Session.SessionID == null)
            {

                return RedirectToAction("LoginPageIndex", "LoginPage");

            }
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
            return View("~/Views/AddAssetMapping/AddAssetMappingPageContent.cshtml");
        }


        public String BindBeneficiaryDDL()
        {
            string data = "<option value='0'>--Select--</option>";
            con.Open();
            string query1 = "select aiid, bpId , First_Name from BeneficiaryDetails";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();


            if (dt1.Rows.Count > 0)
            {

                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    data = data + "<option value=" + dt1.Rows[i]["aiid"] + ">" + dt1.Rows[i]["First_Name"] + "</option>";

                }

            }
            return data;

        }



        public String BindAssetTypeDDL()
        {

            con.Open();
            string query = "select * from AssetsType";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value='0'>--Select--</option>";

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
            string ddlassetcat = "<option value='0'>--Select--</option>";
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











        public string getassetcolumndata()
        {
            int response = Convert.ToInt32(Request["send"]);








            con.Open();
            string query3 = "select * from AssetInformation";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt = new DataTable();
            da3.Fill(dt);
            con.Close();

            string property = "";
            string structure = "";
            string Identifier = "";
            string ddlscheme = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string getjson = dt.Rows[i]["Json"].ToString();
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                    foreach (var item in dict)
                    {
                        string testString = item.Key;
                        ArrayList result = new ArrayList(testString.Split('~'));


                        if (result[0].ToString() == "PropertyDescription")
                        {
                            property = result[1].ToString();
                            if (property == "Scheme")
                            {

                                ddlscheme = ddlscheme + "<option value=" + item.Value + " >" + item.Value + "</option>";
                            }

                        }


                        if (result[0].ToString() == "Identifier")
                        {
                            Identifier = result[1].ToString();

                            ddlscheme = ddlscheme + "<option value=" + item.Value + " >" + item.Value + "</option>";
                        }





                    }
                }





                structure = "<label>Scheme</label><select class='form-control schemenameclass' id='schemename1'  onchange=getschemename(this.id)><option value='0'>--Select--</option>" + ddlscheme + "</select>";





                // structure = structure + data;
                //structure = structure + "<div class='col-sm-4'><div class='form-group'>   <label for='input-1'>Instruments</label> <input type='text' class='form-control' placeholder='MF Scheme' />     </div></div>";
                //structure = structure + "<div class='col-sm-4'><div class='form-group'>   <label for='input-1'>Proportion</label> <input type='text' class='form-control' />     </div></div>";
            }




            return structure;
        }






        public ActionResult InsertBeneficiaryAsset(FormCollection collection)
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



            int Beneficiaryid = 0;
            int AssetId = 0;
            int assetcatid = 0;
            int checknumberofitems = 0;
            int checkweight = 0;
            string getcheckdata = TempData["checkdata"].ToString();


            AssetMappingModel saveasset = new AssetMappingModel();





            ArrayList cheknum = new ArrayList(TempData["calculate"].ToString().Split('~'));

            for (int i = 0; i < cheknum.Count; i++)
            {
                checknumberofitems = Convert.ToInt32(cheknum[0]);
                checkweight = Convert.ToInt32(cheknum[1]);

            }




            string value = Convert.ToString(collection["inputName"]);
            string ddllist = collection["contentList"];

            ArrayList result = new ArrayList(value.Split(','));
            ArrayList dd = new ArrayList(ddllist.Split(','));

            for (int i = 0; i < result.Count; i++)
            {
                saveasset.NumberofItems = Convert.ToInt32(result[0]);
                saveasset.weight = Convert.ToInt32(result[1]);

            }


            for (int i = 0; i < dd.Count; i++)
            {
                Beneficiaryid = Convert.ToInt32(dd[0]);
                AssetId = Convert.ToInt32(dd[1]);
                assetcatid = Convert.ToInt32(dd[2]);
            }

            var radio1 = Convert.ToString(Request.Form["Currentradio"]);
            var radio2 = Convert.ToString(Request.Form["ownershipRadio"]);
            var radio3 = Convert.ToString(Request.Form["nominationradio"]);

            if (saveasset.NumberofItems >= checknumberofitems && saveasset.weight >= checkweight)
            {
                Response.Write("<script>alert('Number of Item Left is " + checknumberofitems + " and Number of Weight Left is " + checkweight + " ')</script>");
            }
            else
            {
                // insert beneficiary asset
                string insertbenefijson = JsonConvert.SerializeObject(saveasset, Newtonsoft.Json.Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                con.Open();
                string inserbeneficiaryasset = "insert into Beneficiary_AssetInfo (bpId,atId,amId,Json) values (" + Beneficiaryid + "," + AssetId + "," + assetcatid + ",'" + insertbenefijson + "')";
                SqlCommand cmd = new SqlCommand(inserbeneficiaryasset, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //end




                con.Open();
                string query = "select * from AssetInformation where amId = " + TempData["amid"] + "";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string data = "";

                if (dt.Rows.Count > 0)
                {
                    string getjson = dt.Rows[0]["Json"].ToString();
                    MainAssetsModel upobj = JsonConvert.DeserializeObject<MainAssetsModel>(getjson);
                    TempData["checkdata"] = getjson;

                    string getcolumn = "";

                    if (upobj.dueDate != null)
                    {
                        getcolumn = getcolumn + upobj.dueDate + "~";
                    }






                    if (upobj.IssuedBy != null)
                    {
                        upobj.IssuedBy = upobj.IssuedBy;
                    }







                    if (upobj.Location != null)
                    {
                        upobj.Location = upobj.Location;
                    }






                    if (upobj.Identifier != null)
                    {
                        upobj.Identifier = upobj.Identifier;
                    }





                    if (upobj.assetsValue != null)
                    {
                        upobj.assetsValue = upobj.assetsValue;
                    }







                    if (upobj.CertificateNumber != null)
                    {
                        upobj.CertificateNumber = upobj.CertificateNumber;
                    }






                    if (upobj.DescriptionTypeofItem != null)
                    {
                        upobj.DescriptionTypeofItem = upobj.DescriptionTypeofItem;
                    }





                    if (upobj.NumberofItems != null)
                    {
                        int cal = Convert.ToInt32(upobj.NumberofItems) - Convert.ToInt32(saveasset.NumberofItems);
                        upobj.NumberofItems = cal.ToString();
                    }





                    if (upobj.Weight != null)
                    {


                        int cal = Convert.ToInt32(upobj.Weight) - Convert.ToInt32(saveasset.weight);
                        upobj.Weight = cal.ToString();
                    }









                    if (upobj.Remark != null)
                    {
                        upobj.Remark = upobj.Remark;
                    }
                    if (upobj.RemarkControls != null)
                    {
                        upobj.RemarkControls = "";
                    }





                    if (upobj.NomineeDetails != null)
                    {
                        upobj.NomineeDetails = upobj.NomineeDetails;
                    }
                    if (upobj.NominationControls != null)
                    {
                        upobj.NominationControls = "";
                    }





                    if (upobj.Name != null)
                    {
                        upobj.Name = upobj.Name;
                    }
                    if (upobj.NameControls != null)
                    {
                        upobj.NameControls = "";
                    }




                    if (upobj.RegisteredAddress != null)
                    {
                        upobj.RegisteredAddress = upobj.RegisteredAddress;
                    }

                    if (upobj.RegisteredAddressControls != null)
                    {
                        upobj.RegisteredAddressControls = "";
                    }




                    if (upobj.PermanentAddress != null)
                    {
                        upobj.PermanentAddress = upobj.PermanentAddress;
                    }
                    if (upobj.PermanentAddressControls != null)
                    {
                        upobj.PermanentAddressControls = "";
                    }





                    if (upobj.Identity_proof != null)
                    {
                        upobj.Identity_proof = upobj.Identity_proof;
                    }
                    if (upobj.Identity_proofControls != null)
                    {
                        upobj.Identity_proofControls = "";
                    }




                    if (upobj.Identity_proof_value != null)
                    {
                        upobj.Identity_proof_value = upobj.Identity_proof_value;
                    }
                    if (upobj.Identity_proof_valueControls != null)
                    {
                        upobj.Identity_proof_valueControls = "";
                    }





                    if (upobj.Alt_Identity_proof != null)
                    {
                        upobj.Alt_Identity_proof = upobj.Alt_Identity_proof;
                    }
                    if (upobj.Alt_Identity_proofControls != null)
                    {
                        upobj.Alt_Identity_proofControls = "";
                    }






                    if (upobj.Alt_Identity_proof_value != null)
                    {
                        upobj.Alt_Identity_proof_value = upobj.Alt_Identity_proof_value;
                    }
                    if (upobj.Alt_Identity_proofControls != null)
                    {
                        upobj.Alt_Identity_proofControls = "";
                    }






                    if (upobj.Phone != null)
                    {
                        upobj.Phone = upobj.Phone;
                    }
                    if (upobj.PhoneControls != null)
                    {
                        upobj.PhoneControls = "";
                    }




                    if (upobj.Mobile != null)
                    {
                        upobj.Mobile = upobj.Mobile;
                    }
                    if (upobj.MobileControls != null)
                    {
                        upobj.MobileControls = "";
                    }




                    if (upobj.Amount != null)
                    {
                        upobj.Amount = upobj.Amount;
                    }
                    if (upobj.AmountControls != null)
                    {
                        upobj.AmountControls = "";
                    }

                    if (upobj.Address != null)
                    {
                        upobj.Address = "";
                    }
                    if (upobj.CTSNo != null)
                    {
                        upobj.CTSNo = "";
                    }
                    con.Close();
                    string upjson = JsonConvert.SerializeObject(upobj, Newtonsoft.Json.Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    con.Open();
                    string updateassetinfo = "update AssetInformation set Json='" + upjson + "' where amId = " + TempData["amid"] + " ";
                    SqlCommand cm2 = new SqlCommand(updateassetinfo, con);
                    cm2.ExecuteNonQuery();
                    con.Close();
                }
            }








            ModelState.Clear();


            return View("~/Views/AddAssetMapping/AddAssetMappingPageContent.cshtml");
        }



        public string ddlassetname()
        {
            int response = Convert.ToInt32(Request["send"]);

            string bindddlname = "<option value='0'>--Select--</option>";
            con.Open();
            string query1 = "select aiid , Json from AssetInformation";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();

            if (dt1.Rows.Count > 0)
            {

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string getjson = dt1.Rows[i]["Json"].ToString();
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                    foreach (var item in dict)
                    {
                        string testString = item.Key;
                        ArrayList result = new ArrayList(testString.Split('~'));


                        if (result[0].ToString() == "IssuedBy")
                        {

                            bindddlname = bindddlname + "   <option value=" + item.Value + ">" + item.Value + "</option>    ";


                        }

                        if (result[0].ToString() == "Identifier")
                        {

                            bindddlname = bindddlname + "   <option value=" + item.Value + ">" + item.Value + "</option>    ";


                        }


                    }



                }



            }


            return bindddlname;
        }



        public ActionResult InsertSingleAssetMappeddata()
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


            string response = Request["send"];
            string assettype = response.Split('~')[0];
            string assetcat = response.Split('~')[1];
            string beneficiary = response.Split('~')[2];
            string schemename = response.Split('~')[3];
            string instrument = response.Split('~')[4];
            string proportion = response.Split('~')[5];


            con.Open();
            string query = "insert into BeneficiaryAssets (AssetType_ID , AssetCategory_ID ,  Beneficiary_ID , SchemeName , InstrumentName , Proportion , tid ) values   (" + assettype + " , " + assetcat + " , " + beneficiary + " , '" + schemename + "' , '" + instrument + "' , '" + proportion + "' , " + Convert.ToInt32(Session["tid"]) + ") ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            ModelState.Clear();
            return View("~/Views/AddAssetMapping/AddAssetMappingPageContent.cshtml");
        }



        public ActionResult InsertMultipleAssetMappeddata(string data, string assettype, string assetcat)
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


            string response = data;
            string filter = response.Replace(" ", string.Empty).Replace("\n", string.Empty);
            ArrayList result = new ArrayList(filter.Split('~'));

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].ToString() != "")
                {
                    con.Open();
                    result[i].ToString();
                    string query = "insert into BeneficiaryAssets (AssetType_ID,AssetCategory_ID,Beneficiary_ID,SchemeName,InstrumentName,Proportion , tid) values (" + assettype+","+assetcat+","+ result[i].ToString() + "," + Convert.ToInt32(Session["tid"]) + ")";
                    SqlCommand cmd = new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }


            con.Open();



            con.Close();
            ModelState.Clear();
            return View("~/Views/AddAssetMapping/AddAssetMappingPageContent.cshtml");
        }





        public string Filterdata()
        {
            int response = Convert.ToInt32(Request["send"]);

            string data = "<option value='0'>--Select--</option>";
            con.Open();
            string query1 = "select aiid, bpId , First_Name from BeneficiaryDetails where  bpId not in ("+ response + ")";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();


            if (dt1.Rows.Count > 0)
            {

                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    data = data + "<option value=" + dt1.Rows[i]["aiid"] + ">" + dt1.Rows[i]["First_Name"] + "</option>";

                }

            }
            return data;
        }




    }
}