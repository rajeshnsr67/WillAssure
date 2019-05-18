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
    public class VisitorDataController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        // GET: VisitorData
        public string VisitorDataIndex()
        {

           
            string msg = "Records Inserted SuccessFully";
            string response = Request["send"].ToString();

            string name = response.Split('~')[0];
            string middlename = response.Split('~')[1];
            string lastname = response.Split('~')[2];
            string contactno = response.Split('~')[3];
            string emailid = response.Split('~')[4];
            string refdistributor = response.Split('~')[5];
            string documenttype = response.Split('~')[6];


            con.Open();

            string query = "insert into VisitorInfo (First_Name,Middle_Name,Last_Name,Mobile,Email,RefDist,DocumentType,uid) values ('" + name + "' , '" + middlename + "' , '" + lastname + "' , '" + contactno + "' , '" + emailid + "' , '" + refdistributor + "' , '" + documenttype + "', 0)";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();

            con.Close();
            


            return msg;
        }
    }
}