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
    public class AddAssetInfoController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddAssetInfo
        public ActionResult AddAssetInfoIndex()
        {
            return View("~/Views/AddAssetInfo/AddAssetInfoPageContent.cshtml");
        }

        public ActionResult AddAssetInfoData(AssetsModel AM)
        {

            if (Session["amId"] != null)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_AssetsInfoCRUD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@amId", Session["amId"]);
                cmd.Parameters.AddWithValue("@assetsCode", AM.assetsCode);
                cmd.Parameters.AddWithValue("@DueDate", AM.dueDate);
                cmd.Parameters.AddWithValue("@CurrentStatus", AM.CurrentStatus);
                cmd.Parameters.AddWithValue("@IssuedBy", AM.IssuedBy);
                cmd.Parameters.AddWithValue("@Location", AM.Location);
                cmd.Parameters.AddWithValue("@Identifier", AM.Identifier);
                cmd.Parameters.AddWithValue("@assetsValue", AM.assetsValue);
                cmd.Parameters.AddWithValue("@CertificateNumber", AM.CertificateNumber);
                cmd.Parameters.AddWithValue("@PropertyDescription", AM.PropertyDescription);
                cmd.Parameters.AddWithValue("@Qty", AM.Qty);
                cmd.Parameters.AddWithValue("@Weight", AM.Weight);
                cmd.Parameters.AddWithValue("@OwnerShip", AM.OwnerShip);
                cmd.Parameters.AddWithValue("@Remark", AM.Remark);
                cmd.Parameters.AddWithValue("@Nomination", AM.Nomination);
                cmd.Parameters.AddWithValue("@NomineeDetails", AM.NomineeDetails);
                cmd.Parameters.AddWithValue("@Name", AM.Name);
                cmd.Parameters.AddWithValue("@RegisteredAddress", AM.RegisteredAddress);
                cmd.Parameters.AddWithValue("@PermanentAddress", AM.PermanentAddress);
                cmd.Parameters.AddWithValue("@Identity_proof", AM.Identity_proof);
                cmd.Parameters.AddWithValue("@Identity_proof_value", AM.Identity_proof_value);
                cmd.Parameters.AddWithValue("@Alt_Identity_proof", AM.Alt_Identity_proof);
                cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.Alt_Identity_proof_value);
                cmd.Parameters.AddWithValue("@Phone", AM.Phone);
                cmd.Parameters.AddWithValue("@Mobile", AM.Mobile);
                cmd.Parameters.AddWithValue("@Amount", AM.Amount);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            else
            {
                Response.Write("<script>alert('Add Asset Category First')</script>");
            }


           


            return View("~/Views/AddAssetInfo/AddAssetInfoPageContent.cshtml");
        }


    }
}