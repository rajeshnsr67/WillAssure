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
    public class AlternateBeneficiaryController : Controller
    {


        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AlternateBeneficiary
        public ActionResult AlternateBeneficiaryIndex()
        {
            return View("~/Views/AlternateBeneficiary/AlternateBeneficiaryPageContent.cshtml");
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


        public ActionResult InsertAlternateBeneficiaryFormData(AlternateBeneficiaryModel ABM)
        {


            int getbeneficiary = 0;

            if (Session["bpId"] != null)
            {
                getbeneficiary = 1;
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUD_alternate_Beneficiary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@bpId", Convert.ToInt32(Session["bpId"]));
                cmd.Parameters.AddWithValue("@First_Name", ABM.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", ABM.Last_Name);
                cmd.Parameters.AddWithValue("@Middle_Name", ABM.Middle_Name);
                cmd.Parameters.AddWithValue("@DOB", ABM.DOB);
                cmd.Parameters.AddWithValue("@Mobile", ABM.Mobile);
                cmd.Parameters.AddWithValue("@Relationship", ABM.Religion_ID);
                cmd.Parameters.AddWithValue("@Marital_Status", ABM.Marital_Status);
                cmd.Parameters.AddWithValue("@Religion", ABM.Religion);
                cmd.Parameters.AddWithValue("@Identity_Proof", ABM.Identity_Proof);
                cmd.Parameters.AddWithValue("@Identity_Proof_Value", ABM.Identity_Proof_Value);
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof", ABM.Alt_Identity_Proof);
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", ABM.Alt_Identity_Proof_Value);
                cmd.Parameters.AddWithValue("@Address1", ABM.Address1);
                cmd.Parameters.AddWithValue("@Address2", ABM.Address2);
                cmd.Parameters.AddWithValue("@Address3", ABM.Address3);
                cmd.Parameters.AddWithValue("@City", ABM.citytext);
                cmd.Parameters.AddWithValue("@State", ABM.statetext);
                cmd.Parameters.AddWithValue("@Pin", ABM.Pin);
                cmd.ExecuteNonQuery();
                con.Close();
                ViewBag.Message = "Verified";
            }
            else
            {
                getbeneficiary = 2;
                ViewBag.Message = "link";


            }



            // Document Rules

            //get latest id first
            con.Open();
            string getquery = "select top 1 * from documentRules order by wdId desc";
            SqlDataAdapter da = new SqlDataAdapter(getquery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int getruleid = 0;
            if (dt.Rows.Count > 0)
            {
                getruleid = Convert.ToInt32(dt.Rows[0]["wdId"]);
            }
            con.Close();

            //end



            con.Open();
            string rulequery = "update documentRules set AlternateBenficiaries = " + getbeneficiary + "  where wdId = " + getruleid + " ";
            SqlCommand cmd2 = new SqlCommand(rulequery, con);
            cmd2.ExecuteNonQuery();
            con.Close();
            //end




            return View("~/Views/AlternateBeneficiary/AlternateBeneficiaryPageContent.cshtml");
        }

    }
}