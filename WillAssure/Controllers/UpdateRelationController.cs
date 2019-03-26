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

namespace WillAssure.Models
{
    public class UpdateRelationController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateRelation
        public ActionResult UpdateRelationIndex(int NestId)
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
            MemberModelcs mmc = new MemberModelcs();

            con.Open();
            string query = "select * from relationship where Rid = '" + NestId + "' ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {
                mmc.Rid = NestId;
                mmc.MemberName = dt.Rows[0]["MemberName"].ToString();




            }

            return View("~/Views/UpdateRelation/UpdateRelationPageContent.cshtml",mmc);
        }


        public ActionResult UpdatingRelation(MemberModelcs mmc)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_RelationShipCRUD", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@Rid ", mmc.Rid);
            cmd.Parameters.AddWithValue("@MemberName ", mmc.MemberName);
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.Message = "Verified";
            return View("~/Views/UpdateRelation/UpdateRelationPageContent.cshtml");
        }


    }
}