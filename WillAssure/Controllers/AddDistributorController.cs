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
                ViewBag.showtitle = "true";
                ViewBag.documentlink = "true";

            }

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
            return View("~/Views/AddDistributor/AddDistributorPageContent.cshtml");
        }
        [HttpPost]
        public ActionResult InsertDistributorFormData(DistributorFormModel DFM)
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
            string s = "none";
            string s2 = "none";
            string s3 = "none";
            string s4 = "none";

                con.Open();
                SqlCommand cmd = new SqlCommand("SP_CrudcompanyDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@condition", "insert");
                cmd.Parameters.AddWithValue("@companyName ", DFM.companyName);
                cmd.Parameters.AddWithValue("@ownerName", DFM.ownerName);
                cmd.Parameters.AddWithValue("@ownerMobileNo", DFM.ownerMobileNo);
                cmd.Parameters.AddWithValue("@Address1", DFM.Address1);
                cmd.Parameters.AddWithValue("@Address2", DFM.Address2);
                cmd.Parameters.AddWithValue("@City", DFM.citytext);
                cmd.Parameters.AddWithValue("@State", DFM.statetext);
                cmd.Parameters.AddWithValue("@Pin", DFM.Pin);
                cmd.Parameters.AddWithValue("@GST_NO", DFM.GST_NO);
                cmd.Parameters.AddWithValue("@Identity_Proof", DFM.Identity_Proof);
                cmd.Parameters.AddWithValue("@Identity_Proof_Value", DFM.Identity_Proof_Value);
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof", DFM.Alt_Identity_Proof);
                cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", DFM.Alt_Identity_Proof_Value);
                cmd.Parameters.AddWithValue("@contactPerson", DFM.contactPerson);
                cmd.Parameters.AddWithValue("@contactMobileNo", DFM.contactMobileNo);
                cmd.Parameters.AddWithValue("@contactMailId", DFM.contactMailId);
                cmd.Parameters.AddWithValue("@bankName", DFM.bankName);
                cmd.Parameters.AddWithValue("@Branch", DFM.Branch);
                cmd.Parameters.AddWithValue("@accountNumber", DFM.accountNumber);
                cmd.Parameters.AddWithValue("@IFSC_Code", DFM.IFSC_Code);
                cmd.Parameters.AddWithValue("@accountName", DFM.accountName);
                cmd.Parameters.AddWithValue("@Referred_By", DFM.Referred_By);
                cmd.Parameters.AddWithValue("@leadgeneratedBy", s);
                cmd.Parameters.AddWithValue("@leadconvertedBy", s2);
                cmd.Parameters.AddWithValue("@relationshipManager", DFM.relationshipManager);
                cmd.Parameters.AddWithValue("@leadStatus", s3);
                cmd.Parameters.AddWithValue("@leadRemark", s4);
                cmd.ExecuteNonQuery();
                con.Close();
          
            // get latest uid by userid filter
            string userid = "";
            con.Open();
            string query2 = "select top 1 * from users order by uId desc";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int newusers = 0;
            if (dt2.Rows.Count > 0)
            {

                userid = Convert.ToString(dt2.Rows[0]["userID"]);

                string q1 = "select * from users where userID = '" + userid + "'  ";
                SqlDataAdapter qda = new SqlDataAdapter(q1, con);
                DataTable qdt = new DataTable();
                qda.Fill(qdt);

                if (qdt.Rows.Count > 0)
                {
                    newusers = Convert.ToInt32(qdt.Rows[0]["uId"]);
                    Session["filterUid"] = newusers;
                }


            }
            con.Close();


            //end



            // ASSIGN TYPE

            con.Open();
            string query3 = "update  users set Type='DistributorAdmin' where uId = " + userid + "  ";
            SqlCommand cm = new SqlCommand(query3, con);
            cm.ExecuteNonQuery();
            con.Close();



            //END





            // get latest inserted compid
            string query5 = "select top 1 * from companyDetails order by compId desc";
            SqlDataAdapter da5 = new SqlDataAdapter(query5, con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            int compid = 0;
            if (dt5.Rows.Count > 0)
            {
                compid = Convert.ToInt32(dt5.Rows[0]["compId"]);
            }
            else
            {
                compid = 0;
            }
            //end



            



         




            ModelState.Clear();


            ViewBag.Message = "Verified";

            return View("~/Views/AddDistributor/AddDistributorPageContent.cshtml");
        }

        public String BindStateDDL()
        {

            con.Open();
            string query = "select distinct * from tbl_state where country_id = 101 order by statename asc  ";
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