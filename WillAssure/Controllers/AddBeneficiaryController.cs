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
    public class AddBeneficiaryController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddBeneficiary
        public ActionResult AddBeneficiaryIndex()
        {
            if (Session.SessionID == null)
            {

                return RedirectToAction("LoginPageIndex", "LoginPage");

            }

            //if (Session["aiid"] == null && Session["tid"] == null)
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
            return View("~/Views/AddBeneficiary/AddBeneficiaryPageContent.cshtml");
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




        public ActionResult InsertBeneficiaryData(BeneficiaryModel BM)
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

            //if (Session["aiid"] != null && Session["tid"].ToString() != null)
            //{
            //BM.aid = Convert.ToInt32(Session["aiid"]);
            //BM.tid = Convert.ToInt32(Session["tid"]);
                BM.aid = 0;

                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CRUDBeneficiaryDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@First_Name ", BM.First_Name);
                cmd.Parameters.AddWithValue("@Last_Name", BM.Last_Name);
                cmd.Parameters.AddWithValue("@Middle_Name", BM.Middle_Name);
                DateTime dat = DateTime.ParseExact(BM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd.Parameters.AddWithValue("@DOB", dat);
                cmd.Parameters.AddWithValue("@Mobile", BM.Mobile);
                cmd.Parameters.AddWithValue("@Relationship", BM.RelationshipTxt);
                cmd.Parameters.AddWithValue("@Marital_Status", BM.Marital_Status);
                cmd.Parameters.AddWithValue("@Religion", BM.Religion);
                cmd.Parameters.AddWithValue("@Identity_proof", BM.Identity_proof);
                cmd.Parameters.AddWithValue("@Identity_proof_value", BM.Identity_proof_value);
                cmd.Parameters.AddWithValue("@Alt_Identity_proof", BM.Alt_Identity_proof);
                cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", BM.Alt_Identity_proof_value);
                cmd.Parameters.AddWithValue("@Address1", BM.Address1);
                cmd.Parameters.AddWithValue("@Address2", BM.Address2);
                cmd.Parameters.AddWithValue("@Address3", BM.Address3);
                cmd.Parameters.AddWithValue("@City", BM.City_txt);
                cmd.Parameters.AddWithValue("@State", BM.State_txt);
                cmd.Parameters.AddWithValue("@Pin", BM.Pin);
                cmd.Parameters.AddWithValue("@aid", BM.aid);
                cmd.Parameters.AddWithValue("@tid", BM.ddltid);
                cmd.Parameters.AddWithValue("@beneficiary_type", BM.beneficiary_type);
                cmd.ExecuteNonQuery();
                con.Close();


            // get latest bpid with filter
            int bpid = 0;
            con.Open();
            string qq = "select top 1 * from BeneficiaryDetails order by bpId desc";
            SqlDataAdapter da = new SqlDataAdapter(qq,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                bpid = Convert.ToInt32(dt.Rows[0]["bpId"]);
            }
            con.Close();
            //end


            if (BM.check == "true")
            {
                con.Open();
                SqlCommand altcmd = new SqlCommand("SP_CRUD_alternate_Beneficiary", con);
                altcmd.CommandType = CommandType.StoredProcedure;
                altcmd.Parameters.AddWithValue("@condition", "insert");
                if (bpid != 0)
                {
                    altcmd.Parameters.AddWithValue("@bpId", bpid);
                }
                else
                {
                    BM.altbpId = 0;
                    altcmd.Parameters.AddWithValue("@bpId",BM.altbpId);
                }
                
                altcmd.Parameters.AddWithValue("@First_Name", BM.altFirst_Name);
                altcmd.Parameters.AddWithValue("@Last_Name", BM.altLast_Name);
                altcmd.Parameters.AddWithValue("@Middle_Name", BM.altMiddle_Name);
                DateTime altdat = DateTime.ParseExact(BM.altDob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                altcmd.Parameters.AddWithValue("@DOB", altdat);
                altcmd.Parameters.AddWithValue("@Mobile", BM.altMobile);
                altcmd.Parameters.AddWithValue("@Relationship", BM.altRelationshipTxt);
                altcmd.Parameters.AddWithValue("@Marital_Status", BM.altMarital_Status_Txt);
                altcmd.Parameters.AddWithValue("@Religion", BM.altReligion_TXT);
                altcmd.Parameters.AddWithValue("@Identity_Proof", BM.altIdentity_Proof);
                altcmd.Parameters.AddWithValue("@Identity_Proof_Value", BM.altIdentity_Proof_Value);
                altcmd.Parameters.AddWithValue("@Alt_Identity_Proof", BM.altAlt_Identity_Proof);
                altcmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", BM.altAlt_Identity_Proof_Value);
                altcmd.Parameters.AddWithValue("@Address1", BM.altAddress1);
                altcmd.Parameters.AddWithValue("@Address2", BM.altAddress2);
                altcmd.Parameters.AddWithValue("@Address3", BM.altAddress3);
                altcmd.Parameters.AddWithValue("@City", BM.altcitytext);
                altcmd.Parameters.AddWithValue("@State", BM.altstatetext);
                altcmd.Parameters.AddWithValue("@Pin", BM.altPin);
                altcmd.ExecuteNonQuery();
                con.Close();
            }



                ViewBag.Message = "RecordsInsert";





            //}
            //else
            //{
            //    ViewBag.Message = "link";
            //}




            ModelState.Clear();
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





        public string BindTestatorDDL()
        {
            con.Open();
            string query = "select a.tId , a.First_Name from TestatorDetails a inner join users b on a.uId=b.uId where b.Linked_user  = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value='' >--Select--</option>";




            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option>";



                }




            }

            return data;
        }





    }
}