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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WillAssure.Controllers
{
    public class AddMainAssetsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        string json = "";
        // GET: AddMainAssets
        public ActionResult AddMainAssetsIndex()
        {
            return View("~/Views/AddMainAssets/AddMainAssetsPageContent.cshtml");
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







            final = "<div class='col-sm-4'><div class='form-group'><label for='input-1'>Select Asset</label><select id='ddlasset' class='form-control'  onChange='getassetcat(this.value)'><option value='0' >--Select--</option>" + data2 + "</select></div></div>            <div class='col-sm-4'><div class='form-group'><label for='input-1'>Select Asset</label><select id='ddlasset' class='form-control'  onChange='getassetcolumntext(this.options[this.selectedIndex].innerHTML)'><option value='0' >--Select--</option>" + data + "</select></div></div>   <div class='col-sm-4'><div class='form-group'><label for='input-1'>Values</label><input type='text' class='form-control'  onchange=bar2(this.value)  placeholder='Enter Value For Your Asset'/></div></div>";




            return final;
        }

        public String BindAssetCategoryDDL()
        {
            int response = Convert.ToInt32(Request["send"]);
            con.Open();
            string query = "select * from AssetsCategory where atId = "+ response + "";
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


        public string  OnChangeDDLCat()
        {
            int response = Convert.ToInt32(Request["send"]);
            TempData["amid"] = response;
            con.Open();
            string query = "select * from AssetsInfo where amId = "+response+" ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt3 = new DataTable();
            da.Fill(dt3);
            con.Close();
            string data = "";
            string column = "";
            string finalstruct = "";
            MainAssetsModel MAM = new MainAssetsModel();
            if (dt3.Rows.Count > 0)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i]["DueDate"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl1' >" + dt3.Rows[i]["DueDate"].ToString() + "</label>";
                        MAM.dueDate = dt3.Rows[i]["DueDate"].ToString();

                    }

                    if (dt3.Rows[i]["DueDateControls"].ToString() != "")
                    {
                     
                        column = column + "<input type=" + dt3.Rows[i]["DueDateControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.dueDateControls = dt3.Rows[i]["DueDateControls"].ToString();
                    }


                    if (dt3.Rows[i]["CurrentStatus"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl2' >" + dt3.Rows[i]["CurrentStatus"].ToString() + "</label>";
                        MAM.CurrentStatus = dt3.Rows[i]["CurrentStatus"].ToString();
                    }

                    if (dt3.Rows[i]["CurrentStatusControls"].ToString() != "")
                    {

                        if (dt3.Rows[i]["CurrentStatusControls"].ToString() == "RadioButton" && dt3.Rows[i]["CurrentStatusValues"].ToString() != "")
                        {

                            string testString = dt3.Rows[i]["CurrentStatusValues"].ToString();
                            ArrayList result = new ArrayList(testString.Split('/'));

                            column = column + " <br> <label class='radio-inline' >  <input type='radio' name='Currentradio' value="+ result[0]+" checked> " + result[0]+ "</label>  <label class='radio - inline'> <input type='radio' name='Currentradio'  value=" + result[1] + ">" + result[1]+ "</label></div></div>";
                           

                        }
                      
                        MAM.CurrentStatusValues = dt3.Rows[i]["CurrentStatusValues"].ToString();

                    }




                    if (dt3.Rows[i]["IssuedBy"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl3' >" + dt3.Rows[i]["IssuedBy"].ToString() + "</label>";
                        MAM.IssuedBy = dt3.Rows[i]["IssuedBy"].ToString();
                    }

                    if (dt3.Rows[i]["IssuedByControls"].ToString() != "")
                    {
                       
                        column = column + "<input type=" + dt3.Rows[i]["IssuedByControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.column = dt3.Rows[i]["IssuedByControls"].ToString();

                    }



                    if (dt3.Rows[i]["Location"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl4' >" + dt3.Rows[i]["Location"].ToString() + "</label>";
                        MAM.Location = dt3.Rows[i]["Location"].ToString();
                    }

                    if (dt3.Rows[i]["LocationControls"].ToString() != "")
                    {
                        if (dt3.Rows[i]["LocationControls"].ToString() == "TextArea")
                        {

                            

                            column = column + "<textarea class='form-control' name='inputName'></textarea></div></div>";
                         

                        }
                        else
                        {
                            column = column + "<input type=" + dt3.Rows[i]["LocationControls"].ToString() + " class='form-control' /></div></div>";
                            
                        }
                        MAM.LocationControls = dt3.Rows[i]["LocationControls"].ToString();
                    }



                    if (dt3.Rows[i]["Identifier"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl5'>" + dt3.Rows[i]["Identifier"].ToString() + "</label>";
                        MAM.Identifier = dt3.Rows[i]["Identifier"].ToString();
                    }

                    if (dt3.Rows[i]["IdentifierControls"].ToString() != "")
                    {
                      
                        column = column + "<input type=" + dt3.Rows[i]["IdentifierControls"].ToString() + " class='form-control' name='inputName'/></div></div>";
                        MAM.IdentifierControls = dt3.Rows[i]["IdentifierControls"].ToString();
                    }



                    if (dt3.Rows[i]["assetsValue"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl6'>" + dt3.Rows[i]["assetsValue"].ToString() + "</label>";
                        MAM.assetsValue = dt3.Rows[i]["assetsValue"].ToString();
                    }
                    if (dt3.Rows[i]["assetsValueControls"].ToString() != "")
                    {
                        
                        column = column + "<input type=" + dt3.Rows[i]["assetsValueControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.assetsValueControls = dt3.Rows[i]["assetsValueControls"].ToString();
                    }

                    if (dt3.Rows[i]["CertificateNumber"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl7'>" + dt3.Rows[i]["CertificateNumber"].ToString() + "</label>";
                        MAM.CertificateNumber = dt3.Rows[i]["CertificateNumber"].ToString();
                    }
                    if (dt3.Rows[i]["CertificateNumberControls"].ToString() != "")
                    {
                    
                        column = column + "<input type=" + dt3.Rows[i]["CertificateNumberControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.CertificateNumberControls = dt3.Rows[i]["CertificateNumberControls"].ToString();
                    }

                    if (dt3.Rows[i]["PropertyDescription"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl8'>" + dt3.Rows[i]["PropertyDescription"].ToString() + "</label>";
                        MAM.PropertyDescription = dt3.Rows[i]["PropertyDescription"].ToString();
                    }

                    if (dt3.Rows[i]["PropertyDescriptionControls"].ToString() != "")
                    {
                      
                        column = column + "<input type=" + dt3.Rows[i]["PropertyDescriptionControls"].ToString() + " class='form-control' name='inputName'/></div></div>";
                        MAM.PropertyDescriptionControls = dt3.Rows[i]["PropertyDescriptionControls"].ToString();

                    }

                    if (dt3.Rows[i]["Qty"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl9' >" + dt3.Rows[i]["Qty"].ToString() + "</label>";
                        MAM.Qty = dt3.Rows[i]["Qty"].ToString();
                    }
                    if (dt3.Rows[i]["QtyControls"].ToString() != "")
                    {
                     
                        column = column + "<input type=" + dt3.Rows[i]["QtyControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.QtyControls = dt3.Rows[i]["QtyControls"].ToString();
                    }

                    if (dt3.Rows[i]["Weight"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl10'>" + dt3.Rows[i]["Weight"].ToString() + "</label>";
                        MAM.Weight = dt3.Rows[i]["Weight"].ToString();
                    }
                    if (dt3.Rows[i]["WeightControls"].ToString() != "")
                    {
                       
                        column = column + "<input type=" + dt3.Rows[i]["WeightControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.WeightControls = dt3.Rows[i]["WeightControls"].ToString();
                    }

                    if (dt3.Rows[i]["OwnerShip"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl11' >" + dt3.Rows[i]["OwnerShip"].ToString() + "</label>";
                        MAM.OwnerShip = dt3.Rows[i]["OwnerShip"].ToString();
                    }
                    if (dt3.Rows[i]["OwnerShipControls"].ToString() != "")
                    {
                        if (dt3.Rows[i]["OwnerShipControls"].ToString() == "RadioButton" && dt3.Rows[i]["OwnerShipValues"].ToString() != "")
                        {

                            string testString = dt3.Rows[i]["OwnerShipValues"].ToString();
                            ArrayList result = new ArrayList(testString.Split('/'));

                            column = column + " <br> <label class='radio-inline' >  <input type='radio' name='ownershipRadio' value="+ result[0] + " checked> " + result[0] + "</label>  <label class='radio - inline'> <input type='radio' name='ownershipRadio' value="+ result[1] + ">" + result[1] + "</label></div></div>";


                        }
                       
                        MAM.OwnerShipValues = dt3.Rows[i]["OwnerShipValues"].ToString();


                    }
                   
                    if (dt3.Rows[i]["Remark"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl12'>" + dt3.Rows[i]["Remark"].ToString() + "</label>";
                        MAM.Remark = dt3.Rows[i]["Remark"].ToString();
                    }
                    if (dt3.Rows[i]["RemarkControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["RemarkControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.RemarkControls = dt3.Rows[i]["RemarkControls"].ToString();
                    }
                
                    if (dt3.Rows[i]["Nomination"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl13' >" + dt3.Rows[i]["Nomination"].ToString() + "</label>";
                        MAM.Nomination = dt3.Rows[i]["Nomination"].ToString();
                    }


                    if (dt3.Rows[i]["NominationControls"].ToString() != "")
                    {
                        if (dt3.Rows[i]["NominationControls"].ToString() == "RadioButton" && dt3.Rows[i]["NominationValues"].ToString() != "")
                        {

                            string testString = dt3.Rows[i]["NominationValues"].ToString();
                            ArrayList result = new ArrayList(testString.Split('/'));

                            column = column + " <br> <label class='radio-inline' >  <input type='radio' name='nominationradio' value=" + result[0] + " checked> " + result[0] + "</label>  <label class='radio - inline'> <input type='radio' name='nominationradio' value=" + result[1] + ">" + result[1] + "</label></div></div>";



                        }
                        else
                        {
                            column = column + "<input type=" + dt3.Rows[i]["NominationControls"].ToString() + " name='inputName' class='form-control' /> </div></div>";
                        }

                        MAM.NominationControls = dt3.Rows[i]["NominationControls"].ToString();

                    }
                  
                    if (dt3.Rows[i]["NomineeDetails"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl14' >" + dt3.Rows[i]["NomineeDetails"].ToString() + "</label>";
                        MAM.NomineeDetails = dt3.Rows[i]["NomineeDetails"].ToString();
                    }


                    if (dt3.Rows[i]["NomineeDetailsControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["NomineeDetailsControls"].ToString() + " class='form-control' name='inputName' /> </div></div>";
                        MAM.NomineeDetailsControls = dt3.Rows[i]["NomineeDetailsControls"].ToString();
                    }
       
                    if (dt3.Rows[i]["Name"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1'  id='lbl15'>" + dt3.Rows[i]["Name"].ToString() + "</label>";
                        MAM.Name = dt3.Rows[i]["Name"].ToString();

                    }
                    if (dt3.Rows[i]["NameControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["NameControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.NameControls = dt3.Rows[i]["NameControls"].ToString();
                    }
                   
                    if (dt3.Rows[i]["RegisteredAddress"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl16' >" + dt3.Rows[i]["RegisteredAddress"].ToString() + "</label>";
                        MAM.RegisteredAddress = dt3.Rows[i]["RegisteredAddress"].ToString();
                    }
                    if (dt3.Rows[i]["RegisteredAddressControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["RegisteredAddressControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.RegisteredAddressControls = dt3.Rows[i]["RegisteredAddressControls"].ToString();
                    }
                 
                    if (dt3.Rows[i]["PermanentAddress"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl17' >" + dt3.Rows[i]["PermanentAddress"].ToString() + "</label>";
                        MAM.PermanentAddress = dt3.Rows[i]["PermanentAddress"].ToString();
                    }
                    if (dt3.Rows[i]["PermanentAddressControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["PermanentAddressControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.PermanentAddressControls = dt3.Rows[i]["PermanentAddressControls"].ToString();
                    }
                  
                    if (dt3.Rows[i]["Identity_proof"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1'  id='lbl18>" + dt3.Rows[i]["Identity_proof"].ToString() + "</label>";
                        MAM.Identity_proof = dt3.Rows[i]["Identity_proof"].ToString();
                    }
                    if (dt3.Rows[i]["Identity_proofControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Identity_proofControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.Identity_proofControls = dt3.Rows[i]["Identity_proofControls"].ToString();
                    }
            
                    if (dt3.Rows[i]["Identity_proof_value"].ToString() != "")
                    { 
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1'  id='lbl19'>" + dt3.Rows[i]["Identity_proof_value"].ToString() + "</label>";
                        MAM.Identity_proof_value = dt3.Rows[i]["Identity_proof_value"].ToString();
                    }
                    if (dt3.Rows[i]["Identity_proof_valueControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Identity_proof_valueControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.Identity_proof_valueControls = dt3.Rows[i]["Identity_proof_valueControls"].ToString();
                    }
                  
                    if (dt3.Rows[i]["Alt_Identity_proof"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1'  id='lbl20'>" + dt3.Rows[i]["Alt_Identity_proof"].ToString() + "</label>";
                        MAM.Alt_Identity_proof = dt3.Rows[i]["Alt_Identity_proof"].ToString();
                    }
                    if (dt3.Rows[i]["Alt_Identity_proofControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Alt_Identity_proofControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.Alt_Identity_proofControls = dt3.Rows[i]["Alt_Identity_proofControls"].ToString();
                    }
                 
                    if (dt3.Rows[i]["Alt_Identity_proof_value"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl21' >" + dt3.Rows[i]["Alt_Identity_proof_value"].ToString() + "</label>";
                        MAM.Alt_Identity_proof_value = dt3.Rows[i]["Alt_Identity_proof_value"].ToString();
                    }
                    if (dt3.Rows[i]["Alt_Identity_proof_valueControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Alt_Identity_proof_valueControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.Alt_Identity_proof_valueControls = dt3.Rows[i]["Alt_Identity_proof_valueControls"].ToString();
                    }
           
                    if (dt3.Rows[i]["Phone"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl22' >" + dt3.Rows[i]["Phone"].ToString() + "</label>";
                        MAM.Phone = dt3.Rows[i]["Phone"].ToString();
                    }
                    if (dt3.Rows[i]["PhoneControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["PhoneControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.PhoneControls = dt3.Rows[i]["PhoneControls"].ToString();
                    }
                   
                    if (dt3.Rows[i]["Mobile"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl23' >" + dt3.Rows[i]["Mobile"].ToString() + "</label>";
                        MAM.Mobile = dt3.Rows[i]["Mobile"].ToString();


                    }
                    if (dt3.Rows[i]["MobileControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["MobileControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.MobileControls = dt3.Rows[i]["MobileControls"].ToString();

                    }

                    if (dt3.Rows[i]["Amount"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' id='lbl24'>" + dt3.Rows[i]["Amount"].ToString() + "</label>";
                        MAM.Amount = dt3.Rows[i]["Amount"].ToString();

                    }
                    if (dt3.Rows[i]["AmountControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["AmountControls"].ToString() + " class='form-control' name='inputName' /></div></div>";
                        MAM.AmountControls = dt3.Rows[i]["AmountControls"].ToString();
                    }

                    json = JsonConvert.SerializeObject(MAM);
                    TempData["mydata"] = json;
                    finalstruct = column;


                }


            }

            return finalstruct;

        }



        [HttpPost]
        public ActionResult InsertMainAsset(FormCollection collection)
        {
            // string response = Convert.ToString(Request["send"]);
            MainAssetsModel MAM = new MainAssetsModel();
            MainAssetsModel JSON = new MainAssetsModel();
            List<MainAssetsModel> assetlist = new List<MainAssetsModel>(); 
            string data = TempData["mydata"].ToString();
            MainAssetsModel obj = JsonConvert.DeserializeObject<MainAssetsModel>(data);
            string value = Convert.ToString(collection["inputName"]);
            var radio1 = Convert.ToString(Request.Form["Currentradio"]);
            var radio2 = Convert.ToString(Request.Form["ownershipRadio"]);
            var radio3 = Convert.ToString(Request.Form["nominationradio"]);


            string c = "";

            if (obj.dueDate != null)
            {
                c = c + obj.dueDate + "~";
            }
           
         
            if (obj.IssuedBy != null)
            {
                c = c + obj.IssuedBy + "~";
            }
            if (obj.Location != null)
            {
                c = c + obj.Location + "~";
            }
            if (obj.Identifier != null)
            {
                c = c + obj.Identifier + "~";
            }
            if (obj.assetsValue != null)
            {
                c = c + obj.assetsValue + "~";
            }
            if (obj.CertificateNumber != null)
            {
                c = c + obj.CertificateNumber + "~";
            }
            if (obj.PropertyDescription != null)
            {
                c = c + obj.PropertyDescription + "~";
            }
            
            if (obj.Qty != null)
            {
                c = c + obj.Qty + "~";
            }
           
            if (obj.Weight != null)
            {
                c = c + obj.Weight + "~";
            }

            if (obj.Remark != null)
            {
                c = c + obj.Remark + "~";
            }
        
            if (obj.NomineeDetails != null)
            {
                c = c + obj.NomineeDetails + "~";
            }
            if (obj.Name != null)
            {
                c = c + obj.Name + "~";
            }
            if (obj.RegisteredAddress != null)
            {
                c = c + obj.RegisteredAddress + "~";
            }
            if (obj.PermanentAddress != null)
            {
                c = c + obj.PermanentAddress + "~";
            }
            if (obj.Identity_proof != null)
            {
                c = c + obj.Identity_proof + "~";
            }
            if (obj.Identity_proof_value != null)
            {
                c = c + obj.Identity_proof_value + "~";
            }
            if (obj.Alt_Identity_proof != null)
            {
                c = c + obj.Alt_Identity_proof + "~";
            }
            if (obj.Alt_Identity_proof_value != null)
            {
                c = c + obj.Alt_Identity_proof_value + "~";
            }
            if (obj.Phone != null)
            {
                c = c + obj.Phone + "~";
            }
            if (obj.Mobile != null)
            {
                c = c + obj.Mobile + "~";
            }
            if (obj.Amount != null)
            {
                c = c + obj.Amount + "~";
            }







            var itemToAdd = new JObject();
            ArrayList Column = new ArrayList(c.Split('~'));
            ArrayList Values = new ArrayList(value.Split(','));
            
            JArray jsonArray6 = new JArray();


            ArrayList NewList = new ArrayList();
            NewList.AddRange(Column);
            NewList.AddRange(Values);

            Dictionary<string, string> dd = new Dictionary<string, string>();
            for (int i = 0; i <= Column.Count; i++)
            {
                if (Column[i].ToString() != "")
                {
                    dd.Add(Column[i].ToString(), Values[i].ToString());
                }
                else
                {
                    break;
                }
                
            }

            if (obj.CurrentStatus != null)
            {


                dd.Add(obj.CurrentStatus, radio1.ToString());
            }


            if (obj.OwnerShip != null)
            {
                dd.Add(obj.OwnerShip, radio2.ToString());
            }

            if (obj.Nomination != null)
            {
                
                dd.Add(obj.Nomination, radio3.ToString());
            }




            string json = JsonConvert.SerializeObject(dd);
            int amid =  Convert.ToInt32(TempData["amid"]);
            con.Open();
            string query = "insert into AssetInformation (amId,Json) values ("+ amid + " ,'" + json + "')";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();


            return View("~/Views/AddMainAssets/AddMainAssetsPageContent.cshtml");
        }


   




    }
}