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
    public class UpdateTestatorFamilyController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateTestatorFamily
        public ActionResult UpdateTestatorFamilyIndex(int NestId)
        {
            TestatorFamilyModel TFM = new TestatorFamilyModel();
            TFM.fId = NestId;

            con.Open();
            string query = "select * from testatorFamily where fId = "+NestId+"";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                           TFM.First_Name =  dt.Rows[i]["First_Name"].ToString() ;
                           TFM.Last_Name = dt.Rows[i]["Last_Name"].ToString() ;
                           TFM.Middle_Name =  dt.Rows[i]["Middle_Name"].ToString() ;
                           TFM.DOB = dt.Rows[i]["DOB"].ToString() ;
                           TFM.Marital_Status =  dt.Rows[i]["Marital_Status"].ToString() ;
                           TFM.Religion =  dt.Rows[i]["Religion"].ToString() ;
                           TFM.Relationship = dt.Rows[i]["Relationship"].ToString() ;
                           TFM.Address1 = dt.Rows[i]["Address1"].ToString() ;
                           TFM.Address2 = dt.Rows[i]["Address2"].ToString() ;
                           TFM.Address3 = dt.Rows[i]["Address3"].ToString() ;
                           TFM.City =  dt.Rows[i]["City"].ToString() ;
                           TFM.State = dt.Rows[i]["State"].ToString() ;
                           TFM.Pin =  dt.Rows[i]["Pin"].ToString() ;
                         
                           TFM.active = dt.Rows[i]["active"].ToString() ;
                           TFM.Identity_Proof = dt.Rows[i]["Identity_Proof"].ToString() ;
                           TFM.Identity_Proof_Value = dt.Rows[i]["Identity_Proof_Value"].ToString() ;
                           TFM.Alt_Identity_Proof= dt.Rows[i]["Alt_Identity_Proof"].ToString() ;
                           TFM.Alt_Identity_Proof_Value= dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() ;
                           TFM.Is_Informed_Person = dt.Rows[i]["Is_Informed_Person"].ToString() ;

                            

                }
            }


            return View("~/Views/UpdateTestatorFamily/UpdateTestatorFamilyPageContent.cshtml",TFM);
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



        public ActionResult UpdateTestatorFamilyFormData(TestatorFamilyModel TFM)
        {
            
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDtestatorfamily", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@fId", TFM.fId);
            cmd.Parameters.AddWithValue("@First_Name", TFM.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", TFM.Last_Name);
            cmd.Parameters.AddWithValue("@Middle_Name", TFM.Middle_Name);
            cmd.Parameters.AddWithValue("@DOB", TFM.DOB);
            cmd.Parameters.AddWithValue("@Marital_Status", TFM.Marital_Status);
            cmd.Parameters.AddWithValue("@Religion", TFM.Religion);
            cmd.Parameters.AddWithValue("@Relationship", TFM.RelationshipTxt);
            cmd.Parameters.AddWithValue("@Address1", TFM.Address1);
            cmd.Parameters.AddWithValue("@Address2", TFM.Address2);
            cmd.Parameters.AddWithValue("@Address3", TFM.Address3);
            cmd.Parameters.AddWithValue("@City", TFM.City_txt);
            cmd.Parameters.AddWithValue("@State", TFM.State_txt);
            cmd.Parameters.AddWithValue("@tId", "");
            cmd.Parameters.AddWithValue("@Pin", TFM.Pin);
            cmd.Parameters.AddWithValue("@active", TFM.active);
            cmd.Parameters.AddWithValue("@Identity_Proof", TFM.Identity_Proof);
            cmd.Parameters.AddWithValue("@Identity_Proof_Value", TFM.Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", TFM.Alt_Identity_Proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", TFM.Alt_Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Is_Informed_Person", TFM.Is_Informed_Person);
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.message = "Verified";
        


            return View("~/Views/AddTestatorFamily/AddTestatorFamilyPageContent.cshtml");
        }

    }
}