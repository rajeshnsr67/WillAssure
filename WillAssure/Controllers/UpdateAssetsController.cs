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


            return View("~/Views/UpdateAssets/UpdateAssetsPageContent.cshtml", Form);
        }

        public ActionResult UpdatingAssetsData(AssetsModel Form)
        {

            string control = Form.entity + "controlsvalues +=";
            string value = Form.entity + "Values";

            con.Open();
            string query = "update AssetsInfo set " + Form.entity + " = '" + Form.entityvalues + "' , " + control + " = '" + Form.controlsvalues + "'  , " + value + " = '" + Form.va + "' where aiId = " + Form.aiId + "  ";
            SqlCommand cmd = new SqlCommand(query, con);
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

                string data = "";

                if (Form.dueDate != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.dueDate + "  />   </div></div>";
                }

                Form.dueDateControls = dt.Rows[0]["DueDateControls"].ToString();

                if (Form.dueDateControls != "")
                {

                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.dueDateControls + "  />   </div></div>";

                }

                Form.DueDateValues = dt.Rows[0]["DueDateValues"].ToString();




                Form.CurrentStatus = dt.Rows[0]["CurrentStatus"].ToString();

                if (Form.CurrentStatus != "")
                {
                    data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.CurrentStatus + "  />   </div></div>";

                }

                Form.CurrentStatusControls = dt.Rows[0]["CurrentStatusControls"].ToString();

                if (Form.CurrentStatusControls != "")
                {
                    data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.CurrentStatusControls + "  />   </div></div>";
                }

                Form.CurrentStatusValues = dt.Rows[0]["CurrentStatusValues"].ToString();

                if (Form.CurrentStatusValues != "")
                {
                    data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.CurrentStatusValues + "  />   </div></div>";

                }

                Form.IssuedBy = dt.Rows[0]["IssuedBy"].ToString();

                if (Form.IssuedBy != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.IssuedBy + "  />   </div></div>";
                }


                Form.IssuedByControls = dt.Rows[0]["IssuedByControls"].ToString();

                if (Form.IssuedByControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.IssuedByControls + "  />   </div></div>";

                }







                Form.Location = dt.Rows[0]["Location"].ToString();

                if (Form.Location != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Location + "  />   </div></div>";
                }

                Form.LocationControls = dt.Rows[0]["LocationControls"].ToString();

                if (Form.LocationControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.LocationControls + "  />   </div></div>";

                }







                Form.Identifier = dt.Rows[0]["Identifier"].ToString();

                if (Form.Identifier != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Identifier + "  />   </div></div>";
                }

                Form.IdentifierControls = dt.Rows[0]["IdentifierControls"].ToString();

                if (Form.IdentifierControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.IdentifierControls + "  />   </div></div>";

                }






                Form.assetsValue = dt.Rows[0]["assetsValue"].ToString();

                if (Form.assetsValue != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.assetsValue + "  />   </div></div>";
                }

                Form.assetsValueControls = dt.Rows[0]["assetsValueControls"].ToString();

                if (Form.assetsValueControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.assetsValueControls + "  />   </div></div>";

                }






                Form.CertificateNumber = dt.Rows[0]["CertificateNumber"].ToString();

                if (Form.CertificateNumber != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.CertificateNumber + "  />   </div></div>";
                }

                Form.CertificateNumberControls = dt.Rows[0]["CertificateNumberControls"].ToString();

                if (Form.CertificateNumberControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.CertificateNumberControls + "  />   </div></div>";

                }





                Form.PropertyDescription = dt.Rows[0]["PropertyDescription"].ToString();

                if (Form.PropertyDescription != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.PropertyDescription + "  />   </div></div>";
                }

                Form.PropertyDescriptionControls = dt.Rows[0]["PropertyDescriptionControls"].ToString();

                if (Form.PropertyDescriptionControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.PropertyDescriptionControls + "  />   </div></div>";
                }






                Form.Qty = dt.Rows[0]["Qty"].ToString();

                if (Form.Qty != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Qty + "  />   </div></div>";
                }


                Form.QtyControls = dt.Rows[0]["QtyControls"].ToString();

                if (Form.QtyControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.QtyControls + "  />   </div></div>";
                }





                Form.Weight = dt.Rows[0]["Weight"].ToString();

                if (Form.Weight != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Weight + "  />   </div></div>";
                }


                Form.WeightControls = dt.Rows[0]["WeightControls"].ToString();

                if (Form.WeightControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.WeightControls + "  />   </div></div>";
                }







                Form.OwnerShip = dt.Rows[0]["OwnerShip"].ToString();

                if (Form.OwnerShip != "")
                {
                    data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.OwnerShip + "  />   </div></div>";
                }

                Form.OwnerShipControls = dt.Rows[0]["OwnerShipControls"].ToString();

                if (Form.OwnerShipControls != "")
                {
                    data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.OwnerShipControls + "  />   </div></div>";
                }

                Form.OwnerShipValues = dt.Rows[0]["OwnerShipValues"].ToString();

                if (Form.OwnerShipValues != "")
                {
                    data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.OwnerShipValues + "  />   </div></div>";
                }


                Form.Remark = dt.Rows[0]["Remark"].ToString();

                if (Form.Remark != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Remark + "  />   </div></div>";
                }

                Form.RemarkControls = dt.Rows[0]["RemarkControls"].ToString();

                if (Form.RemarkControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.RemarkControls + "  />   </div></div>";
                }

                Form.RemarkValues = dt.Rows[0]["RemarkValues"].ToString();


                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.RemarkValues + "  />   </div></div>";




                Form.Nomination = dt.Rows[0]["Nomination"].ToString();

                if (Form.Nomination != "")
                {
                    data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Nomination + "  />   </div></div>";
                }

                Form.NominationControls = dt.Rows[0]["NominationControls"].ToString();

                if (Form.NominationControls != "")
                {
                    data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.NominationControls + "  />   </div></div>";

                }


                Form.NominationValues = dt.Rows[0]["NominationValues"].ToString();

                if (Form.NominationValues != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.NominationValues + "  />   </div></div>";
                }

                Form.NomineeDetails = dt.Rows[0]["NomineeDetails"].ToString();

                if (Form.NomineeDetails != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.NomineeDetails + "  />   </div></div>";
                }

                Form.NomineeDetailsControls = dt.Rows[0]["NomineeDetailsControls"].ToString();

                if (Form.NomineeDetailsControls != "")
                {
                    data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.NomineeDetailsControls + "  />   </div></div>";
                }







                Form.Name = dt.Rows[0]["Name"].ToString();

                if (Form.Name != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Name + "  />   </div></div>";
                }

                Form.NameControls = dt.Rows[0]["NameControls"].ToString();

                if (Form.NameControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.NameControls + "  />   </div></div>";
                }





                Form.RegisteredAddress = dt.Rows[0]["RegisteredAddress"].ToString();

                if (Form.RegisteredAddress != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.RegisteredAddress + "  />   </div></div>";
                }


                Form.RegisteredAddressControls = dt.Rows[0]["RegisteredAddressControls"].ToString();

                if (Form.RegisteredAddressControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.RegisteredAddressControls + "  />   </div></div>";
                }





                Form.PermanentAddress = dt.Rows[0]["PermanentAddress"].ToString();

                if (Form.PermanentAddress != "")
                {

                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.PermanentAddress + "  />   </div></div>";
                }


                Form.PermanentAddressControls = dt.Rows[0]["PermanentAddressControls"].ToString();

                if (Form.PermanentAddressControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.PermanentAddressControls + "  />   </div></div>";
                }








                Form.Identity_proof = dt.Rows[0]["Identity_proof"].ToString();


                if (Form.Identity_proof != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Identity_proof + "  />   </div></div>";
                }


                Form.Identity_proofControls = dt.Rows[0]["Identity_proofControls"].ToString();

                if (Form.Identity_proofControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Identity_proofControls + "  />   </div></div>";
                }







                Form.Identity_proof_value = dt.Rows[0]["Identity_proof_value"].ToString();

                if (Form.Identity_proof_value != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Identity_proof_value + "  />   </div></div>";
                }


                Form.Identity_proof_valueControls = dt.Rows[0]["Identity_proof_valueControls"].ToString();


                if (Form.Identity_proof_valueControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Identity_proof_valueControls + "  />   </div></div>";
                }





                Form.Alt_Identity_proof = dt.Rows[0]["Alt_Identity_proof"].ToString();

                if (Form.Alt_Identity_proof != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Alt_Identity_proof + "  />   </div></div>";
                }

                Form.Alt_Identity_proofControls = dt.Rows[0]["Alt_Identity_proofControls"].ToString();

                if (Form.Alt_Identity_proofControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Alt_Identity_proofControls + "  />   </div></div>";
                }





                Form.Alt_Identity_proof_value = dt.Rows[0]["Alt_Identity_proof_value"].ToString();

                if (Form.Alt_Identity_proof_value != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Alt_Identity_proof_value + "  />   </div></div>";
                }

                Form.Alt_Identity_proof_valueControls = dt.Rows[0]["Alt_Identity_proof_valueControls"].ToString();


                if (Form.Alt_Identity_proof_valueControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Alt_Identity_proof_valueControls + "  />   </div></div>";

                }





                Form.Phone = dt.Rows[0]["Phone"].ToString();

                if (Form.Phone != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Phone + "  />   </div></div>";
                }

                Form.PhoneControls = dt.Rows[0]["PhoneControls"].ToString();

                if (Form.PhoneControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.PhoneControls + "  />   </div></div>";
                }





                Form.Mobile = dt.Rows[0]["Mobile"].ToString();

                if (Form.Mobile != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Mobile + "  />   </div></div>";
                }

                Form.MobileControls = dt.Rows[0]["MobileControls"].ToString();
                if (Form.MobileControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.MobileControls + "  />   </div></div>";
                }




                Form.Amount = dt.Rows[0]["Amount"].ToString();

                if (Form.Amount != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.Amount + "  />   </div></div>";
                }

                Form.AmountControls = dt.Rows[0]["AmountControls"].ToString();
                if (Form.AmountControls != "")
                {
                    data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control'  value=" + Form.AmountControls + "  />   </div></div>";
                }







                f = data;

            }





            return f;
        }










    }








}

