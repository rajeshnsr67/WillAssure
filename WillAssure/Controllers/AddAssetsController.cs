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
using System.Web.Script.Serialization;

namespace WillAssure.Controllers
{
    public class AddAssetsController : Controller
    {

        public static int nCount;

        int id = 1;
       

        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        string ddl = "";
        string ddl2 = "";
        string structure = "";
        string query1 = "";
        // GET: AddAssets
        public ActionResult AddAssetsIndex()
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

            nCount = 1;
            Session["fields"] = 0;
            return View("~/Views/AddAssets/AddAssetsPageContent.cshtml");
        }

        public String BindAssetTypeDDL()
        {

            con.Open();
            string query = "select * from AssetsType";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";
           
            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["atId"].ToString() + " >" + dt.Rows[i]["AssetsType"].ToString() + "</option> ";



                }



            }

            return data;

        }



        public String BindAssetCategoryDDL()
        {
            int index = Convert.ToInt32(Request["send"]);
            int amid = 0;
            con.Open();
            string query = "select * from AssetsCategory where atId = '" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {

              
                for (int i = 0; i < dt.Rows.Count; i++)
                {




                    data = data + "<option value=" + dt.Rows[i]["amId"].ToString() + " >" + dt.Rows[i]["AssetsCategory"].ToString() + "</option>";



                }




            }

            return data;

        }


       





    



        public string DDLBindAssetColumn()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AssetColumns",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {







                data = data + "<option value='0'>--Select--</option><option value='1' >" + dt.Rows[0]["DueDate"].ToString() + "</option>" +
                data + "<option value='2' >" + dt.Rows[0]["CurrentStatus"].ToString() + "</option>" +
                data + "<option value='3' >" + dt.Rows[0]["IssuedBy"].ToString() + "</option>" +
                data + "<option value='4' >" + dt.Rows[0]["Location"].ToString() + "</option>" +
                data + "<option value='5' >" + dt.Rows[0]["Identifier"].ToString() + "</option>" +
                data + "<option value='6' >" + dt.Rows[0]["assetsValue"].ToString() + "</option>" +
                data + "<option value='7' >" + dt.Rows[0]["CertificateNumber"].ToString() + "</option>" +
                data + "<option value='8' >" + dt.Rows[0]["PropertyDescription"].ToString() + "</option>" +
                data + "<option value='9' >" + dt.Rows[0]["Qty"].ToString() + "</option>" +
                data + "<option value='10' >" + dt.Rows[0]["Weight"].ToString() + "</option>" +
                data + "<option value='11' >" + dt.Rows[0]["OwnerShip"].ToString() + "</option>" +
                data + "<option value='12' >" + dt.Rows[0]["Remark"].ToString() + "</option>" +
                data + "<option value='13' >" + dt.Rows[0]["Nomination"].ToString() + "</option>" +
                data + "<option value='14' >" + dt.Rows[0]["NomineeDetails"].ToString() + "</option>" +
                data + "<option value='15' >" + dt.Rows[0]["Name"].ToString() + "</option>" +
                data + "<option value='16' >" + dt.Rows[0]["RegisteredAddress"].ToString() + "</option>" +
                data + "<option value='17' >" + dt.Rows[0]["PermanentAddress"].ToString() + "</option>" +
                data + "<option value='18' >" + dt.Rows[0]["Identity_proof"].ToString() + "</option>" +
                data + "<option value='19' >" + dt.Rows[0]["Identity_proof_value"].ToString() + "</option>" +
                data + "<option value='20' >" + dt.Rows[0]["Alt_Identity_proof"].ToString() + "</option>" +
                data + "<option value='21' >" + dt.Rows[0]["Alt_Identity_proof_value"].ToString() + "</option>" +
                data + "<option value='22' >" + dt.Rows[0]["Phone"].ToString() + "</option>" +
                data + "<option value='23' >" + dt.Rows[0]["Mobile"].ToString() + "</option>" +
                data + "<option value='24' >" + dt.Rows[0]["Amount"].ToString() + "</option>";







            }

            return data;




          
        }



        public string DynamicFields()
        {
            AssetsModel Am = new AssetsModel();
            
            int c = nCount++;
           
            Session["fields"] = c; 
          
            string ddstruct = "";
            string finalstruct = "";
            // dynamic control

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_AssetColumns", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
          

           
            
            if (dt.Rows.Count > 0)
            {







                ddstruct = ddstruct + "<select class='form-control Entityinput validate[required]' onchange=getAssetColumnValue(this.options[this.selectedIndex].innerHTML)   ><option value=''>--Select--</option><option value='1' >" + dt.Rows[0]["DueDate"].ToString() + "</option>" +
                ddstruct + "<option value='2' >" + dt.Rows[0]["CurrentStatus"].ToString() + "</option>" +
                ddstruct + "<option value='3' >" + dt.Rows[0]["IssuedBy"].ToString() + "</option>" +
                ddstruct + "<option value='4' >" + dt.Rows[0]["Location"].ToString() + "</option>" +
                ddstruct + "<option value='5' >" + dt.Rows[0]["Identifier"].ToString() + "</option>" +
                ddstruct + "<option value='6' >" + dt.Rows[0]["assetsValue"].ToString() + "</option>" +
                ddstruct + "<option value='7' >" + dt.Rows[0]["CertificateNumber"].ToString() + "</option>" +
                ddstruct + "<option value='8' >" + dt.Rows[0]["PropertyDescription"].ToString() + "</option>" +
                ddstruct + "<option value='9' >" + dt.Rows[0]["Qty"].ToString() + "</option>" +
                ddstruct + "<option value='10' >" + dt.Rows[0]["Weight"].ToString() + "</option>" +
                ddstruct + "<option value='11' >" + dt.Rows[0]["OwnerShip"].ToString() + "</option>" +
                ddstruct + "<option value='12' >" + dt.Rows[0]["Remark"].ToString() + "</option>" +
                ddstruct + "<option value='13' >" + dt.Rows[0]["Nomination"].ToString() + "</option>" +
                ddstruct + "<option value='14' >" + dt.Rows[0]["NomineeDetails"].ToString() + "</option>" +
                ddstruct + "<option value='15' >" + dt.Rows[0]["Name"].ToString() + "</option>" +
                ddstruct + "<option value='16' >" + dt.Rows[0]["RegisteredAddress"].ToString() + "</option>" +
                ddstruct + "<option value='17' >" + dt.Rows[0]["PermanentAddress"].ToString() + "</option>" +
                ddstruct + "<option value='18' >" + dt.Rows[0]["Identity_proof"].ToString() + "</option>" +
                ddstruct + "<option value='19' >" + dt.Rows[0]["Identity_proof_value"].ToString() + "</option>" +
                ddstruct + "<option value='20' >" + dt.Rows[0]["Alt_Identity_proof"].ToString() + "</option>" +
                ddstruct + "<option value='21' >" + dt.Rows[0]["Alt_Identity_proof_value"].ToString() + "</option>" +
                ddstruct + "<option value='22' >" + dt.Rows[0]["Phone"].ToString() + "</option>" +
                ddstruct + "<option value='23' >" + dt.Rows[0]["Mobile"].ToString() + "</option>" +
                ddstruct + "<option value='24' >" + dt.Rows[0]["Amount"].ToString() + "</option></select>";



            }

            //end


            finalstruct = finalstruct + "<div class='row group'><div class='col-sm-3'><div class='form-group'><label for='input - 1'>Entity</label>     " + ddstruct + " </div></div>" +
            finalstruct + "<div class='col-sm-3'><div class='form-group'><label for='input-1'>Label</label>   <input type='text' onchange=bar(this.value) class='form-control validate[required] text-input labelinput'  name='txtlabel'  autocomplete='off' />    </div></div>" +
            finalstruct + "<div class='col-sm-3 '><div class='form-group choosen'>   <label for='input-1'>Controls</label>   <select class='form-control ddlcontrolinput validate[required]' id='controlsDDL'     name='DDLControls' >    <option value=''>--Select--</option >   <option value='TextBox'>TextBox</option >    <option value='TextArea'>TextArea</option>    <option value='DatePicker'>DatePicker</option>     <option value='CheckBox'>CheckBox</option>   <option value='RadioButton'>RadioButton</option>  </select></div></div>" +
            finalstruct + "<div class='col-sm-3'><div class='form-group'><label for='input-1' id='lbldynamic'>Values</label>  <input type='text'  class='form-control  text - input'   onchange=bar2(this.value) name='txtval' id='valuefield'  autocomplete='off' />    </div></div> </div>";
            



            return finalstruct;
        }




        public string BindAssetColumnLabel()
        {
            string response = Request["send"];
            
            string Data = "";

            con.Open();
            string query = "select distinct "+response+" from [dbo].[AssetsInfo]   where "+response+" NOT LIKE  'NA'";
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();


            if (dt.Rows.Count > 0)
            {

                string value = 

                Data = "<input type='text' name='name' class='form-control validate[required] text - input' id='generator'  autocomplete='off' />";

            }


            return Data;
        }




        public ActionResult InsertAssetsData(AssetsModel form)
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






            string column = form.assetcolumn.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
            string cv = form.assetcolumnValues.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
            string col = form.col.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
            string val = form.val.Replace(" ", string.Empty).Replace("\r\n", string.Empty);

            string cc = form.controls.Replace(" ", string.Empty).Replace("\r\n", string.Empty);
            string vv = form.values.Replace(" ", string.Empty).Replace("\r\n", string.Empty);

            


            //if (Session["tid"] != null)
            //{
                if (column != "" && cv != "" && col != "" && val != "" && cc != "" && vv != "")
                {
                    string c = column.Substring(0, column.Length - 1);

                    string contr = col.Substring(0, col.Length - 1);
                    string valu = val.Substring(0, val.Length - 1);
                    string c1 = cc.Substring(0, cc.Length - 1);
                    string v1 = vv.Substring(0, vv.Length - 1);


                    string columnvalues = cv.Substring(0, cv.Length - 1);



                    con.Open();
                    query1 = "insert into AssetsInfo (amId," + c + "," + contr + ", " + valu + ") values (" + form.amId + " , " + columnvalues + " , " + c1 + " , " + v1 + ") ";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    con.Open();
                    string query = "select top 1 aiId from AssetsInfo order by aiId desc";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                   

                    if (dt.Rows.Count > 0)
                    {
                        Session["aiId"] = dt.Rows[0]["aiId"];
                    }


                    con.Close();


                    ViewBag.Message = "Verified";


                }
            //}
            //else
            //{
            //    Response.Write("<script>alert('Please Fill Testator First')</script>");
            //}
          






            return View("~/Views/AddAssets/AddAssetsPageContent.cshtml");
        }




    }
}