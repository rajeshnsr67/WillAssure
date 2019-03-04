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
                    if (dt3.Rows[i]["DueDate"].ToString()  != "")
                    {

                    }

                    if (dt3.Rows[i]["DueDateControls"].ToString()  != "")
                    {

                    }

                    if (dt3.Rows[i]["DueDateValues"].ToString()  != "")
                    {

                    }

                    if (dt3.Rows[i]["CurrentStatus"].ToString()  != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["CurrentStatus"].ToString() + "</label>";
                    }

                    if (dt3.Rows[i]["CurrentStatusControls"].ToString()  != "")
                    {
                        column = column + "<input type="+ dt3.Rows[i]["CurrentStatusControls"].ToString()+" class='form-control' /></div></div>";
                    }


                    if (dt3.Rows[i]["CurrentStatusValues"].ToString()  != "")
                    {

                    }

                    if (dt3.Rows[i]["IssuedBy"].ToString()  != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["IssuedBy"].ToString() + "</label>";
                    }

                    if (dt3.Rows[i]["IssuedByControls"].ToString()  != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["IssuedByControls"].ToString() + " class='form-control' /> </div></div>";
                    }

                    if (dt3.Rows[i]["IssuedByValues"].ToString()  != "")
                    {

                    }

                    if (dt3.Rows[i]["Location"].ToString()  != "")
                    {

                    }

                    if (dt3.Rows[i]["LocationControls"].ToString()  != "")
                    {

                    }

                    if (dt3.Rows[i]["LocationValues"].ToString()  != "")
                    {

                    }

                    if (dt3.Rows[i]["Identifier"].ToString()  != "")
                    {

                    }

                    if (dt3.Rows[i]["IdentifierControls"].ToString()  != "")
                    {

                    }

                    if (dt3.Rows[i]["IdentifierValues"].ToString()  != "")
                    {

                    }

                    if (dt3.Rows[i]["assetsValue"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["assetsValueControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["assetsValueValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["CertificateNumber"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["CertificateNumberControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["CertificateNumberValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["PropertyDescription"].ToString()  != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["PropertyDescription"].ToString() + "</label>";
                    }
                    if (dt3.Rows[i]["PropertyDescriptionControls"].ToString()  != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["PropertyDescriptionControls"].ToString() + " class='form-control' /> </div></div>";
                    }
                    if (dt3.Rows[i]["PropertyDescriptionValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Qty"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["QtyControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["QtyValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Weight"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["WeightControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["WeightValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["OwnerShip"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["OwnerShipControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["OwnerShipValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Remark"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["RemarkControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["RemarkValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Nomination"].ToString()  != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["Nomination"].ToString() + "</label>";
                    }
                    if (dt3.Rows[i]["NominationControls"].ToString()  != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["NominationControls"].ToString() + " class='form-control' /> </div></div>";
                    }
                    if (dt3.Rows[i]["NominationValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["NomineeDetails"].ToString()  != "")
                    {
                        column = column + "<div class='col-sm-3'> <div class='form-group'><label for='input-1' >" + dt3.Rows[i]["NomineeDetails"].ToString() + "</label>";
                    }
                    if (dt3.Rows[i]["NomineeDetailsControls"].ToString()  != "")
                    {
                        column = column + "<input type=" + dt3.Rows[i]["NomineeDetailsControls"].ToString() + " class='form-control' /> </div></div>";
                    }
                    if (dt3.Rows[i]["NomineeDetailsValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Name"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["NameControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["NameValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["RegisteredAddress"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["RegisteredAddressControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["RegisteredAddressValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["PermanentAddress"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["PermanentAddressControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["PermanentAddressValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Identity_proof"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Identity_proofControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Identity_proofValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Identity_proof_value"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Identity_proof_valueControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Identity_proof_valueValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Alt_Identity_proof"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Alt_Identity_proofControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Alt_Identity_proofValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Alt_Identity_proof_value"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Alt_Identity_proof_valueControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Alt_Identity_proof_valueValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Phone"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["PhoneControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["PhoneValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Mobile"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["MobileControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["MobileValues"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["Amount"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["AmountControls"].ToString()  != "")
                    {

                    }
                    if (dt3.Rows[i]["AmountValues"].ToString()  != "")
                    {

                    }


                    finalstruct = column;


                }
                

            }

            con.Close();



            return finalstruct;
        }


    }
}