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
    public class UpdateBeneficiaryController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateBeneficiary


        public ActionResult UpdateBeneficiaryIndex(int NestId)
        {
            BeneficiaryModel BM = new BeneficiaryModel();

            con.Open();
            string query = "select * from BeneficiaryDetails where bpId = '" + NestId + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {

                BM.bpId = NestId;
                BM.First_Name = dt.Rows[0]["First_Name"].ToString();
                BM.Last_Name = dt.Rows[0]["Last_Name"].ToString();
                BM.Middle_Name = dt.Rows[0]["Middle_Name"].ToString();
                BM.DOB = dt.Rows[0]["DOB"].ToString();
                BM.Mobile = dt.Rows[0]["Mobile"].ToString();
                BM.Relationship = dt.Rows[0]["Relationship"].ToString();
                BM.Marital_Status = dt.Rows[0]["Marital_Status"].ToString();
                BM.Religion = dt.Rows[0]["Religion"].ToString();
                BM.Identity_proof =  dt.Rows[0]["Identity_proof"].ToString();
                BM.Identity_proof_value = dt.Rows[0]["Identity_proof_value"].ToString();
                BM.Alt_Identity_proof = dt.Rows[0]["Alt_Identity_proof"].ToString();
                BM.Alt_Identity_proof_value = dt.Rows[0]["Alt_Identity_proof_value"].ToString();
                BM.Address1 = dt.Rows[0]["Address1"].ToString();
                BM.Address2 = dt.Rows[0]["Address2"].ToString();
                BM.Address3 = dt.Rows[0]["Address3"].ToString();
                BM.City = dt.Rows[0]["City"].ToString();
                BM.State = dt.Rows[0]["State"].ToString();
                BM.Pin = dt.Rows[0]["Pin"].ToString();
                BM.aid = 0;
                BM.tid = 0;
                BM.createdBy = 0;
                BM.documentId = 0;
                BM.beneficiary_type = dt.Rows[0]["beneficiary_type"].ToString(); 

            }



            return View("~/Views/UpdateBeneficiary/UpdateBeneficiary.cshtml",BM);
        }



        public ActionResult UpdatingBeneficiaryData(BeneficiaryModel BM)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDBeneficiaryDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@bpId  ", BM.bpId);
            cmd.Parameters.AddWithValue("@First_Name ", BM.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", BM.Last_Name);
            cmd.Parameters.AddWithValue("@Middle_Name", BM.Middle_Name);
            cmd.Parameters.AddWithValue("@DOB", BM.DOB);
            cmd.Parameters.AddWithValue("@Mobile", BM.Mobile);
            cmd.Parameters.AddWithValue("@Relationship", BM.RelationshipTxt);
            cmd.Parameters.AddWithValue("@Marital_Status", BM.Marital_Status);
            cmd.Parameters.AddWithValue("@Religion", BM.Religion);
            cmd.Parameters.AddWithValue("@Identity_proof", BM.Identity_proof);
            cmd.Parameters.AddWithValue("@Identity_proof_value", BM.Identity_proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof", BM.Alt_Identity_proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", BM.Alt_Identity_proof_value);
            cmd.Parameters.AddWithValue("@Address1", BM.Address1);
            cmd.Parameters.AddWithValue("@Address2", BM.Address2);
            cmd.Parameters.AddWithValue("@Address3", BM.Address3);
            cmd.Parameters.AddWithValue("@City", BM.City_txt);
            cmd.Parameters.AddWithValue("@State", BM.State_txt);
            cmd.Parameters.AddWithValue("@Pin", BM.Pin);
            cmd.Parameters.AddWithValue("@aid", "");
            cmd.Parameters.AddWithValue("@tid", "");
            cmd.Parameters.AddWithValue("@beneficiary_type", BM.beneficiary_type);
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



        public String BindRelationDDL()
        {

            con.Open();
            string query = "select * from relationship";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value='' >--Select--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["Rid"].ToString() + " >" + dt.Rows[i]["MemberName"].ToString() + "</option>";



                }




            }

            return data;

        }



    }
}