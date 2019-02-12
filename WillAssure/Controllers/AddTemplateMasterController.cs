using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using WillAssure.Models;


namespace WillAssure.Controllers
{
    public class AddTemplateMasterController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddTemplateMaster
        public ActionResult AddTemplateMasterIndex()
        {
            return View("~/Views/AddTemplateMaster/AddTemplateMasterContent.cshtml");
        }


        public ActionResult InsertTemplateData(TemplateMasterModel TMM)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_templateMasterCRUD", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "insert");
            cmd.Parameters.AddWithValue("@templateType",TMM.templatetxt);
            cmd.Parameters.AddWithValue("@value",TMM.value);
            cmd.Parameters.AddWithValue("@testator_type",TMM.testator_typetxt);
            cmd.ExecuteNonQuery();
            con.Close();



            return View("~/Views/AddTemplateMaster/AddTemplateMasterContent.cshtml");
        }


        public int onchangeddltestatortype()
        {
            int index = Convert.ToInt32(Request["send"]);


            return index;
        }



    }
}