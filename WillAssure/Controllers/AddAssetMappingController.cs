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
            return View("~/Views/AddAssetMapping/AddAssetMappingPageContent.cshtml");
        }


        public String BindBeneficiaryDDL()
        {
            string data = "<option value='0'>--Select--</option>";
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

                    data = data + "<option value=" + dt1.Rows[i]["aid"] + ">" + dt1.Rows[i]["First_Name"] + "</option>";

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
            AssetMappingModel amm = new AssetMappingModel();
            con.Open();
            string query3 = "select * from AssetsInfo where amId = " + response + " ";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            
            string column = "";
            string control = "<div class='col-sm-3'> <div class='form-group'>";
            string value = "";
            string finalstruct = "";
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i]["DueDate"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["DueDate"].ToString() + "</label>";
                        amm.dueDate = dt3.Rows[i]["DueDate"].ToString();

                    }

                    if (dt3.Rows[i]["DueDateControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["DueDateControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        amm.dueDateControls = dt3.Rows[i]["DueDateControls"].ToString();
                    }


                    if (dt3.Rows[i]["CurrentStatus"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["CurrentStatus"].ToString() + "</label>";
                        amm.CurrentStatus = dt3.Rows[i]["CurrentStatus"].ToString();
                    }

                    if (dt3.Rows[i]["CurrentStatusControls"].ToString() != "")
                    {

                        if (dt3.Rows[i]["CurrentStatusControls"].ToString() == "RadioButton" && dt3.Rows[i]["CurrentStatusValues"].ToString() != "")
                        {

                            string testString = dt3.Rows[i]["CurrentStatusValues"].ToString();
                            ArrayList result = new ArrayList(testString.Split('/'));

                            column = column + " <br> <label class='radio-inline' >  <input type='radio' name='optradio' checked> " + result[0] + "</label>  <label class='radio - inline'> <input type='radio' name='optradio'>" + result[1] + "</label></div></div>";


                        }
                        else
                        {
                            column = column + "<input type=" + dt3.Rows[i]["CurrentStatusControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        }
                        amm.CurrentStatusValues = dt3.Rows[i]["CurrentStatusValues"].ToString();

                    }




                    if (dt3.Rows[i]["IssuedBy"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["IssuedBy"].ToString() + "</label>";
                    }

                    if (dt3.Rows[i]["IssuedByControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["IssuedByControls"].ToString() + " class='form-control' name='inputName' /></div></div>";


                    }



                    if (dt3.Rows[i]["Location"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Location"].ToString() + "</label>";

                    }

                    if (dt3.Rows[i]["LocationControls"].ToString() != "")
                    {
                        if (dt3.Rows[i]["LocationControls"].ToString() == "TextArea")
                        {



                            column = column + "<textarea class='form-control' name='inputName'></textarea></div></div>";


                        }
                        else
                        {
                            column = column + "<input type=" + dt3.Rows[i]["LocationControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        }
                    }



                    if (dt3.Rows[i]["Identifier"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Identifier"].ToString() + "</label>";

                    }

                    if (dt3.Rows[i]["IdentifierControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["IdentifierControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }



                    if (dt3.Rows[i]["assetsValue"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["assetsValue"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["assetsValueControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["assetsValueControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    if (dt3.Rows[i]["CertificateNumber"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["CertificateNumber"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["CertificateNumberControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["CertificateNumberControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    if (dt3.Rows[i]["PropertyDescription"].ToString() != "")
                    {
                        if (dt3.Rows[i]["PropertyDescriptionControls"].ToString() == "DescriptionTypeofItem")
                        {
                            column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["PropertyDescription"].ToString() + "</label>";
                        }
                    }

                    if (dt3.Rows[i]["PropertyDescriptionControls"].ToString() != "")
                    {

                        if (dt3.Rows[i]["PropertyDescriptionControls"].ToString() == "DescriptionTypeofItem")
                        {
                            column = column + "<input type=" + dt3.Rows[i]["PropertyDescriptionControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        }
                        


                    }

                    if (dt3.Rows[i]["Qty"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Qty"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["QtyControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["QtyControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    if (dt3.Rows[i]["Weight"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Weight"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["WeightControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["WeightControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    if (dt3.Rows[i]["OwnerShip"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["OwnerShip"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["OwnerShipControls"].ToString() != "")
                    {
                        if (dt3.Rows[i]["OwnerShipControls"].ToString() == "RadioButton" && dt3.Rows[i]["OwnerShipValues"].ToString() != "")
                        {

                            string testString = dt3.Rows[i]["OwnerShipValues"].ToString();
                            ArrayList result = new ArrayList(testString.Split('/'));

                            column = column + " <br> <label class='radio-inline' >  <input type='radio' name='optradio' checked> " + result[0] + "</label>  <label class='radio - inline'> <input type='radio' name='optradio'>" + result[1] + "</label></div></div>";


                        }
                        else
                        {
                            column = column + "<input type=" + dt3.Rows[i]["OwnerShipControls"].ToString() + " class='form-control' name='inputName'/></div></div>";
                        }



                    }

                    if (dt3.Rows[i]["Remark"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Remark"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["RemarkControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["RemarkControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    if (dt3.Rows[i]["Nomination"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Nomination"].ToString() + "</label>";
                    }


                    if (dt3.Rows[i]["NominationControls"].ToString() != "")
                    {
                        if (dt3.Rows[i]["NominationControls"].ToString() == "RadioButton" && dt3.Rows[i]["NominationValues"].ToString() != "")
                        {

                            string testString = dt3.Rows[i]["NominationValues"].ToString();
                            ArrayList result = new ArrayList(testString.Split('/'));

                            column = column + " <br> <label class='radio-inline' >  <input type='radio' name='optradio' checked> " + result[0] + "</label>  <label class='radio - inline'> <input type='radio' name='optradio'>" + result[1] + "</label></div></div>";


                        }
                        else
                        {
                            column = column + "<input type=" + dt3.Rows[i]["NominationControls"].ToString() + " class='form-control' name='inputName' /> </div></div>";
                        }



                    }

                    if (dt3.Rows[i]["NomineeDetails"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["NomineeDetails"].ToString() + "</label>";
                    }


                    if (dt3.Rows[i]["NomineeDetailsControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["NomineeDetailsControls"].ToString() + " class='form-control'  name='inputName'/> </div></div>";
                    }

                    if (dt3.Rows[i]["Name"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Name"].ToString() + "</label>";


                    }
                    if (dt3.Rows[i]["NameControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["NameControls"].ToString() + " class='form-control' name='inputName'/></div></div>";

                    }

                    if (dt3.Rows[i]["RegisteredAddress"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["RegisteredAddress"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["RegisteredAddressControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["RegisteredAddressControls"].ToString() + " class='form-control' name='inputName'/></div></div>";

                    }

                    if (dt3.Rows[i]["PermanentAddress"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["PermanentAddress"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["PermanentAddressControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["PermanentAddressControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    if (dt3.Rows[i]["Identity_proof"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Identity_proof"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["Identity_proofControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Identity_proofControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    if (dt3.Rows[i]["Identity_proof_value"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Identity_proof_value"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["Identity_proof_valueControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Identity_proof_valueControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    if (dt3.Rows[i]["Alt_Identity_proof"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Alt_Identity_proof"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["Alt_Identity_proofControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Alt_Identity_proofControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    if (dt3.Rows[i]["Alt_Identity_proof_value"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Alt_Identity_proof_value"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["Alt_Identity_proof_valueControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Alt_Identity_proof_valueControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    if (dt3.Rows[i]["Phone"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Phone"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["PhoneControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["PhoneControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    if (dt3.Rows[i]["Mobile"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Mobile"].ToString() + "</label>";



                    }
                    if (dt3.Rows[i]["MobileControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["MobileControls"].ToString() + " class='form-control' name='inputName' /></div></div>";


                    }

                    if (dt3.Rows[i]["Amount"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Amount"].ToString() + "</label>";


                    }
                    if (dt3.Rows[i]["AmountControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["AmountControls"].ToString() + " class='form-control' name='inputName' /></div></div>";

                    }

                    var f = "";
                    string s = "";
                    TempData["amid"] = response;
                    string query = "select * from AssetInformation where amId = "+response+"";
                    SqlDataAdapter da = new SqlDataAdapter(query,con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    string data = "";

                    if (dt.Rows.Count > 0 )
                    {
                        string getjson = dt.Rows[0]["Json"].ToString();
                        MainAssetsModel obj = JsonConvert.DeserializeObject<MainAssetsModel>(getjson);
                        TempData["checkdata"] = getjson;

                        if (obj.dueDate != null)
                        {
                            data = data + obj.dueDate + "~";
                        }
                        if (obj.dueDateControls != null)
                        {
                            data = data + obj.dueDateControls + "~";
                        }
                        if (obj.DueDateValues != null)
                        {
                            data = data + obj.DueDateValues + "~";
                        }




                        if (obj.IssuedBy != null)
                        {
                            data = data + obj.IssuedBy + "~";
                        }
                        if (obj.IssuedByControls != null)
                        {
                            data = data + obj.IssuedByControls + "~";
                        }
                        if (obj.IssuedByValues != null)
                        {
                            data = data + obj.IssuedByValues + "~";
                        }





                        if (obj.Location != null)
                        {
                            data = data + obj.Location + "~";
                        }
                        if (obj.LocationControls != null)
                        {
                            data = data + obj.LocationControls + "~";
                        }
                        if (obj.LocationValues != null)
                        {
                            data = data + obj.LocationValues + "~";
                        }




                        if (obj.Identifier != null)
                        {
                            data = data + obj.Identifier + "~";
                        }
                        if (obj.IdentifierControls != null)
                        {
                            data = data + obj.IdentifierControls + "~";
                        }
                        if (obj.IdentifierValues != null)
                        {
                            data = data + obj.IdentifierValues + "~";
                        }



                        if (obj.assetsValue != null)
                        {
                            data = data + obj.assetsValue + "~";
                        }
                        if (obj.assetsValueControls != null)
                        {
                            data = data + obj.assetsValueControls + "~";
                        }
                        if (obj.assetsValueValues != null)
                        {
                            data = data + obj.assetsValueValues + "~";
                        }





                        if (obj.CertificateNumber != null)
                        {
                            data = data + obj.CertificateNumber + "~";
                        }
                        if (obj.CertificateNumberControls != null)
                        {
                            data = data + obj.CertificateNumberControls + "~";
                        }

                        if (obj.CertificateNumberValues != null)
                        {
                            data = data + obj.CertificateNumberValues + "~";
                        }




                        if (obj.DescriptionTypeofItem != null)
                        {
                            data = data + obj.DescriptionTypeofItem + "~";
                        }
                    




                        if (obj.NumberofItems != null)
                        {
                            data = data + obj.NumberofItems + "~";
                        }
                       




                        if (obj.Weight != null)
                        {
                            data = data + obj.Weight + "~";
                        }
                        if (obj.WeightControls != null)
                        {
                            data = data + obj.WeightControls + "~";
                        }
                        if (obj.WeightValues != null)
                        {
                            data = data + obj.WeightValues + "~";
                        }





                        if (obj.Remark != null)
                        {
                            data = data + obj.Remark + "~";
                        }
                        if (obj.RemarkControls != null)
                        {
                            data = data + obj.RemarkControls + "~";
                        }
                        if (obj.RemarkValues != null)
                        {
                            data = data + obj.RemarkValues + "~";
                        }




                        if (obj.NomineeDetails != null)
                        {
                            data = data + obj.NomineeDetails + "~";
                        }
                        if (obj.NominationControls != null)
                        {
                            data = data + obj.NominationControls + "~";
                        }
                        if (obj.NominationValues != null)
                        {
                            data = data + obj.NominationValues + "~";
                        }




                        if (obj.Name != null)
                        {
                            data = data + obj.Name + "~";
                        }
                        if (obj.NameControls != null)
                        {
                            data = data + obj.NameControls + "~";
                        }
                        if (obj.NameValues != null)
                        {
                            data = data + obj.NameValues + "~";
                        }



                        if (obj.RegisteredAddress != null)
                        {
                            data = data + obj.RegisteredAddress + "~";
                        }

                        if (obj.RegisteredAddressControls != null)
                        {
                            data = data + obj.RegisteredAddressControls + "~";
                        }

                        if (obj.RegisteredAddressValues != null)
                        {
                            data = data + obj.RegisteredAddressValues + "~";
                        }


                        if (obj.PermanentAddress != null)
                        {
                            data = data + obj.PermanentAddress + "~";
                        }
                        if (obj.PermanentAddressControls != null)
                        {
                            data = data + obj.PermanentAddressControls + "~";
                        }
                        if (obj.PermanentAddressValues != null)
                        {
                            data = data + obj.PermanentAddressValues + "~";
                        }




                        if (obj.Identity_proof != null)
                        {
                            data = data + obj.Identity_proof + "~";
                        }
                        if (obj.Identity_proofControls != null)
                        {
                            data = data + obj.Identity_proofControls + "~";
                        }
                        if (obj.Identity_proofValues != null)
                        {
                            data = data + obj.Identity_proofValues + "~";
                        }



                        if (obj.Identity_proof_value != null)
                        {
                            data = data + obj.Identity_proof_value + "~";
                        }
                        if (obj.Identity_proof_valueControls != null)
                        {
                            data = data + obj.Identity_proof_valueControls + "~";
                        }
                        if (obj.Identity_proof_valueValues != null)
                        {
                            data = data + obj.Identity_proof_valueValues + "~";
                        }




                        if (obj.Alt_Identity_proof != null)
                        {
                            data = data + obj.Alt_Identity_proof + "~";
                        }
                        if (obj.Alt_Identity_proofControls != null)
                        {
                            data = data + obj.Alt_Identity_proofControls + "~";
                        }
                        if (obj.Alt_Identity_proof != null)
                        {
                            data = data + obj.Alt_Identity_proof + "~";
                        }





                        if (obj.Alt_Identity_proof_value != null)
                        {
                            data = data + obj.Alt_Identity_proof_value + "~";
                        }
                        if (obj.Alt_Identity_proofControls != null)
                        {
                            data = data + obj.Alt_Identity_proofControls + "~";
                        }
                        if (obj.Alt_Identity_proofValues != null)
                        {
                            data = data + obj.Alt_Identity_proofValues + "~";
                        }





                        if (obj.Phone != null)
                        {
                            data = data + obj.Phone + "~";
                        }
                        if (obj.PhoneControls != null)
                        {
                            data = data + obj.PhoneControls + "~";
                        }
                        if (obj.PhoneValues != null)
                        {
                            data = data + obj.PhoneValues + "~";
                        }



                        if (obj.Mobile != null)
                        {
                            data = data + obj.Mobile + "~";
                        }
                        if (obj.MobileControls != null)
                        {
                            data = data + obj.MobileControls + "~";
                        }
                        if (obj.MobileValues != null)
                        {
                            data = data + obj.MobileValues + "~";
                        }



                        if (obj.Amount != null)
                        {
                            data = data + obj.Amount + "~";
                        }
                        if (obj.AmountControls != null)
                        {
                            data = data + obj.AmountControls + "~";
                        }
                        if (obj.AmountValues != null)
                        {
                            data = data + obj.Amount + "~";
                        }
                        if (obj.Address != null)
                        {
                            data = data + obj.Address + "~";
                        }
                        if (obj.CTSNo != null)
                        {
                            data = data + obj.CTSNo + "~";
                        }

                        f = data;

                        ArrayList fdata = new ArrayList(f.Split('~'));
                        string getnonfinancialinput = "";
                        for (int j = 1; j < fdata.Count; j++)
                        {
                            if (fdata[j].ToString() != "")
                            {
                                TempData["calculate"] =  getnonfinancialinput = getnonfinancialinput + fdata[j].ToString() + "~";
                                s = s + "<input type='text' id='output' class='form-control' value='" + fdata[j].ToString() + "' />";
                            }
                            
                        }


                    }

                 


                    finalstruct = column + s;


                }


            }

            con.Close();



            return finalstruct;
        }


        



        public ActionResult InsertBeneficiaryAsset(FormCollection collection)
        {
          
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
                Response.Write("<script>alert('Number of Item Left is "+ checknumberofitems + " and Number of Weight Left is "+ checkweight + " ')</script>");
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


         


       


           
                

                return View("~/Views/AddAssetMapping/AddAssetMappingPageContent.cshtml");
        }



    }
}