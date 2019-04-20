using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WillAssure.Models;

namespace WillAssure.Controllers
{
    public class WillDetailsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: WillDetails
        public ActionResult WillDetailsIndex(int NestId)
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

            WillDetailModel WDM = new WillDetailModel();




            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                con.Open();
                string query = "select * from TestatorDetails where tId  = " + NestId + " ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                WDM.VerifyId = NestId;
                if (dt.Rows.Count > 0)
                {

                    // testator details

                    WDM.TestatorName = dt.Rows[0]["First_Name"].ToString();

                    WDM.TestatorLastName = dt.Rows[0]["Last_Name"].ToString();
                    WDM.TestatorMiddleName = dt.Rows[0]["Middle_Name"].ToString();
                    WDM.TestatorDOB = dt.Rows[0]["DOB"].ToString();
                    WDM.TestatorOccupation = dt.Rows[0]["Occupation"].ToString();
                    WDM.TestatorMobile = dt.Rows[0]["Mobile"].ToString();
                    WDM.TestatorEmail = dt.Rows[0]["Email"].ToString();
                    WDM.TestatorMaritalStatus = dt.Rows[0]["maritalStatus"].ToString();
                    WDM.TestatorRelationship = dt.Rows[0]["RelationShip"].ToString();
                    WDM.TestatorReligion = dt.Rows[0]["Religion"].ToString();
                    WDM.TestatorIdentityProof = dt.Rows[0]["Identity_Proof"].ToString();
                    WDM.TestatorIdentityProofValue = dt.Rows[0]["Identity_proof_Value"].ToString();
                    WDM.TestatorAltIdentityProof = dt.Rows[0]["Alt_Identity_Proof"].ToString();
                    WDM.TestatorAltIdentityProofValue = dt.Rows[0]["Alt_Identity_proof_Value"].ToString();
                    WDM.TestatorGender = dt.Rows[0]["Gender"].ToString();
                    WDM.TestatorAddress1 = dt.Rows[0]["Address1"].ToString();
                    WDM.TestatorAddress2 = dt.Rows[0]["Address2"].ToString();
                    WDM.TestatorAddress3 = dt.Rows[0]["Address3"].ToString();
                    WDM.TestatorCity = dt.Rows[0]["City"].ToString();
                    WDM.TestatorState = dt.Rows[0]["State"].ToString(); 
                    WDM.TestatorCountry = dt.Rows[0]["Country"].ToString(); 
                    WDM.TestatorPin = dt.Rows[0]["Pin"].ToString();
                    //end
                }



                // beneficiary 
                con.Open();
                string query2 = "select * from BeneficiaryDetails where tId  = " + NestId + " ";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                con.Close();


                WDM.VerifyId = NestId;
                if (dt2.Rows.Count > 0)
                {

                  

                    WDM.BeneficiaryName = dt2.Rows[0]["First_Name"].ToString();

                    WDM.BeneficiaryLastName = dt2.Rows[0]["Last_Name"].ToString();
                    WDM.BeneficiaryMiddleName = dt2.Rows[0]["Middle_Name"].ToString();
                    WDM.BeneficiaryDOB = dt2.Rows[0]["DOB"].ToString();
                    WDM.BeneficiaryMobile = dt2.Rows[0]["Mobile"].ToString();
                    WDM.BeneficiaryRelationship = dt2.Rows[0]["Relationship"].ToString();
                    WDM.BeneficiaryMartialStatus = dt2.Rows[0]["Marital_Status"].ToString();
                    WDM.BeneficiaryReligion = dt2.Rows[0]["Religion"].ToString();
                    WDM.BeneficiaryIdentityProof = dt2.Rows[0]["Identity_proof"].ToString();
                    WDM.BeneficiaryIdentityProofValue = dt2.Rows[0]["Identity_proof_value"].ToString();
                    WDM.BeneficiaryaltidentityProof = dt2.Rows[0]["Alt_Identity_proof"].ToString();
                    WDM.beneficiaryaltidentityproofvalue = dt2.Rows[0]["Alt_Identity_proof_value"].ToString();
                    WDM.beneficiaryaddress1 = dt2.Rows[0]["Address1"].ToString();
                    WDM.beneficiaryaddress2 = dt2.Rows[0]["Address2"].ToString();
                    WDM.beneficiaryaddress3 = dt2.Rows[0]["Address3"].ToString();
                    WDM.beneficiarycity = dt2.Rows[0]["City"].ToString();
                    WDM.beneficiarystate = dt2.Rows[0]["State"].ToString();
                    WDM.beneficiarypin = dt2.Rows[0]["Pin"].ToString();
                   
                  
                }



                //end






                // appointees 
                con.Open();
                string query3 = "select * from Appointees where tId  = " + NestId + " ";
                SqlDataAdapter da4 = new SqlDataAdapter(query3, con);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                con.Close();


                WDM.VerifyId = NestId;
                if (dt4.Rows.Count > 0)
                {



                    WDM.appointeesType = dt4.Rows[0]["Type"].ToString();

                    WDM.appointeesSubtype = dt4.Rows[0]["subType"].ToString();
                    WDM.appointeesName = dt4.Rows[0]["Name"].ToString();
                    WDM.appointeesmiddle = dt4.Rows[0]["middleName"].ToString();
                    WDM.appointeessurname = dt4.Rows[0]["Surname"].ToString();
                    WDM.appointeesidentityproof = dt4.Rows[0]["Identity_Proof"].ToString();
                    WDM.appointeesIdentityproofvalue = dt4.Rows[0]["Identity_Proof_Value"].ToString();
                    WDM.appointeesaltidentityproof = dt4.Rows[0]["Alt_Identity_Proof"].ToString();
                    WDM.appointeesaltidentityproofvalue = dt4.Rows[0]["Alt_Identity_Proof_Value"].ToString();
                    WDM.appointeesDOB = dt4.Rows[0]["DOB"].ToString();
                    WDM.appointeesGender = dt4.Rows[0]["Gender"].ToString();
                    WDM.appointeesOccupation = dt4.Rows[0]["Occupation"].ToString();
                    WDM.appointeesrelationship = dt4.Rows[0]["Relationship"].ToString();
                    WDM.appointeesaddress1 = dt4.Rows[0]["Address1"].ToString();
                    WDM.appointeesaddress2 = dt4.Rows[0]["Address2"].ToString();
                    WDM.appointeesaddress3 = dt4.Rows[0]["Address3"].ToString();
                    WDM.appointeescity = dt4.Rows[0]["City"].ToString();
                    WDM.appointeesstate = dt4.Rows[0]["State"].ToString(); 
                    WDM.appointeespin = dt4.Rows[0]["Pin"].ToString();

                }



                //end






                // Testator Family 
                con.Open();
                string query5 = "select * from testatorFamily where tId  = " + NestId + " ";
                SqlDataAdapter da5 = new SqlDataAdapter(query5, con);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);
                con.Close();


                WDM.VerifyId = NestId;
                if (dt5.Rows.Count > 0)
                {



                    WDM.tffirstname = dt5.Rows[0]["First_Name"].ToString();

                    WDM.tflastname = dt5.Rows[0]["Last_Name"].ToString();
                    WDM.tfmiddlename = dt5.Rows[0]["Middle_Name"].ToString();
                    WDM.tfdob = dt5.Rows[0]["DOB"].ToString();
                    WDM.tfmaritalstatus = dt5.Rows[0]["Marital_Status"].ToString();
                    WDM.tfreligion = dt5.Rows[0]["Religion"].ToString();
                    WDM.tfrelationship = dt5.Rows[0]["Relationship"].ToString();
                    WDM.tfaddress1 = dt5.Rows[0]["Address1"].ToString();
                    WDM.tfaddress2 = dt5.Rows[0]["Address2"].ToString();
                    WDM.tfaddress3 = dt5.Rows[0]["Address3"].ToString();
                    WDM.tfcity = dt5.Rows[0]["City"].ToString();
                    WDM.tfstate = dt5.Rows[0]["State"].ToString();
                    WDM.tfpin = dt5.Rows[0]["Pin"].ToString();
                    WDM.tfidentityproof = dt5.Rows[0]["Identity_Proof"].ToString();
                    WDM.tfidentityproofvalue = dt5.Rows[0]["Identity_Proof_Value"].ToString();
                    WDM.tfaltidentityproof = dt5.Rows[0]["Alt_Identity_Proof"].ToString();
                    WDM.tfaltidentityproofvalue = dt5.Rows[0]["Alt_Identity_Proof_Value"].ToString();
                    WDM.tfisinformedperson = dt5.Rows[0]["Is_Informed_Person"].ToString();
                   

                }



                //end




                // Testator Family 
                con.Open();
                string query6 = "select c.AssetsType , b.AssetsCategory , a.SchemeName , a.InstrumentName , a.Proportion  from BeneficiaryAssets a inner join AssetsCategory b on a.AssetCategory_ID = b.atId  inner join AssetsType c on c.atId=c.atId where a.tid = " + NestId + " ";
                SqlDataAdapter da6 = new SqlDataAdapter(query6, con);
                DataTable dt6 = new DataTable();
                da6.Fill(dt6);
                con.Close();


                WDM.VerifyId = NestId;
                if (dt6.Rows.Count > 0)
                {



                    WDM.tffirstname = dt6.Rows[0]["First_Name"].ToString();

                    WDM.tflastname = dt6.Rows[0]["Last_Name"].ToString();
                    WDM.tfmiddlename = dt6.Rows[0]["Middle_Name"].ToString();
                    WDM.tfdob = dt6.Rows[0]["DOB"].ToString();
                    WDM.tfmaritalstatus = dt6.Rows[0]["Marital_Status"].ToString();
                    WDM.tfreligion = dt6.Rows[0]["Religion"].ToString();
                    WDM.tfrelationship = dt5.Rows[0]["Relationship"].ToString();
                    WDM.tfaddress1 = dt5.Rows[0]["Address1"].ToString();
                    WDM.tfaddress2 = dt5.Rows[0]["Address2"].ToString();
                    WDM.tfaddress3 = dt5.Rows[0]["Address3"].ToString();
                    WDM.tfcity = dt5.Rows[0]["City"].ToString();
                    WDM.tfstate = dt5.Rows[0]["State"].ToString();
                    WDM.tfpin = dt5.Rows[0]["Pin"].ToString();
                    WDM.tfidentityproof = dt5.Rows[0]["Identity_Proof"].ToString();
                    WDM.tfidentityproofvalue = dt5.Rows[0]["Identity_Proof_Value"].ToString();
                    WDM.tfaltidentityproof = dt5.Rows[0]["Alt_Identity_Proof"].ToString();
                    WDM.tfaltidentityproofvalue = dt5.Rows[0]["Alt_Identity_Proof_Value"].ToString();
                    WDM.tfisinformedperson = dt5.Rows[0]["Is_Informed_Person"].ToString();


                }



                //end






            }
            else
            {


                con.Open();
                string query = "select * from TestatorDetails where tId  = " + NestId + " ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                WDM.VerifyId = NestId;
                if (dt.Rows.Count > 0)
                {

                    WDM.TestatorName = dt.Rows[0]["First_Name"].ToString();

                    WDM.TestatorLastName = dt.Rows[0]["Last_Name"].ToString();
                    WDM.TestatorMiddleName = dt.Rows[0]["Middle_Name"].ToString();
                    WDM.TestatorDOB = dt.Rows[0]["DOB"].ToString();
                    WDM.TestatorOccupation = dt.Rows[0]["Occupation"].ToString();
                    WDM.TestatorMobile = dt.Rows[0]["Mobile"].ToString();
                    WDM.TestatorEmail = dt.Rows[0]["Email"].ToString();
                    WDM.TestatorMaritalStatus = dt.Rows[0]["maritalStatus"].ToString();
                    WDM.TestatorRelationship = dt.Rows[0]["RelationShip"].ToString();
                    WDM.TestatorReligion = dt.Rows[0]["Religion"].ToString();
                    WDM.TestatorIdentityProof = dt.Rows[0]["Identity_Proof"].ToString();
                    WDM.TestatorIdentityProofValue = dt.Rows[0]["Identity_proof_Value"].ToString();
                    WDM.TestatorAltIdentityProof = dt.Rows[0]["Alt_Identity_Proof"].ToString();
                    WDM.TestatorAltIdentityProofValue = dt.Rows[0]["Alt_Identity_proof_Value"].ToString();
                    WDM.TestatorGender = dt.Rows[0]["Gender"].ToString();
                    WDM.TestatorAddress1 = dt.Rows[0]["Address1"].ToString();
                    WDM.TestatorAddress2 = dt.Rows[0]["Address2"].ToString();
                    WDM.TestatorAddress3 = dt.Rows[0]["Address3"].ToString();
                    WDM.TestatorCity = dt.Rows[0]["City"].ToString();
                    WDM.TestatorState = dt.Rows[0]["State"].ToString();
                    WDM.TestatorCountry = dt.Rows[0]["Country"].ToString();
                    WDM.TestatorPin = dt.Rows[0]["Pin"].ToString();
                }



            }



           

           


            return View("~/Views/WillDetails/WillDetailsPageContent.cshtml", WDM);
        }



        public ActionResult GetTidForVerification(WillDetailModel WDM)
        {
            int Response = Convert.ToInt32(Request["send"]);

            con.Open();

            string query = "insert into DocumentVerification (Uid,Tid,Verification_Status) values ("+Convert.ToInt32(Session["uuid"])+" ," + Response + " , 'InActive' )";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();


            con.Close();



            //check document matches with rules
            con.Open();
            string checkquery = "select b.templateId , b.tId , a.documentType , a.category , a.guardian , a.executors_category , a.AlternateBenficiaries , a.AlternateGaurdian , a.AlternateExecutors from documentRules a inner join documentMaster b on a.wdId=b.wdId where a.tid =" + Response + "";
            SqlDataAdapter checkda = new SqlDataAdapter(checkquery, con);
            DataTable checkdt = new DataTable();
            checkda.Fill(checkdt);

            int documentType1 = 0;
            int category = 0;
            int guardian = 0;
            int executors_category = 0;
            int AlternateBenficiaries = 0;
            int AlternateGaurdian = 0;
            int AlternateExecutors = 0;
            int Dmtemplateid = 0;

            if (checkdt.Rows.Count > 0)
            {

                Dmtemplateid = Convert.ToInt32(checkdt.Rows[0]["templateId"]);
                documentType1 = Convert.ToInt32(checkdt.Rows[0]["documentType"]);
                category = Convert.ToInt32(checkdt.Rows[0]["category"]);
                guardian = Convert.ToInt32(checkdt.Rows[0]["guardian"]);
                executors_category = Convert.ToInt32(checkdt.Rows[0]["executors_category"]);
                AlternateBenficiaries = Convert.ToInt32(checkdt.Rows[0]["AlternateBenficiaries"]);
                AlternateGaurdian = Convert.ToInt32(checkdt.Rows[0]["AlternateGaurdian"]);
                AlternateExecutors = Convert.ToInt32(checkdt.Rows[0]["AlternateExecutors"]);

            }




            con.Close();




            // find match

            con.Open();
            string matchquery = "select TemplateID from DocumentIdentifier where DocumentType = " + documentType1 + " and TypeOfWill = " + category + " and AppointmentOfGuardian = " + guardian + " and NumberOfExecutors = " + executors_category + "  and AppointmentOfAltBeneficiary = " + AlternateBenficiaries + " and AppointmentOfAltGuardian = " + AlternateGaurdian + "  and AppointmentOfAltExecutor = " + AlternateExecutors + " ";
            SqlDataAdapter matchda = new SqlDataAdapter(matchquery, con);
            DataTable matchdt = new DataTable();
            matchda.Fill(matchdt);
            int TemplateID = 0;
            if (matchdt.Rows.Count > 0)
            {
                // update documentmaster with match template id 

                TemplateID = Convert.ToInt32(matchdt.Rows[0]["TemplateID"]);
                string query3 = "update documentMaster set templateId = " + Convert.ToInt32(matchdt.Rows[0]["TemplateID"]) + " where tId= " + TemplateID + "  ";
                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd3.ExecuteNonQuery();

                //
            }


            ViewBag.Message = "Verified";

            return View("~/Views/WillDetails/WillDetailsPageContent.cshtml");
        }
    }
}