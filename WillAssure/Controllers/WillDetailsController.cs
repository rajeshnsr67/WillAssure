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
                string query = "select  a.First_Name as TestatorName , a.Last_Name as TestatorLastName , a.Middle_Name as TestatorMiddleName , a.DOB as TestatorDOB , a.Occupation as TestatorOccupation , a.Mobile as TestatorMobile , a.Email as TestatorEmail , a.maritalStatus as TestatorMaritalStatus , a.RelationShip as TestatorRelationShip , a.Religion as TestatorReligion , a.Identity_Proof as TestatorIdentitProof , a.Identity_proof_Value as TestatorIdentityProofValue , a.Alt_Identity_Proof as TestatorAltIdentityProof , a.Alt_Identity_proof_Value as TestatorAltProofValue , a.Gender as TestatorGender , a.Address1 as TestatorAddress1 , a.Address2 as TestatorAddress2 , a.Address3  as TestatorAddress3 , a.City as TestatorCity , a.State as TestatorState , a.Country as TestatorCountry , a.Pin as TestatorPin , b.First_Name as BeneficiaryName , b.Last_Name as BeneficiaryLastName , b.Middle_Name as BeneficiaryMiddleName , b.DOB as BeneficiaryDOB , b.Mobile as BeneficiaryMobile , b.Relationship as BeneficiaryRelationship , b.Marital_Status as BeneficiaryMartialStatus , b.Religion as BeneficiaryReligion , b.Identity_proof as BeneficiaryIdentityProof , b.Identity_proof_value as BeneficiaryIdentityProofValue , b.Alt_Identity_proof as BeneficiaryaltidentityProof , b.Alt_Identity_proof_value as beneficiaryaltidentityproofvalue  , b.Address1 as beneficiaryaddress1 , b.Address2 as beneficiaryaddress2 , b.Address3 as beneficiaryaddress3 , b.City as beneficiarycity , b.State as beneficiarystate , b.Pin as beneficiarypin , c.Type as appointeesType , c.subType as appointeesSubtype , c.Name as appointeesName , c.middleName as appointeesmiddle , c.Surname as appointeessurname , c.Identity_Proof as appointeesidentityproof , c.Identity_Proof_Value as appointeesIdentityproofvalue , c.Alt_Identity_Proof as appointeesaltidentityproof , c.Alt_Identity_Proof_Value as appointeesaltidentityproofvalue , c.DOB as appointeesDOB ,c.Gender as appointeesGender , c.Occupation as appointeesOccupation , c.Relationship as appointeesrelationship , c.Address1 as appointeesaddress1 , c.Address2 as appointeesaddress2 , c.Address3 as appointeesaddress3 , c.City as appointeescity , c.State as appointeesstate , c.Pin as appointeespin , e.First_Name as tffirstname , e.Last_Name as tflastname , e.Middle_Name as tfmiddlename , e.DOB as tfdob , e.Marital_Status as tfmaritalstatus , e.Religion as tfreligion , e.Relationship as tfrelationship , e.Address1 as tfaddress1 , e.Address2 as tfaddress2 , e.Address3 as tfaddress3 , e.City as tfcity , e.State as tfstate , e.Pin as tfpin , e.Identity_Proof as tfidentityproof , e.Identity_Proof_Value as tfidentityproofvalue , e.Alt_Identity_Proof as tfaltidentityproof , e.Alt_Identity_Proof_Value as tfaltidentityproofvalue , e.Is_Informed_Person as tfisinformedperson , h.AssetsType as bmassettype , g.AssetsCategory as bmassetcat , f.SchemeName as bmschemename , f.InstrumentName as bminstrumentname  ,  f.Proportion as bmproportion , ab.First_Name as altbenefirstname , ab.Last_Name as altbenelastname , ab.Middle_Name as altbenemiddlename , ab.DOB as altbenedob , ab.Mobile as altbenemobile , ab.Relationship as altbenerelationship , ab.Marital_Status as altbenemaritalstatus , ab.Religion as altbenereligion  , ab.Identity_Proof as altbeneidentityproof , ab.Identity_Proof_Value as altbeneidentityproofvalue , ab.Alt_Identity_Proof as altbenealtidentityproof  ,  ab.Alt_Identity_Proof_Value as altbenealtidentityproofvalue , ab.Address1 as altbeneaddress1 , ab.Address2 as altbeneaddress2 , ab.Address3 as altbeneaddress3 , ab.City as altbenecity , ab.State  as altbenestate , ab.Pin as altbenepin , ap.Name as altappname , ap.MiddleName as altappmiddlename , ap.Surname as altappsurname , ap.Identity_proof as altappidentityproof , ap.Identity_proof_value as altappidentityproofvalue , ap.Alt_Identity_proof as altappaltidentityproof , ap.Alt_Identity_proof_value as altappaltidentityproofvalue ,ap.DOB as altappdob ,  ap.Gender as altappgender , ap.Occupation as altappoccupation , ap.Relationship as altapprelationship , ap.Address1 as altappaddress1 , ap.Address2 as altappaddress2 , ap.Address3 as altappaddress3 , ap.City as altappcity , ap.State as altappstate , ap.Pin as altapppin , ap.altguardian as altappaltguardian , ap.altexec as altappaltexec , nom.First_Name as nomfirstname , nom.Last_Name as nomlastname , nom.Middle_Name as nommiddlename , nom.DOB as nomdob , nom.Mobile as nommobile , nom.Relationship as nomrelationship , nom.Marital_Status as nommaritalstatus , nom.Religion as nomreligion , nom.Identity_Proof as nomidentityproof , nom.Identity_Proof_Value as nomidentityproofvalue , nom.Alt_Identity_Proof as nomaltidentityproof , nom.Alt_Identity_Proof_Value as nomaltidentityproofvalue , nom.Address1 as nomaddress1 , nom.Address2 as nomaddress2 , nom.Address3 as nomaddress3 , nom.City as nomcity , nom.State as nomstate , nom.Pin as nompin  from TestatorDetails a inner join BeneficiaryDetails b on a.tId=b.tId inner join Appointees c on a.tId = c.tid  inner join testatorFamily e on a.tId=e.tId inner join BeneficiaryAssets f on a.tId=f.tid  inner join AssetsCategory g on g.amId=f.AssetCategory_ID inner join AssetsType h on g.atId=h.atId inner join alternate_Beneficiary as ab on b.bpId=ab.bpId  inner join alternate_Appointees ap on ap.apId=c.apId inner join Nominee as nom on a.tId = nom.tId inner join  users i on a.uId=i.uId where a.tId = " + NestId + " ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                WDM.VerifyId = NestId;
                if (dt.Rows.Count > 0)
                {
                    WDM.TestatorName = dt.Rows[0]["TestatorName"].ToString();
                    WDM.TestatorLastName = dt.Rows[0]["TestatorLastName"].ToString();
                    WDM.TestatorMiddleName = dt.Rows[0]["TestatorMiddleName"].ToString();
                    WDM.TestatorDOB = dt.Rows[0]["TestatorDOB"].ToString();
                    WDM.TestatorOccupation = dt.Rows[0]["TestatorOccupation"].ToString();
                    WDM.TestatorMobile = dt.Rows[0]["TestatorMobile"].ToString();
                    WDM.TestatorEmail = dt.Rows[0]["TestatorEmail"].ToString();
                    WDM.TestatorMaritalStatus = dt.Rows[0]["TestatorMaritalStatus"].ToString();
                    WDM.TestatorRelationship = dt.Rows[0]["TestatorRelationship"].ToString();
                    WDM.TestatorReligion = dt.Rows[0]["TestatorReligion"].ToString();
                    WDM.TestatorIdentityProof = dt.Rows[0]["TestatorIdentitProof"].ToString();
                    WDM.TestatorIdentityProofValue = dt.Rows[0]["TestatorIdentityProofValue"].ToString();
                    WDM.TestatorAltIdentityProof = dt.Rows[0]["TestatorAltIdentityProof"].ToString();
                    WDM.TestatorAltIdentityProofValue = dt.Rows[0]["TestatorAltProofValue"].ToString();
                    WDM.TestatorGender = dt.Rows[0]["TestatorGender"].ToString();
                    WDM.TestatorAddress1 = dt.Rows[0]["TestatorAddress1"].ToString();
                    WDM.TestatorAddress2 = dt.Rows[0]["TestatorAddress2"].ToString();
                    WDM.TestatorAddress3 = dt.Rows[0]["TestatorAddress3"].ToString();
                    WDM.TestatorCity = dt.Rows[0]["TestatorCity"].ToString();
                    WDM.TestatorState = dt.Rows[0]["TestatorState"].ToString();
                    WDM.TestatorCountry = dt.Rows[0]["TestatorCountry"].ToString();
                    WDM.TestatorPin = dt.Rows[0]["TestatorPin"].ToString();


                    WDM.BeneficiaryName = dt.Rows[0]["BeneficiaryName"].ToString();
                    WDM.BeneficiaryLastName = dt.Rows[0]["BeneficiaryLastName"].ToString();
                    WDM.BeneficiaryMiddleName = dt.Rows[0]["BeneficiaryMiddleName"].ToString();
                    WDM.BeneficiaryDOB = dt.Rows[0]["BeneficiaryDOB"].ToString();
                    WDM.BeneficiaryMobile = dt.Rows[0]["BeneficiaryMobile"].ToString();
                    WDM.BeneficiaryRelationship = dt.Rows[0]["BeneficiaryRelationship"].ToString();
                    WDM.BeneficiaryMartialStatus = dt.Rows[0]["BeneficiaryMartialStatus"].ToString();
                    WDM.BeneficiaryReligion = dt.Rows[0]["BeneficiaryReligion"].ToString();
                    WDM.BeneficiaryIdentityProof = dt.Rows[0]["BeneficiaryIdentityProof"].ToString();
                    WDM.BeneficiaryIdentityProofValue = dt.Rows[0]["BeneficiaryIdentityProofValue"].ToString();
                    WDM.BeneficiaryaltidentityProof = dt.Rows[0]["BeneficiaryaltidentityProof"].ToString();
                    WDM.beneficiaryaltidentityproofvalue = dt.Rows[0]["beneficiaryaltidentityproofvalue"].ToString();
                    WDM.beneficiaryaddress1 = dt.Rows[0]["beneficiaryaddress1"].ToString();
                    WDM.beneficiaryaddress2 = dt.Rows[0]["beneficiaryaddress2"].ToString();
                    WDM.beneficiaryaddress3 = dt.Rows[0]["beneficiaryaddress3"].ToString();
                    WDM.beneficiarycity = dt.Rows[0]["beneficiarycity"].ToString();
                    WDM.beneficiarystate = dt.Rows[0]["beneficiarystate"].ToString();
                    WDM.beneficiarypin = dt.Rows[0]["beneficiarypin"].ToString();


                    WDM.appointeesType = dt.Rows[0]["appointeesType"].ToString();
                    WDM.appointeesSubtype = dt.Rows[0]["appointeesSubtype"].ToString();
                    WDM.appointeesName = dt.Rows[0]["appointeesName"].ToString();
                    WDM.appointeesmiddle = dt.Rows[0]["appointeesmiddle"].ToString();
                    WDM.appointeessurname = dt.Rows[0]["appointeessurname"].ToString();
                    WDM.appointeesidentityproof = dt.Rows[0]["appointeesidentityproof"].ToString();
                    WDM.appointeesIdentityproofvalue = dt.Rows[0]["appointeesIdentityproofvalue"].ToString();
                    WDM.appointeesaltidentityproof = dt.Rows[0]["appointeesaltidentityproof"].ToString();
                    WDM.appointeesaltidentityproofvalue = dt.Rows[0]["appointeesaltidentityproofvalue"].ToString();
                    WDM.appointeesDOB = dt.Rows[0]["appointeesDOB"].ToString();
                    WDM.appointeesGender = dt.Rows[0]["appointeesGender"].ToString();
                    WDM.appointeesOccupation = dt.Rows[0]["appointeesOccupation"].ToString();
                    WDM.appointeesrelationship = dt.Rows[0]["appointeesrelationship"].ToString();
                    WDM.appointeesaddress1 = dt.Rows[0]["appointeesaddress1"].ToString();
                    WDM.appointeesaddress2 = dt.Rows[0]["appointeesaddress2"].ToString();
                    WDM.appointeesaddress3 = dt.Rows[0]["appointeesaddress3"].ToString();
                    WDM.appointeescity = dt.Rows[0]["appointeescity"].ToString();
                    WDM.appointeesstate = dt.Rows[0]["appointeesstate"].ToString();
                    WDM.appointeespin = dt.Rows[0]["appointeespin"].ToString();


                    WDM.tffirstname = dt.Rows[0]["tffirstname"].ToString();
                    WDM.tflastname = dt.Rows[0]["tflastname"].ToString();
                    WDM.tfmiddlename = dt.Rows[0]["tfmiddlename"].ToString();
                    WDM.tfdob = dt.Rows[0]["tfdob"].ToString();
                    WDM.tfmaritalstatus = dt.Rows[0]["tfmaritalstatus"].ToString();
                    WDM.tfreligion = dt.Rows[0]["tfreligion"].ToString();
                    WDM.tfreligion = dt.Rows[0]["tfreligion"].ToString();
                    WDM.tfaddress1 = dt.Rows[0]["tfaddress1"].ToString();
                    WDM.tfaddress2 = dt.Rows[0]["tfaddress2"].ToString();
                    WDM.tfaddress3 = dt.Rows[0]["tfaddress3"].ToString();
                    WDM.tfcity = dt.Rows[0]["tfcity"].ToString();
                    WDM.tfstate = dt.Rows[0]["tfstate"].ToString();
                    WDM.tfpin = dt.Rows[0]["tfpin"].ToString();
                    WDM.tfidentityproof = dt.Rows[0]["tfidentityproof"].ToString();
                    WDM.tfidentityproofvalue = dt.Rows[0]["tfidentityproofvalue"].ToString();
                    WDM.tfaltidentityproof = dt.Rows[0]["tfaltidentityproof"].ToString();
                    WDM.tfaltidentityproofvalue = dt.Rows[0]["tfaltidentityproofvalue"].ToString();
                    WDM.tfisinformedperson = dt.Rows[0]["tfisinformedperson"].ToString();


                    WDM.bmassettype = dt.Rows[0]["bmassettype"].ToString();
                    WDM.bmassetcat = dt.Rows[0]["bmassetcat"].ToString();
                    WDM.bmschemename = dt.Rows[0]["bmschemename"].ToString();
                    WDM.bminstrumentname = dt.Rows[0]["bminstrumentname"].ToString();
                    WDM.bmproportion = dt.Rows[0]["bmproportion"].ToString();


                    WDM.altbenefirstname = dt.Rows[0]["altbenefirstname"].ToString();
                    WDM.altbenelastname = dt.Rows[0]["altbenelastname"].ToString();
                    WDM.altbenemiddlename = dt.Rows[0]["altbenemiddlename"].ToString();
                    WDM.altbenedob = dt.Rows[0]["altbenedob"].ToString();
                    WDM.altbenemobile = dt.Rows[0]["altbenemobile"].ToString();
                    WDM.altbenerelationship = dt.Rows[0]["altbenerelationship"].ToString();
                    WDM.altbenemaritalstatus = dt.Rows[0]["altbenemaritalstatus"].ToString();
                    WDM.altbenereligion = dt.Rows[0]["altbenereligion"].ToString();
                    WDM.altbeneidentityproof = dt.Rows[0]["altbeneidentityproof"].ToString();
                    WDM.altbeneidentityproofvalue = dt.Rows[0]["altbeneidentityproofvalue"].ToString();
                    WDM.altbenealtidentityproof = dt.Rows[0]["altbenealtidentityproof"].ToString();
                    WDM.altbenealtidentityproofvalue = dt.Rows[0]["altbenealtidentityproofvalue"].ToString();
                    WDM.altbeneaddress1 = dt.Rows[0]["altbeneaddress1"].ToString();
                    WDM.altbeneaddress2 = dt.Rows[0]["altbeneaddress2"].ToString();
                    WDM.altbeneaddress3 = dt.Rows[0]["altbeneaddress3"].ToString();
                    WDM.altbenecity = dt.Rows[0]["altbenecity"].ToString();
                    WDM.altbenestate = dt.Rows[0]["altbenestate"].ToString();
                    WDM.altbenepin = dt.Rows[0]["altbenepin"].ToString();


                    WDM.altappname = dt.Rows[0]["altappname"].ToString();
                    WDM.altappmiddlename = dt.Rows[0]["altappmiddlename"].ToString();
                    WDM.altappsurname = dt.Rows[0]["altappsurname"].ToString();
                    WDM.altappidentityproof = dt.Rows[0]["altappidentityproof"].ToString();
                    WDM.altappidentityproofvalue = dt.Rows[0]["altappidentityproofvalue"].ToString();
                    WDM.altappaltidentityproof = dt.Rows[0]["altappaltidentityproof"].ToString();
                    WDM.altappaltidentityproofvalue = dt.Rows[0]["altappaltidentityproofvalue"].ToString();
                    WDM.altappdob = dt.Rows[0]["altappdob"].ToString();
                    WDM.altappgender = dt.Rows[0]["altappgender"].ToString();
                    WDM.altappoccupation = dt.Rows[0]["altappoccupation"].ToString();
                    WDM.altapprelationship = dt.Rows[0]["altapprelationship"].ToString();
                    WDM.altappaddress1 = dt.Rows[0]["altappaddress1"].ToString();
                    WDM.altappaddress2 = dt.Rows[0]["altappaddress2"].ToString();
                    WDM.altappaddress3 = dt.Rows[0]["altappaddress3"].ToString();
                    WDM.altappcity = dt.Rows[0]["altappcity"].ToString();
                    WDM.altappstate = dt.Rows[0]["altappstate"].ToString();
                    WDM.altapppin = dt.Rows[0]["altapppin"].ToString();
                    WDM.altappaltguardian = dt.Rows[0]["altappaltguardian"].ToString();
                    WDM.altappaltexec = dt.Rows[0]["altappaltexec"].ToString();


                    WDM.nomfirstname = dt.Rows[0]["nomfirstname"].ToString();
                    WDM.nomlastname = dt.Rows[0]["nomlastname"].ToString();
                    WDM.nommiddlename = dt.Rows[0]["nommiddlename"].ToString();
                    WDM.nomdob = dt.Rows[0]["nomdob"].ToString();
                    WDM.nommobile = dt.Rows[0]["nommobile"].ToString();
                    WDM.nomrelationship = dt.Rows[0]["nomrelationship"].ToString();
                    WDM.nommaritalstatus = dt.Rows[0]["nommaritalstatus"].ToString();
                    WDM.nomreligion = dt.Rows[0]["nomreligion"].ToString();
                    WDM.nomidentityproof = dt.Rows[0]["nomidentityproof"].ToString();
                    WDM.nomidentityproofvalue = dt.Rows[0]["nomidentityproofvalue"].ToString();
                    WDM.nomaltidentityproof = dt.Rows[0]["nomaltidentityproof"].ToString();
                    WDM.nomaltidentityproofvalue = dt.Rows[0]["nomaltidentityproofvalue"].ToString();
                    WDM.nomaddress1 = dt.Rows[0]["nomaddress1"].ToString();
                    WDM.nomaddress2 = dt.Rows[0]["nomaddress2"].ToString();
                    WDM.nomaddress3 = dt.Rows[0]["nomaddress3"].ToString();
                    WDM.nomcity = dt.Rows[0]["nomcity"].ToString();
                    WDM.nomstate = dt.Rows[0]["nomstate"].ToString();
                    WDM.nompin = dt.Rows[0]["nompin"].ToString();



                }

            }
            else
            {


                con.Open();
                string query = "select  a.First_Name as TestatorName , a.Last_Name as TestatorLastName , a.Middle_Name as TestatorMiddleName , a.DOB as TestatorDOB , a.Occupation as TestatorOccupation , a.Mobile as TestatorMobile , a.Email as TestatorEmail , a.maritalStatus as TestatorMaritalStatus , a.RelationShip as TestatorRelationShip , a.Religion as TestatorReligion , a.Identity_Proof as TestatorIdentitProof , a.Identity_proof_Value as TestatorIdentityProofValue , a.Alt_Identity_Proof as TestatorAltIdentityProof , a.Alt_Identity_proof_Value as TestatorAltProofValue , a.Gender as TestatorGender , a.Address1 as TestatorAddress1 , a.Address2 as TestatorAddress2 , a.Address3  as TestatorAddress3 , a.City as TestatorCity , a.State as TestatorState , a.Country as TestatorCountry , a.Pin as TestatorPin , b.First_Name as BeneficiaryName , b.Last_Name as BeneficiaryLastName , b.Middle_Name as BeneficiaryMiddleName , b.DOB as BeneficiaryDOB , b.Mobile as BeneficiaryMobile , b.Relationship as BeneficiaryRelationship , b.Marital_Status as BeneficiaryMartialStatus , b.Religion as BeneficiaryReligion , b.Identity_proof as BeneficiaryIdentityProof , b.Identity_proof_value as BeneficiaryIdentityProofValue , b.Alt_Identity_proof as BeneficiaryaltidentityProof , b.Alt_Identity_proof_value as beneficiaryaltidentityproofvalue  , b.Address1 as beneficiaryaddress1 , b.Address2 as beneficiaryaddress2 , b.Address3 as beneficiaryaddress3 , b.City as beneficiarycity , b.State as beneficiarystate , b.Pin as beneficiarypin , c.Type as appointeesType , c.subType as appointeesSubtype , c.Name as appointeesName , c.middleName as appointeesmiddle , c.Surname as appointeessurname , c.Identity_Proof as appointeesidentityproof , c.Identity_Proof_Value as appointeesIdentityproofvalue , c.Alt_Identity_Proof as appointeesaltidentityproof , c.Alt_Identity_Proof_Value as appointeesaltidentityproofvalue , c.DOB as appointeesDOB ,c.Gender as appointeesGender , c.Occupation as appointeesOccupation , c.Relationship as appointeesrelationship , c.Address1 as appointeesaddress1 , c.Address2 as appointeesaddress2 , c.Address3 as appointeesaddress3 , c.City as appointeescity , c.State as appointeesstate , c.Pin as appointeespin , e.First_Name as tffirstname , e.Last_Name as tflastname , e.Middle_Name as tfmiddlename , e.DOB as tfdob , e.Marital_Status as tfmaritalstatus , e.Religion as tfreligion , e.Relationship as tfrelationship , e.Address1 as tfaddress1 , e.Address2 as tfaddress2 , e.Address3 as tfaddress3 , e.City as tfcity , e.State as tfstate , e.Pin as tfpin , e.Identity_Proof as tfidentityproof , e.Identity_Proof_Value as tfidentityproofvalue , e.Alt_Identity_Proof as tfaltidentityproof , e.Alt_Identity_Proof_Value as tfaltidentityproofvalue , e.Is_Informed_Person as tfisinformedperson , h.AssetsType as bmassettype , g.AssetsCategory as bmassetcat , f.SchemeName as bmschemename , f.InstrumentName as bminstrumentname  ,  f.Proportion as bmproportion , ab.First_Name as altbenefirstname , ab.Last_Name as altbenelastname , ab.Middle_Name as altbenemiddlename , ab.DOB as altbenedob , ab.Mobile as altbenemobile , ab.Relationship as altbenerelationship , ab.Marital_Status as altbenemaritalstatus , ab.Religion as altbenereligion  , ab.Identity_Proof as altbeneidentityproof , ab.Identity_Proof_Value as altbeneidentityproofvalue , ab.Alt_Identity_Proof as altbenealtidentityproof  ,  ab.Alt_Identity_Proof_Value as altbenealtidentityproofvalue , ab.Address1 as altbeneaddress1 , ab.Address2 as altbeneaddress2 , ab.Address3 as altbeneaddress3 , ab.City as altbenecity , ab.State  as altbenestate , ab.Pin as altbenepin , ap.Name as altappname , ap.MiddleName as altappmiddlename , ap.Surname as altappsurname , ap.Identity_proof as altappidentityproof , ap.Identity_proof_value as altappidentityproofvalue , ap.Alt_Identity_proof as altappaltidentityproof , ap.Alt_Identity_proof_value as altappaltidentityproofvalue ,ap.DOB as altappdob ,  ap.Gender as altappgender , ap.Occupation as altappoccupation , ap.Relationship as altapprelationship , ap.Address1 as altappaddress1 , ap.Address2 as altappaddress2 , ap.Address3 as altappaddress3 , ap.City as altappcity , ap.State as altappstate , ap.Pin as altapppin , ap.altguardian as altappaltguardian , ap.altexec as altappaltexec , nom.First_Name as nomfirstname , nom.Last_Name as nomlastname , nom.Middle_Name as nommiddlename , nom.DOB as nomdob , nom.Mobile as nommobile , nom.Relationship as nomrelationship , nom.Marital_Status as nommaritalstatus , nom.Religion as nomreligion , nom.Identity_Proof as nomidentityproof , nom.Identity_Proof_Value as nomidentityproofvalue , nom.Alt_Identity_Proof as nomaltidentityproof , nom.Alt_Identity_Proof_Value as nomaltidentityproofvalue , nom.Address1 as nomaddress1 , nom.Address2 as nomaddress2 , nom.Address3 as nomaddress3 , nom.City as nomcity , nom.State as nomstate , nom.Pin as nompin  from TestatorDetails a inner join BeneficiaryDetails b on a.tId=b.tId inner join Appointees c on a.tId = c.tid  inner join testatorFamily e on a.tId=e.tId inner join BeneficiaryAssets f on a.tId=f.tid  inner join AssetsCategory g on g.amId=f.AssetCategory_ID inner join AssetsType h on g.atId=h.atId inner join alternate_Beneficiary as ab on b.bpId=ab.bpId  inner join alternate_Appointees ap on ap.apId=c.apId inner join Nominee as nom on a.tId = nom.tId inner join  users i on a.uId=i.uId where a.tId = " + NestId + " ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                WDM.VerifyId = NestId;
                if (dt.Rows.Count > 0)
                {
                    WDM.TestatorName = dt.Rows[0]["TestatorName"].ToString();
                    WDM.TestatorLastName = dt.Rows[0]["TestatorLastName"].ToString();
                    WDM.TestatorMiddleName = dt.Rows[0]["TestatorMiddleName"].ToString();
                    WDM.TestatorDOB = dt.Rows[0]["TestatorDOB"].ToString();
                    WDM.TestatorOccupation = dt.Rows[0]["TestatorOccupation"].ToString();
                    WDM.TestatorMobile = dt.Rows[0]["TestatorMobile"].ToString();
                    WDM.TestatorEmail = dt.Rows[0]["TestatorEmail"].ToString();
                    WDM.TestatorMaritalStatus = dt.Rows[0]["TestatorMaritalStatus"].ToString();
                    WDM.TestatorRelationship = dt.Rows[0]["TestatorRelationship"].ToString();
                    WDM.TestatorReligion = dt.Rows[0]["TestatorReligion"].ToString();
                    WDM.TestatorIdentityProof = dt.Rows[0]["TestatorIdentitProof"].ToString();
                    WDM.TestatorIdentityProofValue = dt.Rows[0]["TestatorIdentityProofValue"].ToString();
                    WDM.TestatorAltIdentityProof = dt.Rows[0]["TestatorAltIdentityProof"].ToString();
                    WDM.TestatorAltIdentityProofValue = dt.Rows[0]["TestatorAltProofValue"].ToString();
                    WDM.TestatorGender = dt.Rows[0]["TestatorGender"].ToString();
                    WDM.TestatorAddress1 = dt.Rows[0]["TestatorAddress1"].ToString();
                    WDM.TestatorAddress2 = dt.Rows[0]["TestatorAddress2"].ToString();
                    WDM.TestatorAddress3 = dt.Rows[0]["TestatorAddress3"].ToString();
                    WDM.TestatorCity = dt.Rows[0]["TestatorCity"].ToString();
                    WDM.TestatorState = dt.Rows[0]["TestatorState"].ToString();
                    WDM.TestatorCountry = dt.Rows[0]["TestatorCountry"].ToString();
                    WDM.TestatorPin = dt.Rows[0]["TestatorPin"].ToString();


                    WDM.BeneficiaryName = dt.Rows[0]["BeneficiaryName"].ToString();
                    WDM.BeneficiaryLastName = dt.Rows[0]["BeneficiaryLastName"].ToString();
                    WDM.BeneficiaryMiddleName = dt.Rows[0]["BeneficiaryMiddleName"].ToString();
                    WDM.BeneficiaryDOB = dt.Rows[0]["BeneficiaryDOB"].ToString();
                    WDM.BeneficiaryMobile = dt.Rows[0]["BeneficiaryMobile"].ToString();
                    WDM.BeneficiaryRelationship = dt.Rows[0]["BeneficiaryRelationship"].ToString();
                    WDM.BeneficiaryMartialStatus = dt.Rows[0]["BeneficiaryMartialStatus"].ToString();
                    WDM.BeneficiaryReligion = dt.Rows[0]["BeneficiaryReligion"].ToString();
                    WDM.BeneficiaryIdentityProof = dt.Rows[0]["BeneficiaryIdentityProof"].ToString();
                    WDM.BeneficiaryIdentityProofValue = dt.Rows[0]["BeneficiaryIdentityProofValue"].ToString();
                    WDM.BeneficiaryaltidentityProof = dt.Rows[0]["BeneficiaryaltidentityProof"].ToString();
                    WDM.beneficiaryaltidentityproofvalue = dt.Rows[0]["beneficiaryaltidentityproofvalue"].ToString();
                    WDM.beneficiaryaddress1 = dt.Rows[0]["beneficiaryaddress1"].ToString();
                    WDM.beneficiaryaddress2 = dt.Rows[0]["beneficiaryaddress2"].ToString();
                    WDM.beneficiaryaddress3 = dt.Rows[0]["beneficiaryaddress3"].ToString();
                    WDM.beneficiarycity = dt.Rows[0]["beneficiarycity"].ToString();
                    WDM.beneficiarystate = dt.Rows[0]["beneficiarystate"].ToString();
                    WDM.beneficiarypin = dt.Rows[0]["beneficiarypin"].ToString();


                    WDM.appointeesType = dt.Rows[0]["appointeesType"].ToString();
                    WDM.appointeesSubtype = dt.Rows[0]["appointeesSubtype"].ToString();
                    WDM.appointeesName = dt.Rows[0]["appointeesName"].ToString();
                    WDM.appointeesmiddle = dt.Rows[0]["appointeesmiddle"].ToString();
                    WDM.appointeessurname = dt.Rows[0]["appointeessurname"].ToString();
                    WDM.appointeesidentityproof = dt.Rows[0]["appointeesidentityproof"].ToString();
                    WDM.appointeesIdentityproofvalue = dt.Rows[0]["appointeesIdentityproofvalue"].ToString();
                    WDM.appointeesaltidentityproof = dt.Rows[0]["appointeesaltidentityproof"].ToString();
                    WDM.appointeesaltidentityproofvalue = dt.Rows[0]["appointeesaltidentityproofvalue"].ToString();
                    WDM.appointeesDOB = dt.Rows[0]["appointeesDOB"].ToString();
                    WDM.appointeesGender = dt.Rows[0]["appointeesGender"].ToString();
                    WDM.appointeesOccupation = dt.Rows[0]["appointeesOccupation"].ToString();
                    WDM.appointeesrelationship = dt.Rows[0]["appointeesrelationship"].ToString();
                    WDM.appointeesaddress1 = dt.Rows[0]["appointeesaddress1"].ToString();
                    WDM.appointeesaddress2 = dt.Rows[0]["appointeesaddress2"].ToString();
                    WDM.appointeesaddress3 = dt.Rows[0]["appointeesaddress3"].ToString();
                    WDM.appointeescity = dt.Rows[0]["appointeescity"].ToString();
                    WDM.appointeesstate = dt.Rows[0]["appointeesstate"].ToString();
                    WDM.appointeespin = dt.Rows[0]["appointeespin"].ToString();


                    WDM.tffirstname = dt.Rows[0]["tffirstname"].ToString();
                    WDM.tflastname = dt.Rows[0]["tflastname"].ToString();
                    WDM.tfmiddlename = dt.Rows[0]["tfmiddlename"].ToString();
                    WDM.tfdob = dt.Rows[0]["tfdob"].ToString();
                    WDM.tfmaritalstatus = dt.Rows[0]["tfmaritalstatus"].ToString();
                    WDM.tfreligion = dt.Rows[0]["tfreligion"].ToString();
                    WDM.tfreligion = dt.Rows[0]["tfreligion"].ToString();
                    WDM.tfaddress1 = dt.Rows[0]["tfaddress1"].ToString();
                    WDM.tfaddress2 = dt.Rows[0]["tfaddress2"].ToString();
                    WDM.tfaddress3 = dt.Rows[0]["tfaddress3"].ToString();
                    WDM.tfcity = dt.Rows[0]["tfcity"].ToString();
                    WDM.tfstate = dt.Rows[0]["tfstate"].ToString();
                    WDM.tfpin = dt.Rows[0]["tfpin"].ToString();
                    WDM.tfidentityproof = dt.Rows[0]["tfidentityproof"].ToString();
                    WDM.tfidentityproofvalue = dt.Rows[0]["tfidentityproofvalue"].ToString();
                    WDM.tfaltidentityproof = dt.Rows[0]["tfaltidentityproof"].ToString();
                    WDM.tfaltidentityproofvalue = dt.Rows[0]["tfaltidentityproofvalue"].ToString();
                    WDM.tfisinformedperson = dt.Rows[0]["tfisinformedperson"].ToString();


                    WDM.bmassettype = dt.Rows[0]["bmassettype"].ToString();
                    WDM.bmassetcat = dt.Rows[0]["bmassetcat"].ToString();
                    WDM.bmschemename = dt.Rows[0]["bmschemename"].ToString();
                    WDM.bminstrumentname = dt.Rows[0]["bminstrumentname"].ToString();
                    WDM.bmproportion = dt.Rows[0]["bmproportion"].ToString();


                    WDM.altbenefirstname = dt.Rows[0]["altbenefirstname"].ToString();
                    WDM.altbenelastname = dt.Rows[0]["altbenelastname"].ToString();
                    WDM.altbenemiddlename = dt.Rows[0]["altbenemiddlename"].ToString();
                    WDM.altbenedob = dt.Rows[0]["altbenedob"].ToString();
                    WDM.altbenemobile = dt.Rows[0]["altbenemobile"].ToString();
                    WDM.altbenerelationship = dt.Rows[0]["altbenerelationship"].ToString();
                    WDM.altbenemaritalstatus = dt.Rows[0]["altbenemaritalstatus"].ToString();
                    WDM.altbenereligion = dt.Rows[0]["altbenereligion"].ToString();
                    WDM.altbeneidentityproof = dt.Rows[0]["altbeneidentityproof"].ToString();
                    WDM.altbeneidentityproofvalue = dt.Rows[0]["altbeneidentityproofvalue"].ToString();
                    WDM.altbenealtidentityproof = dt.Rows[0]["altbenealtidentityproof"].ToString();
                    WDM.altbenealtidentityproofvalue = dt.Rows[0]["altbenealtidentityproofvalue"].ToString();
                    WDM.altbeneaddress1 = dt.Rows[0]["altbeneaddress1"].ToString();
                    WDM.altbeneaddress2 = dt.Rows[0]["altbeneaddress2"].ToString();
                    WDM.altbeneaddress3 = dt.Rows[0]["altbeneaddress3"].ToString();
                    WDM.altbenecity = dt.Rows[0]["altbenecity"].ToString();
                    WDM.altbenestate = dt.Rows[0]["altbenestate"].ToString();
                    WDM.altbenepin = dt.Rows[0]["altbenepin"].ToString();


                    WDM.altappname = dt.Rows[0]["altappname"].ToString();
                    WDM.altappmiddlename = dt.Rows[0]["altappmiddlename"].ToString();
                    WDM.altappsurname = dt.Rows[0]["altappsurname"].ToString();
                    WDM.altappidentityproof = dt.Rows[0]["altappidentityproof"].ToString();
                    WDM.altappidentityproofvalue = dt.Rows[0]["altappidentityproofvalue"].ToString();
                    WDM.altappaltidentityproof = dt.Rows[0]["altappaltidentityproof"].ToString();
                    WDM.altappaltidentityproofvalue = dt.Rows[0]["altappaltidentityproofvalue"].ToString();
                    WDM.altappdob = dt.Rows[0]["altappdob"].ToString();
                    WDM.altappgender = dt.Rows[0]["altappgender"].ToString();
                    WDM.altappoccupation = dt.Rows[0]["altappoccupation"].ToString();
                    WDM.altapprelationship = dt.Rows[0]["altapprelationship"].ToString();
                    WDM.altappaddress1 = dt.Rows[0]["altappaddress1"].ToString();
                    WDM.altappaddress2 = dt.Rows[0]["altappaddress2"].ToString();
                    WDM.altappaddress3 = dt.Rows[0]["altappaddress3"].ToString();
                    WDM.altappcity = dt.Rows[0]["altappcity"].ToString();
                    WDM.altappstate = dt.Rows[0]["altappstate"].ToString();
                    WDM.altapppin = dt.Rows[0]["altapppin"].ToString();
                    WDM.altappaltguardian = dt.Rows[0]["altappaltguardian"].ToString();
                    WDM.altappaltexec = dt.Rows[0]["altappaltexec"].ToString();


                    WDM.nomfirstname = dt.Rows[0]["nomfirstname"].ToString();
                    WDM.nomlastname = dt.Rows[0]["nomlastname"].ToString();
                    WDM.nommiddlename = dt.Rows[0]["nommiddlename"].ToString();
                    WDM.nomdob = dt.Rows[0]["nomdob"].ToString();
                    WDM.nommobile = dt.Rows[0]["nommobile"].ToString();
                    WDM.nomrelationship = dt.Rows[0]["nomrelationship"].ToString();
                    WDM.nommaritalstatus = dt.Rows[0]["nommaritalstatus"].ToString();
                    WDM.nomreligion = dt.Rows[0]["nomreligion"].ToString();
                    WDM.nomidentityproof = dt.Rows[0]["nomidentityproof"].ToString();
                    WDM.nomidentityproofvalue = dt.Rows[0]["nomidentityproofvalue"].ToString();
                    WDM.nomaltidentityproof = dt.Rows[0]["nomaltidentityproof"].ToString();
                    WDM.nomaltidentityproofvalue = dt.Rows[0]["nomaltidentityproofvalue"].ToString();
                    WDM.nomaddress1 = dt.Rows[0]["nomaddress1"].ToString();
                    WDM.nomaddress2 = dt.Rows[0]["nomaddress2"].ToString();
                    WDM.nomaddress3 = dt.Rows[0]["nomaddress3"].ToString();
                    WDM.nomcity = dt.Rows[0]["nomcity"].ToString();
                    WDM.nomstate = dt.Rows[0]["nomstate"].ToString();
                    WDM.nompin = dt.Rows[0]["nompin"].ToString();



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