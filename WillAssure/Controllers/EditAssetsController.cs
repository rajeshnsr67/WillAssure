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
    public class EditAssetsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: EditAssets
        public ActionResult EditAssetsIndex()
        {
            return View("~/Views/EditAssets/EditAssetsPageContent.cshtml");
        }

        public string BindAssetData()
        {
            con.Open();
            string query = "select * from AssetsInfo";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiId"].ToString() + "</td>"

                                + "<td>" + dt.Rows[i]["amId"].ToString() + "</td>"
                             
                                + "<td>" + dt.Rows[i]["DueDate"].ToString() + ""
                                + "" + dt.Rows[i]["DueDateControls"].ToString() + ""
                                + "" + dt.Rows[i]["DueDateValues"].ToString() + ""
                                + "" + dt.Rows[i]["CurrentStatus"].ToString() + ""
                                + "" + dt.Rows[i]["CurrentStatusControls"].ToString() + ""
                                + "" + dt.Rows[i]["CurrentStatusValues"].ToString() + ""
                                + "" + dt.Rows[i]["IssuedBy"].ToString() + ""
                                + "" + dt.Rows[i]["IssuedByControls"].ToString() + ""
                                + "" + dt.Rows[i]["IssuedByValues"].ToString() + ""
                                + "" + dt.Rows[i]["Location"].ToString() + ""
                                + "" + dt.Rows[i]["LocationControls"].ToString() + ""
                                + "" + dt.Rows[i]["LocationValues"].ToString() + ""
                                + "" + dt.Rows[i]["Identifier"].ToString() + ""
                                + "" + dt.Rows[i]["IdentifierControls"].ToString() + ""
                                + "" + dt.Rows[i]["IdentifierValues"].ToString() + ""
                                + "" + dt.Rows[i]["assetsValue"].ToString() + ""
                                + "" + dt.Rows[i]["assetsValueControls"].ToString() + ""
                                + "" + dt.Rows[i]["assetsValueValues"].ToString() + ""
                                + "" + dt.Rows[i]["CertificateNumber"].ToString() + ""
                                + "" + dt.Rows[i]["CertificateNumberControls"].ToString() + ""
                                + "" + dt.Rows[i]["CertificateNumberValues"].ToString() + ""
                                + "" + dt.Rows[i]["PropertyDescription"].ToString() + ""
                                + "" + dt.Rows[i]["PropertyDescriptionControls"].ToString() + ""
                                + "" + dt.Rows[i]["PropertyDescriptionValues"].ToString() + ""
                                + "" + dt.Rows[i]["Qty"].ToString() + ""
                                + "" + dt.Rows[i]["QtyControls"].ToString() + ""
                                + "" + dt.Rows[i]["QtyValues"].ToString() + ""
                                + "" + dt.Rows[i]["Weight"].ToString() + ""
                                + "" + dt.Rows[i]["WeightControls"].ToString() + ""
                                + "" + dt.Rows[i]["WeightValues"].ToString() + ""
                                + "" + dt.Rows[i]["OwnerShip"].ToString() + ""
                                + "" + dt.Rows[i]["OwnerShipControls"].ToString() + ""
                                + "" + dt.Rows[i]["OwnerShipValues"].ToString() + ""
                                + "" + dt.Rows[i]["Remark"].ToString() + ""
                                + "" + dt.Rows[i]["RemarkControls"].ToString() + ""
                                + "" + dt.Rows[i]["RemarkValues"].ToString() + ""
                                + "" + dt.Rows[i]["Nomination"].ToString() + ""
                                + "" + dt.Rows[i]["NominationControls"].ToString() + ""
                                + "" + dt.Rows[i]["NominationValues"].ToString() + ""
                                + "" + dt.Rows[i]["NomineeDetails"].ToString() + ""
                                + "" + dt.Rows[i]["NomineeDetailsControls"].ToString() + ""
                                + "" + dt.Rows[i]["NomineeDetailsValues"].ToString() + ""
                                + "" + dt.Rows[i]["Name"].ToString() + ""
                                + "" + dt.Rows[i]["NameControls"].ToString() + ""
                                + "" + dt.Rows[i]["NameValues"].ToString() + ""
                                + "" + dt.Rows[i]["RegisteredAddress"].ToString() + ""
                                + "" + dt.Rows[i]["RegisteredAddressControls"].ToString() + ""
                                + "" + dt.Rows[i]["RegisteredAddressValues"].ToString() + ""
                                + "" + dt.Rows[i]["PermanentAddress"].ToString() + ""
                                + "" + dt.Rows[i]["PermanentAddressControls"].ToString() + ""
                                + "" + dt.Rows[i]["PermanentAddressValues"].ToString() + ""
                                + "" + dt.Rows[i]["Identity_proof"].ToString() + ""
                                + "" + dt.Rows[i]["Identity_proofControls"].ToString() + ""
                                + "" + dt.Rows[i]["Identity_proofValues"].ToString() + ""
                                + "" + dt.Rows[i]["Identity_proof_value"].ToString() + ""
                                + "" + dt.Rows[i]["Identity_proof_valueControls"].ToString() + ""
                                + "" + dt.Rows[i]["Identity_proof_valueValues"].ToString() + ""
                                + "" + dt.Rows[i]["Alt_Identity_proof"].ToString() + ""
                                + "" + dt.Rows[i]["Alt_Identity_proofControls"].ToString() + ""
                                + "" + dt.Rows[i]["Alt_Identity_proofValues"].ToString() + ""
                                + "" + dt.Rows[i]["Phone"].ToString() + ""
                                + "" + dt.Rows[i]["Alt_Identity_proof_valueControls"].ToString() + ""
                                + "" + dt.Rows[i]["Alt_Identity_proof_valueValues"].ToString() + ""
                                + "" + dt.Rows[i]["Phone"].ToString() + ""
                                + "" + dt.Rows[i]["PhoneControls"].ToString() + ""
                                + "" + dt.Rows[i]["PhoneValues"].ToString() + ""
                                + "" + dt.Rows[i]["Mobile"].ToString() + ""
                                + "" + dt.Rows[i]["MobileControls"].ToString() + ""
                                + "" + dt.Rows[i]["MobileValues"].ToString() + ""
                                + "" + dt.Rows[i]["Amount"].ToString() + ""
                                + "" + dt.Rows[i]["AmountControls"].ToString() + ""
                                + "" + dt.Rows[i]["AmountValues"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button></td>    </tr>";

                }
            }

            return data;
        }


        public string DeleteAssetData(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            string query = "delete from AssetsInfo where aiId = '" + index + "'";
            SqlCommand cmd = new SqlCommand(query,con);
           
            cmd.ExecuteNonQuery();
            con.Close();




            con.Open();
            string query2 = "select * from AssetsInfo";
            SqlDataAdapter da = new SqlDataAdapter(query2, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["aiId"].ToString() + "</td>"

                                + "<td>" + dt.Rows[i]["amId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["assetsCode"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["DueDate"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["DueDateControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["DueDateValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["CurrentStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["CurrentStatusControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["CurrentStatusValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IssuedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IssuedByControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IssuedByValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Location"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["LocationControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["LocationValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identifier"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IdentifierControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IdentifierValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["assetsValue"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["assetsValueControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["assetsValueValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["CertificateNumber"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["CertificateNumberControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["CertificateNumberValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["PropertyDescription"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["PropertyDescriptionControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["PropertyDescriptionValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Qty"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["QtyControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["QtyValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Weight"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["WeightControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["WeightValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["OwnerShip"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["OwnerShipControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["OwnerShipValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Remark"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["RemarkControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["RemarkValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Nomination"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["NominationControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["NominationValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["NomineeDetails"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["NomineeDetailsControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["NomineeDetailsValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Name"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["NameControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["NameValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["RegisteredAddress"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["RegisteredAddressControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["RegisteredAddressValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["PermanentAddress"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["PermanentAddressControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["PermanentAddressValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_proofControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_proofValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_proof_value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_proof_valueControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_proof_valueValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_proofControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_proofValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_proof_value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_proof_valueControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_proof_valueValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Phone"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["PhoneControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["PhoneValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Mobile"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["MobileControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["MobileValues"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Amount"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["AmountControls"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["AmountValues"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger '>Delete</button></td>    </tr>";

                }
            }

            return data;
        }



        public int UpdateAssetData()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }



    }
}