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
    public class UpdateNomineeController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateNominee
        public ActionResult UpdateNomineeIndex(int NestId)
        {
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
            NomineeModel NM = new NomineeModel();
            con.Open();
            string query = "select * from Nominee";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
          

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NM.nId = NestId;
                 NM.First_Name =dt.Rows[i]["First_Name"].ToString();
                 NM.Last_Name = dt.Rows[i]["Last_Name"].ToString();
                 NM.Middle_Name = dt.Rows[i]["Middle_Name"].ToString();
                 NM.DOB = dt.Rows[i]["DOB"].ToString();
                 NM.Mobile = dt.Rows[i]["Mobile"].ToString();
                 NM.Relationship = dt.Rows[i]["Relationship"].ToString();
                 NM.Marital_Status = dt.Rows[i]["Marital_Status"].ToString();
                 NM.Religion = dt.Rows[i]["Religion"].ToString();
                 NM.Identity_Proof = dt.Rows[i]["Identity_Proof"].ToString();
                 NM.Identity_Proof_Value = dt.Rows[i]["Identity_Proof_Value"].ToString();
                 NM.Alt_Identity_Proof = dt.Rows[i]["Alt_Identity_Proof"].ToString();
                 NM.Alt_Identity_Proof_Value = dt.Rows[i]["Alt_Identity_Proof_Value"].ToString();
                 NM.Address1 = dt.Rows[i]["Address1"].ToString();
                 NM.Address2 = dt.Rows[i]["Address2"].ToString();
                 NM.Address3 = dt.Rows[i]["Address3"].ToString();
                 NM.City = dt.Rows[i]["City"].ToString();
                 NM.State =dt.Rows[i]["State"].ToString();
                 NM.Pin =dt.Rows[i]["Pin"].ToString();
                 NM.aid = Convert.ToInt32(dt.Rows[i]["aid"]);
                 NM.tId = Convert.ToInt32(dt.Rows[i]["tId"]);
                
                 NM.createdBy = dt.Rows[i]["createdBy"].ToString();
                 NM.documentId =Convert.ToInt32(dt.Rows[i]["documentId"]);
                 NM.Description_of_Assets = dt.Rows[i]["Description_of_Assets"].ToString();

                               

                }
            }



            return View("~/Views/UpdateNominee/UpdateNomineePageContent.cshtml",NM);
        }




        public ActionResult UpdatingNominee(NomineeModel NM)
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

            if (Session["aiId"] != null)
            {
                NM.aid = Convert.ToInt32(Session["aiId"]);

            }
            else
            {
                NM.aid = 0;
            }

            if (Session["tid"] != null)
            {
                NM.tId = Convert.ToInt32(Session["tid"]);

            }
            else
            {
                NM.tId = 0;
            }

            if (Session["Document_Created_By"] != null)
            {
                NM.createdBy = Session["Document_Created_By"].ToString();
            }
            else
            {
                NM.createdBy = "0";
            }



            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDNominee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@nId", NM.nId);
            cmd.Parameters.AddWithValue("@First_Name", NM.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", NM.Last_Name);
            cmd.Parameters.AddWithValue("@Middle_Name", NM.Middle_Name);
            cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(NM.DOB));
            cmd.Parameters.AddWithValue("@Mobile", NM.Mobile);
            cmd.Parameters.AddWithValue("@Relationship", NM.Relationship);
            cmd.Parameters.AddWithValue("@Marital_Status", NM.Marital_Status);
            cmd.Parameters.AddWithValue("@Religion", NM.Religion);
            cmd.Parameters.AddWithValue("@Identity_Proof", NM.Identity_Proof);
            cmd.Parameters.AddWithValue("@Identity_Proof_Value", NM.Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", NM.Alt_Identity_Proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", NM.Alt_Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Address1", NM.Address1);
            cmd.Parameters.AddWithValue("@Address2", NM.Address2);
            cmd.Parameters.AddWithValue("@Address3", NM.Address3);
            cmd.Parameters.AddWithValue("@City", NM.citytext);
            cmd.Parameters.AddWithValue("@State", NM.statetext);
            cmd.Parameters.AddWithValue("@Pin", NM.Pin);
            cmd.Parameters.AddWithValue("@aid", NM.aid);
            cmd.Parameters.AddWithValue("@tId", NM.tId);
            cmd.Parameters.AddWithValue("@createdBy", NM.createdBy);
            cmd.Parameters.AddWithValue("@documentId", NM.documentId);
            cmd.Parameters.AddWithValue("@Description_of_Assets", NM.Description_of_Assets);
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.Message = "Verified";

          
            return View("~/Views/UpdateNominee/UpdateNomineePageContent.cshtml");
        }




        public String BindStateDDL()
        {

            con.Open();
            string query = "select * from tbl_state";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value='0'>--Select--</option>";

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