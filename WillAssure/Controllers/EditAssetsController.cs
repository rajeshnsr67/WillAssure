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
            return View("~/Views/EditAssets/EditAssetsPageContent.cshtml");
        }

        public string BindAssetData()
        {

            // check roles
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








            }

            con.Close();





            //end
            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[8].Action;

            }






            con.Open();
            string query = "select * from AssetsInfo";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {
                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
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
                                    + "<td><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
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
                                    + "<td><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
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
                                    + "<td><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
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
                                    + "" + dt.Rows[i]["AmountValues"].ToString() + "</td>";
                                 

                    }
                }



              
            }

            return data;
        }


        public string DeleteAssetData(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            string query2 = "delete from AssetsInfo where aiId = '" + index + "'";
            SqlCommand cmd2 = new SqlCommand(query2,con);
           
            cmd2.ExecuteNonQuery();
            con.Close();


            // check roles
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








            }

            con.Close();





            //end
            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[8].Action;

            }






            con.Open();
            string query = "select * from AssetsInfo";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {
                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
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
                                    + "<td><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
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
                                    + "<td><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "'    class='btn btn-danger deletenotification '>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
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
                                    + "<td><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["aiId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
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
                                    + "" + dt.Rows[i]["AmountValues"].ToString() + "</td>";


                    }
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