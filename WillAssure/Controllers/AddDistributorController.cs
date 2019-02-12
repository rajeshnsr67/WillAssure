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
        [HttpPost]
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
            cmd.Parameters.AddWithValue("@City", DFM.citytext);
            cmd.Parameters.AddWithValue("@State", DFM.statetext);
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

            

            con.Open();
            string query = "select TOP 1 * FROM  companyDetails ORDER BY compId DESC";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["compId"] = Convert.ToInt32(dt.Rows[0]["compId"]); 
            }
            con.Close();

            

          

            ViewBag.Message = "Verified";

            return View("~/Views/AddDistributor/AddDistributorPageContent.cshtml");
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


        public ActionResult InsertUserFormData(DistributorFormModel DFM)
        {


            con.Open();

            SqlCommand cmd = new SqlCommand();




            con.Close();


            return View("~/Views/AddDistributor/AddDistributorPageContent.cshtml");
        }



    }
}