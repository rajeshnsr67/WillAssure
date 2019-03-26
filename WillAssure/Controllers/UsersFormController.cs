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
    public class UsersFormController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        public ActionResult UsersFormIndex()
        {
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

            return View("~/Views/UsersForm/UsersFormPageContent.cshtml");
        }

        public ActionResult GetUserFormData(UserFormModel UFM)
        {
             
            

            if (Session["compId"] != null)
            {


                con.Open();
                string q = "select count(*) from users where userID = '"+ UFM.UserId + "'";
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
                    cmd.Parameters.AddWithValue("@Dob", UFM.Dob);
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
                    UFM.CompId = Convert.ToInt32(Session["compid"].ToString());
                    cmd.Parameters.AddWithValue("@compId", UFM.CompId);
                    cmd.Parameters.AddWithValue("@Linked_user", UFM.rid);
                    cmd.ExecuteNonQuery();


                    string query = "SELEct * from users where compId = '" + UFM.CompId + "'";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["rId"]) == 1)
                        {

                            string update = "update users set Linked_user = 0 where  CompId = '" + UFM.CompId + "'";
                            SqlCommand cmd2 = new SqlCommand(update, con);
                            cmd2.ExecuteNonQuery();

                        }


                    }

                    con.Close();
                    string query2 = "select top 1 * from users order by uId desc";
                    SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                    DataTable dt2 = new DataTable();
                    da.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        Session["uid"] = "";
                        Session["uid"] = Convert.ToInt32(dt.Rows[0]["uId"]);
                    }
                    con.Open();










                    ViewBag.Message = "Verified";

                }






               
            }
            else
            {

                ViewBag.Message = "link";

            }

           
           


          

           



          

            return View("~/Views/UsersForm/UsersFormPageContent.cshtml");
        }



     


        public String BindStateDDL()
        {

            con.Open();
            string query = "select * from tbl_state";
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




        public String BindRoleDDL()
        {

            int roles = 0;
            roles = Convert.ToInt32(Session["rId"]);
            if (roles != 1 && roles != 4)
            {

                con.Open();
                string query = "select * from subroles";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                string data = "<option value=''>--Select Role--</option>";

                if (dt.Rows.Count > 0)
                {


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {




                        data = data + "<option value=" + dt.Rows[i]["Subrid"].ToString() + " >" + dt.Rows[i]["SubRolesName"].ToString() + "</option>";



                    }




                }
                return data;

            }
            else
            {
          
                con.Open();
                string query = "select * from Roles";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                string data = "<option value=''>--Select Role--</option>";

                if (dt.Rows.Count > 0)
                {


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {




                        data = data + "<option value=" + dt.Rows[i]["rid"].ToString() + " >" + dt.Rows[i]["Role"].ToString() + "</option>";



                    }




                }

                return data;
            }

        }






    }
}