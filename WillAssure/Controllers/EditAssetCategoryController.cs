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
    public class EditAssetCategoryController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditAssetCategory
        public ActionResult EditAssetCategoryIndex()
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
            return View("~/Views/EditAssetCategory/EditAssetCategoryPageContent.cshtml");
        }

        public string BindAssetCategoryFormData()
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
                testString = Lmlist[3].Action;

            }




            con.Open();
            string query = "select a.amId , b.AssetsType , a.AssetsCategory , a.assetsCode from AssetsCategory a inner join AssetsType b on a.atId=b.atId";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["amId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["assetsCode"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["amId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["assetsCode"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["amId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["assetsCode"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["amId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["assetsCode"].ToString() + "</td>";
                                   

                    }
                }



               


            }

            return data;
        }



        public string DeleteAssetCategoryData(RoleFormModel RFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AssetsCategoryCRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@amId", index);
            cmd.Parameters.AddWithValue("@atid", "");
            cmd.Parameters.AddWithValue("@assetcategory", "");
            cmd.Parameters.AddWithValue("@assetcode", "");

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
                testString = Lmlist[3].Action;

            }





            con.Open();
            string query = "select a.amId , b.AssetsType , a.AssetsCategory , a.assetsCode from AssetsCategory a inner join AssetsType b on a.atId=b.atId";
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
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["amId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["assetsCode"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button></td>    </tr>";

                    }
                }

                if (testString == "1,0,3" || testString == "0,0,3" || testString == "0,2,3" || testString == "1,0,3" || testString == "0,0,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["amId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["assetsCode"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "'    class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }
                }


                if (testString == "1,2,3" || testString == "0,2,3")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["amId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["assetsCode"].ToString() + "</td>"
                                    + "<td><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["amId"].ToString() + "'   class='btn btn-danger deletenotification'>Delete</button></td>    </tr>";

                    }

                }


                if (testString == "0,0,0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["amId"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsType"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["AssetsCategory"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["assetsCode"].ToString() + "</td>";


                    }
                }






            }

            return data;
        }





        public int UpdateAssetCategoryData()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }


    }
}