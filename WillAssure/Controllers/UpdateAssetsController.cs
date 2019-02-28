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

namespace WillAssure.Models
{
    public class UpdateAssetsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateAssets
        public ActionResult UpdateAssetsIndex(int NestId)
        {

            AssetsModel Form = new AssetsModel();
            Form.aiId = NestId;


            return View("~/Views/UpdateAssets/UpdateAssetsPageContent.cshtml",Form);
        }

        public ActionResult UpdatingAssetsData(AssetsModel Form)
        {

            string control = Form.entity + "controlsvalues +=";
            string value = Form.entity + "Values";

            con.Open();
            string query = "update AssetsInfo set "+Form.entity+" = '"+Form.entityvalues + "' , "+control+" = '"+Form.controlsvalues + "'  , "+value+" = '"+Form.va+ "' where aiId = " + Form.aiId+"  ";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();



            return View("~/Views/UpdateAssets/UpdateAssetsPageContent.cshtml", Form);
        }



        public string DynamicFields(AssetsModel Form)
        {
            string f = "";
            int aid = Convert.ToInt32(Request["send"]);
           
            int count = Convert.ToInt32(Session["fields"]);

            con.Open();
            string query = "select * from AssetsInfo where aiId = '" + aid + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                

                Form.amId = Convert.ToInt32(dt.Rows[0]["amId"]);
                Form.assetsCode = dt.Rows[0]["assetsCode"].ToString();
                Form.dueDate = dt.Rows[0]["DueDate"].ToString();

                if (Form.dueDate != "")
                {
                    Form.entityvalues = Form.dueDate;
                }

                Form.dueDateControls = dt.Rows[0]["DueDateControls"].ToString();

                if (Form.dueDateControls != "")
                {
                    
                    Form.controlsvalues += "<div class='col-sm-3'><div class='form-group'> <input  type='text' value='" + Form.dueDate + "' class='form-control' /> </div></div>";

                }

                Form.DueDateValues = dt.Rows[0]["DueDateValues"].ToString();

                if (Form.DueDateValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'> <input  type='text' value='" + Form.DueDateValues + "' class='form-control' /> </div></div>";
                }

                Form.CurrentStatus = dt.Rows[0]["CurrentStatus"].ToString();

                if (Form.CurrentStatus != "")
                {
                    Form.entityvalues =  Form.CurrentStatus;

                }

                Form.CurrentStatusControls = dt.Rows[0]["CurrentStatusControls"].ToString();

                if (Form.CurrentStatusControls != "")
                {
                    Form.controlsvalues += "<div class='col-sm-3'><div class='form-group'> <input  type='text' value='"+Form.CurrentStatusControls + "' class='form-control' /> </div></div>";
                }

                Form.CurrentStatusValues = dt.Rows[0]["CurrentStatusValues"].ToString();

                if (Form.CurrentStatusValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.CurrentStatusValues + " /></div></div>";

                }

                Form.IssuedBy = dt.Rows[0]["IssuedBy"].ToString();

                if (Form.IssuedBy != "")
                {
                    Form.entityvalues = Form.IssuedBy;
                }


                Form.IssuedByControls = dt.Rows[0]["IssuedByControls"].ToString();

                if (Form.IssuedByControls != "")
                {
                    Form.controlsvalues += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.IssuedByControls + " /></div></div>";

                }

                Form.IssuedByValues = dt.Rows[0]["IssuedByValues"].ToString();

                if (Form.IssuedByValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.IssuedByValues + " /></div></div>";

                }


                Form.Location = dt.Rows[0]["Location"].ToString();

                if (Form.Location != "")
                {
                    Form.entityvalues = Form.Location;
                }

                Form.LocationControls = dt.Rows[0]["LocationControls"].ToString();

                if (Form.LocationControls != "")
                {
                    Form.controlsvalues += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.LocationControls + " /></div></div>";

                }

                Form.LocationValues = dt.Rows[0]["LocationValues"].ToString();

                if (Form.LocationValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.LocationValues + " /></div></div>";

                }


                Form.Identifier = dt.Rows[0]["Identifier"].ToString();

                if (Form.Identifier != "")
                {
                    Form.entityvalues = Form.Identifier;
                }

                Form.IdentifierControls = dt.Rows[0]["IdentifierControls"].ToString();

                if (Form.IdentifierControls != "")
                {
                    Form.controlsvalues += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.IdentifierControls + " /></div></div>";

                }

                Form.IdentifierValues = dt.Rows[0]["IdentifierValues"].ToString();

                if (Form.IdentifierValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.IdentifierValues + " /></div></div>";

                }

                Form.assetsValue = dt.Rows[0]["assetsValue"].ToString();

                if (Form.assetsValue != "")
                {
                    Form.entityvalues = Form.assetsValue;
                }

                Form.assetsValueControls = dt.Rows[0]["assetsValueControls"].ToString();

                if (Form.assetsValueControls != "")
                {
                    Form.controlsvalues += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.assetsValueControls + " /></div></div>";

                }

                Form.assetsValueValues = dt.Rows[0]["assetsValueValues"].ToString();

                if (Form.assetsValueValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.assetsValueValues + " /></div></div>";

                }

                Form.CertificateNumber = dt.Rows[0]["CertificateNumber"].ToString();

                if (Form.CertificateNumber != "")
                {
                    Form.entityvalues = Form.CertificateNumber;
                }

                Form.CertificateNumberControls = dt.Rows[0]["CertificateNumberControls"].ToString();

                if (Form.CertificateNumberControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.CertificateNumberControls + " /></div></div>";

                }


                Form.CertificateNumberValues = dt.Rows[0]["CertificateNumberValues"].ToString();

                if (Form.CertificateNumberValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.CertificateNumberValues + " /></div></div>";

                }

                Form.PropertyDescription = dt.Rows[0]["PropertyDescription"].ToString();

                if (Form.PropertyDescription != "")
                {
                    Form.entityvalues = Form.PropertyDescription;
                }

                Form.PropertyDescriptionControls = dt.Rows[0]["PropertyDescriptionControls"].ToString();

                if (Form.PropertyDescriptionControls != "")
                {
                    Form.controlsvalues += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.PropertyDescriptionControls + " /></div></div>";

                }

                Form.PropertyDescriptionValues = dt.Rows[0]["PropertyDescriptionValues"].ToString();

                if (Form.PropertyDescriptionValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.PropertyDescriptionValues + " /></div></div>";

                }


                Form.Qty = dt.Rows[0]["Qty"].ToString();

                if (Form.Qty != "")
                {
                    Form.entityvalues = Form.Qty;
                }


                Form.QtyControls = dt.Rows[0]["QtyControls"].ToString();

                if (Form.QtyControls != "")
                {
                    Form.controlsvalues += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.QtyControls + " /></div></div>";

                }

                Form.QtyValues = dt.Rows[0]["QtyValues"].ToString();

                if (Form.QtyValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.QtyValues + " /></div></div>";

                }

                Form.Weight = dt.Rows[0]["Weight"].ToString();

                if (Form.Weight != "")
                {
                    Form.entityvalues = Form.Weight;
                }


                Form.WeightControls = dt.Rows[0]["WeightControls"].ToString();

                if (Form.WeightControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.WeightControls + " /></div></div>";

                }

                Form.WeightValues = dt.Rows[0]["WeightValues"].ToString();

                if (Form.WeightValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.WeightValues + " /></div></div>";

                }


                Form.OwnerShip = dt.Rows[0]["OwnerShip"].ToString();

                if (Form.OwnerShip != "")
                {
                    Form.entityvalues = Form.OwnerShip;
                }

                Form.OwnerShipControls = dt.Rows[0]["OwnerShipControls"].ToString();

                if (Form.OwnerShipControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.OwnerShipControls + " /></div></div>";

                }

                Form.OwnerShipValues = dt.Rows[0]["OwnerShipValues"].ToString();

                if (Form.OwnerShipValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.OwnerShipValues + " /></div></div>";

                }


                Form.Remark = dt.Rows[0]["Remark"].ToString();

                if (Form.Remark != "")
                {
                    Form.entityvalues = Form.Remark;
                }

                Form.RemarkControls = dt.Rows[0]["RemarkControls"].ToString();

                if (Form.RemarkControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.RemarkControls + " /></div></div>";

                }

                Form.RemarkValues = dt.Rows[0]["RemarkValues"].ToString();

                if (Form.RemarkValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.RemarkValues + " /></div></div>";

                }


                Form.Nomination = dt.Rows[0]["Nomination"].ToString();

                if (Form.Nomination != "")
                {
                    Form.entityvalues = Form.Nomination;
                }

                Form.NominationControls = dt.Rows[0]["NominationControls"].ToString();

                if (Form.NominationControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.NominationControls + " /></div></div>";

                }


                Form.NominationValues = dt.Rows[0]["NominationValues"].ToString();

                if (Form.NominationValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.NominationValues + " /></div></div>";

                }

                Form.NomineeDetails = dt.Rows[0]["NomineeDetails"].ToString();

                if (Form.NomineeDetails != "")
                {
                    Form.entityvalues = Form.NomineeDetails;
                }

                Form.NomineeDetailsControls = dt.Rows[0]["NomineeDetailsControls"].ToString();

                if (Form.NomineeDetailsControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.NomineeDetailsControls + " /></div></div>";

                }


                Form.NomineeDetailsValues = dt.Rows[0]["NomineeDetailsValues"].ToString();


                if (Form.NomineeDetailsValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.NomineeDetailsValues + " /></div></div>";

                }

                Form.Name = dt.Rows[0]["Name"].ToString();

                if (Form.Name != "")
                {
                    Form.entityvalues = Form.Name;
                }

                Form.NameControls = dt.Rows[0]["NameControls"].ToString();

                if (Form.NameControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.NameControls + " /></div></div>";

                }

                Form.NameValues = dt.Rows[0]["NameValues"].ToString();

                if (Form.NameValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.NameValues + " /></div></div>";

                }

                Form.RegisteredAddress = dt.Rows[0]["RegisteredAddress"].ToString();

                if (Form.RegisteredAddress != "")
                {
                    Form.entityvalues = Form.RegisteredAddress;
                }


                Form.RegisteredAddressControls = dt.Rows[0]["RegisteredAddressControls"].ToString();

                if (Form.RegisteredAddressControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.RegisteredAddressControls + " /></div></div>";

                }

                Form.RegisteredAddressValues = dt.Rows[0]["RegisteredAddressValues"].ToString();

                if (Form.RegisteredAddressControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.RegisteredAddressControls + " /></div></div>";

                }

                Form.PermanentAddress = dt.Rows[0]["PermanentAddress"].ToString();

                if (Form.PermanentAddress != "")
                {
                    Form.entityvalues = Form.PermanentAddress;
                }


                Form.PermanentAddressControls = dt.Rows[0]["PermanentAddressControls"].ToString();

                if (Form.PermanentAddressControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.PermanentAddressControls + " /></div></div>";

                }


                Form.PermanentAddressValues = dt.Rows[0]["PermanentAddressValues"].ToString();

                if (Form.PermanentAddressValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.PermanentAddressValues + " /></div></div>";

                }



                Form.Identity_proof = dt.Rows[0]["Identity_proof"].ToString();


                if (Form.Identity_proof != "")
                {
                    Form.entityvalues = Form.Identity_proof;
                }


                Form.Identity_proofControls = dt.Rows[0]["Identity_proofControls"].ToString();

                if (Form.Identity_proofControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.Identity_proofControls + " /></div></div>";

                }


                Form.Identity_proofValues = dt.Rows[0]["Identity_proofValues"].ToString();

                if (Form.Identity_proofValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.Identity_proofValues + " /></div></div>";

                }


                Form.Identity_proof_value = dt.Rows[0]["Identity_proof_value"].ToString();

                if (Form.Identity_proof_value != "")
                {
                    Form.entityvalues = Form.Identity_proof_value;
                }


                Form.Identity_proof_valueControls = dt.Rows[0]["Identity_proof_valueControls"].ToString();


                if (Form.Identity_proof_valueControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.Identity_proof_valueControls + " /></div></div>";

                }

                Form.Identity_proof_valueValues = dt.Rows[0]["Identity_proof_valueValues"].ToString();

                if (Form.Identity_proof_valueValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.Identity_proof_valueValues + " /></div></div>";

                }

                Form.Alt_Identity_proof = dt.Rows[0]["Alt_Identity_proof"].ToString();

                if (Form.Alt_Identity_proof != "")
                {
                    Form.entityvalues = Form.Alt_Identity_proof;
                }

                Form.Alt_Identity_proofControls = dt.Rows[0]["Alt_Identity_proofControls"].ToString();

                if (Form.Alt_Identity_proofControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.Alt_Identity_proofControls + " /></div></div>";

                }

                Form.Alt_Identity_proofValues = dt.Rows[0]["Alt_Identity_proofValues"].ToString();

                if (Form.Alt_Identity_proofValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.Alt_Identity_proofValues + " /></div></div>";

                }

                Form.Alt_Identity_proof_value = dt.Rows[0]["Alt_Identity_proof_value"].ToString();

                if (Form.Alt_Identity_proof_value != "")
                {
                    Form.entityvalues = Form.Alt_Identity_proof_value;
                }

                Form.Alt_Identity_proof_valueControls = dt.Rows[0]["Alt_Identity_proof_valueControls"].ToString();


                if (Form.Alt_Identity_proof_valueControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.Alt_Identity_proof_valueControls + " /></div></div>";

                }

                Form.Alt_Identity_proof_valueValues = dt.Rows[0]["Alt_Identity_proof_valueValues"].ToString();

                if (Form.Alt_Identity_proof_valueValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.Alt_Identity_proof_valueValues + " /></div></div>";

                }

                Form.Phone = dt.Rows[0]["Phone"].ToString();

                if (Form.Phone != "")
                {
                    Form.entityvalues = Form.Phone;
                }

                Form.PhoneControls = dt.Rows[0]["PhoneControls"].ToString();

                if (Form.PhoneControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.PhoneControls + " /></div></div>";

                }

                Form.PhoneValues = dt.Rows[0]["PhoneValues"].ToString();

                if (Form.PhoneValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.PhoneValues + " /></div></div>";

                }

                Form.Mobile = dt.Rows[0]["Mobile"].ToString();

                if (Form.Mobile != "")
                {
                    Form.entityvalues = Form.Mobile;
                }

                Form.MobileControls = dt.Rows[0]["MobileControls"].ToString();
                if (Form.MobileControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.MobileControls + " /></div></div>";

                }

                Form.MobileValues = dt.Rows[0]["MobileValues"].ToString();
                if (Form.MobileValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.MobileValues + " /></div></div>";

                }

                Form.Amount = dt.Rows[0]["Amount"].ToString();

                if (Form.Amount != "")
                {
                    Form.entityvalues += Form.Amount;
                }

                Form.AmountControls = dt.Rows[0]["AmountControls"].ToString();
                if (Form.AmountControls != "")
                {
                    Form.controlsvalues +=  "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.AmountControls + " /></div></div>";

                }

                Form.AmountValues = dt.Rows[0]["AmountValues"].ToString();

                if (Form.AmountValues != "")
                {
                    Form.va += "<div class='col-sm-3'><div class='form-group'><input type='text' value="+ Form.AmountValues + " /></div></div>";

                }


                 f =  Form.va;

            }





            return f;
        }










    }








}