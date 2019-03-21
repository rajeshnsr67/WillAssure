using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            // Testator details
            string query1 = "select top 1   First_Name as TestatorName , Last_Name as Sirname , RelationShip as TestatorRelationship , DOB as TestatorAge ,  Address1 as TestatorAddress from TestatorDetails order by tId desc";
            SqlDataAdapter da = new SqlDataAdapter(query1,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                TestatorName = dt.Rows[0]["TestatorName"].ToString();
                TestatorRelationShip = dt.Rows[0]["TestatorRelationship"].ToString();
             
                DateTime dateOfBirth = Convert.ToDateTime(dt.Rows[0]["TestatorAge"]);
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));
                age = (now - dob) / 10000;

                TestatorAge = age.ToString();
                
                TestatorAddress = dt.Rows[0]["TestatorAddress"].ToString();

                testatorsirname = dt.Rows[0]["Sirname"].ToString();
            }
            //end




            // beneficiary name

            con.Open();
            string query2 = "select  top 1 First_Name as BeneficiaryName , Last_Name as Beneficiarysirname from BeneficiaryDetails order by bpId desc";
            SqlDataAdapter da2 = new SqlDataAdapter(query2,con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                BeneficiaryName = dt2.Rows[0]["BeneficiaryName"].ToString();

                beneficiarysirname = dt2.Rows[0]["Beneficiarysirname"].ToString();
            }

            con.Close();



            //end



            // executor name

            con.Open();
            string query3 = "select top 1 Name as executorname from Appointees order by apId desc";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);

            if (dt3.Rows.Count > 0)
            {
                executorname = dt3.Rows[0]["executorname"].ToString();


            }

            con.Close();


            //end




            // alternate executor name

            con.Open();
            string query4 = "select top 1 id , Name as alternateexecutorname from  alternate_Appointees order by id desc";
            SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);

            if (dt4.Rows.Count > 0)
            {
                alternateexecutorname = dt4.Rows[0]["alternateexecutorname"].ToString();


            }

            con.Close();



            //end





            // family details

            con.Open();
            string query5 = "select top 1  First_Name as Relation from testatorFamily where RelationShip = 'wife' order by fId desc";
            SqlDataAdapter da5 = new SqlDataAdapter(query5, con);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);

            if (dt5.Rows.Count > 0)
            {
                Relation = dt5.Rows[0]["Relation"].ToString();


            }

            con.Close();




            //end




            // asset info


            con.Open();
            string query6 = "select b.AssetsCategory , a.InstrumentName , c.First_Name as BeneficiaryName , a.Proportion  from BeneficiaryAssets a inner join AssetsCategory b on a.AssetCategory_ID =b.amId inner join BeneficiaryDetails c on a.Beneficiary_ID = c.bpId";
            SqlDataAdapter da6 = new SqlDataAdapter(query6, con);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);

            if (dt6.Rows.Count > 0)
            {
                assetcategory = dt6.Rows[0]["AssetsCategory"].ToString();
                instrumentname = dt6.Rows[0]["InstrumentName"].ToString();
                mapbeneficiary = dt6.Rows[0]["BeneficiaryName"].ToString();
                proportion = dt6.Rows[0]["Proportion"].ToString();


            }

            con.Close();




            //end



            WillTestator rpt = new WillTestator();

           // ReportDocument rpt = new ReportDocument();
            //rpt.SetParameterValue("testator", TestatorName);
            rpt.SetParameterValue("testatorsirname", TestatorName + testatorsirname);
            rpt.SetParameterValue("testatorrelation", TestatorRelationShip);
            rpt.SetParameterValue("testatorage", TestatorAge);
            rpt.SetParameterValue("beneficiaryname", BeneficiaryName);
            rpt.SetParameterValue("beneficiarysirname", beneficiarysirname);
            rpt.SetParameterValue("testatoradd", TestatorAddress);
            rpt.SetParameterValue("appointee1", executorname);
            rpt.SetParameterValue("appointee2", alternateexecutorname);
            rpt.SetParameterValue("wifename", Relation);
            rpt.SetParameterValue("assetcategory", assetcategory);
            rpt.SetParameterValue("assetname", instrumentname);
            rpt.SetParameterValue("benefname", mapbeneficiary);
            rpt.SetParameterValue("percent", proportion);

            //rpt.Load(Server.MapPath(@"~/CrystalReports/WillTestator.rpt"));

            CrystalReportViewer1.ReportSource = rpt;
            CrystalReportViewer1.Zoom(125);

        }



     

    }
}