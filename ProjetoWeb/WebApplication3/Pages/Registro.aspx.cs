using System;
using System.Collections.Generic;
using SAPbobsCOM;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3.Pages
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public static Company company = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            company = new Company();
            company.Server = "DESKTOP-73SFH92";
            company.DbServerType = BoDataServerTypes.dst_MSSQL2017;
            company.CompanyDB = "SBO_Car";
            company.UserName = "manager";
            company.Password = "GB45@Lab";
            company.language = BoSuppLangs.ln_English;
            txtFname.Focus();

        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            int Resultado = company.Connect();

            if (Resultado == 0)
            {
                try
                {


                    SAPbobsCOM.EmployeesInfo employeesInfo = company.GetBusinessObject(BoObjectTypes.oEmployeesInfo);

                    string firstName = txtFname.Text;
                    string lastName = txtLname.Text;
                    string Email = txtEmail.Text;
                    string jobtitle = txtJobtitle.Text;
                    string adress = txtAdress.Text;

                    if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(jobtitle) || string.IsNullOrEmpty(adress))
                    {
                        LabelEmpty.Visible = true;
                        LabelEmpty.Text = "Preencha todos os campos obrigatórios.";
                    }

                    else
                    {
                        employeesInfo.FirstName = firstName;
                        employeesInfo.LastName = lastName;
                        employeesInfo.eMail = Email;
                        employeesInfo.JobTitle = jobtitle;
                        employeesInfo.WorkCity = adress;
                        
                        if(employeesInfo.Add()  == 0)
                        {
                            string empIDStr = company.GetNewObjectKey();
                            int empID = int.Parse(empIDStr);
                            Session["empID"] = empID;
                            Response.Redirect("PosLogin.aspx");
                        }

                        LabelEmpty.Visible = true;
                        LabelEmpty.Text = "Funcionário cadastrado com sucesso";


                    }
                }

                catch (Exception ex)
                {
                    Response.Write($"Erro: {ex.Message}");
                }
                finally
                {
                    company.Disconnect();
                }
            }
            else
            {
                Response.Write($"Falha na conexão. Código de erro: {company.GetLastErrorDescription()}");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }


}








