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
using System.Collections;
using Newtonsoft.Json;

namespace WillAssure.Controllers
{
    public class UpdateBeneficiaryMappingController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: UpdateBeneficiaryMapping
        public ActionResult UpdateBeneficiaryMappingIndex(int NestId)
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

            LoginModel MAM = new LoginModel();

            con.Open();
            string query = "select a.Beneficiary_Asset_ID , e.First_Name , c.AssetsType , b.AssetsCategory , a.SchemeName , a.InstrumentName , a.Proportion from BeneficiaryAssets a inner join AssetsCategory b on a.AssetCategory_ID = b.amId inner join AssetsType c on b.atId = c.atId inner join TestatorDetails d on a.tid = d.tId inner join BeneficiaryDetails e on a.Beneficiary_ID = e.bpId where a.Beneficiary_Asset_ID = "+NestId+" ";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            


           


            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   MAM.Beneficiary_Asset_ID = Convert.ToInt32(dt.Rows[i]["Beneficiary_Asset_ID"]);
                   MAM.AssetsType = dt.Rows[i]["AssetsType"].ToString();
                   MAM.AssetsCategory = dt.Rows[i]["AssetsCategory"].ToString();
                   MAM.SchemeName = dt.Rows[i]["SchemeName"].ToString();
                   MAM.InstrumentName = dt.Rows[i]["InstrumentName"].ToString();
                   MAM.Proportion = dt.Rows[i]["Proportion"].ToString();
                   MAM.Beneficiarytxt = dt.Rows[i]["First_Name"].ToString();

                }





            }





            return View("~/Views/UpdateBeneficiaryMapping/UpdateBeneficiaryMappingPageContent.cshtml", MAM);
        }




        public ActionResult UpdateBeneficiaryMappingDATA(LoginModel M)
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



            con.Open();
            string update = "update BeneficiaryAssets set AssetType_ID = "+M.AssetsType+ " , AssetCategory_ID ="+ M.AssetsCategory + " , SchemeName = '"+ M.SchemeName+ "'  , InstrumentName = '"+ M.InstrumentName+ "'  ,Proportion ="+ M.Proportion+ " where Beneficiary_Asset_ID = "+ M.Beneficiary_Asset_ID+" ";
            SqlCommand cmd = new SqlCommand(update,con);
            cmd.ExecuteNonQuery();

            con.Close();



            return View("~/Views/UpdateBeneficiaryMapping/UpdateBeneficiaryMappingPageContent.cshtml");
        }


        public String BindBeneficiaryDDL()
        {

            string ck = "select type from users where uId =" + Convert.ToInt32(Session["uuid"]) + "";
            SqlDataAdapter cda = new SqlDataAdapter(ck, con);
            DataTable cdt = new DataTable();
            cda.Fill(cdt);
            string type = "";
            if (cdt.Rows.Count > 0)
            {
                type = cdt.Rows[0]["type"].ToString();

            }
            string d = "";

            if (type == "Testator")
            {
                d = "select a.aiid, a.bpId , a.First_Name from BeneficiaryDetails a inner join TestatorDetails b on a.tId = b.tId inner join users c on b.uId=c.uId where c.uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            }
            else if (type == "SuperAdmin")
            {
                d = "select a.aiid, a.bpId , a.First_Name from BeneficiaryDetails a inner join TestatorDetails b on a.tId = b.tId  ";
            }
            else
            {

                d = "select a.aiid, a.bpId , a.First_Name from BeneficiaryDetails a inner join TestatorDetails b on a.tId = b.tId inner join users c on b.uId=c.uId where c.Linked_user = " + Convert.ToInt32(Session["uuid"]) + " ";
            }





            string data = "<option value='0'>--Select--</option>";
            con.Open();

            SqlDataAdapter da1 = new SqlDataAdapter(d, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();


            if (dt1.Rows.Count > 0)
            {

                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    data = data + "<option value=" + dt1.Rows[i]["bpId"] + ">" + dt1.Rows[i]["First_Name"] + "</option>";

                }

            }
            return data;

        }


        public String BindAssetTypeDDL()
        {

            con.Open();
            string query = "select * from AssetsType";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "<option value=''>--Select--</option>";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["atId"].ToString() + " >" + dt.Rows[i]["AssetsType"].ToString() + "</option> ";



                }



            }

            return data;

        }

        public string bindassetcatDDL()
        {
            int response = Convert.ToInt32(Request["send"]);
            string ddlassetcat = "<option value=''>--Select--</option>";
            con.Open();
            string query3 = "select * from AssetsCategory where atId = " + response + " ";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            con.Close();


            if (dt3.Rows.Count > 0)
            {

                for (int i = 0; i < dt3.Rows.Count; i++)
                {

                    ddlassetcat = ddlassetcat + "<option value=" + dt3.Rows[i]["amId"] + "  onchange='getassetcatid(this.value)'  >" + dt3.Rows[i]["AssetsCategory"] + "</option>";

                }

            }

            return ddlassetcat;
        }



        public string getassetcolumndata()
        {
           



            con.Open();
            string query3 = "select * from AssetInformation";
            SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
            DataTable dt = new DataTable();
            da3.Fill(dt);
            con.Close();

            string property = "";
            string structure = "";
            string Identifier = "";
            string ddlscheme = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string getjson = dt.Rows[i]["Json"].ToString();
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                    foreach (var item in dict)
                    {
                        string testString = item.Key;
                        ArrayList result = new ArrayList(testString.Split('~'));


                        if (result[0].ToString() == "PropertyDescription")
                        {
                            property = result[1].ToString();
                            if (property == "Scheme")
                            {

                                ddlscheme = ddlscheme + "<option value=" + item.Value + " >" + item.Value + "</option>";
                            }

                        }


                        if (result[0].ToString() == "Identifier")
                        {
                            Identifier = result[1].ToString();

                            ddlscheme = ddlscheme + "<option value=" + item.Value + " >" + item.Value + "</option>";
                        }





                    }
                }





                structure = "<label>Scheme</label><select class='form-control schemenameclass' id='schemename1'  onchange=getschemename(this.id)><option value='0'>--Select--</option>" + ddlscheme + "</select>";





                // structure = structure + data;
                //structure = structure + "<div class='col-sm-4'><div class='form-group'>   <label for='input-1'>Instruments</label> <input type='text' class='form-control' placeholder='MF Scheme' />     </div></div>";
                //structure = structure + "<div class='col-sm-4'><div class='form-group'>   <label for='input-1'>Proportion</label> <input type='text' class='form-control' />     </div></div>";
            }
            else
            {
                structure = "<label>Scheme</label><select class='form-control schemenameclass' id='schemename1'  onchange=getschemename(this.id)><option value='0'>--Select--</option>" + ddlscheme + "</select>";
            }




            return structure;
        }



        public string ddlassetname()
        {
            

            string bindddlname = "<option value='0'>--Select--</option>";
            con.Open();
            string query1 = "select aiid , Json from AssetInformation";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            con.Close();
            int index = 2;
            if (dt1.Rows.Count > 0)
            {

                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string getjson = dt1.Rows[i]["Json"].ToString();
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(getjson);
                    int count = index++;
                    foreach (var item in dict)
                    {
                        string testString = item.Key;
                        ArrayList result = new ArrayList(testString.Split('~'));


                        if (result[0].ToString() == "IssuedBy")
                        {

                            bindddlname = bindddlname + "   <option value=" + count + ">" + item.Value + "</option>    ";


                        }

                        if (result[0].ToString() == "Identifier")
                        {

                            bindddlname = bindddlname + "   <option value=" + count + ">" + item.Value + "</option>    ";


                        }


                    }



                }



            }


            return bindddlname;
        }



    }
}