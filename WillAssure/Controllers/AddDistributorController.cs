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
    public class AddDistributorController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddDistributor
        public ActionResult AddDistributorIndex()
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
            return View("~/Views/AddDistributor/AddDistributorPageContent.cshtml");
        }
        [HttpPost]
        public ActionResult InsertDistributorFormData(DistributorFormModel DFM)
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
            SqlCommand cmd = new SqlCommand("SP_CrudcompanyDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "insert");
            cmd.Parameters.AddWithValue("@companyName ", DFM.companyName );
            cmd.Parameters.AddWithValue("@ownerName", DFM.ownerName);
            cmd.Parameters.AddWithValue("@ownerMobileNo", DFM.ownerMobileNo);
            cmd.Parameters.AddWithValue("@Address1", DFM.Address1 );
            cmd.Parameters.AddWithValue("@Address2", DFM.Address2);
            cmd.Parameters.AddWithValue("@City", DFM.citytext);
            cmd.Parameters.AddWithValue("@State", DFM.statetext);
            cmd.Parameters.AddWithValue("@Pin", DFM.Pin );
            cmd.Parameters.AddWithValue("@GST_NO", DFM.GST_NO );
            cmd.Parameters.AddWithValue("@Identity_Proof", DFM.Identity_Proof);
            cmd.Parameters.AddWithValue("@Identity_Proof_Value", DFM.Identity_Proof_Value);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", DFM.Alt_Identity_Proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value",DFM.Alt_Identity_Proof_Value );
            cmd.Parameters.AddWithValue("@contactPerson", DFM.contactPerson);
            cmd.Parameters.AddWithValue("@contactMobileNo",DFM.contactMobileNo );
            cmd.Parameters.AddWithValue("@contactMailId",DFM.contactMailId );
            cmd.Parameters.AddWithValue("@bankName", DFM.bankName);
            cmd.Parameters.AddWithValue("@Branch", DFM.Branch);
            cmd.Parameters.AddWithValue("@accountNumber",DFM.accountNumber );
            cmd.Parameters.AddWithValue("@IFSC_Code",DFM.IFSC_Code );
            cmd.Parameters.AddWithValue("@accountName", DFM.accountName);
            cmd.Parameters.AddWithValue("@Referred_By", DFM.Referred_By);
            cmd.Parameters.AddWithValue("@leadgeneratedBy",DFM.leadgeneratedBy );
            cmd.Parameters.AddWithValue("@leadconvertedBy",DFM.leadconvertedBy );
            cmd.Parameters.AddWithValue("@relationshipManager", DFM.relationshipManager );
            cmd.Parameters.AddWithValue("@leadStatus", DFM.leadStatus );
            cmd.Parameters.AddWithValue("@leadRemark", DFM.leadRemark);
            cmd.ExecuteNonQuery();
            con.Close();


            int compid = 0;
            con.Open();
            string query = "select TOP 1 * FROM  companyDetails ORDER BY compId DESC";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                compid = Convert.ToInt32(dt.Rows[0]["compId"]); 
            }
            con.Close();

            // get recent uid
            int uid = 0;
            con.Open();
            string query2 = "select TOP 1 * FROM  users ORDER BY  uId DESC    ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {

                uid = Convert.ToInt32(dt2.Rows[0]["uId"]);
            }
            con.Close();


            //end

            // add comp id to testator
            con.Open();
            string que = "update users set compId = "+compid+" where uId = "+ uid + "  ";
            SqlCommand cmd2 = new SqlCommand(que,con);
            cmd2.ExecuteNonQuery();
            con.Close();


            ViewBag.Message = "Verified";

            return View("~/Views/AddDistributor/AddDistributorPageContent.cshtml");
        }

        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state order by statename asc  ";
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
            string query = "select distinct * from tbl_city where state_id = '" + response + "' order by city_name asc ";
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


        public ActionResult InsertUserFormData(DistributorFormModel DFM)
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

            SqlCommand cmd = new SqlCommand();




            con.Close();


            return View("~/Views/AddDistributor/AddDistributorPageContent.cshtml");
        }



    }
}