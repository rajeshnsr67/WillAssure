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

namespace WillAssure.Views.ViewDocument
{
    public partial class Report : System.Web.UI.Page
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);


        protected void Page_Load(object sender, EventArgs e)
        {
            string TestatorName = "";
            string TestatorRelationShip = "";
            int age = 0;
            string TestatorAge = "";
            string TestatorAddress = "";
            string BeneficiaryName = "";
            string executorname = "";
            string alternateexecutorname = "";
            string Relation =  "";
            string assetcategory = "";
            string instrumentname = "";
            string mapbeneficiary = "";
            string proportion = "";
            string testatorsirname = "";
            string beneficiarysirname = "";
           
            string query1 = "select a.First_Name as TestatorName , a.Last_Name as Testatorsirname , a.DOB as TestatorAge , a.RelationShip as TestatorRelationship , a.Address1 as TestatorAddress , b.First_Name as BeneficiaryName , b.Last_Name as Beneficiarysirname  , c.Name as executorname , d.Name as alternateexecutorname , e.Relationship as Relation , g.AssetsCategory , f.InstrumentName , b.First_Name as BeneficiaryName , f.Proportion    from TestatorDetails a inner join BeneficiaryDetails b on a.tId=b.tId inner join Appointees c on a.tId = c.tid  inner join Appointees d on a.tId=d.tid inner join testatorFamily e on a.tId=e.tId inner join BeneficiaryAssets f on a.tId=f.tid  inner join AssetsCategory g on g.amId=f.AssetCategory_ID where a.uId = " + Convert.ToInt32(Session["uid"]) + "";
            SqlDataAdapter da = new SqlDataAdapter(query1,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                TestatorName = dt.Rows[0]["TestatorName"].ToString();

                testatorsirname = dt.Rows[0]["Testatorsirname"].ToString();

               

                DateTime dateOfBirth = Convert.ToDateTime(dt.Rows[0]["TestatorAge"]);
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));
                age = (now - dob) / 10000;

                TestatorAge = age.ToString();


                TestatorRelationShip = dt.Rows[0]["TestatorRelationship"].ToString();


                TestatorAddress = dt.Rows[0]["TestatorAddress"].ToString();

               

                BeneficiaryName = dt.Rows[0]["BeneficiaryName"].ToString();

                beneficiarysirname = dt.Rows[0]["Beneficiarysirname"].ToString();



                executorname = dt.Rows[0]["executorname"].ToString();


                alternateexecutorname = dt.Rows[0]["alternateexecutorname"].ToString();


                Relation = dt.Rows[0]["Relation"].ToString();



                assetcategory = dt.Rows[0]["AssetsCategory"].ToString();
                instrumentname = dt.Rows[0]["InstrumentName"].ToString();
                mapbeneficiary = dt.Rows[0]["BeneficiaryName"].ToString();
                proportion = dt.Rows[0]["Proportion"].ToString();



                con.Close();




                

            }

            //WillTestator rpt = new WillTestator();

            ////ReportDocument rpt = new ReportDocument();
            //rpt.SetParameterValue("testator", TestatorName);
            //rpt.SetParameterValue("testatorsirname", TestatorName + testatorsirname);
            //rpt.SetParameterValue("testatorrelation", TestatorRelationShip);
            //rpt.SetParameterValue("testatorage", TestatorAge);
            //rpt.SetParameterValue("beneficiaryname", BeneficiaryName);
            //rpt.SetParameterValue("beneficiarysirname", beneficiarysirname);
            //rpt.SetParameterValue("testatoradd", TestatorAddress);
            //rpt.SetParameterValue("appointee1", executorname);
            //rpt.SetParameterValue("appointee2", alternateexecutorname);
            //rpt.SetParameterValue("wifename", Relation);
            //rpt.SetParameterValue("assetcategory", assetcategory);
            //rpt.SetParameterValue("assetname", instrumentname);
            //rpt.SetParameterValue("benefname", mapbeneficiary);
            //rpt.SetParameterValue("percent", proportion);

            //rpt.Load(Server.MapPath(@"~/CrystalReports/WillTestator.rpt"));

            //CrystalReportViewer1.ReportSource = rpt;
            //CrystalReportViewer1.Zoom(125);

        }



     

    }
}