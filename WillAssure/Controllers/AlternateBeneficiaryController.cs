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
    public class AlternateBeneficiaryController : Controller
    {


        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AlternateBeneficiary
        public ActionResult AlternateBeneficiaryIndex()
        {
            // check type 
            string typ = "";
            con.Open();
            string qq1 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa = new SqlDataAdapter(qq1, con);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            con.Close();

            if (dtt.Rows.Count > 0)
            {
                typ = dtt.Rows[0]["Type"].ToString();
            }



            //end



            if (typ == "Testator")
            {
                // check will status
                con.Open();
                string qry1 = "select Will  from users where Will = 1 ";
                SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                DataTable dtt1 = new DataTable();
                daa1.Fill(dtt1);
                if (dtt1.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
                con.Close();
                //end


                // check codocil status
                con.Open();
                string qry2 = "select Codocil  from users where Codocil = 1 ";
                SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                DataTable dtt2 = new DataTable();
                daa2.Fill(dtt2);
                if (dtt2.Rows.Count > 0)
                {
                    ViewBag.documentbtn2 = "true";
                }
                con.Close();

                //end


                // check Poa status
                con.Open();
                string qry4 = "select POA  from users where POA = 1 ";
                SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                DataTable dtt4 = new DataTable();
                daa4.Fill(dtt4);
                if (dtt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }
                con.Close();
                //end


                // check gift deeds status
                con.Open();
                string qry3 = "select Giftdeeds  from users where Giftdeeds = 1 ";
                SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                DataTable dtt3 = new DataTable();
                daa3.Fill(dtt3);
                if (dtt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }
                con.Close();
                //end
            }
            else
            {

                ViewBag.documentlink = "true";

            }

            if (Session["rId"] == null || Session["uuid"] == null)
            {

               RedirectToAction("LoginPageIndex", "LoginPage");

            }
            //if (Session["bpId"] == null)
            //{
            //    ViewBag.Message = "link";
            //}

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
            return View("~/Views/AlternateBeneficiary/AlternateBeneficiaryPageContent.cshtml");
        }




        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state where country_id = 101 order by statename asc  ";
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
            string query = "select distinct * from tbl_city where state_id = '" + response + "' order by city_name asc";
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


        public ActionResult InsertAlternateBeneficiaryFormData(AlternateBeneficiaryModel ABM)
        {
            // check type 
            string typ = "";
            con.Open();
            string qq1 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa = new SqlDataAdapter(qq1, con);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            con.Close();

            if (dtt.Rows.Count > 0)
            {
                typ = dtt.Rows[0]["Type"].ToString();
            }



            //end



            if (typ == "Testator")
            {
                // check will status
                con.Open();
                string qry1 = "select Will  from users where Will = 1 ";
                SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                DataTable dtt1 = new DataTable();
                daa1.Fill(dtt1);
                if (dtt1.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
                con.Close();
                //end


                // check codocil status
                con.Open();
                string qry2 = "select Codocil  from users where Codocil = 1 ";
                SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                DataTable dtt2 = new DataTable();
                daa2.Fill(dtt2);
                if (dtt2.Rows.Count > 0)
                {
                    ViewBag.documentbtn2 = "true";
                }
                con.Close();

                //end


                // check Poa status
                con.Open();
                string qry4 = "select POA  from users where POA = 1 ";
                SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                DataTable dtt4 = new DataTable();
                daa4.Fill(dtt4);
                if (dtt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }
                con.Close();
                //end


                // check gift deeds status
                con.Open();
                string qry3 = "select Giftdeeds  from users where Giftdeeds = 1 ";
                SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                DataTable dtt3 = new DataTable();
                daa3.Fill(dtt3);
                if (dtt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }
                con.Close();
                //end
            }
            else
            {

                ViewBag.documentlink = "true";

            }

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

            int getbeneficiary = 0;

            if (Session["bpId"] != null)
            {
                getbeneficiary = 1;
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUD_alternate_Beneficiary", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@bpId", "");
                cmd.Parameters.AddWithValue("@First_Name", ABM.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", ABM.Last_Name);
                cmd.Parameters.AddWithValue("@Middle_Name", ABM.Middle_Name);
                DateTime dat = DateTime.ParseExact(ABM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@DOB", dat);
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


            ModelState.Clear();

            return View("~/Views/AlternateBeneficiary/AlternateBeneficiaryPageContent.cshtml");
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