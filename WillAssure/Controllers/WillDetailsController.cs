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
        public ActionResult WillDetailsIndex()
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
            List<WillDetailModel> list1 = new List<WillDetailModel>();
            List<WillDetailModel> list2 = new List<WillDetailModel>();
            List<WillDetailModel> list3 = new List<WillDetailModel>();
            List<WillDetailModel> list4 = new List<WillDetailModel>();
            List<WillDetailModel> list5 = new List<WillDetailModel>();
            List<WillDetailModel> list6 = new List<WillDetailModel>();
            List<WillDetailModel> list7 = new List<WillDetailModel>();
            List<WillDetailModel> list8 = new List<WillDetailModel>();
            List<WillDetailModel> list9 = new List<WillDetailModel>();

            if (Convert.ToInt32(Session["uuid"]) != 1)
            {
                con.Open();
                string query = "select * from TestatorDetails";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                //WDM.VerifyId = NestId;
                if (dt.Rows.Count > 0)
                {

                    // testator details
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        WillDetailModel WDM1 = new WillDetailModel();

                        WDM1.TestatorName = dt.Rows[i]["First_Name"].ToString();

                        WDM1.TestatorLastName = dt.Rows[i]["Last_Name"].ToString();
                        WDM1.TestatorMiddleName = dt.Rows[i]["Middle_Name"].ToString();
                        WDM1.TestatorDOB = dt.Rows[i]["DOB"].ToString();
                        WDM1.TestatorOccupation = dt.Rows[i]["Occupation"].ToString();
                        WDM1.TestatorMobile = dt.Rows[i]["Mobile"].ToString();
                        WDM1.TestatorEmail = dt.Rows[i]["Email"].ToString();
                        WDM1.TestatorMaritalStatus = dt.Rows[i]["maritalStatus"].ToString();
                        WDM1.TestatorRelationship = dt.Rows[i]["RelationShip"].ToString();
                        WDM1.TestatorReligion = dt.Rows[i]["Religion"].ToString();
                        WDM1.TestatorIdentityProof = dt.Rows[i]["Identity_Proof"].ToString();
                        WDM1.TestatorIdentityProofValue = dt.Rows[i]["Identity_proof_Value"].ToString();
                        WDM1.TestatorAltIdentityProof = dt.Rows[i]["Alt_Identity_Proof"].ToString();
                        WDM1.TestatorAltIdentityProofValue = dt.Rows[i]["Alt_Identity_proof_Value"].ToString();
                        WDM1.TestatorGender = dt.Rows[i]["Gender"].ToString();
                        WDM1.TestatorAddress1 = dt.Rows[i]["Address1"].ToString();
                        WDM1.TestatorAddress2 = dt.Rows[i]["Address2"].ToString();
                        WDM1.TestatorAddress3 = dt.Rows[i]["Address3"].ToString();
                        WDM1.TestatorCity = dt.Rows[i]["City"].ToString();
                        WDM1.TestatorState = dt.Rows[i]["State"].ToString();
                        WDM1.TestatorCountry = dt.Rows[i]["Country"].ToString();
                        WDM1.TestatorPin = dt.Rows[i]["Pin"].ToString();
                        //end

                          list1.Add(WDM1);
                        
                    }


                    ViewBag.TestatorDetails = list1;

                }



                // beneficiary 
                con.Open();
                string query2 = "select * from BeneficiaryDetails";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                con.Close();


                
                if (dt2.Rows.Count > 0)
                {

                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        WillDetailModel WDM2 = new WillDetailModel();
                      
                        WDM2.BeneficiaryName = dt2.Rows[i]["First_Name"].ToString();

                        WDM2.BeneficiaryLastName = dt2.Rows[i]["Last_Name"].ToString();
                        WDM2.BeneficiaryMiddleName = dt2.Rows[i]["Middle_Name"].ToString();
                        WDM2.BeneficiaryDOB = dt2.Rows[i]["DOB"].ToString();
                        WDM2.BeneficiaryMobile = dt2.Rows[i]["Mobile"].ToString();
                        WDM2.BeneficiaryRelationship = dt2.Rows[i]["Relationship"].ToString();
                        WDM2.BeneficiaryMartialStatus = dt2.Rows[i]["Marital_Status"].ToString();
                        WDM2.BeneficiaryReligion = dt2.Rows[i]["Religion"].ToString();
                        WDM2.BeneficiaryIdentityProof = dt2.Rows[i]["Identity_proof"].ToString();
                        WDM2.BeneficiaryIdentityProofValue = dt2.Rows[i]["Identity_proof_value"].ToString();
                        WDM2.BeneficiaryaltidentityProof = dt2.Rows[i]["Alt_Identity_proof"].ToString();
                        WDM2.beneficiaryaltidentityproofvalue = dt2.Rows[i]["Alt_Identity_proof_value"].ToString();
                        WDM2.beneficiaryaddress1 = dt2.Rows[i]["Address1"].ToString();
                        WDM2.beneficiaryaddress2 = dt2.Rows[i]["Address2"].ToString();
                        WDM2.beneficiaryaddress3 = dt2.Rows[i]["Address3"].ToString();
                        WDM2.beneficiarycity = dt2.Rows[i]["City"].ToString();
                        WDM2.beneficiarystate = dt2.Rows[i]["State"].ToString();
                        WDM2.beneficiarypin = dt2.Rows[i]["Pin"].ToString();

                        list2.Add(WDM2);
                        
                    }

                    ViewBag.beneficiary = list2;



                }



                //end






                // appointees 
                con.Open();
                string query3 = "select * from Appointees ";
                SqlDataAdapter da4 = new SqlDataAdapter(query3, con);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                con.Close();


            
                if (dt4.Rows.Count > 0)
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        WillDetailModel WDM4 = new WillDetailModel();


                        WDM4.appointeesType = dt4.Rows[i]["Type"].ToString();

                        WDM4.appointeesSubtype = dt4.Rows[i]["subType"].ToString();
                        WDM4.appointeesName = dt4.Rows[i]["Name"].ToString();
                        WDM4.appointeesmiddle = dt4.Rows[i]["middleName"].ToString();
                        WDM4.appointeessurname = dt4.Rows[i]["Surname"].ToString();
                        WDM4.appointeesidentityproof = dt4.Rows[i]["Identity_Proof"].ToString();
                        WDM4.appointeesIdentityproofvalue = dt4.Rows[i]["Identity_Proof_Value"].ToString();
                        WDM4.appointeesaltidentityproof = dt4.Rows[i]["Alt_Identity_Proof"].ToString();
                        WDM4.appointeesaltidentityproofvalue = dt4.Rows[i]["Alt_Identity_Proof_Value"].ToString();
                        WDM4.appointeesDOB = dt4.Rows[i]["DOB"].ToString();
                        WDM4.appointeesGender = dt4.Rows[i]["Gender"].ToString();
                        WDM4.appointeesOccupation = dt4.Rows[i]["Occupation"].ToString();
                        WDM4.appointeesrelationship = dt4.Rows[i]["Relationship"].ToString();
                        WDM4.appointeesaddress1 = dt4.Rows[i]["Address1"].ToString();
                        WDM4.appointeesaddress2 = dt4.Rows[i]["Address2"].ToString();
                        WDM4.appointeesaddress3 = dt4.Rows[i]["Address3"].ToString();
                        WDM4.appointeescity = dt4.Rows[i]["City"].ToString();
                        WDM4.appointeesstate = dt4.Rows[i]["State"].ToString();
                        WDM4.appointeespin = dt4.Rows[i]["Pin"].ToString();

                        list5.Add(WDM4);
                    }
                    ViewBag.appointees = list5;

                }



                //end






                // Testator Family 
                con.Open();
                string query5 = "select * from testatorFamily";
                SqlDataAdapter da5 = new SqlDataAdapter(query5, con);
                DataTable dt5 = new DataTable();
                da5.Fill(dt5);
                con.Close();


           
                if (dt5.Rows.Count > 0)
                {

                    for (int i = 0; i < dt5.Rows.Count; i++)
                    {
                        WillDetailModel WDM3 = new WillDetailModel();
                        WDM3.tffirstname = dt5.Rows[i]["First_Name"].ToString();

                        WDM3.tflastname = dt5.Rows[i]["Last_Name"].ToString();
                        WDM3.tfmiddlename = dt5.Rows[i]["Middle_Name"].ToString();
                        WDM3.tfdob = dt5.Rows[i]["DOB"].ToString();
                        WDM3.tfmaritalstatus = dt5.Rows[i]["Marital_Status"].ToString();
                        WDM3.tfreligion = dt5.Rows[i]["Religion"].ToString();
                        WDM3.tfrelationship = dt5.Rows[i]["Relationship"].ToString();
                        WDM3.tfaddress1 = dt5.Rows[i]["Address1"].ToString();
                        WDM3.tfaddress2 = dt5.Rows[i]["Address2"].ToString();
                        WDM3.tfaddress3 = dt5.Rows[i]["Address3"].ToString();
                        WDM3.tfcity = dt5.Rows[i]["City"].ToString();
                        WDM3.tfstate = dt5.Rows[i]["State"].ToString();
                        WDM3.tfpin = dt5.Rows[i]["Pin"].ToString();
                        WDM3.tfidentityproof = dt5.Rows[i]["Identity_Proof"].ToString();
                        WDM3.tfidentityproofvalue = dt5.Rows[i]["Identity_Proof_Value"].ToString();
                        WDM3.tfaltidentityproof = dt5.Rows[i]["Alt_Identity_Proof"].ToString();
                        WDM3.tfaltidentityproofvalue = dt5.Rows[i]["Alt_Identity_Proof_Value"].ToString();
                        WDM3.tfisinformedperson = dt5.Rows[i]["Is_Informed_Person"].ToString();

                        list3.Add(WDM3);
                        
                    }
                    ViewBag.testatorFamily = list3;



                }



                //end





                // Beneficiary Mapping
                con.Open();
                string query6 = "select c.AssetsType , b.AssetsCategory , a.SchemeName , a.InstrumentName , a.Proportion from BeneficiaryAssets a inner join AssetsCategory b on a.AssetCategory_ID=b.amId inner join AssetsType c on b.atId = c.atId";
                SqlDataAdapter da6 = new SqlDataAdapter(query6, con);
                DataTable dt6 = new DataTable();
                da6.Fill(dt6);
                con.Close();


           
                if (dt6.Rows.Count > 0)
                {

                    for (int i = 0; i < dt6.Rows.Count; i++)
                    {
                        WillDetailModel WDM5 = new WillDetailModel();
                        WDM5.bmassettype = dt6.Rows[i]["AssetsType"].ToString();

                        WDM5.bmassetcat = dt6.Rows[i]["AssetsCategory"].ToString();
                        WDM5.bmschemename = dt6.Rows[i]["SchemeName"].ToString();
                        WDM5.bminstrumentname = dt6.Rows[i]["InstrumentName"].ToString();
                        WDM5.bmproportion = dt6.Rows[i]["Proportion"].ToString();
                       

                        list6.Add(WDM5);

                    }
                    ViewBag.BeneficiaryMapping = list6;



                }



                //end



                // altbene 
              
              

                con.Open();
                string query7 = "select * from alternate_Beneficiary";
                SqlDataAdapter da7 = new SqlDataAdapter(query7, con);
                DataTable dt7 = new DataTable();
                da7.Fill(dt7);

                con.Close();

                if (dt7.Rows.Count > 0)
                {
                    for (int i = 0; i < dt7.Rows.Count; i++)
                    {
                        WillDetailModel ABM = new WillDetailModel();
                        ABM.altbenefirstname = dt7.Rows[i]["First_Name"].ToString();
                        ABM.altbenelastname = dt7.Rows[i]["Last_Name"].ToString();
                        ABM.altbenemiddlename = dt7.Rows[i]["Middle_Name"].ToString();

                        ABM.altbenedob = dt7.Rows[i]["DOB"].ToString();
                        ABM.altbenemobile = dt7.Rows[i]["Mobile"].ToString();
                        ABM.altbenerelationship = dt7.Rows[i]["Relationship"].ToString();
                        ABM.altbenemaritalstatus = dt7.Rows[i]["Marital_Status"].ToString();
                        ABM.altbenereligion = dt7.Rows[i]["Religion"].ToString();
                        ABM.altbeneidentityproof = dt7.Rows[i]["Identity_Proof"].ToString();
                        ABM.altbeneidentityproofvalue = dt7.Rows[i]["Identity_Proof_Value"].ToString();
                        ABM.altbenealtidentityproof = dt7.Rows[i]["Alt_Identity_Proof"].ToString();
                        ABM.altbenealtidentityproofvalue = dt7.Rows[i]["Alt_Identity_Proof_Value"].ToString();
                        ABM.altbeneaddress1 = dt7.Rows[i]["Address1"].ToString();
                        ABM.altbeneaddress2 = dt7.Rows[i]["Address2"].ToString();
                        ABM.altbeneaddress3 = dt7.Rows[i]["Address3"].ToString();
                        ABM.altbenecity = dt7.Rows[i]["City"].ToString();
                        ABM.altbenestate = dt7.Rows[i]["State"].ToString();
                        ABM.altbenepin = dt7.Rows[i]["Pin"].ToString();

                        list7.Add(ABM);

                    }

                    ViewBag.altbene = list7;


                }




                //end



                //nominee


                
                con.Open();
                string query8 = "select * from Nominee";
                SqlDataAdapter da8 = new SqlDataAdapter(query8, con);
                DataTable dt8 = new DataTable();
                da8.Fill(dt8);
                con.Close();


                if (dt8.Rows.Count > 0)
                {


                    for (int i = 0; i < dt8.Rows.Count; i++)
                    {
                        WillDetailModel NM = new WillDetailModel();
                      
                        NM.nomfirstname = dt8.Rows[i]["First_Name"].ToString();
                        NM.nomlastname = dt8.Rows[i]["Last_Name"].ToString();
                        NM.nommiddlename = dt8.Rows[i]["Middle_Name"].ToString();
                        NM.nomdob = dt8.Rows[0]["DOB"].ToString();
                        NM.nommobile = dt8.Rows[i]["Mobile"].ToString();
                        NM.nomrelationship = dt8.Rows[i]["Relationship"].ToString();
                        NM.nommaritalstatus = dt8.Rows[i]["Marital_Status"].ToString();
                        NM.nomreligion = dt8.Rows[i]["Religion"].ToString();
                        NM.nomidentityproof = dt8.Rows[i]["Identity_Proof"].ToString();
                        NM.nomidentityproofvalue = dt8.Rows[i]["Identity_Proof_Value"].ToString();
                        NM.nomaltidentityproof = dt8.Rows[i]["Alt_Identity_Proof"].ToString();
                        NM.nomaltidentityproofvalue = dt8.Rows[i]["Alt_Identity_Proof_Value"].ToString();
                        NM.nomaddress1 = dt8.Rows[i]["Address1"].ToString();
                        NM.nomaddress2 = dt8.Rows[i]["Address2"].ToString();
                        NM.nomaddress3 = dt8.Rows[i]["Address3"].ToString();
                        NM.nomcity = dt8.Rows[i]["City"].ToString();
                        NM.nomstate = dt8.Rows[i]["State"].ToString();
                        NM.nompin = dt8.Rows[i]["Pin"].ToString();
                       


                        list8.Add(NM);
                    }


                    ViewBag.nominee = list8;
                }



                //end




                // alt appointment
               
               

                con.Open();
                string query9 = "select * from alternate_Appointees";
                SqlDataAdapter da9 = new SqlDataAdapter(query9, con);
                DataTable dt9 = new DataTable();
                da9.Fill(dt9);
                con.Close();
                string data = "";

                if (dt9.Rows.Count > 0)
                {


                    for (int i = 0; i < dt9.Rows.Count; i++)
                    {
                        WillDetailModel Am = new WillDetailModel();


                        Am.altappname = dt9.Rows[i]["Name"].ToString();
                        Am.altappmiddlename = dt9.Rows[i]["middleName"].ToString();
                        Am.altappsurname = dt9.Rows[i]["Surname"].ToString();
                        Am.altappidentityproof = dt9.Rows[i]["Identity_Proof"].ToString();
                        Am.altappidentityproofvalue = dt9.Rows[i]["Identity_Proof_Value"].ToString();
                        Am.altappaltidentityproof = dt9.Rows[i]["Alt_Identity_Proof"].ToString();
                        Am.altappaltidentityproofvalue = dt9.Rows[i]["Alt_Identity_Proof_Value"].ToString();

                        Am.altappdob = dt9.Rows[i]["DOB"].ToString();

                        Am.altappgender = dt9.Rows[i]["Gender"].ToString();
                        Am.altappoccupation = dt9.Rows[i]["Occupation"].ToString();
                        Am.altapprelationship = dt9.Rows[i]["Relationship"].ToString();
                        Am.altappaddress1 = dt9.Rows[i]["Address1"].ToString();
                        Am.altappaddress2 = dt9.Rows[i]["Address2"].ToString();
                        Am.altappaddress3 = dt9.Rows[i]["Address3"].ToString();
                        Am.altappcity = dt9.Rows[i]["City"].ToString();
                        Am.altappstate = dt9.Rows[i]["State"].ToString();
                        Am.altapppin = dt9.Rows[i]["Pin"].ToString();
                        Am.altappaltguardian = dt9.Rows[i]["altguardian"].ToString();
                        Am.altappaltexec = dt9.Rows[i]["altexec"].ToString();


                        list9.Add(Am);

                    }

                    ViewBag.altappointment = list9;
                }






                //end








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
            int TemplateID =0;
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