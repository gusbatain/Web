using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3.Pages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public static Company company = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnConexao_Click(object sender, EventArgs e)
        {
            try
            {
                bool Resposta = false;
                company = new Company();
                company.Server = "DESKTOP-73SFH92";
                company.DbServerType = BoDataServerTypes.dst_MSSQL2017;
                company.CompanyDB = "SBO_Car";
                company.UserName = "manager";
                company.Password = "GB45@Lab";
                company.language = BoSuppLangs.ln_English;

                 int error = company.Connect();

                if (error == 0)
                {
                    Resposta = true;
                    LBMsj.Text = "sucesso";

                }
                else
                {
                   LBMsj.Text ="Error - " + company.GetLastErrorDescription().ToString();

                }

                SAPbobsCOM.EmployeesInfo employeesInfo = company.GetBusinessObject(BoObjectTypes.oEmployeesInfo);
                employeesInfo.LastName = "Batain";
                employeesInfo.FirstName = "Gustavo";
                
                if(employeesInfo.Add() != 0)
                {
                    LBMsj.Text = "Error - " + company.GetLastErrorDescription().ToString();
                }
                
                SAPbobsCOM.Recordset query = company.GetBusinessObject(BoObjectTypes.BoRecordset);
                query.DoQuery("SELECT FIRSTNAME FROM OHEM");

                
            }
            catch (Exception ex)
            {

                LBMsj.Text = ex.Message;
            }

            //Registro
            //  if (company.Connected)
            //{
            //    Documents oEmpMaster = (Documents)company.GetBusinessObject(BoObjectTypes.oEmployeesInfo);


            //  oEmpMaster.UserFields.Fields.Item("U_FIRSTNAME").Value = txtUsuario.Text;
            //  oEmpMaster.UserFields.Fields.Item("U_LASTNAME").Value = txtUsuario.Text;


            //  int result = oEmpMaster.Add();

            //  if (result == 0)
            //  {
            //   Response.Redirect("PosLogin.aspx");
            //   }
            //  else
            //  {
            //  LabelPass.Visible = true;
            //     LabelEmpty.Visible = false;
            //         txtPassword.Text = "";
            //       txtPassword.Text = "";
            //       txtUsuario.Text = "";
            // }
            //   }
            //  else
            //  {

            //   }



        }
    }
}