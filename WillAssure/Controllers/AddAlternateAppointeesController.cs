using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WillAssure.Models;

namespace WillAssure.Controllers
{
    public class AddAlternateAppointeesController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddAlternateAppointees
        public ActionResult AddAlternateAppointeesIndex()
        {
            return View("~/Views/AddAlternateAppointees/AddAlternateAppointeesPageContent.cshtml");
        }

        public String BindStateDDL()
        {

            con.Open();
            string query = "select * from tbl_state";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select--</option>";

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
            string data = "<option value=''>--Select--</option>";

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


        public ActionResult InsertAlternateAppointeesFormData(AlternateAppointeesModel AM)
        {



            int getAlternateGaurdian = 0;
            int getAlternateExecutors = 0;


            if (Session["apId"] != null)
            {
                getAlternateExecutors = 1;
                getAlternateGaurdian = 1;

                string apid = Session["apId"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDAlternateAppointees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@apId", Convert.ToInt32(apid.ToString()));

                cmd.Parameters.AddWithValue("@Name", AM.Name);
                cmd.Parameters.AddWithValue("@middleName", AM.middleName);
                cmd.Parameters.AddWithValue("@Surname", AM.Surname);
                cmd.Parameters.AddWithValue("@Identity_proof", AM.Identity_Proof);
                cmd.Parameters.AddWithValue("@Identity_proof_value", AM.Identity_Proof_Value);
                cmd.Parameters.AddWithValue("@Alt_Identity_proof", AM.Alt_Identity_Proof);
                cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.Alt_Identity_Proof_Value);
                cmd.Parameters.AddWithValue("@DOB", AM.DOB.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@Gender", AM.Gender);
                cmd.Parameters.AddWithValue("@Occupation", AM.Occupation);
                cmd.Parameters.AddWithValue("@Relationship", AM.RelationshipTxt);
                cmd.Parameters.AddWithValue("@Address1", AM.Address1);
                cmd.Parameters.AddWithValue("@Address2", AM.Address2);
                cmd.Parameters.AddWithValue("@Address3", AM.Address3);
                cmd.Parameters.AddWithValue("@City", AM.citytext);
                cmd.Parameters.AddWithValue("@State", AM.statetext);
                cmd.Parameters.AddWithValue("@Pin", AM.Pin);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                getAlternateExecutors = 2;
                getAlternateGaurdian = 2;

                Response.Write("<script>alert('Please Fill out Appointees Form First....!')</script>");
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
            string rulequery = "update documentRules set AlternateGaurdian = " + getAlternateGaurdian + " , AlternateExecutors  = "+getAlternateExecutors+"        where wdId = " + getruleid + " ";
            SqlCommand cmd2 = new SqlCommand(rulequery, con);
            cmd2.ExecuteNonQuery();
            con.Close();
            //end




            return View("~/Views/AddAlternateAppointees/AddAlternateAppointeesPageContent.cshtml");
        }

    }
}