using SAPbobsCOM;
using System.Web.SessionState;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;


namespace WebApplication3.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static Company company = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
            company = new Company();
            company.Server = "DESKTOP-73SFH92";
            company.DbServerType = BoDataServerTypes.dst_MSSQL2017;
            company.CompanyDB = "SBO_Car";
            company.UserName = "manager";
            company.Password = "GB45@Lab";
            company.language = BoSuppLangs.ln_English;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SAPbobsCOM.EmployeesInfo employeesInfo = company.GetBusinessObject(BoObjectTypes.oEmployeesInfo);
                employeesInfo.LastName = txtLname.Text;
                employeesInfo.eMail = txtEmail.Text;
                SAPbobsCOM.Recordset query = company.GetBusinessObject(BoObjectTypes.BoRecordset);

                if (company.Connected)
                {
                    query.DoQuery($"SELECT empID FROM OHEM WHERE email ='{txtEmail.Text}' AND lastName = '{txtLname.Text}' ");

                }

                if (Session["email"] != null)
                {
                    string empIDStr = company.GetNewObjectKey();
                    int empID = int.Parse(empIDStr);
                    Session["empID"] = empID;
                }

                if (!query.EoF)
                {
                    Response.Redirect("PosLogin.aspx");
                }
                else if (txtEmail.Text == "" && txtLname.Text == "")
                {
                    LabelEmpty.Visible = true;
                    LabelPass.Visible = false;
                }

                else
                {
                    LabelPass.Visible = true;
                    LabelEmpty.Visible = false;
                    txtEmail.Text = "";
                    txtEmail.Text = "";

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
