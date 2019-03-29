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
    public class UpdateTestatorsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: UpdateTestators
        public ActionResult UpdateTestatorsIndex(int NestId)
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
            TestatorFormModel TFM = new TestatorFormModel();

            con.Open();
            string query = "select * from TestatorDetails where tId = '" + NestId + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                       TFM.tId = NestId;
                       TFM.First_Name = dt.Rows[0]["First_Name"].ToString();
                       TFM.Last_Name =  dt.Rows[0]["Last_Name"].ToString();
                       TFM.Middle_Name = dt.Rows[0]["Middle_Name"].ToString();
                       TFM.Dob = dt.Rows[0]["DOB"].ToString();
                       TFM.Occupation = dt.Rows[0]["Occupation"].ToString();
                       TFM.Mobile = dt.Rows[0]["Mobile"].ToString();
                       TFM.Email = dt.Rows[0]["Email"].ToString();
                       TFM.Gendertext = dt.Rows[0]["maritalStatus"].ToString();
                       TFM.Religiontext = dt.Rows[0]["Religion"].ToString();
                       TFM.Identity_Proof = dt.Rows[0]["Identity_Proof"].ToString();
                       TFM.Identity_proof_Value = dt.Rows[0]["Identity_proof_Value"].ToString();
                       TFM.Alt_Identity_Proof = dt.Rows[0]["Alt_Identity_Proof"].ToString();
                       TFM.Alt_Identity_proof_Value =     dt.Rows[0]["Alt_Identity_proof_Value"].ToString();
                       TFM.Gendertext = dt.Rows[0]["Gender"].ToString();
                       TFM.Address1 = dt.Rows[0]["Address1"].ToString();
                       TFM.Address2 = dt.Rows[0]["Address2"].ToString();
                       TFM.Address3 = dt.Rows[0]["Address3"].ToString();
                       TFM.citytext = dt.Rows[0]["City"].ToString();
                       TFM.statetext = dt.Rows[0]["State"].ToString();
                       TFM.countrytext = dt.Rows[0]["Country"].ToString();
                       TFM.Pin = dt.Rows[0]["Pin"].ToString();
                       TFM.active = dt.Rows[0]["active"].ToString(); 





            }


            return View("~/Views/UpdateTestators/UpdateTestatorPageContent.cshtml", TFM);
        }


        public ActionResult UpdatingTestatorFormData(TestatorFormModel TFM)
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
            //SqlCommand cmd = new SqlCommand("SP_CRUDTestatorDetails", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@condition", "update");
            //cmd.Parameters.AddWithValue("@tId", TFM.tId);
            //cmd.Parameters.AddWithValue("@First_Name", TFM.First_Name);
            //cmd.Parameters.AddWithValue("@Last_Name", TFM.Last_Name);
            //cmd.Parameters.AddWithValue("@Middle_Name", TFM.Middle_Name);
            //cmd.Parameters.AddWithValue("@DOB", TFM.DOB);
            //cmd.Parameters.AddWithValue("@Occupation", TFM.Occupation);
            //cmd.Parameters.AddWithValue("@Mobile", TFM.Mobile);
            //cmd.Parameters.AddWithValue("@Email", TFM.Email);
            //cmd.Parameters.AddWithValue("@maritalStatus", TFM.Gendertext);
            //cmd.Parameters.AddWithValue("@Religion", TFM.Religiontext);
            //cmd.Parameters.AddWithValue("@Identity_Proof", TFM.Identity_Proof);
            //cmd.Parameters.AddWithValue("@Identity_proof_Value", TFM.Identity_proof_Value);
            //cmd.Parameters.AddWithValue("@Alt_Identity_Proof", TFM.Alt_Identity_Proof);
            //cmd.Parameters.AddWithValue("@Alt_Identity_proof_Value", TFM.Alt_Identity_proof_Value);
            //cmd.Parameters.AddWithValue("@Gender", TFM.Gendertext);
            //cmd.Parameters.AddWithValue("@Address1", TFM.Address1);
            //cmd.Parameters.AddWithValue("@Address2", TFM.Address2);
            //cmd.Parameters.AddWithValue("@Address3", TFM.Address3);
            //cmd.Parameters.AddWithValue("@City", TFM.cityid);
            //cmd.Parameters.AddWithValue("@State", TFM.stateid);
            //cmd.Parameters.AddWithValue("@Country", TFM.countryid);
            //cmd.Parameters.AddWithValue("@Pin", TFM.Pin);
            //cmd.Parameters.AddWithValue("@active", TFM.active);


            //cmd.ExecuteNonQuery();
            DateTime dat = DateTime.ParseExact(TFM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var sqlFormattedDate = dat;
            string query = "update TestatorDetails set First_Name = '"+TFM.First_Name+"' , Last_Name='"+TFM.Last_Name+"' ,Middle_Name= '"+TFM.Middle_Name+"' , DOB = '"+ sqlFormattedDate + "' ,Occupation='"+TFM.Occupation+"' ,Mobile='"+TFM.Mobile+"' ,Email = '"+TFM.Email+"' ,maritalStatus='"+TFM.material_status +"' , Religion='"+TFM.Religiontext+ "' ,  Relationship = '"+TFM.RelationshipTxt + "'   ,Identity_Proof='" + TFM.Identity_Proof+"' ,Identity_proof_Value='"+TFM.Identity_proof_Value+"',Alt_Identity_Proof='"+TFM.Alt_Identity_Proof+"',Alt_Identity_proof_Value='"+TFM.Alt_Identity_proof_Value+"',Gender='"+TFM.Gendertext+"',Address1='"+TFM.Address1+"',Address2='"+TFM.Address2+"',Address3='"+TFM.Address3+"',Country='"+TFM.countrytext+"',State='"+TFM.statetext+"',City='"+TFM.citytext+"',Pin='"+TFM.Pin+"',active='"+TFM.active+ "'  where  tId = " + TFM.tId+"";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.Message = "Verified";


            return View("~/Views/UpdateTestators/UpdateTestatorPageContent.cshtml");
        }


        public String BindCountryDDL()
        {

            con.Open();
            string query = "select distinct * from country_tbl order by CountryName asc  ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["CountryID"].ToString() + " >" + dt.Rows[i]["CountryName"].ToString() + "</option>";



                }




            }

            return data;

        }



        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state order by statename asc  ";
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






        public String BindCityDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_city  order by city_name asc ";
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


        public string OnChangeBindState()
        {
            string response = Request["send"];
            con.Open();
            string query = "select distinct * from tbl_state where country_id = '" + response + "' order by statename asc";
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


    }
}