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
    public class AddRelationController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        // GET: AddRelation
        public ActionResult AddRelationIndex()
        {
            return View("~/Views/AddRelation/AddRelationPageContent.cshtml");
        }


        public ActionResult InsertMemberFormData(MemberModelcs MMC)
        {


            con.Open();
            string query = "select count(*) from relationship  where MemberName = '" + MMC.MemberName + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            int count = (int)cmd.ExecuteScalar();

            if (count > 0)
            {
                ViewBag.Message = "Duplicate";
            }
            else
            {

                SqlCommand cmd2 = new SqlCommand("SP_RelationShipCRUD", con);
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@action", "insert");
                cmd2.Parameters.AddWithValue("@MemberName ", MMC.MemberName);
                cmd2.ExecuteNonQuery();


                ViewBag.Message = "Verified";
            }


            return View("~/Views/AddRelation/AddRelationPageContent.cshtml");
        }

    }

    
}