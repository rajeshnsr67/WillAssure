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
    public class AddDistributorController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddDistributor
        public ActionResult AddDistributorIndex()
        {
            return View("~/Views/AddDistributor/AddDistributorPageContent.cshtml");
        }

        public ActionResult InsertDistributorFormData(DistributorFormModel DFM)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CrudcompanyDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "insert");
            cmd.Parameters.AddWithValue("@companyName ", DFM.companyName );
            cmd.Parameters.AddWithValue("@ownerName", DFM.ownerName);
            cmd.Parameters.AddWithValue("@ownerMobileNo", DFM.ownerMobileNo);
            cmd.Parameters.AddWithValue("@Address1", DFM.Address1 );
            cmd.Parameters.AddWithValue("@Address2", DFM.Address2);
            cmd.Parameters.AddWithValue("@City", DFM.City);
            cmd.Parameters.AddWithValue("@State", DFM.State);
            cmd.Parameters.AddWithValue("@Pin", DFM.Pin );
            cmd.Parameters.AddWithValue("@GST_NO", DFM.GST_NO );
            cmd.Parameters.AddWithValue("@Identity_Proof", DFM.Identity_Proof);
            cmd.Parameters.AddWithValue("@Identity_Proof_Value", DFM.Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", DFM.Alt_Identity_Proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value",DFM.Alt_Identity_Proof_Value );
            cmd.Parameters.AddWithValue("@contactPerson", DFM.contactPerson);
            cmd.Parameters.AddWithValue("@contactMobileNo",DFM.contactMobileNo );
            cmd.Parameters.AddWithValue("@contactMailId",DFM.contactMailId );
            cmd.Parameters.AddWithValue("@bankName", DFM.bankName);
            cmd.Parameters.AddWithValue("@Branch", DFM.Branch);
            cmd.Parameters.AddWithValue("@accountNumber",DFM.accountNumber );
            cmd.Parameters.AddWithValue("@IFSC_Code",DFM.IFSC_Code );
            cmd.Parameters.AddWithValue("@accountName", DFM.accountName);
            cmd.Parameters.AddWithValue("@Referred_By", DFM.Referred_By);
            cmd.Parameters.AddWithValue("@leadgeneratedBy",DFM.leadgeneratedBy );
            cmd.Parameters.AddWithValue("@leadconvertedBy",DFM.leadconvertedBy );
            cmd.Parameters.AddWithValue("@relationshipManager", DFM.relationshipManager );
            cmd.Parameters.AddWithValue("@leadStatus", DFM.leadStatus );
            cmd.Parameters.AddWithValue("@leadRemark", DFM.leadRemark);
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Write("<script type='text/javascript'>$(document).ready(function(){$('#alert-success').trigger('click');});</ script > ");


            return View("~/Views/AddDistributor/AddDistributorPageContent.cshtml");
        }



        public ActionResult InsertUserFormData(DistributorFormModel DFM)
        {


            con.Open();

            SqlCommand cmd = new SqlCommand();




            con.Close();


            return View("~/Views/AddDistributor/AddDistributorPageContent.cshtml");
        }



    }
}