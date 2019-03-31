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
using System.Globalization;

namespace WillAssure.Controllers
{
    public class AddAppointeesController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddAppointees
        public ActionResult AddAppointeesIndex()
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
            return View("/Views/AddAppointees/AddAppointeesPageContent.cshtml");
        }


        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state order by statename asc  ";
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
            string query = "select distinct * from tbl_city where state_id ='" + response + "' order by city_name asc ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value='0'>--Select--</option>";

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


        public ActionResult InsertAppointeesFormData(AppointeesModel AM)
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



            AM.documentId =0;

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDAppointees",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "insert");
            cmd.Parameters.AddWithValue("@documentId", AM.documentId);
            cmd.Parameters.AddWithValue("@Type", AM.Typetxt);
            cmd.Parameters.AddWithValue("@subType", AM.subTypetxt);
            cmd.Parameters.AddWithValue("@Name", AM.Name);
            cmd.Parameters.AddWithValue("@middleName", AM.middleName);
            cmd.Parameters.AddWithValue("@Surname", AM.Surname);
            cmd.Parameters.AddWithValue("@Identity_proof", AM.Identity_Proof);
            cmd.Parameters.AddWithValue("@Identity_proof_value", AM.Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof", AM.Alt_Identity_Proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", AM.Alt_Identity_Proof_Value);
            DateTime dat = DateTime.ParseExact(AM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            cmd.Parameters.AddWithValue("@DOB", dat);
            cmd.Parameters.AddWithValue("@Gender", AM.Gender);
            cmd.Parameters.AddWithValue("@Occupation", AM.Occupation);
            cmd.Parameters.AddWithValue("@Relationship", AM.RelationshipTxt);
            cmd.Parameters.AddWithValue("@Address1", AM.Address1);
            cmd.Parameters.AddWithValue("@Address2", AM.Address2);
            cmd.Parameters.AddWithValue("@Address3", AM.Address3);
            cmd.Parameters.AddWithValue("@City", AM.citytext);
            cmd.Parameters.AddWithValue("@State", AM.statetext);
            cmd.Parameters.AddWithValue("@Pin", AM.Pin);
            cmd.Parameters.AddWithValue("@tid", Convert.ToInt32(Session["tid"]));
            cmd.ExecuteNonQuery();
            con.Close();
            ViewBag.Message = "Verified";

            // dropdown selection
            int AppointmentofGuardian = 0;
            if (AM.Type == "Guardian")
            {
                AppointmentofGuardian = 1;    //yes
            }
            else
            {
                AppointmentofGuardian = 2;    // no
            }

            int Numberofexecutors = 0;
            if (AM.subType == "Single")
            {
                Numberofexecutors = 1;    
            }
            if (AM.subType == "Many Joint")
            {
                Numberofexecutors = 2;    
            }
            if (AM.subType == "Many Independent")
            {
                Numberofexecutors = 3;    
            }

            //end

            // Document Rules

            //get latest id first
            con.Open();
            string getquery = "select top 1 * from documentRules order by wdId desc";
            SqlDataAdapter da = new SqlDataAdapter(getquery,con);
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
            string rulequery = "update documentRules set guardian = "+AppointmentofGuardian+" ,executors_category = "+Numberofexecutors+ " where wdId = "+getruleid+" ";
            SqlCommand cmd2 = new SqlCommand(rulequery,con);
            cmd2.ExecuteNonQuery();
            con.Close();
            //end



            con.Open();
            string query = "select top 1 * from Appointees order by apId desc";
            SqlDataAdapter da2 = new SqlDataAdapter(query,con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
               
                Session["apId"] = Convert.ToInt32(dt2.Rows[0]["apId"]);
            }
            con.Close();





            return View("/Views/AddAppointees/AddAppointeesPageContent.cshtml");
        }



    }
}