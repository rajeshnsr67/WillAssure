using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using WillAssure.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CrystalDecisions.CrystalReports;
using WillAssure.CrystalReports;
using System.IO;

namespace WillAssure.page
{
    public partial class ChangeTemplate : System.Web.UI.Page
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            int tempid = Convert.ToInt32(Request.QueryString["tempid"]);

            ViewState["tid"] = tempid; 


        }

        protected void btnupdatetemplate_Click(object sender, EventArgs e)
        {



            con.Open();
            string query = "update documentMaster set templateId = "+ddltemplate.SelectedValue+" where Tid= " + Convert.ToInt32(ViewState["tid"]) + "  ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}