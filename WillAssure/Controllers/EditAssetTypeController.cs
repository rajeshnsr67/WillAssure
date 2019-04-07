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
using System.Collections;

namespace WillAssure.Controllers
{
    public class EditAssetTypeController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: EditAssetType
        public ActionResult EditAssetTypeIndex()
        {
            if (Session.SessionID == null)
            {

                return RedirectToAction("LoginPageIndex", "LoginPage");

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
            return View("~/Views/EditAssetType/EditAssetTypePageContent.cshtml");
        }

        public string BindAssetTypeFormData()
        {
            // check roles
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








            }

            con.Close();





            //end



            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[6].Action;

            }



            con.Open();
            string query = "select * from AssetsType";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {
                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["atid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["atid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["atid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["atid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["atid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["atid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["atid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["atid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";

                                   

                    }
                }


               







            }

            return data;
        }



        public string DeleteAssetTypeRecords(AssetTypeModel ATM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AssetsTypeCRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@atid", index); 
            cmd.Parameters.AddWithValue("@assettype", "");

            cmd.ExecuteNonQuery();
            con.Close();


            // check roles
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








            }

            con.Close();





            //end



            string testString = "";

            for (int i = 0; i < Lmlist.Count(); i++)
            {
                testString = Lmlist[6].Action;

            }



            con.Open();
            string query = "select * from AssetsType";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {
                if (testString == "1,2,0" || testString == "0,2,0" || testString == "0,2,3" || testString == "0,2,3" || testString == "0,2,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["atid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["atid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td></tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["atid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["atid"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["atid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"

                                    + "<td><button type='button'   id='" + dt.Rows[i]["atid"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["atid"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td></tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["atid"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>";



                    }
                }










            }

            return data;
        }




        public int UpdateAssetTypeForm()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }


    }
}