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