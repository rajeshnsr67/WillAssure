using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WillAssure.Models;
using System.Collections;
using System.Globalization;

namespace WillAssure.Controllers
{
    public class AddAlternateAppointeesController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddAlternateAppointees
        public ActionResult AddAlternateAppointeesIndex()
        {
            if ()
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }

            if (Session["rId"] == null || Session["uuid"] == null) {

               RedirectToAction("LoginPageIndex", "LoginPage");

            }


            if (Session["apId"] == null)
            {
                ViewBag.Message = "link";
            }


         



            List<LoginModel> Lmlist = new List<LoginModel>();
            con.Open();
               string q = "select * from Assignment_Roles where RoleId = "+ Convert.ToInt32(Session["rId"]) + "";
                SqlDataAdapter da3 = new SqlDataAdapter(q,con);
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





       


            return View("~/Views/AddAlternateAppointees/AddAlternateAppointeesPageContent.cshtml");
        }

        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * tbl_state where country_id = 101 order by statename asc  ";
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


            int getAlternateGaurdian = 0;
            int getAlternateExecutors = 0;


            //if (Session["apId"] != null)
            //{
                getAlternateExecutors = 1;
                getAlternateGaurdian = 1;

            //string apid = Session["apId"].ToString();
            string apid = "";
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
                cmd.Parameters.AddWithValue("@tid",  "");
                cmd.ExecuteNonQuery();
                con.Close();
                ViewBag.Message = "Verified";
            }
            else
            {
                getAlternateExecutors = 2;
                getAlternateGaurdian = 2;

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
            string rulequery = "update documentRules set AlternateGaurdian = " + getAlternateGaurdian + " , AlternateExecutors  = "+getAlternateExecutors+"        where wdId = " + getruleid + " ";
            SqlCommand cmd2 = new SqlCommand(rulequery, con);
            cmd2.ExecuteNonQuery();
            con.Close();


            //end

            // rule id in document master

            con.Open();
            string getquery2 = "select top 1 * from documentMaster order by documentId desc";
            SqlDataAdapter da2 = new SqlDataAdapter(getquery2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int getruleid2 = 0;
            if (dt2.Rows.Count > 0)
            {
                getruleid2 = Convert.ToInt32(dt2.Rows[0]["documentId"]);
            }
            con.Close();



            con.Open();
            string rulequery3 = "update documentMaster set wdId = " + getruleid + "  where documentId = " + getruleid2 + " ";
            SqlCommand cmd3 = new SqlCommand(rulequery3, con);
            cmd3.ExecuteNonQuery();
            con.Close();

            //end

            ModelState.Clear();
            return View("~/Views/AddAlternateAppointees/AddAlternateAppointeesPageContent.cshtml");
        }



        public string BindTestatorDDL()
        {
            con.Open();
            string query = "select tId , First_Name from TestatorDetails where tId = " + Convert.ToInt32(Session["tId"]) + "  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";




            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = dt.Rows[i]["First_Name"].ToString();



                }




            }

            return data;
        }


    }
}