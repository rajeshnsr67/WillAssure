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
    public class UpdateTestatorsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: UpdateTestators
        public ActionResult UpdateTestatorsIndex(int NestId)
        {
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
                       TFM.DOB = Convert.ToDateTime(dt.Rows[0]["DOB"]);
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

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CRUDTestatorDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@tId", TFM.tId);
            cmd.Parameters.AddWithValue("@First_Name", TFM.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", TFM.Last_Name);
            cmd.Parameters.AddWithValue("@Middle_Name", TFM.Middle_Name);
            cmd.Parameters.AddWithValue("@DOB", TFM.DOB);
            cmd.Parameters.AddWithValue("@Occupation", TFM.Occupation);
            cmd.Parameters.AddWithValue("@Mobile", TFM.Mobile);
            cmd.Parameters.AddWithValue("@Email", TFM.Email);
            cmd.Parameters.AddWithValue("@maritalStatus", TFM.GenderId);
            cmd.Parameters.AddWithValue("@Religion", TFM.ReligionId);
            cmd.Parameters.AddWithValue("@Identity_Proof", TFM.Identity_Proof);
            cmd.Parameters.AddWithValue("@Identity_proof_Value", TFM.Identity_proof_Value);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", TFM.Alt_Identity_Proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_Value", TFM.Alt_Identity_proof_Value);
            cmd.Parameters.AddWithValue("@Gender", TFM.GenderId);
            cmd.Parameters.AddWithValue("@Address1", TFM.Address1);
            cmd.Parameters.AddWithValue("@Address2", TFM.Address2);
            cmd.Parameters.AddWithValue("@Address3", TFM.Address3);
            cmd.Parameters.AddWithValue("@City", TFM.countryid);
            cmd.Parameters.AddWithValue("@State", TFM.stateid);
            cmd.Parameters.AddWithValue("@Country", TFM.countryid);
            cmd.Parameters.AddWithValue("@Pin", TFM.Pin);
            cmd.Parameters.AddWithValue("@active", TFM.active);
            cmd.Parameters.AddWithValue("@uid", TFM.uId);
     
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.Message = "Verified";


            return View("~/Views/UpdateTestators/UpdateTestatorPageContent.cshtml");
        }




    }
}