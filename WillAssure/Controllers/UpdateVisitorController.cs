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
namespace WillAssure.Controllers
{
    public class UpdateVisitorController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: UpdateVisitor
        public ActionResult UpdateVisitorIndex(int NestId)
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




            VisitorModel Vm = new VisitorModel();


            con.Open();
            string query = "select * from visitorinfo where vid = "+NestId+"";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
 






            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Vm.vid = Convert.ToInt32(dt.Rows[i]["vid"]);
                    Vm.First_Name = dt.Rows[i]["First_Name"].ToString();
                    Vm.Middle_Name = dt.Rows[i]["Middle_Name"].ToString();
                    Vm.Last_Name = dt.Rows[i]["Last_Name"].ToString();
                    Vm.Mobile = dt.Rows[i]["Mobile"].ToString();
                    Vm.Email = dt.Rows[i]["Email"].ToString();
                    Vm.RefDist = dt.Rows[i]["RefDist"].ToString();
                    Vm.DocumentType = dt.Rows[i]["DocumentType"].ToString();
                   
                }








            }








            return View("~/Views/UpdateVisitor/UpdateVisitorPageContent.cshtml",Vm);
        }



        public ActionResult UpdateVisitordata(VisitorModel VM)
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
            string query = "update visitorinfo set First_Name='"+VM.First_Name+ "' , Middle_Name ='"+VM.Middle_Name+ "' , Last_Name ='"+VM.Last_Name+ "' , Mobile = '"+VM.Mobile+ "' , Email='"+VM.Email+ "' , RefDist = '"+VM.RefDist+ "' , DocumentType = '" + VM.documenttypec + "' WHERE vid = "+VM.vid+"  ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();


            ViewBag.Message = "Verified";



            return View("~/Views/UpdateVisitor/UpdateVisitorPageContent.cshtml");
        }



    }
}