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

namespace WillAssure.Models
{
    public class UpdateAssetsController : Controller
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);

        // GET: UpdateAssets
        public ActionResult UpdateAssetsIndex(int NestId)
        {
            // check type 
            string typ = "";
            con.Open();
            string qq1 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa = new SqlDataAdapter(qq1, con);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            con.Close();

            if (dtt.Rows.Count > 0)
            {
                typ = dtt.Rows[0]["Type"].ToString();
            }



            //end



            if (typ == "Testator")
            {


                con.Open();
                string qq12 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " and designation = 1 ";
                SqlDataAdapter da42 = new SqlDataAdapter(qq12, con);
                DataTable d4t2 = new DataTable();
                da42.Fill(d4t2);
                con.Close();

                if (d4t2.Rows.Count > 0)
                {
                    ViewBag.documentlink = "true";
                }


                // check will status
                con.Open();
                string qry1 = "select Will  from users where Will = 1 ";
                SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                DataTable dtt1 = new DataTable();
                daa1.Fill(dtt1);
                if (dtt1.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
                con.Close();
                //end


                // check codocil status
                con.Open();
                string qry2 = "select Codocil  from users where Codocil = 1 ";
                SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                DataTable dtt2 = new DataTable();
                daa2.Fill(dtt2);
                if (dtt2.Rows.Count > 0)
                {
                    ViewBag.documentbtn2 = "true";
                }
                con.Close();

                //end


                // check Poa status
                con.Open();
                string qry4 = "select POA  from users where POA = 1 ";
                SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                DataTable dtt4 = new DataTable();
                daa4.Fill(dtt4);
                if (dtt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }
                con.Close();
                //end


                // check gift deeds status
                con.Open();
                string qry3 = "select Giftdeeds  from users where Giftdeeds = 1 ";
                SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                DataTable dtt3 = new DataTable();
                daa3.Fill(dtt3);
                if (dtt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }
                con.Close();
                //end
            }
            else
            {


                ViewBag.documentlink = "true";

            }






            if (Session["rId"] == null || Session["uuid"] == null)
            {

                RedirectToAction("LoginPageIndex", "LoginPage");

            }
            //if (Session["tid"]== null)
            //{
            //    ViewBag.message = "link";
            //}


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

            AssetsModel Form = new AssetsModel();
            Form.aiId = NestId;
            
         
            return View("~/Views/UpdateAssets/UpdateAssetsPageContent.cshtml", Form);
        }

      

        public ActionResult UpdatingAssetsData(FormCollection collection, AssetsModel Form)
        {

            // check type 
            string typ5 = "";
            con.Open();
            string qq15 = "select Type from users where uId = " + Convert.ToInt32(Session["uuid"]) + " ";
            SqlDataAdapter daa5 = new SqlDataAdapter(qq15, con);
            DataTable dtt5 = new DataTable();
            daa5.Fill(dtt5);
            con.Close();

            if (dtt5.Rows.Count > 0)
            {
                typ5 = dtt5.Rows[0]["Type"].ToString();
            }



            //end



            if (typ5 == "Testator")
            {
                // check will status
                con.Open();
                string qry1 = "select Will  from users where Will = 1 ";
                SqlDataAdapter daa1 = new SqlDataAdapter(qry1, con);
                DataTable dtt1 = new DataTable();
                daa1.Fill(dtt1);
                if (dtt1.Rows.Count > 0)
                {
                    ViewBag.documentbtn1 = "true";
                }
                con.Close();
                //end


                // check codocil status
                con.Open();
                string qry2 = "select Codocil  from users where Codocil = 1 ";
                SqlDataAdapter daa2 = new SqlDataAdapter(qry2, con);
                DataTable dtt2 = new DataTable();
                daa2.Fill(dtt2);
                if (dtt2.Rows.Count > 0)
                {
                    ViewBag.documentbtn2 = "true";
                }
                con.Close();

                //end


                // check Poa status
                con.Open();
                string qry4 = "select POA  from users where POA = 1 ";
                SqlDataAdapter daa4 = new SqlDataAdapter(qry4, con);
                DataTable dtt4 = new DataTable();
                daa4.Fill(dtt4);
                if (dtt4.Rows.Count > 0)
                {
                    ViewBag.documentbtn3 = "true";
                }
                con.Close();
                //end


                // check gift deeds status
                con.Open();
                string qry3 = "select Giftdeeds  from users where Giftdeeds = 1 ";
                SqlDataAdapter daa3 = new SqlDataAdapter(qry3, con);
                DataTable dtt3 = new DataTable();
                daa3.Fill(dtt3);
                if (dtt3.Rows.Count > 0)
                {
                    ViewBag.documentbtn4 = "true";
                }
                con.Close();
                //end
            }
            else
            {

                ViewBag.documentlink = "true";

            }


            // roleassignment
            List<LoginModel> Lmlist = new List<LoginModel>();
            con.Open();
            string q2 = "select * from Assignment_Roles where RoleId = " + Convert.ToInt32(Session["rId"]) + "";
            SqlDataAdapter da3 = new SqlDataAdapter(q2, con);
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

            string col = Convert.ToString(collection["tblcol"]);
            string colcontrol = Convert.ToString(collection["column"]);
            string valcontrol = Convert.ToString(collection["control"]);
            string mulcontrol = Convert.ToString(collection["multiple"]);
            
            ArrayList columnName = new ArrayList(col.Split(','));
            ArrayList columnValue = new ArrayList(colcontrol.Split(','));
            ArrayList columnControl = new ArrayList(valcontrol.Split(','));
         
            



            string q = "";
            string q1 = "";
            for (int i = 0; i < columnName.Count; i++)
            {

                if (columnControl.ToString() == "RadioButton")
                {
                    ArrayList ControlValue = new ArrayList(mulcontrol.Split(','));
                    q = q + "" + columnName[i].ToString() + " = " + columnValue[i].ToString() + "," + columnName[i].ToString() + "Controls" + "=" + "'" + columnControl[i].ToString() + "'" + "," + columnName[i].ToString() + "Values" + "=" + "'" + ControlValue[i].ToString() + "'";
                    q1 = q.Substring(0, q.Length - 1);
                }
                else
                {
                    if (columnName[i].ToString() != null)
                    {
                        q = q + "" + columnName[i].ToString() + " = " + "'" + columnName[i].ToString() + "~" + columnValue[i].ToString() + "'" + "," + columnName[i].ToString() + "Controls" + "=" + "'" + columnControl[i].ToString() + "'" + ",";
                    }

                    
                    
                }

               
                   
                


            }

            q1 = q.Substring(0, q.Length - 1);

            con.Open();
            string query = "update AssetsInfo set " + q1 + " where aiId =" + Form.aiId + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            ViewBag.Message = "Verified";

            return View("~/Views/UpdateAssets/UpdateAssetsPageContent.cshtml");
        }



        public string DynamicFields(AssetsModel Form)
        {
            string f = "";
            if (Request["send"] != "")
            {


                int aid = Convert.ToInt32(Request["send"]);

                int count = Convert.ToInt32(Session["fields"]);

                con.Open();
                string query = "select * from AssetsInfo where aiId = '" + aid + "' ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();


                if (dt.Rows.Count > 0)
                {


                    Form.amId = Convert.ToInt32(dt.Rows[0]["amId"]);
                    Form.assetsCode = dt.Rows[0]["assetsCode"].ToString();
                    Form.dueDate = dt.Rows[0]["DueDate"].ToString();

                    string data = "";
                    string updatequery = "";
                    if (Form.dueDate != "")
                    {
                        ArrayList va = new ArrayList(Form.dueDate.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {


                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'   value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }


                    }

                    Form.dueDateControls = dt.Rows[0]["DueDateControls"].ToString();

                    if (Form.dueDateControls != "")
                    {

                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.dueDateControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>   </div></div>";

                    }

                    Form.DueDateValues = dt.Rows[0]["DueDateValues"].ToString();




                    Form.CurrentStatus = dt.Rows[0]["CurrentStatus"].ToString();

                    if (Form.CurrentStatus != "")
                    {
                        ArrayList va = new ArrayList(Form.CurrentStatus.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.CurrentStatusControls = dt.Rows[0]["CurrentStatusControls"].ToString();

                    if (Form.CurrentStatusControls != "")
                    {
                        data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.CurrentStatusControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }

                    Form.CurrentStatusValues = dt.Rows[0]["CurrentStatusValues"].ToString();

                    if (Form.CurrentStatusValues != "")
                    {
                        data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control' name='multiple'  value=" + Form.CurrentStatusValues + "  />   </div></div>";

                    }

                    Form.IssuedBy = dt.Rows[0]["IssuedBy"].ToString();

                    if (Form.IssuedBy != "")
                    {
                        ArrayList va = new ArrayList(Form.IssuedBy.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }


                    Form.IssuedByControls = dt.Rows[0]["IssuedByControls"].ToString();

                    if (Form.IssuedByControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.IssuedByControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>   </div></div>";

                    }







                    Form.Location = dt.Rows[0]["Location"].ToString();

                    if (Form.Location != "")
                    {
                        ArrayList va = new ArrayList(Form.Location.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.LocationControls = dt.Rows[0]["LocationControls"].ToString();

                    if (Form.LocationControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.LocationControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>   </div></div>";

                    }







                    Form.Identifier = dt.Rows[0]["Identifier"].ToString();

                    if (Form.Identifier != "")
                    {
                        ArrayList va = new ArrayList(Form.Identifier.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.IdentifierControls = dt.Rows[0]["IdentifierControls"].ToString();

                    if (Form.IdentifierControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.IdentifierControls + "  />  <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>   </div></div>";

                    }






                    Form.assetsValue = dt.Rows[0]["assetsValue"].ToString();

                    if (Form.assetsValue != "")
                    {
                        ArrayList va = new ArrayList(Form.assetsValue.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.assetsValueControls = dt.Rows[0]["assetsValueControls"].ToString();

                    if (Form.assetsValueControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.assetsValueControls + "  />  <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>   </div></div>";

                    }






                    Form.CertificateNumber = dt.Rows[0]["CertificateNumber"].ToString();

                    if (Form.CertificateNumber != "")
                    {
                        ArrayList va = new ArrayList(Form.CertificateNumber.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }



                        }

                    }

                    Form.CertificateNumberControls = dt.Rows[0]["CertificateNumberControls"].ToString();

                    if (Form.CertificateNumberControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.CertificateNumberControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }





                    Form.PropertyDescription = dt.Rows[0]["PropertyDescription"].ToString();

                    if (Form.PropertyDescription != "")
                    {
                        ArrayList va = new ArrayList(Form.PropertyDescription.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.PropertyDescriptionControls = dt.Rows[0]["PropertyDescriptionControls"].ToString();

                    if (Form.PropertyDescriptionControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.PropertyDescriptionControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }






                    Form.Qty = dt.Rows[0]["Qty"].ToString();

                    if (Form.Qty != "")
                    {
                        ArrayList va = new ArrayList(Form.Qty.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }


                    Form.QtyControls = dt.Rows[0]["QtyControls"].ToString();

                    if (Form.QtyControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.QtyControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }





                    Form.Weight = dt.Rows[0]["Weight"].ToString();

                    if (Form.Weight != "")
                    {
                        ArrayList va = new ArrayList(Form.Weight.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }


                    Form.WeightControls = dt.Rows[0]["WeightControls"].ToString();

                    if (Form.WeightControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.WeightControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }







                    Form.OwnerShip = dt.Rows[0]["OwnerShip"].ToString();

                    if (Form.OwnerShip != "")
                    {
                        ArrayList va = new ArrayList(Form.OwnerShip.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break; 
                            }


                        }

                    }

                    Form.OwnerShipControls = dt.Rows[0]["OwnerShipControls"].ToString();

                    if (Form.OwnerShipControls != "")
                    {
                        data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.OwnerShipControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }

                    Form.OwnerShipValues = dt.Rows[0]["OwnerShipValues"].ToString();

                    if (Form.OwnerShipValues != "")
                    {
                        data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control' name='multiple'  value=" + Form.OwnerShipValues + "  />   </div></div>";

                    }


                    Form.Remark = dt.Rows[0]["Remark"].ToString();

                    if (Form.Remark != "")
                    {
                        ArrayList va = new ArrayList(Form.Remark.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.RemarkControls = dt.Rows[0]["RemarkControls"].ToString();

                    if (Form.RemarkControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.RemarkControls + "  />  <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select> </div></div>";

                    }

                    Form.RemarkValues = dt.Rows[0]["RemarkValues"].ToString();







                    Form.Nomination = dt.Rows[0]["Nomination"].ToString();

                    if (Form.Nomination != "")
                    {
                        ArrayList va = new ArrayList(Form.Nomination.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div>";
                                break;
                            }


                        }

                    }

                    Form.NominationControls = dt.Rows[0]["NominationControls"].ToString();

                    if (Form.NominationControls != "")
                    {
                        data = data + " <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.NominationControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }


                    Form.NominationValues = dt.Rows[0]["NominationValues"].ToString();

                    if (Form.NominationValues != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='multiple'  value=" + Form.NominationValues + "  />   </div></div>";

                    }

                    Form.NomineeDetails = dt.Rows[0]["NomineeDetails"].ToString();

                    if (Form.NomineeDetails != "")
                    {
                        ArrayList va = new ArrayList(Form.NomineeDetails.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.NomineeDetailsControls = dt.Rows[0]["NomineeDetailsControls"].ToString();

                    if (Form.NomineeDetailsControls != "")
                    {
                        data = data + "<div class='col-sm-4'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.NomineeDetailsControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }







                    Form.Name = dt.Rows[0]["Name"].ToString();

                    if (Form.Name != "")
                    {
                        ArrayList va = new ArrayList(Form.Name.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.NameControls = dt.Rows[0]["NameControls"].ToString();

                    if (Form.NameControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.NameControls + "  />  <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select> </div></div>";

                    }





                    Form.RegisteredAddress = dt.Rows[0]["RegisteredAddress"].ToString();

                    if (Form.RegisteredAddress != "")
                    {
                        ArrayList va = new ArrayList(Form.RegisteredAddress.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }


                    Form.RegisteredAddressControls = dt.Rows[0]["RegisteredAddressControls"].ToString();

                    if (Form.RegisteredAddressControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.RegisteredAddressControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }





                    Form.PermanentAddress = dt.Rows[0]["PermanentAddress"].ToString();

                    if (Form.PermanentAddress != "")
                    {

                        ArrayList va = new ArrayList(Form.PermanentAddress.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }


                    Form.PermanentAddressControls = dt.Rows[0]["PermanentAddressControls"].ToString();

                    if (Form.PermanentAddressControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.PermanentAddressControls + "  />  <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select> </div></div>";

                    }








                    Form.Identity_proof = dt.Rows[0]["Identity_proof"].ToString();


                    if (Form.Identity_proof != "")
                    {
                        ArrayList va = new ArrayList(Form.Identity_proof.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }


                    Form.Identity_proofControls = dt.Rows[0]["Identity_proofControls"].ToString();

                    if (Form.Identity_proofControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.Identity_proofControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }







                    Form.Identity_proof_value = dt.Rows[0]["Identity_proof_value"].ToString();

                    if (Form.Identity_proof_value != "")
                    {
                        ArrayList va = new ArrayList(Form.Identity_proof_value.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }


                    Form.Identity_proof_valueControls = dt.Rows[0]["Identity_proof_valueControls"].ToString();


                    if (Form.Identity_proof_valueControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.Identity_proof_valueControls + "  />  <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select> </div></div>";

                    }





                    Form.Alt_Identity_proof = dt.Rows[0]["Alt_Identity_proof"].ToString();

                    if (Form.Alt_Identity_proof != "")
                    {
                        ArrayList va = new ArrayList(Form.Alt_Identity_proof.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.Alt_Identity_proofControls = dt.Rows[0]["Alt_Identity_proofControls"].ToString();

                    if (Form.Alt_Identity_proofControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.Alt_Identity_proofControls + "  />  <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select> </div></div>";

                    }





                    Form.Alt_Identity_proof_value = dt.Rows[0]["Alt_Identity_proof_value"].ToString();

                    if (Form.Alt_Identity_proof_value != "")
                    {
                        ArrayList va = new ArrayList(Form.Alt_Identity_proof_value.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.Alt_Identity_proof_valueControls = dt.Rows[0]["Alt_Identity_proof_valueControls"].ToString();


                    if (Form.Alt_Identity_proof_valueControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.Alt_Identity_proof_valueControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }





                    Form.Phone = dt.Rows[0]["Phone"].ToString();

                    if (Form.Phone != "")
                    {
                        ArrayList va = new ArrayList(Form.Phone.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.PhoneControls = dt.Rows[0]["PhoneControls"].ToString();

                    if (Form.PhoneControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.PhoneControls + "  />  <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select> </div></div>";

                    }





                    Form.Mobile = dt.Rows[0]["Mobile"].ToString();

                    if (Form.Mobile != "")
                    {
                        ArrayList va = new ArrayList(Form.Mobile.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.MobileControls = dt.Rows[0]["MobileControls"].ToString();
                    if (Form.MobileControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control' value=" + Form.MobileControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }




                    Form.Amount = dt.Rows[0]["Amount"].ToString();

                    if (Form.Amount != "")
                    {
                        ArrayList va = new ArrayList(Form.Amount.Split('~'));
                        for (int i = 0; i < va.Count; i++)
                        {
                            if (va.ToString() != "")
                            {

                                data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text'  class='form-control' name='column'  value=" + va[1].ToString() + "  />  <input type='hidden' name='tblcol'  class='form-control'  value=" + va[0].ToString() + "  />  </div></div>";
                                break;
                            }


                        }

                    }

                    Form.AmountControls = dt.Rows[0]["AmountControls"].ToString();
                    if (Form.AmountControls != "")
                    {
                        data = data + "<div class='col-sm-6'>  <div class='form-group'> <input type='text' class='form-control' name='control'  value=" + Form.AmountControls + "  /> <select class='form-control' id='ddlcontrols' style='display:none'><option value=''>--Select--</option><option value='TextBox'>TextBox</option> <option value='TextArea'>TextArea</option> <option value='DatePicker'>DatePicker</option> <option value='CheckBox'>CheckBox</option> <option value='RadioButton'>RadioButton</option></select>  </div></div>";

                    }




                    string query2 = updatequery;


                    f = data;

                }


            }
            

            return f;
        }




    









    }








}

