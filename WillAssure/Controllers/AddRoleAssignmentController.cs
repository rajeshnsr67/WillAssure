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
using System.Net.Mail;
using System.Net;
using System.Collections;

namespace WillAssure.Controllers
{
    public class AddRoleAssignmentController : Controller
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: AddRoleAssignment
        public ActionResult AddRoleAssignmentIndex()
        {

            if (Session.SessionID == null)
            {
                return View("~/Views/LoginPage/LoginPageContent.cshtml");
            }
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
            return View("~/Views/AddRoleAssignment/AddRoleAssignmentPageContent.cshtml");
        }



        public ActionResult GetAssignRoles(string data, int roleid)
        {
            // roleassignment
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


            //end


            con.Open();
            string qq = "select count(*) from Assignment_Roles where RoleId = "+roleid+"";
            SqlCommand cmd2 = new SqlCommand(qq,con);
            int count = (int)cmd2.ExecuteScalar();

            if (count > 0)
            {
          
                
                ArrayList result = new ArrayList(data.Split('~'));


                for (int i = 0; i < result.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand(result[i].ToString(), con);
                    cmd.ExecuteNonQuery();
                }



         
            }
            else
            {
               

                string qry = "";
                //string MainLink = "";
                //string SubLink1 = "";
                //string SubLink2 = "";

                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values ("+ roleid + " , 'Roles',' Add Roles~RoleAddIndex~RoleAdd','Edit Roles~EditRoleIndex~EditRole')";
             

                //if (roleid == 2)
                //{
                //    MainLink = "Distributor User";
                //    SubLink1 = "Add Users";
                //    SubLink2 = "Edit Users";
                //}
                //else
                //{
                //    MainLink = "Distributor";
                //    SubLink1 = "Add Distributor";
                //    SubLink2 = "Edit Distributor";
                //}
                //if (roleid == 3)
                //{
                //    MainLink = "WillAssure User";
                //    SubLink1 = "Add Users";
                //    SubLink2 = "Edit Users";

                //}



                //qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Company','Add Company~AddDistributorIndex~AddDistributor','Edit Company~EditDistributorIndex~EditDistributor')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Distributor','Add Distributor~UsersFormIndex~UsersForm','Edit Distributor~EditUserFormIndex~EditUserForm')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AssignRoles','Assign~AddRoleAssignmentIndex~AddRoleAssignment','NULL~NULL~NULL')";



                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Testators','Add Testators~AddTestatorsFormIndex~AddTestatorsForm','Edit Testators~EditTestatorIndex~EditTestator')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'TestatorsFamily','Add Testator Family~AddTestatorFamilyIndex~AddTestatorFamily','Edit Testator Family~EditTestatorFamilyIndex~EditTestatorFamily')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AssetType','Add Asset Type~AssetTypeIndex~AssetType','Edit Asset Type~EditAssetTypeIndex~EditAssetType')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AssetCategory','Add Category~AddAssetCategoryIndex~AddAssetCategory','Edit Category~EditAssetCategoryIndex~EditAssetCategory')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AssetControlsMapping','Add Assets Controls~AddAssetsIndex~AddAssets','Edit Assets Controls~EditAssetsIndex~EditAssets')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AssetInformation','Add Assets~AddMainAssetsIndex~AddMainAssets','Edit Assets~EditMainAssetsIndex~EditMainAssets')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Relation','Add Relation~AddRelationIndex~AddRelation','Edit Relation~EditRelationIndex~EditRelation')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Beneficiary','Add Beneficiary~AddBeneficiaryIndex~AddBeneficiary','Edit Beneficiary~EditBeneficiaryIndex~EditBeneficiary')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AlternateBeneficiary','Add Alt Beneficiary~AlternateBeneficiaryIndex~AlternateBeneficiary','Edit Alt Beneficiary~EditAlternateBeneficiaryIndex~EditAlternateBeneficiary')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Nominee','Add Nominee~AddNomineeIndex~AddNominee','Edit Nominee~EditNomineeIndex~EditNominee')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Appointees','Add Appointees~AddAppointeesIndex~AddAppointees','Edit Appointees~EditAppointeesIndex~EditAppointees')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AlternateAppointees','Add Alternate Appointees~AddAlternateAppointeesIndex~AddAlternateAppointees','  Edit Alternate Appointees~EditAlternateAppointeesIndex~EditAlternateAppointees')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'CreateCoupons','Add Coupons~AddCouponsIndex~AddCoupons','NULL~NULL~NULL')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Mapping','Mapping~AddAssetMappingIndex~AddAssetMapping','NULL~NULL~NULL')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Document','View Document~Report.aspx~page','NULL~NULL~NULL')";


                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'WillEmployee','Add Distributor~UsersFormIndex~UsersForm','Edit Distributor~EditUserFormIndex~EditUserForm')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'DistributorEmployee','Add Distributor~UsersFormIndex~UsersForm','Edit Distributor~EditUserFormIndex~EditUserForm')";

                SqlCommand cmd = new SqlCommand(qry,con);
                cmd.ExecuteNonQuery();


                
            }
            con.Close();


           
            return View("~/Views/AddRoleAssignment/AddRoleAssignmentPageContent.cshtml");
        }


        public string BindRoleddl()
        {

            string data = "";
            con.Open();
            string query = "select * from Roles where Pid = " + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<option value=" + Convert.ToInt32(dt.Rows[i]["rId"]) + ">" + dt.Rows[i]["Role"].ToString() + "</option>";
                }

                


            }


           



            return data;
        }






        public string BindPageDDl()
        {

            string data = "";
            con.Open();
            string query = "select PageId , ParentMenu from dynamicmenu";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<option value=" + Convert.ToInt32(dt.Rows[i]["PageId"]) + ">" + dt.Rows[i]["ParentMenu"].ToString() + "</option>";
                }




            }






            return data;
        }



        public string CheckRoleId()
        {
            int response = Convert.ToInt32(Request["send"]);
            string data = "";
            con.Open();
            string query = "select count(RoleId) as total from Assignment_Roles where RoleId ="+ response + "";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            data = dt.Rows[0]["total"].ToString();


            return data;
        }



    }
}