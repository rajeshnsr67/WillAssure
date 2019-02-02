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
using System.Net.Mail;
using System.Net;

namespace WillAssure.Controllers
{
    public class AddTestatorsFormController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: AddTestatorsForm
        public ActionResult AddTestatorsFormIndex()
        {



            return View("~/Views/AddTestatorsForm/AddTestatorPageContent.cshtml");
        }

        public ActionResult InsertTestatorFormData(TestatorFormModel TFM)
        {
            //con.Open();
            //SqlCommand cmd = new SqlCommand("SP_CRUDTestatorDetails", con);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@condition", "insert");
            //cmd.Parameters.AddWithValue("@First_Name", TFM.First_Name);
            //cmd.Parameters.AddWithValue("@Last_Name", TFM.Last_Name);
            //cmd.Parameters.AddWithValue("@Middle_Name", TFM.Middle_Name);
            //cmd.Parameters.AddWithValue("@DOB", TFM.DOB);
            //cmd.Parameters.AddWithValue("@Occupation", TFM.Occupation);
            //cmd.Parameters.AddWithValue("@Mobile", TFM.Mobile);
            //cmd.Parameters.AddWithValue("@Email", TFM.Email);
            //cmd.Parameters.AddWithValue("@maritalStatus", TFM.GenderId);
            //cmd.Parameters.AddWithValue("@Religion", TFM.ReligionId);
            //cmd.Parameters.AddWithValue("@Identity_Proof", TFM.Identity_Proof);
            //cmd.Parameters.AddWithValue("@Identity_proof_Value", TFM.Identity_proof_Value);
            //cmd.Parameters.AddWithValue("@Alt_Identity_Proof", TFM.Alt_Identity_Proof);
            //cmd.Parameters.AddWithValue("@Alt_Identity_proof_Value", TFM.Alt_Identity_proof_Value);
            //cmd.Parameters.AddWithValue("@Gender", TFM.GenderId);
            //cmd.Parameters.AddWithValue("@Address1", TFM.Address1);
            //cmd.Parameters.AddWithValue("@Address2", TFM.Address2);
            //cmd.Parameters.AddWithValue("@Address3", TFM.Address3);
            //cmd.Parameters.AddWithValue("@City", TFM.countryid);
            //cmd.Parameters.AddWithValue("@State", TFM.stateid);
            //cmd.Parameters.AddWithValue("@Country", TFM.countryid);
            //cmd.Parameters.AddWithValue("@Pin", TFM.Pin);
            //cmd.Parameters.AddWithValue("@active", TFM.active);

            //cmd.ExecuteNonQuery();
            //con.Close();



           
            //1st condition
            if (TFM.Amt_Paid_By_txt == "Distributor" && TFM.Document_Created_By_txt == "Distributor")
            {
                TFM.Authentication_Required = 0;
                TFM.Link_Required = 0;
                TFM.Login_Required = 0;

                con.Open();
                string query = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '"+TFM.Authentication_Required+"' , '"+TFM.Link_Required+"' , '"+TFM.Login_Required+"') ";
                SqlCommand cmd2 = new SqlCommand(query,con);
                cmd2.ExecuteNonQuery();
                con.Close();


                string email = "imransayyed528@gmail.com";
                string to = "imransayyed528@gmail.com";
                string subject = "Testing Email";
                string body = "Mail Has Been Send By Will Assure";
                string password = "transformerrobotb4u";
                MailMessage mail = new MailMessage();
               
                mail.To.Add("imran@prolifiquetech.in");
                mail.From = new MailAddress("imransayyed528@gmail.com");
                mail.Subject = "Confirmation of Registration on Job Junction.";
                string Body = "Hi, this mail is to test sending mail using Gmail in ASP.NET";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
                //smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential(email,password);
                //smtp.Port = 587;
                //Or your Smtp Email ID and Password
                smtp.Send(mail);


            }
            //end
            //2nd condition 
            if (TFM.Amt_Paid_By_txt == "Distributor" && TFM.Document_Created_By_txt == "Testator")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query, con);
                cmd2.ExecuteNonQuery();
                con.Close();

              



            }
            //end
            // 3rd condtion
            if (TFM.Amt_Paid_By_txt == "Testator" && TFM.Document_Created_By_txt == "Distributor")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query, con);
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            //end
            //4th condition
            if (TFM.Amt_Paid_By_txt == "Testator" && TFM.Document_Created_By_txt == "Testator")
            {
                TFM.Authentication_Required = 1;
                TFM.Link_Required = 1;
                TFM.Login_Required = 1;

                con.Open();
                string query = "insert into Authorization_Rules (Document_Created_By,Distributor_Id,Amt_Paid_By,Testator_Id,Authentication_Required,Link_Required,Login_Required) values ('" + TFM.Document_Created_By_txt + "' , '" + TFM.Document_Created_By_ID + "' , '" + TFM.Amt_Paid_By_txt + "' , '" + TFM.Amt_Paid_By + "'  , '" + TFM.Authentication_Required + "' , '" + TFM.Link_Required + "' , '" + TFM.Login_Required + "') ";
                SqlCommand cmd2 = new SqlCommand(query, con);
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            //end





           


            return View("~/Views/AddTestatorsForm/AddTestatorPageContent.cshtml");
        }





        public String BindCountryDDL()
        {

            con.Open();
            string query = "select * from country_tbl";
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






        public String BindCityDDL()
        {

            con.Open();
            string query = "select * from tbl_city";
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
            string query = "select * from tbl_state where country_id = '"+ response + "'";
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








    }
}