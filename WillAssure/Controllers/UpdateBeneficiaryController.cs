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
    public class UpdateBeneficiaryController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateBeneficiary


        public ActionResult UpdateBeneficiaryIndex(int NestId)
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


                con.Open();
                string qq12 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " and designation = 1 ";
                SqlDataAdapter da42 = new SqlDataAdapter(qq12, con);
                DataTable d4t2 = new DataTable();
                da42.Fill(d4t2);
                con.Close();

                if (d4t2.Rows.Count > 0)
                {
                    ViewBag.documentlink = "true";
                }


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
            //if (Session["tid"]== null)
            //{
            //    ViewBag.message = "link";
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
            BeneficiaryModel BM = new BeneficiaryModel();

            con.Open();
            string query = "select * from BeneficiaryDetails where bpId = '" + NestId + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {

                BM.bpId = NestId;
                BM.First_Name = dt.Rows[0]["First_Name"].ToString();
                BM.Last_Name = dt.Rows[0]["Last_Name"].ToString();
                BM.Middle_Name = dt.Rows[0]["Middle_Name"].ToString();
                BM.Dob = dt.Rows[0]["DOB"].ToString();
                BM.Mobile = dt.Rows[0]["Mobile"].ToString();
                BM.RelationshipTxt = dt.Rows[0]["Relationship"].ToString();
                BM.Marital_Status = dt.Rows[0]["Marital_Status"].ToString();
                BM.Religion = dt.Rows[0]["Religion"].ToString();
                BM.Identity_proof =  dt.Rows[0]["Identity_proof"].ToString();
                BM.Identity_proof_value = dt.Rows[0]["Identity_proof_value"].ToString();
                BM.Alt_Identity_proof = dt.Rows[0]["Alt_Identity_proof"].ToString();
                BM.Alt_Identity_proof_value = dt.Rows[0]["Alt_Identity_proof_value"].ToString();
                BM.Address1 = dt.Rows[0]["Address1"].ToString();
                BM.Address2 = dt.Rows[0]["Address2"].ToString();
                BM.Address3 = dt.Rows[0]["Address3"].ToString();
                BM.City_txt = dt.Rows[0]["City"].ToString();
                BM.State_txt = dt.Rows[0]["State"].ToString();
                BM.Pin = dt.Rows[0]["Pin"].ToString();
                BM.aid = 0;
                BM.tid = 0;
                BM.createdBy = 0;
                BM.documentId = 0;
                BM.beneficiary_type = dt.Rows[0]["beneficiary_type"].ToString(); 

            }





            // for alterbeneficiary
            //if (Session["upbeneficiaryid"] == null)
            //{
            //    RedirectToAction("LoginPageIndex", "LoginPage");
            //}
            con.Open();
            string query2 = "select * from alternate_Beneficiary where bpId = "+Convert.ToInt32(Session["upbeneficiaryid"]) +" ";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            con.Close();
            if (dt2.Rows.Count > 0)
            {
                BM.altFirst_Name = dt2.Rows[0]["First_Name"].ToString();
                BM.altLast_Name = dt2.Rows[0]["Last_Name"].ToString();
                BM.altMiddle_Name = dt2.Rows[0]["Middle_Name"].ToString();

                BM.altDob = dt2.Rows[0]["DOB"].ToString();
                BM.altMobile = dt2.Rows[0]["Mobile"].ToString();
                BM.altRelationshipTxt = dt2.Rows[0]["Relationship"].ToString();
                BM.altMarital_Status_Txt = dt2.Rows[0]["Marital_Status"].ToString();
                BM.altReligion_TXT = dt2.Rows[0]["Religion"].ToString();
                BM.altIdentity_Proof = dt2.Rows[0]["Identity_Proof"].ToString();
                BM.altIdentity_Proof_Value = dt2.Rows[0]["Identity_Proof_Value"].ToString();
                BM.altAlt_Identity_Proof = dt2.Rows[0]["Alt_Identity_Proof"].ToString();
                BM.altAlt_Identity_Proof_Value = dt2.Rows[0]["Alt_Identity_Proof_Value"].ToString();
                BM.altAddress1 = dt2.Rows[0]["Address1"].ToString();
                BM.altAddress2 = dt2.Rows[0]["Address2"].ToString();
                BM.altAddress3 = dt2.Rows[0]["Address3"].ToString();
                BM.altcitytext = dt2.Rows[0]["City"].ToString();
                BM.altstatetext = dt2.Rows[0]["State"].ToString();
                BM.altPin = dt2.Rows[0]["Pin"].ToString();
            }
            






            //end



            return View("~/Views/UpdateBeneficiary/UpdateBeneficiary.cshtml",BM);
        }



        public ActionResult UpdatingBeneficiaryData(BeneficiaryModel BM)
        {

            // check type 
            string typ5 = "";
            con.Open();
            string qq15 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa5 = new SqlDataAdapter(qq15, con);
            DataTable dtt5 = new DataTable();
            daa5.Fill(dtt5);
            con.Close();

            if (dtt5.Rows.Count > 0)
            {
                typ5 = dtt5.Rows[0]["Type"].ToString();
            }



            //end



            if (typ5 == "Testator")
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
            SqlCommand cmd = new SqlCommand("SP_CRUDBeneficiaryDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "update");
            cmd.Parameters.AddWithValue("@bpId  ", BM.bpId);
            cmd.Parameters.AddWithValue("@First_Name ", BM.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", BM.Last_Name);
            cmd.Parameters.AddWithValue("@Middle_Name", BM.Middle_Name);
          
            cmd.Parameters.AddWithValue("@DOB",Convert.ToDateTime(BM.Dob));
            cmd.Parameters.AddWithValue("@Mobile", BM.Mobile);
            cmd.Parameters.AddWithValue("@Relationship", BM.RelationshipTxt);
            cmd.Parameters.AddWithValue("@Marital_Status", "none");
            cmd.Parameters.AddWithValue("@Religion", "none");
            cmd.Parameters.AddWithValue("@Identity_proof", BM.Identity_proof);
            cmd.Parameters.AddWithValue("@Identity_proof_value", BM.Alt_Identity_proof_value);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof", BM.Alt_Identity_proof);
            cmd.Parameters.AddWithValue("@Alt_Identity_proof_value", BM.Alt_Identity_proof_value);
            cmd.Parameters.AddWithValue("@Address1", BM.Address1);
            cmd.Parameters.AddWithValue("@Address2", BM.Address2);
            cmd.Parameters.AddWithValue("@Address3", BM.Address3);
            cmd.Parameters.AddWithValue("@City", BM.City_txt);
            cmd.Parameters.AddWithValue("@State", BM.State_txt);
            cmd.Parameters.AddWithValue("@Pin", BM.Pin);
            cmd.Parameters.AddWithValue("@aid", "");
            cmd.Parameters.AddWithValue("@tid", BM.ddltid);
            cmd.Parameters.AddWithValue("@beneficiary_type", "none");
            cmd.ExecuteNonQuery();
            con.Close();




            if (Convert.ToInt32(Session["upbeneficiaryid"]) != 0)
            {
                BM.check = "true";
            }

            if (Session["upbeneficiaryid"] == null)
            {
                RedirectToAction("LoginPageIndex", "LoginPage");
            }


            if (BM.check == "true")
            {

                con.Open();
                SqlCommand cmd2 = new SqlCommand("SP_CRUD_alternate_Beneficiary", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@condition", "update");
                cmd2.Parameters.AddWithValue("@lnk_bd_id", Convert.ToInt32(Session["upbeneficiaryid"]));
                cmd2.Parameters.AddWithValue("@bpId", BM.altbpId);
                cmd2.Parameters.AddWithValue("@First_Name", BM.altFirst_Name);
                cmd2.Parameters.AddWithValue("@Last_Name", BM.altLast_Name);
                cmd2.Parameters.AddWithValue("@Middle_Name", BM.altMiddle_Name);
                //DateTime dat2 = DateTime.ParseExact(BM.altDob, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                cmd2.Parameters.AddWithValue("@DOB", Convert.ToDateTime(BM.altDob));
                cmd2.Parameters.AddWithValue("@Mobile", BM.altMobile);
                cmd2.Parameters.AddWithValue("@Relationship", BM.altRelationshipTxt);
                cmd2.Parameters.AddWithValue("@Marital_Status","none");
                cmd2.Parameters.AddWithValue("@Religion", "none");
                cmd2.Parameters.AddWithValue("@Identity_Proof", BM.altIdentity_Proof);
                cmd2.Parameters.AddWithValue("@Identity_Proof_Value", BM.altIdentity_Proof_Value);
                cmd2.Parameters.AddWithValue("@Alt_Identity_Proof", BM.altAlt_Identity_Proof);
                cmd2.Parameters.AddWithValue("@Alt_Identity_Proof_Value", BM.altAlt_Identity_Proof_Value);
                cmd2.Parameters.AddWithValue("@Address1", BM.altAddress1);
                cmd2.Parameters.AddWithValue("@Address2", BM.altAddress2);
                cmd2.Parameters.AddWithValue("@Address3", BM.altAddress3);
                cmd2.Parameters.AddWithValue("@City", BM.altcitytext);
                cmd2.Parameters.AddWithValue("@State", BM.altstatetext);
                cmd2.Parameters.AddWithValue("@Pin", BM.altPin);
                cmd2.ExecuteNonQuery();
                con.Close();


            }




                ViewBag.Message = "Verified";


            return View("~/Views/UpdateBeneficiary/UpdateBeneficiary.cshtml");
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



        public string OnChangeBindCity()
        {
            string response = Request["send"];
            con.Open();
            string query = "select distinct * from tbl_city where state_id ='" + response + "' order by city_name asc ";
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



        public string BindTestatorDDL()
        {

            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                string ck = "select type from users where uId =" + Convert.ToInt32(Session["uuid"]) + "";
                SqlDataAdapter cda = new SqlDataAdapter(ck, con);
                DataTable cdt = new DataTable();
                cda.Fill(cdt);
                string type = "";
                if (cdt.Rows.Count > 0)
                {
                    type = cdt.Rows[0]["type"].ToString();

                }

                if (type != "Testator")
                {
                    con.Open();
                    string query = "select * from TestatorDetails a   inner join users b on a.uId = b.uId  where b.Linked_user = " + Convert.ToInt32(Session["uuid"]) + " ";
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
                else
                {
                    con.Open();
                    string query = "select * from TestatorDetails a   inner join users b on a.uId = b.uId  where b.uId = " + Convert.ToInt32(Session["uuid"]) + " ";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    string data = "";




                    if (dt.Rows.Count > 0)
                    {



                        for (int i = 0; i < dt.Rows.Count; i++)
                        {




                            data = data + "<option value=" + dt.Rows[i]["tId"].ToString() + " >" + dt.Rows[i]["First_Name"].ToString() + "</option> " + "~" + dt.Rows[i]["tId"].ToString();



                        }




                    }

                    return data;


                }



            }
            else
            {
                con.Open();
                string query = "select * from TestatorDetails";
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
}