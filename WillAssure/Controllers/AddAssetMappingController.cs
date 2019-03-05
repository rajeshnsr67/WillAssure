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



     




            final = "<div class='col-sm-4'> <div class='form-group'> <label for='input-1'>Beneficiary</label> <select id='ddlcity' class='form-control'>  <option value='0'>--Select Beneficiary--</option> "+ddlbeneficiary+"</select> </div></div>";
            final +="<div class='col-sm-4'> <div class='form-group'> <label for='input-1'>Assets</label> <select id='ddlassettype' onChange='getassettypeid(this.value)' class='form-control'>  <option value='0'>--Select--</option> "+ddlassettype+"  </select> </div></div>";
            final += "<div class='col-sm-4'> <div class='form-group'> <label for='input-1'>Assets</label> <select id='ddlassetcat' onChange='getassetcatid(this.value)' class='form-control'>  <option value='0'>--Select--</option> </select> </div></div>";
          //  final +="<div class='col-sm-3'> <div class='form-group'> <label for='input-1'>Values</label> <input type='text' class='form-control'  /></div></div>";


            return final;
        }



        public string bindassetcatDDL()
        {
            int response = Convert.ToInt32(Request["send"]);
            string ddlassetcat = "<option value='0'>--Select--</option>";
            con.Open();
            string query3 = "select * from AssetsCategory where atId = "+response+" ";
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

                        column = column + "<input type=" + dt3.Rows[i]["DueDateControls"].ToString() + " class='form-control' /></div></div>";
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
                            column = column + "<input type=" + dt3.Rows[i]["CurrentStatusControls"].ToString() + " class='form-control' /></div></div>";
                        }
                        amm.CurrentStatusValues = dt3.Rows[i]["CurrentStatusValues"].ToString();

                    }




                    if (dt3.Rows[i]["IssuedBy"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["IssuedBy"].ToString() + "</label>";
                    }

                    if (dt3.Rows[i]["IssuedByControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["IssuedByControls"].ToString() + " class='form-control' /></div></div>";


                    }



                    if (dt3.Rows[i]["Location"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Location"].ToString() + "</label>";

                    }

                    if (dt3.Rows[i]["LocationControls"].ToString() != "")
                    {
                        if (dt3.Rows[i]["LocationControls"].ToString() == "TextArea")
                        {



                            column = column + "<textarea class='form-control'></textarea></div></div>";


                        }
                        else
                        {
                            column = column + "<input type=" + dt3.Rows[i]["LocationControls"].ToString() + " class='form-control' /></div></div>";
                        }
                    }



                    if (dt3.Rows[i]["Identifier"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Identifier"].ToString() + "</label>";

                    }

                    if (dt3.Rows[i]["IdentifierControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["IdentifierControls"].ToString() + " class='form-control' /></div></div>";

                    }



                    if (dt3.Rows[i]["assetsValue"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["assetsValue"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["assetsValueControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["assetsValueControls"].ToString() + " class='form-control' /></div></div>";

                    }

                    if (dt3.Rows[i]["CertificateNumber"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["CertificateNumber"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["CertificateNumberControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["CertificateNumberControls"].ToString() + " class='form-control' /></div></div>";

                    }

                    if (dt3.Rows[i]["PropertyDescription"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["PropertyDescription"].ToString() + "</label>";
                    }

                    if (dt3.Rows[i]["PropertyDescriptionControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["PropertyDescriptionControls"].ToString() + " class='form-control' /></div></div>";


                    }

                    if (dt3.Rows[i]["Qty"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Qty"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["QtyControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["QtyControls"].ToString() + " class='form-control' /></div></div>";

                    }

                    if (dt3.Rows[i]["Weight"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Weight"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["WeightControls"].ToString() != "")
                    {

                        column = column + "<input type=" + dt3.Rows[i]["WeightControls"].ToString() + " class='form-control' /></div></div>";

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
                            column = column + "<input type=" + dt3.Rows[i]["OwnerShipControls"].ToString() + " class='form-control' /></div></div>";
                        }



                    }

                    if (dt3.Rows[i]["Remark"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Remark"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["RemarkControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["RemarkControls"].ToString() + " class='form-control' /></div></div>";

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
                            column = column + "<input type=" + dt3.Rows[i]["NominationControls"].ToString() + " class='form-control' /> </div></div>";
                        }



                    }

                    if (dt3.Rows[i]["NomineeDetails"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["NomineeDetails"].ToString() + "</label>";
                    }


                    if (dt3.Rows[i]["NomineeDetailsControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["NomineeDetailsControls"].ToString() + " class='form-control' /> </div></div>";
                    }

                    if (dt3.Rows[i]["Name"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Name"].ToString() + "</label>";


                    }
                    if (dt3.Rows[i]["NameControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["NameControls"].ToString() + " class='form-control' /></div></div>";

                    }

                    if (dt3.Rows[i]["RegisteredAddress"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["RegisteredAddress"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["RegisteredAddressControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["RegisteredAddressControls"].ToString() + " class='form-control' /></div></div>";

                    }

                    if (dt3.Rows[i]["PermanentAddress"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["PermanentAddress"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["PermanentAddressControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["PermanentAddressControls"].ToString() + " class='form-control' /></div></div>";

                    }

                    if (dt3.Rows[i]["Identity_proof"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Identity_proof"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["Identity_proofControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Identity_proofControls"].ToString() + " class='form-control' /></div></div>";

                    }

                    if (dt3.Rows[i]["Identity_proof_value"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Identity_proof_value"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["Identity_proof_valueControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Identity_proof_valueControls"].ToString() + " class='form-control' /></div></div>";

                    }

                    if (dt3.Rows[i]["Alt_Identity_proof"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Alt_Identity_proof"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["Alt_Identity_proofControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Alt_Identity_proofControls"].ToString() + " class='form-control' /></div></div>";

                    }

                    if (dt3.Rows[i]["Alt_Identity_proof_value"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Alt_Identity_proof_value"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["Alt_Identity_proof_valueControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["Alt_Identity_proof_valueControls"].ToString() + " class='form-control' /></div></div>";

                    }

                    if (dt3.Rows[i]["Phone"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Phone"].ToString() + "</label>";

                    }
                    if (dt3.Rows[i]["PhoneControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["PhoneControls"].ToString() + " class='form-control' /></div></div>";

                    }

                    if (dt3.Rows[i]["Mobile"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Mobile"].ToString() + "</label>";



                    }
                    if (dt3.Rows[i]["MobileControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["MobileControls"].ToString() + " class='form-control' /></div></div>";


                    }

                    if (dt3.Rows[i]["Amount"].ToString() != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Amount"].ToString() + "</label>";


                    }
                    if (dt3.Rows[i]["AmountControls"].ToString() != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["AmountControls"].ToString() + " class='form-control' /></div></div>";

                    }


                    
                    finalstruct = column;


                }


            }

            con.Close();



            return finalstruct;
        }


    }
}