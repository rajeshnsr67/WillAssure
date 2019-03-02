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
    public class AddBeneficiaryController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddBeneficiary
        public ActionResult AddBeneficiaryIndex()
        {
            return View("~/Views/AddBeneficiary/AddBeneficiaryPageContent.cshtml");
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




        public ActionResult InsertBeneficiaryData(BeneficiaryModel BM)
        {

            if (Session["aiId"] != null)
            {
                BM.aid = Convert.ToInt32(Session["aiId"]);
            }

            if (Session["tid"] != null)
            {
                BM.tid = Convert.ToInt32(Session["tId"]);
            }

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDBeneficiaryDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "insert");
            cmd.Parameters.AddWithValue("@First_Name ", BM.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", BM.Last_Name);
            cmd.Parameters.AddWithValue("@Middle_Name", BM.Middle_Name);
            cmd.Parameters.AddWithValue("@DOB", BM.DOB);
            cmd.Parameters.AddWithValue("@Mobile", BM.Mobile);
            cmd.Parameters.AddWithValue("@Relationship", BM.RelationshipTxt);
            cmd.Parameters.AddWithValue("@Marital_Status", BM.Marital_Status);
            cmd.Parameters.AddWithValue("@Religion", BM.Religion);
            cmd.Parameters.AddWithValue("@Identity_proof", BM.Identity_proof);
            cmd.Parameters.AddWithValue("@Identity_proof_value", BM.Identity_proof_value);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof", BM.Alt_Identity_proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", BM.Alt_Identity_proof_value);
            cmd.Parameters.AddWithValue("@Address1",BM.Address1);
            cmd.Parameters.AddWithValue("@Address2",BM.Address2);
            cmd.Parameters.AddWithValue("@Address3",BM.Address3);
            cmd.Parameters.AddWithValue("@City", BM.City_txt);
            cmd.Parameters.AddWithValue("@State",BM.State_txt);
            cmd.Parameters.AddWithValue("@Pin",BM.Pin);
            cmd.Parameters.AddWithValue("@aid", BM.aid);
            cmd.Parameters.AddWithValue("@tid", BM.tid);
            cmd.Parameters.AddWithValue("@beneficiary_type",BM.beneficiary_type);
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.Message = "RecordsInsert";

            return View("~/Views/AddBeneficiary/AddBeneficiaryPageContent.cshtml");
        }



        public String BindRelationDDL()
        {

            con.Open();
            string query = "select * from relationship";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value='0' >--Select--</option>";

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