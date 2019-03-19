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
    public class AddNomineeController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddNominee
        public ActionResult AddNomineeIndex()
        {
            return View("~/Views/AddNominee/AddNomineePageContent.cshtml");
        }


        public ActionResult InsertNomineeData(NomineeModel NM)
        {





            if (Session["aiid"] != null && Session["tid"] != null)
            {
                NM.aid = Convert.ToInt32(Session["aiid"]);
                NM.tId = Convert.ToInt32(Session["tid"]);
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDNominee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "insert");
                cmd.Parameters.AddWithValue("@First_Name", NM.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", NM.Last_Name);
                cmd.Parameters.AddWithValue("@Middle_Name", NM.Middle_Name);
                cmd.Parameters.AddWithValue("@DOB", NM.DOB);
                cmd.Parameters.AddWithValue("@Mobile", NM.Mobile);
                cmd.Parameters.AddWithValue("@Relationship", NM.RelationshipTxt);
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
                cmd.Parameters.AddWithValue("@createdBy", Convert.ToInt32(Session["uid"]));
                cmd.Parameters.AddWithValue("@documentId", NM.documentId);
                cmd.Parameters.AddWithValue("@Description_of_Assets", NM.Description_of_Assets);
                cmd.ExecuteNonQuery();
                con.Close();

                ViewBag.Message = "Verified";
            }
            else
            {

                Response.Write("<script>alert('Please Fill Out AssetInformation and Testator Form First....!')</script>");


            }




            return View("~/Views/AddNominee/AddNomineePageContent.cshtml");
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