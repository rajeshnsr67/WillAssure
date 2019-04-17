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
using System.Net.Mail;
using System.Net;

namespace WillAssure.Controllers
{
    public class AddWillEmployeeController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: AddWillEmployee
        public ActionResult AddWillEmployeeIndex()
        {
            if (Session["rId"] == null || Session["uuid"] == null)
            {

               RedirectToAction("LoginPageIndex", "LoginPage");

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

            int RoleId = Convert.ToInt32(Session["rId"]);



            return View("~/Views/AddWillEmployee/AddWillEmployeePageContent.cshtml");
        }




        public ActionResult GetUserFormData(UserFormModel UFM)
        {
            // roleassignment
            List<LoginModel> Lmlist = new List<LoginModel>();
            con.Open();
            string q3 = "select * from Assignment_Roles where RoleId = " + Convert.ToInt32(Session["rId"]) + "";
            SqlDataAdapter da3 = new SqlDataAdapter(q3, con);
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


            //if (Session["compId"] != null)
            //{


            con.Open();
            string q = "select count(*) from users where userID = '" + UFM.UserId + "'";
            SqlCommand c = new SqlCommand(q, con);
            int count = (int)c.ExecuteScalar();

            if (count > 0)
            {
                ViewBag.Message = "Duplicate";
            }
            else
            {

                SqlCommand cmd = new SqlCommand("SP_Users", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@FirstName", UFM.FirstName);
                cmd.Parameters.AddWithValue("@LastName", UFM.LastName);
                cmd.Parameters.AddWithValue("@MiddleName", UFM.MiddleName);



                DateTime dat = DateTime.ParseExact(UFM.Dob, "dd-MM-yyyy", CultureInfo.InvariantCulture);

                cmd.Parameters.AddWithValue("@Dob", dat);
                cmd.Parameters.AddWithValue("@Mobile", UFM.Mobile);
                cmd.Parameters.AddWithValue("@Email", UFM.Email);
                cmd.Parameters.AddWithValue("@Address1", UFM.Address1);
                cmd.Parameters.AddWithValue("@Address2", UFM.Address2);
                cmd.Parameters.AddWithValue("@Address3", UFM.Address3);
                cmd.Parameters.AddWithValue("@City", UFM.citytext);
                cmd.Parameters.AddWithValue("@State ", UFM.statetext);
                cmd.Parameters.AddWithValue("@Pin", UFM.Pin);
                cmd.Parameters.AddWithValue("@UserId", UFM.UserId);
                cmd.Parameters.AddWithValue("@UserPassword", UFM.UserPassword);
                cmd.Parameters.AddWithValue("@Designation", UFM.Designation);
                cmd.Parameters.AddWithValue("@Active", UFM.Active);

           

                  
               

                    cmd.Parameters.AddWithValue("@rid", UFM.rid);
                


                UFM.CompId = 0;

                cmd.Parameters.AddWithValue("@compId", UFM.CompId);





                cmd.Parameters.AddWithValue("@Linked_user", UFM.rid);
                cmd.ExecuteNonQuery();


                string query = "SELEct * from users where compId = '" + UFM.CompId + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);


      

                con.Close();

                con.Open();
                string query2 = "select top 1 * from users order by uId desc";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                int willempid = 0;
                if (dt2.Rows.Count > 0)
                {

                  
                    willempid = Convert.ToInt32(dt2.Rows[0]["uId"]);
                }
                con.Close();


                con.Open();
                string query3 = "update  users set Type='WillEmployee' where uId = " + willempid + "  ";
                SqlCommand cm = new SqlCommand(query3, con);
                cm.ExecuteNonQuery();
                con.Close();




                //generate Mail
                string mailto = "";
                string userid = "";

                mailto = UFM.Email;
                userid = UFM.UserId;
                string subject = "Will Assure Login Credentials";

                string text = "<font color='Green' style='font-size=3em;'>Your UserId And Password For Logging In Is <br> UserID : " + userid + " <br> Password : " + UFM.UserPassword + "</font>";
                string body = "<font color='red'>" + text + "</font>";


                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("info@drinco.in");
                msg.To.Add(mailto);
                msg.Subject = subject;
                msg.Body = body;

                msg.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("216.10.240.149", 25);
                smtp.Credentials = new NetworkCredential("info@drinco.in", "95Bzf%s7");
                smtp.EnableSsl = false;
                smtp.Send(msg);
                smtp.Dispose();


                //end


                //Linked Users Query

                con.Open();

                string LinkedQuery = "update users set Linked_user = " + Convert.ToInt32(Session["uuid"]) + " where uId = " + willempid + "  ";
                SqlCommand LinkedCommand = new SqlCommand(LinkedQuery, con);
                LinkedCommand.ExecuteNonQuery();
                con.Close();

                //end

                ModelState.Clear();


                ViewBag.Message = "Verified";

            }







            //}
            //else
            //{

            //    ViewBag.Message = "link";

            //}












            return View("~/Views/AddWillEmployee/AddWillEmployeePageContent.cshtml");
        }






        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state where country_id = 101 order by statename asc";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select State--</option>";

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
            string data = "<option value=''>--Select City--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["id"].ToString() + " >" + dt.Rows[i]["city_name"].ToString() + "</option>";



                }




            }

            return data;
        }




        public String BindRoleDDL()
        {
            string data = "";


            data = "<option value=''>--Select Role--</option>";



            if (Session["rId"] != null)
            {
                int roles = 0;
                roles = Convert.ToInt32(Session["rId"]);

                if (roles == 1)
                {
                    con.Open();
                    string query = "select top 1 a.rId , a.Role , a.Pid from Roles a inner join users b on a.rId = b.rId where b.Linked_user = 1  and  a.rId = 3";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();


                    if (dt.Rows.Count > 0)
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {




                            data = data + "<option value=" + dt.Rows[i]["rid"].ToString() + " >" + dt.Rows[i]["Role"].ToString() + "</option>";



                        }




                    }
                }
                else
                {

                    con.Open();
                    string query = "select a.rId , a.Role from Roles a inner join users b on a.Pid = b.uId where a.Pid = " + Convert.ToInt32(Session["uuid"])+"";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();


                    if (dt.Rows.Count > 0)
                    {


                        for (int i = 0; i < dt.Rows.Count; i++)
                        {




                            data = data + "<option value=" + dt.Rows[i]["rid"].ToString() + " >" + dt.Rows[i]["Role"].ToString() + "</option>";



                        }




                    }




                }







            }

            return data;
        }




        public String BindCompanyDDL()
        {

            con.Open();
            string query = "select compId , companyName  from companydetails";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select --</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["compId"].ToString() + " >" + dt.Rows[i]["companyName"].ToString() + "</option>";



                }




            }

            return data;

        }



        public string checktype()
        {

            string buttonname = "";

            if (Convert.ToInt32(Session["rId"]) == 1)
            {











                buttonname = "Add Distributor";
                ViewBag.type = buttonname;






            }


            //bindbutton


            return buttonname;
        }




    }
}