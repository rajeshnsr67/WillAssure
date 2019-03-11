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

      

        public ActionResult UpdatingAssetsData(FormCollection collection, AssetsModel Form)
        {
            string col = Convert.ToString(collection["tblcol"]);
            string colcontrol = Convert.ToString(collection["column"]);
            string valcontrol = Convert.ToString(collection["control"]);
            string mulcontrol = Convert.ToString(collection["multiple"]);
            
            ArrayList columnName = new ArrayList(col.Split(','));
            ArrayList columnValue = new ArrayList(colcontrol.Split(','));
            ArrayList columnControl = new ArrayList(valcontrol.Split(','));
         
            



            string q = "";
            string q1 = "";
            for (int i = 0; i < columnName.Count; i++)
            {

                if (mulcontrol != null)
                {
                    ArrayList ControlValue = new ArrayList(mulcontrol.Split(','));
                    q = q + "" + columnName[i].ToString() + " = " + columnValue[i].ToString() + "," + columnName[i].ToString() + "Controls" + "=" + "'" + columnControl[i].ToString() + "'" + "," + columnName[i].ToString() + "Values" + "=" + "'" + ControlValue[i].ToString() + "'";
                    q1 = q.Substring(0, q.Length - 1);
                }
                else
                {
                    q = q + "" + columnName[i].ToString() + " = " + "'" + columnName[i].ToString() + "~" + columnValue[i].ToString() + "'" + "," + columnName[i].ToString() + "Controls" + "=" + "'" + columnControl[i].ToString() + "'" + ",";
                    
                }

               
                   
                


            }

            q1 = q.Substring(0, q.Length - 1);

            con.Open();
            string query = "update AssetsInfo set " + q1 + " where aiId =" + Form.aiId + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();



            return View("~/Views/UpdateAssets/UpdateAssetsPageContent.cshtml");
        }



        public string DynamicFields(AssetsModel Form)
        {
            string f = "";
            if (Request["send"] != "")
            {


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
                    string updatequery = "";
                    if (Form.dueDate != "")
                    {
                        ArrayList va = new ArrayList(Form.dueDate.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'   value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }


                    }

                    Form.dueDateControls = dt.Rows[0]["DueDateControls"].ToString();

                    if (Form.dueDateControls != "")
                    {

                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.dueDateControls + "  />   </div></div>";

                    }

                    Form.DueDateValues = dt.Rows[0]["DueDateValues"].ToString();




                    Form.CurrentStatus = dt.Rows[0]["CurrentStatus"].ToString();

                    if (Form.CurrentStatus != "")
                    {
                        ArrayList va = new ArrayList(Form.CurrentStatus.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.CurrentStatusControls = dt.Rows[0]["CurrentStatusControls"].ToString();

                    if (Form.CurrentStatusControls != "")
                    {
                        data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.CurrentStatusControls + "  />   </div></div>";

                    }

                    Form.CurrentStatusValues = dt.Rows[0]["CurrentStatusValues"].ToString();

                    if (Form.CurrentStatusValues != "")
                    {
                        data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control' name='multiple'  value=" + Form.CurrentStatusValues + "  />   </div></div>";

                    }

                    Form.IssuedBy = dt.Rows[0]["IssuedBy"].ToString();

                    if (Form.IssuedBy != "")
                    {
                        ArrayList va = new ArrayList(Form.IssuedBy.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }


                    Form.IssuedByControls = dt.Rows[0]["IssuedByControls"].ToString();

                    if (Form.IssuedByControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.IssuedByControls + "  />   </div></div>";

                    }







                    Form.Location = dt.Rows[0]["Location"].ToString();

                    if (Form.Location != "")
                    {
                        ArrayList va = new ArrayList(Form.Location.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.LocationControls = dt.Rows[0]["LocationControls"].ToString();

                    if (Form.LocationControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.LocationControls + "  />   </div></div>";

                    }







                    Form.Identifier = dt.Rows[0]["Identifier"].ToString();

                    if (Form.Identifier != "")
                    {
                        ArrayList va = new ArrayList(Form.Identifier.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.IdentifierControls = dt.Rows[0]["IdentifierControls"].ToString();

                    if (Form.IdentifierControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.IdentifierControls + "  />   </div></div>";

                    }






                    Form.assetsValue = dt.Rows[0]["assetsValue"].ToString();

                    if (Form.assetsValue != "")
                    {
                        ArrayList va = new ArrayList(Form.assetsValue.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.assetsValueControls = dt.Rows[0]["assetsValueControls"].ToString();

                    if (Form.assetsValueControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.assetsValueControls + "  />   </div></div>";

                    }






                    Form.CertificateNumber = dt.Rows[0]["CertificateNumber"].ToString();

                    if (Form.CertificateNumber != "")
                    {
                        ArrayList va = new ArrayList(Form.CertificateNumber.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.CertificateNumberControls = dt.Rows[0]["CertificateNumberControls"].ToString();

                    if (Form.CertificateNumberControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.CertificateNumberControls + "  />   </div></div>";

                    }





                    Form.PropertyDescription = dt.Rows[0]["PropertyDescription"].ToString();

                    if (Form.PropertyDescription != "")
                    {
                        ArrayList va = new ArrayList(Form.PropertyDescription.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.PropertyDescriptionControls = dt.Rows[0]["PropertyDescriptionControls"].ToString();

                    if (Form.PropertyDescriptionControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.PropertyDescriptionControls + "  />   </div></div>";

                    }






                    Form.Qty = dt.Rows[0]["Qty"].ToString();

                    if (Form.Qty != "")
                    {
                        ArrayList va = new ArrayList(Form.Qty.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }


                    Form.QtyControls = dt.Rows[0]["QtyControls"].ToString();

                    if (Form.QtyControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.QtyControls + "  />   </div></div>";

                    }





                    Form.Weight = dt.Rows[0]["Weight"].ToString();

                    if (Form.Weight != "")
                    {
                        ArrayList va = new ArrayList(Form.Weight.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }


                    Form.WeightControls = dt.Rows[0]["WeightControls"].ToString();

                    if (Form.WeightControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.WeightControls + "  />   </div></div>";

                    }







                    Form.OwnerShip = dt.Rows[0]["OwnerShip"].ToString();

                    if (Form.OwnerShip != "")
                    {
                        ArrayList va = new ArrayList(Form.OwnerShip.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.OwnerShipControls = dt.Rows[0]["OwnerShipControls"].ToString();

                    if (Form.OwnerShipControls != "")
                    {
                        data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.OwnerShipControls + "  />   </div></div>";

                    }

                    Form.OwnerShipValues = dt.Rows[0]["OwnerShipValues"].ToString();

                    if (Form.OwnerShipValues != "")
                    {
                        data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control' name='multiple'  value=" + Form.OwnerShipValues + "  />   </div></div>";

                    }


                    Form.Remark = dt.Rows[0]["Remark"].ToString();

                    if (Form.Remark != "")
                    {
                        ArrayList va = new ArrayList(Form.Remark.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.RemarkControls = dt.Rows[0]["RemarkControls"].ToString();

                    if (Form.RemarkControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.RemarkControls + "  />   </div></div>";

                    }

                    Form.RemarkValues = dt.Rows[0]["RemarkValues"].ToString();







                    Form.Nomination = dt.Rows[0]["Nomination"].ToString();

                    if (Form.Nomination != "")
                    {
                        ArrayList va = new ArrayList(Form.Nomination.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.NominationControls = dt.Rows[0]["NominationControls"].ToString();

                    if (Form.NominationControls != "")
                    {
                        data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.NominationControls + "  />   </div></div>";

                    }


                    Form.NominationValues = dt.Rows[0]["NominationValues"].ToString();

                    if (Form.NominationValues != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='multiple'  value=" + Form.NominationValues + "  />   </div></div>";

                    }

                    Form.NomineeDetails = dt.Rows[0]["NomineeDetails"].ToString();

                    if (Form.NomineeDetails != "")
                    {
                        ArrayList va = new ArrayList(Form.NomineeDetails.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.NomineeDetailsControls = dt.Rows[0]["NomineeDetailsControls"].ToString();

                    if (Form.NomineeDetailsControls != "")
                    {
                        data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.NomineeDetailsControls + "  />   </div></div>";

                    }







                    Form.Name = dt.Rows[0]["Name"].ToString();

                    if (Form.Name != "")
                    {
                        ArrayList va = new ArrayList(Form.Name.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.NameControls = dt.Rows[0]["NameControls"].ToString();

                    if (Form.NameControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.NameControls + "  />   </div></div>";

                    }





                    Form.RegisteredAddress = dt.Rows[0]["RegisteredAddress"].ToString();

                    if (Form.RegisteredAddress != "")
                    {
                        ArrayList va = new ArrayList(Form.RegisteredAddress.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }


                    Form.RegisteredAddressControls = dt.Rows[0]["RegisteredAddressControls"].ToString();

                    if (Form.RegisteredAddressControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.RegisteredAddressControls + "  />   </div></div>";

                    }





                    Form.PermanentAddress = dt.Rows[0]["PermanentAddress"].ToString();

                    if (Form.PermanentAddress != "")
                    {

                        ArrayList va = new ArrayList(Form.PermanentAddress.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }


                    Form.PermanentAddressControls = dt.Rows[0]["PermanentAddressControls"].ToString();

                    if (Form.PermanentAddressControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.PermanentAddressControls + "  />   </div></div>";

                    }








                    Form.Identity_proof = dt.Rows[0]["Identity_proof"].ToString();


                    if (Form.Identity_proof != "")
                    {
                        ArrayList va = new ArrayList(Form.Identity_proof.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }


                    Form.Identity_proofControls = dt.Rows[0]["Identity_proofControls"].ToString();

                    if (Form.Identity_proofControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.Identity_proofControls + "  />   </div></div>";

                    }







                    Form.Identity_proof_value = dt.Rows[0]["Identity_proof_value"].ToString();

                    if (Form.Identity_proof_value != "")
                    {
                        ArrayList va = new ArrayList(Form.Identity_proof_value.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }


                    Form.Identity_proof_valueControls = dt.Rows[0]["Identity_proof_valueControls"].ToString();


                    if (Form.Identity_proof_valueControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.Identity_proof_valueControls + "  />   </div></div>";

                    }





                    Form.Alt_Identity_proof = dt.Rows[0]["Alt_Identity_proof"].ToString();

                    if (Form.Alt_Identity_proof != "")
                    {
                        ArrayList va = new ArrayList(Form.Alt_Identity_proof.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.Alt_Identity_proofControls = dt.Rows[0]["Alt_Identity_proofControls"].ToString();

                    if (Form.Alt_Identity_proofControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.Alt_Identity_proofControls + "  />   </div></div>";

                    }





                    Form.Alt_Identity_proof_value = dt.Rows[0]["Alt_Identity_proof_value"].ToString();

                    if (Form.Alt_Identity_proof_value != "")
                    {
                        ArrayList va = new ArrayList(Form.Alt_Identity_proof_value.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.Alt_Identity_proof_valueControls = dt.Rows[0]["Alt_Identity_proof_valueControls"].ToString();


                    if (Form.Alt_Identity_proof_valueControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.Alt_Identity_proof_valueControls + "  />   </div></div>";

                    }





                    Form.Phone = dt.Rows[0]["Phone"].ToString();

                    if (Form.Phone != "")
                    {
                        ArrayList va = new ArrayList(Form.Phone.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.PhoneControls = dt.Rows[0]["PhoneControls"].ToString();

                    if (Form.PhoneControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.PhoneControls + "  />   </div></div>";

                    }





                    Form.Mobile = dt.Rows[0]["Mobile"].ToString();

                    if (Form.Mobile != "")
                    {
                        ArrayList va = new ArrayList(Form.Mobile.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.MobileControls = dt.Rows[0]["MobileControls"].ToString();
                    if (Form.MobileControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control' value=" + Form.MobileControls + "  />   </div></div>";

                    }




                    Form.Amount = dt.Rows[0]["Amount"].ToString();

                    if (Form.Amount != "")
                    {
                        ArrayList va = new ArrayList(Form.Amount.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                            }


                        }

                    }

                    Form.AmountControls = dt.Rows[0]["AmountControls"].ToString();
                    if (Form.AmountControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.AmountControls + "  />   </div></div>";

                    }




                    string query2 = updatequery;


                    f = data;

                }


            }
            

            return f;
        }




    









    }








}

