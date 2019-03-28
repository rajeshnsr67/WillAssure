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
    public class UpdateAlternateBeneficiaryController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateAlternateBeneficiary
        public ActionResult UpdateAlternateBeneficiaryIndex(int NestId)
        {
            if (Session.SessionID == null)
            {
                return View("~/Views/LoginPage/LoginPageContent.cshtml");
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
            AlternateBeneficiaryModel ABM = new AlternateBeneficiaryModel();
            ABM.lnk_bd_id = NestId;

            con.Open();
            string query = "select * from alternate_Beneficiary";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
         
            ABM.First_Name = dt.Rows[0]["First_Name"].ToString();
            ABM.Last_Name =  dt.Rows[0]["Last_Name"].ToString();
            ABM.Middle_Name =dt.Rows[0]["Middle_Name"].ToString();
            ABM.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
            ABM.Mobile = dt.Rows[0]["Mobile"].ToString();
            ABM.Relationship =  dt.Rows[0]["Relationship"].ToString();
            ABM.Marital_Status = dt.Rows[0]["Marital_Status"].ToString();
            ABM.Religion = dt.Rows[0]["Religion"].ToString();
            ABM.Identity_Proof = dt.Rows[0]["Identity_Proof"].ToString();
            ABM.Identity_Proof_Value = dt.Rows[0]["Identity_Proof_Value"].ToString();
            ABM.Alt_Identity_Proof = dt.Rows[0]["Alt_Identity_Proof"].ToString();
            ABM.Alt_Identity_Proof_Value = dt.Rows[0]["Alt_Identity_Proof_Value"].ToString();
            ABM.Address1 = dt.Rows[0]["Address1"].ToString();
            ABM.Address2 = dt.Rows[0]["Address2"].ToString();
            ABM.Address3 = dt.Rows[0]["Address3"].ToString();
            ABM.citytext = dt.Rows[0]["City"].ToString();
            ABM.State = dt.Rows[0]["State"].ToString();
            ABM.Pin =  dt.Rows[0]["Pin"].ToString(); 

            return View("~/Views/UpdateAlternateBeneficiary/UpdateAlternateBeneficiaryPageContent.cshtml",ABM);
        }



        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state order by statename asc ";
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
            string query = "select distinct * from tbl_city where state_id = '" + response + "' order by city_name asc ";
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



        public ActionResult UpdatingAlternateBeneficiary(AlternateBeneficiaryModel ABM)
        {
            // roleassignment
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


            //end

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUD_alternate_Beneficiary", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@lnk_bd_id", ABM.lnk_bd_id);
            cmd.Parameters.AddWithValue("@bpId", ABM.bpId);
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


            return View("~/Views/UpdateAlternateBeneficiary/UpdateAlternateBeneficiaryPageContent.cshtml");
        }
    }
}