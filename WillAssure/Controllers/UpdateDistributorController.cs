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
    public class UpdateDistributorController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: UpdateDistributor
        public ActionResult UpdateDistributorIndex(int NestId)
        {
            DistributorFormModel DFM = new DistributorFormModel();

            con.Open();
            string query = "select * from companyDetails where compId = '" + NestId + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                DFM.compId = NestId;
                DFM.companyName = dt.Rows[0]["companyName"].ToString();
                DFM.ownerName = dt.Rows[0]["ownerName"].ToString();
                DFM.ownerMobileNo = dt.Rows[0]["ownerMobileNo"].ToString();
                DFM.Address1 = dt.Rows[0]["Address1"].ToString();
                DFM.Address2 = dt.Rows[0]["Address2"].ToString();
                DFM.City = dt.Rows[0]["City"].ToString();
                DFM.State = dt.Rows[0]["State"].ToString();
                DFM.Pin = dt.Rows[0]["Pin"].ToString();
                DFM.GST_NO = dt.Rows[0]["GST_NO"].ToString();
                DFM.Identity_Proof = dt.Rows[0]["Identity_Proof"].ToString();
                DFM.Identity_Proof_Value = dt.Rows[0]["Identity_Proof_Value"].ToString();
                DFM.Alt_Identity_Proof = dt.Rows[0]["Alt_Identity_Proof"].ToString();
                DFM.Alt_Identity_Proof_Value = dt.Rows[0]["Alt_Identity_Proof_Value"].ToString();
                DFM.contactPerson = dt.Rows[0]["contactPerson"].ToString();
                DFM.contactMobileNo = dt.Rows[0]["contactMobileNo"].ToString();
                DFM.contactMailId= dt.Rows[0]["contactMailId"].ToString();
                DFM.bankName = dt.Rows[0]["bankName"].ToString();
                DFM.Branch = dt.Rows[0]["Branch"].ToString();
                DFM.accountNumber = dt.Rows[0]["accountNumber"].ToString();
                DFM.IFSC_Code = dt.Rows[0]["IFSC_Code"].ToString();
                DFM.accountName = dt.Rows[0]["accountName"].ToString();
                DFM.Referred_By = dt.Rows[0]["Referred_By"].ToString();
                DFM.leadgeneratedBy = dt.Rows[0]["leadgeneratedBy"].ToString();
                DFM.leadconvertedBy = dt.Rows[0]["leadconvertedBy"].ToString();
                DFM.relationshipManager = dt.Rows[0]["relationshipManager"].ToString();
                DFM.leadStatus = dt.Rows[0]["leadStatus"].ToString();
                DFM.leadRemark = dt.Rows[0]["leadRemark"].ToString();
                              


            }


            return View("~/Views/UpdateDistributor/UpdateDistributorPageContent.cshtml", DFM);
        }



        public ActionResult UpdatingDistributorData(DistributorFormModel DFM)
        {
        
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CrudcompanyDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@compId ", DFM.compId);
            cmd.Parameters.AddWithValue("@companyName ", DFM.companyName);
            cmd.Parameters.AddWithValue("@ownerName", DFM.ownerName);
            cmd.Parameters.AddWithValue("@ownerMobileNo", DFM.ownerMobileNo);
            cmd.Parameters.AddWithValue("@Address1", DFM.Address1);
            cmd.Parameters.AddWithValue("@Address2", DFM.Address2);
            cmd.Parameters.AddWithValue("@City", DFM.citytext);
            cmd.Parameters.AddWithValue("@State", DFM.statetext);
            cmd.Parameters.AddWithValue("@Pin", DFM.Pin);
            cmd.Parameters.AddWithValue("@GST_NO", DFM.GST_NO);
            cmd.Parameters.AddWithValue("@Identity_Proof", DFM.Identity_Proof);
            cmd.Parameters.AddWithValue("@Identity_Proof_Value", DFM.Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", DFM.Alt_Identity_Proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", DFM.Alt_Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@contactPerson", DFM.contactPerson);
            cmd.Parameters.AddWithValue("@contactMobileNo", DFM.contactMobileNo);
            cmd.Parameters.AddWithValue("@contactMailId", DFM.contactMailId);
            cmd.Parameters.AddWithValue("@bankName", DFM.bankName);
            cmd.Parameters.AddWithValue("@Branch", DFM.Branch);
            cmd.Parameters.AddWithValue("@accountNumber", DFM.accountNumber);
            cmd.Parameters.AddWithValue("@IFSC_Code", DFM.IFSC_Code);
            cmd.Parameters.AddWithValue("@accountName", DFM.accountName);
            cmd.Parameters.AddWithValue("@Referred_By", DFM.Referred_By);
            cmd.Parameters.AddWithValue("@leadgeneratedBy", DFM.leadgeneratedBy);
            cmd.Parameters.AddWithValue("@leadconvertedBy", DFM.leadconvertedBy);
            cmd.Parameters.AddWithValue("@relationshipManager", DFM.relationshipManager);
            cmd.Parameters.AddWithValue("@leadStatus", DFM.leadStatus);
            cmd.Parameters.AddWithValue("@leadRemark", DFM.leadRemark);
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.Message = "Verified";
            return View("~/Views/UpdateDistributor/UpdateDistributorPageContent.cshtml");
        }





        public String BindStateDDL()
        {

            con.Open();
            string query = "select * from tbl_state";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["state_id"].ToString() + " >" + dt.Rows[i]["statename"].ToString() + "</option>";



                }




            }

            return data;

        }



        public string OnChangeBindCity()
        {
            string response = Request["send"];
            con.Open();
            string query = "select * from tbl_city where state_id = '" + response + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["id"].ToString() + " >" + dt.Rows[i]["city_name"].ToString() + "</option>";



                }




            }

            return data;
        }





    }
}