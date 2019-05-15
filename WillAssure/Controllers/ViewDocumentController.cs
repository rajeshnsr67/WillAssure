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
using System.Globalization;

namespace WillAssure.Controllers
{
    public class ViewDocumentController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: ViewDocument
        public ActionResult ViewDocumentIndex()
        {
            ViewBag.documentlink = "true";
            ViewBag.collapse = "true";
            return View("~/Views/ViewDocument/EditViewDocumentPageContent.cshtml");
        }





        public string BindDocumentData()
        {


            string data = "";
            if (Convert.ToInt32(Session["uuid"]) != 1)
            {

               
                 

                        con.Open();
                        string query = "select a.tId , a.First_Name  , b.beneficiary_type   from TestatorDetails a inner join BeneficiaryDetails b on a.tId=b.tId inner join users c on a.uId=c.uId where c.uId =  " + Convert.ToInt32(Session["uuid"]) + " ";
                        SqlDataAdapter da = new SqlDataAdapter(query, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        con.Close();




                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {

                                data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
        + "<td>" + dt.Rows[i]["beneficiary_type"].ToString() + "</td>"
        + "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
        + "<td> <button type='button'   id=" + dt.Rows[i]["tId"].ToString() + " onClick='detailid(this.id)'   class='btn btn-primary'>View Details</button></tr>";






                            }







                        }
                    
                




            }
            else
            {


                con.Open();
                string query = "select a.tId , a.First_Name  , b.beneficiary_type   from TestatorDetails a inner join BeneficiaryDetails b on a.tId=b.tId inner join users c on a.uId=c.uId ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();




                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        data = data + "<tr class='nr'><td>" + dt.Rows[i]["tId"].ToString() + "</td>"
+ "<td>" + dt.Rows[i]["beneficiary_type"].ToString() + "</td>"
+ "<td>" + dt.Rows[i]["First_Name"].ToString() + "</td>"
+ "<td> <button type='button'   id=" + dt.Rows[i]["tId"].ToString() + " onClick='Edit(this.id)'   class='btn btn-primary'>View Document</button></tr>";






                    }







                }




            }


           



            return data;
        }



        public int getdocumentdata()
        {
            int index = Convert.ToInt32(Request["send"]);


            return index;

        }


    }
}