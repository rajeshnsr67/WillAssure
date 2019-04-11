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

                return RedirectToAction("LoginPageIndex", "LoginPage");

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
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Distributor','Add Distributor~UsersFormIndex~UsersForm','View Distributor~EditUserFormIndex~EditUserForm')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'WillEmployee','Add Employee~AddWillEmployeeIndex~AddWillEmployee','View Employee~EditWillEmployeeIndex~EditWillEmployee')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'DistributorEmployee','Add Employee~AddDistributorEmployeeIndex~AddDistributorEmployee','View Employee~EditDistributorEmployeeIndex~EditDistributorEmployee')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AssignRoles','Assign~AddRoleAssignmentIndex~AddRoleAssignment','NULL~NULL~NULL')";





                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Testators','Add Testators~AddTestatorsFormIndex~AddTestatorsForm','View Testators~EditTestatorIndex~EditTestator')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'TestatorsFamily','Add Testator Family~AddTestatorFamilyIndex~AddTestatorFamily','View Testator Family~EditTestatorFamilyIndex~EditTestatorFamily')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AssetType','Add Asset Type~AssetTypeIndex~AssetType','View Asset Type~EditAssetTypeIndex~EditAssetType')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AssetCategory','Add Category~AddAssetCategoryIndex~AddAssetCategory','View Category~EditAssetCategoryIndex~EditAssetCategory')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AssetControlsMapping','Add Assets Controls~AddAssetsIndex~AddAssets','View Assets Controls~EditAssetsIndex~EditAssets')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AssetInformation','Add Assets~AddMainAssetsIndex~AddMainAssets','View Assets~EditMainAssetsIndex~EditMainAssets')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Relation','Add Relation~AddRelationIndex~AddRelation','View Relation~EditRelationIndex~EditRelation')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Beneficiary','Add Beneficiary~AddBeneficiaryIndex~AddBeneficiary','View Beneficiary~EditBeneficiaryIndex~EditBeneficiary')";
                //qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AlternateBeneficiary','Add Alt Beneficiary~AlternateBeneficiaryIndex~AlternateBeneficiary','Edit Alt Beneficiary~EditAlternateBeneficiaryIndex~EditAlternateBeneficiary')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Nominee','Add Nominee~AddNomineeIndex~AddNominee','View Nominee~EditNomineeIndex~EditNominee')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Appointees','Add Appointees~AddAppointeesIndex~AddAppointees','View Appointees~EditAppointeesIndex~EditAppointees')";
                //qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'AlternateAppointees','Add Alternate Appointees~AddAlternateAppointeesIndex~AddAlternateAppointees','  Edit Alternate Appointees~EditAlternateAppointeesIndex~EditAlternateAppointees')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'CreateCoupons','Add Coupons~AddCouponsIndex~AddCoupons','View Coupons~EditCouponsIndex~EditCoupons')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Mapping','Mapping~AddAssetMappingIndex~AddAssetMapping','NULL~NULL~NULL')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'Document','View Document~ViewDocumentIndex~ViewDocument','NULL~NULL~NULL')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'DocumentAllotment','Allotment~AddDocumentAllotmentIndex~AddDocumentAllotment','NULL~NULL~NULL')";
                qry = qry + "insert into Assignment_Roles (RoleId,PageName,Nav1,Nav2) values (" + roleid + " ,'CouponAllotment','Allotment~CouponsAllotmentIndex~CouponsAllotment','NULL~NULL~NULL')";


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



        public JsonResult CheckRoleId()
        {
            List<PaymentModel> data = new List<PaymentModel>();
          
            if (Request["send"] != "")
            {

                int response = Convert.ToInt32(Request["send"]);
                
              


                    //con.Open();
                    //string query = "select count(RoleId) as total from Assignment_Roles where RoleId =" + response + "";
                    //SqlDataAdapter da = new SqlDataAdapter(query, con);
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);

                    //data = dt.Rows[0]["total"].ToString();
                    //con.Close();



                    con.Open();
                    string query2 = "select PageName from Assignment_Roles  where PageStatus = 'Active' and RoleId = " + response + "";
                    SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    con.Close();


                    if (dt2.Rows.Count > 0)
                    {

                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            PaymentModel p = new PaymentModel();

                            p.PageName = p.PageName + dt2.Rows[i]["PageName"].ToString();

                           data.Add(p);
                        }

                    }







             

            }







            return Json(data);
        }



    }
}