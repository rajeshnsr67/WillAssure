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

namespace WillAssure.Controllers
{
    public class EditDistributorController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: EditDistributor
        public ActionResult EditDistributorIndex()
        {
            return View("~/Views/EditDistributor/EditDistributorPageContent.cshtml");
        }

        public string BindDistributorFormData()
        {
            con.Open();
            string query = "select * from companyDetails";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["companyName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["GST_NO"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactPerson"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMailId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["bankName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Branch"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountNumber"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IFSC_Code"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Referred_By"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadgeneratedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadconvertedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["relationshipManager"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadRemark"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";

                }
            }

            return data;
        }



        public string DeleteDistributorFormRecords(DistributorFormModel DFM)
        {
            int index = Convert.ToInt32(Request["send"]);

            con.Open();
            SqlCommand cmd = new SqlCommand("SP_CrudcompanyDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@condition", "delete");
            cmd.Parameters.AddWithValue("@compId ", index);
            cmd.Parameters.AddWithValue("@companyName ", "");
            cmd.Parameters.AddWithValue("@ownerName", "");
            cmd.Parameters.AddWithValue("@ownerMobileNo", "");
            cmd.Parameters.AddWithValue("@Address1", "");
            cmd.Parameters.AddWithValue("@Address2", "");
            cmd.Parameters.AddWithValue("@City", "");
            cmd.Parameters.AddWithValue("@State", "");
            cmd.Parameters.AddWithValue("@Pin", "");
            cmd.Parameters.AddWithValue("@GST_NO", "");
            cmd.Parameters.AddWithValue("@Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Identity_Proof_Value", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof", "");
            cmd.Parameters.AddWithValue("@Alt_Identity_Proof_Value", "");
            cmd.Parameters.AddWithValue("@contactPerson", "");
            cmd.Parameters.AddWithValue("@contactMobileNo", "");
            cmd.Parameters.AddWithValue("@contactMailId", "");
            cmd.Parameters.AddWithValue("@bankName", "");
            cmd.Parameters.AddWithValue("@Branch", "");
            cmd.Parameters.AddWithValue("@accountNumber", "");
            cmd.Parameters.AddWithValue("@IFSC_Code", "");
            cmd.Parameters.AddWithValue("@accountName", "");
            cmd.Parameters.AddWithValue("@Referred_By","");
            cmd.Parameters.AddWithValue("@leadgeneratedBy","");
            cmd.Parameters.AddWithValue("@leadconvertedBy", "");
            cmd.Parameters.AddWithValue("@relationshipManager", "");
            cmd.Parameters.AddWithValue("@leadStatus", "");
            cmd.Parameters.AddWithValue("@leadRemark", "");
            cmd.ExecuteNonQuery();
            con.Close();


            con.Open();
            string query = "select * from companyDetails";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            string data = "";

            if (dt.Rows.Count > 0)
            {


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data = data + "<tr class='nr'><td>" + dt.Rows[i]["compId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["companyName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["ownerMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address1"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Address2"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["City"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["State"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Pin"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["GST_NO"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Alt_Identity_Proof_Value"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactPerson"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMobileNo"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["contactMailId"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["bankName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Branch"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountNumber"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["IFSC_Code"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["accountName"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["Referred_By"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadgeneratedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadconvertedBy"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["relationshipManager"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadStatus"].ToString() + "</td>"
                                + "<td>" + dt.Rows[i]["leadRemark"].ToString() + "</td>"
                                + "<td><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Edit(this.id)'   class='btn btn-primary'>Edit</button><button type='button'   id='" + dt.Rows[i]["compId"].ToString() + "' onClick='Delete(this.id)'   class='btn btn-danger'>Delete</button></td></tr>";

                }
            }
            Response.Write("<script>alert('Your Records Have Been Deleted...!')</script>");
            return data;
        }





        public int UpdateDistributorForm()
        {
            int index = Convert.ToInt32(Request["send"]);




            return index;
        }


    }
}