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
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        string ddl = "";
        string ddl2 = "";
        string structure = "";
        // GET: AddAssets
        public ActionResult AddAssetsIndex()
        {
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




                    data = data + " <option value=" + dt.Rows[i]["atId"].ToString() + " >" + dt.Rows[i]["AssetsType"].ToString() + "</option> ";



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


       





        public string AssetFields()
        {
            AssetsModel Am = new AssetsModel();
            string data = "";
         


            int index = Convert.ToInt32(Request["send"]);
           
            con.Open();
            string query = "select * from AssetsInfo where amId = '" + index + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            Am.Qty = "0";
            Am.Weight = "0";
            Am.nId = 0;
           
            if (dt.Rows.Count > 0)
            {
                Am.amId = Convert.ToInt32(dt.Rows[0]["amId"]);
                Am.aId = Convert.ToInt32(dt.Rows[0]["aiId"]);
                Am.assetsCode = dt.Rows[0]["assetsCode"].ToString();
                Am.dueDate = dt.Rows[0]["dueDate"].ToString();
                Am.currentStatus = dt.Rows[0]["currentStatus"].ToString();
                Am.issuedBy = dt.Rows[0]["issuedBy"].ToString();
                Am.Location = dt.Rows[0]["Location"].ToString();
                Am.assetsValue = dt.Rows[0]["assetsValue"].ToString();
                Am.certificateNumber = dt.Rows[0]["certificateNumber"].ToString();
                Am.propertyDescription = dt.Rows[0]["propertyDescription"].ToString();

                if (Convert.ToString(dt.Rows[0]["Qty"]) != "0")
                {
                    Am.Qty = Convert.ToString(dt.Rows[0]["Qty"]);
                }


                if (Convert.ToString(dt.Rows[0]["Weight"]) != "0")
                {

                    Am.Weight = Convert.ToString(dt.Rows[0]["Weight"]);
                }

                Am.ownerShip = dt.Rows[0]["ownerShip"].ToString();

              
                    Am.Remark = dt.Rows[0]["Remark"].ToString();


                Am.Nomination = dt.Rows[0]["Nomination"].ToString();
                Am.NomineeDetails = dt.Rows[0]["NomineeDetails"].ToString();
                Am.Name = dt.Rows[0]["Name"].ToString();
                Am.RegisteredAddress = dt.Rows[0]["RegisteredAddress"].ToString();
                Am.PermanentAddress = dt.Rows[0]["PermanentAddress"].ToString();
                Am.Identity_proof = dt.Rows[0]["Identity_proof"].ToString();
                Am.Identity_proof_value = dt.Rows[0]["Identity_proof_value"].ToString();
                Am.Alt_Identity_proof = dt.Rows[0]["Alt_Identity_proof"].ToString();
                Am.Alt_Identity_proof_value = dt.Rows[0]["Alt_Identity_proof_value"].ToString();
                Am.Phone = dt.Rows[0]["Phone"].ToString();
                Am.Mobile = dt.Rows[0]["Mobile"].ToString();
                Am.Amount = dt.Rows[0]["Amount"].ToString();
                Am.identifier = dt.Rows[0]["identifier"].ToString();

                if (index == 1)
                {

                    data = data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.currentStatus + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select >      </div></div>" +
                    data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.issuedBy + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select >      </div></div>" +
                    data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.propertyDescription + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select >      </div></div>" +
                    data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.Nomination + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select>      </div></div>" +
                    data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.NomineeDetails + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select >      </div></div>";



                }


                if (index == 2)
                {

                    data = data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.issuedBy + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.identifier + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.Nomination + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.NomineeDetails + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>";


                    
                }


                if (index == 3)
                {

                    data = data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.issuedBy + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.identifier + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.Nomination + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.NomineeDetails + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>";


                  
                }


                if (index == 4)
                {

                    data = data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.issuedBy + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
              
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.Nomination + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.NomineeDetails + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>";


                   
                }


                if (index == 5)
                {

                    data = data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.dueDate + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +

               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.issuedBy + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.identifier + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.Nomination + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.NomineeDetails + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>";


                   
                }


                if (index == 6)
                {

                    data = data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.dueDate + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +

               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.issuedBy + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.identifier + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.Nomination + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.NomineeDetails + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>";


                   
                }



                if (index == 7)
                {



                    data = data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.issuedBy + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.identifier + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.Nomination + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.NomineeDetails + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>";


                   
                }


                if (index == 8)
                {



                    data = data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.issuedBy + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.identifier + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.Nomination + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.NomineeDetails + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>";


                 
                }


                if (index == 9)
                {



                    data = data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.issuedBy + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
             
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.Nomination + " </label><select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.NomineeDetails + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>";


                   
                }


                if (index == 10)
                {



                    data = data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.issuedBy + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
                 data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.identifier + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.Nomination + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>" +
               data + "<div class='col-sm-6'><div class='form-group'>  <label for='input-1'> " + Am.NomineeDetails + " </label> <select class='form-control' id='ddlcontrol'>  <option value='1'>CheckBox</option>    <option value='2'>RadioButton</option>   <option value='3'>TextArea</option>     <option value='4'>Textbox</option></select ></div></div>";


                   
                }




            }


            return data;
        }



        public ActionResult InsertAssetsData()
        {




            return View("~/Views/AddAssets/AddAssetsPageContent.cshtml");
        }



        //public string DynamicFields()
        //{

        //    con.Open();
        //    string query = "select * from AssetsType";
        //    SqlDataAdapter da = new SqlDataAdapter(query, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    string data = "";

        //    if (dt.Rows.Count > 0)
        //    {


        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {




        //            data = data + " <option value=" + dt.Rows[i]["atId"].ToString() + " >" + dt.Rows[i]["AssetsType"].ToString() + "</option> ";



        //        }
        //    }




        //    con.Open();
        //    string query2 = "select * from AssetsCategory";
        //    SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
        //    DataTable dt2 = new DataTable();
        //    da2.Fill(dt2);
        //    con.Close();
        //    string data2 = "";

        //    if (dt2.Rows.Count > 0)
        //    {


        //        for (int i = 0; i < dt2.Rows.Count; i++)
        //        {




        //            data2 = data2 + " <option value=" + dt2.Rows[i]["amId"].ToString() + " >" + dt2.Rows[i]["AssetsCategory"].ToString() + "</option> ";



        //        }
        //    }



        //    for (int i = 0; i < 1; i++)
        //        {
        //            ddl = ddl + "<select id='ddlAssetTypeTemp' onchange='ddlAssetTypeTempChange()' class='form-control'><option value='0'>--Select--</option>'" + data + "'</select>";
        //            ddl2 = ddl2 + "<select id='ddlAssetCategoryTemp' onchange='myFunction()' class='form-control'><option value='0'>--Select--</option></select>";
        //        }



          




        //    structure = "<div class='col-sm-6'><div class='form-group'> " + ddl + " </div></div> <div></div>  <div class='col-sm-6'><div class='form-group'> " + ddl2 + " </div></div>";


        //    string f = structure;




           
           




        //    return f;
        //}


      

    }
}