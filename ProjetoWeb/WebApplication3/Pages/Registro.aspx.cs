using System;
using System.Collections.Generic;
using SAPbobsCOM;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;


namespace WebApplication3.Pages
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFname.Focus();
            if (!IsPostBack)
            {
                txtFname.Visible = (rblUserType.SelectedValue == "Employee");
                txtAdress.Visible = (rblUserType.SelectedValue == "Employee");
                txtJobtitle.Visible = (rblUserType.SelectedValue == "Employee");
                txtLname.Visible = (rblUserType.SelectedValue == "Employee");
                txtEmail.Visible = (rblUserType.SelectedValue == "Employee");
            }
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            Company company = Application["SAPConnection"] as Company;

            try
            {
                if (company != null && company.Connected)
                {
                    string userType = rblUserType.SelectedValue;

                    if (userType == "Employee")
                    {
                        SAPbobsCOM.EmployeesInfo employeesInfo = company.GetBusinessObject(BoObjectTypes.oEmployeesInfo);

                        string firstName = txtFname.Text;
                        string lastName = txtLname.Text;
                        string email = txtEmail.Text;
                        string jobTitle = txtJobtitle.Text;
                        string address = txtAdress.Text;

                        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(jobTitle) || string.IsNullOrEmpty(address))
                        {
                            LabelEmpty.Visible = true;
                            LabelEmpty.Text = "Preencha todos os campos obrigatórios.";
                        }
                        else
                        {
                            employeesInfo.FirstName = firstName;
                            employeesInfo.LastName = lastName;
                            employeesInfo.eMail = email;
                            employeesInfo.JobTitle = jobTitle;
                            employeesInfo.WorkCity = address;

                            if (employeesInfo.Add() == 0)
                            {
                                LabelEmpty.Visible = true;
                                LabelEmpty.Text = "Funcionário cadastrado com sucesso";
                            }
                            else
                            {
                                LabelEmpty.Visible = true;
                                LabelEmpty.Text = $"Erro ao cadastrar funcionário: {company.GetLastErrorDescription()}";
                            }
                        }
                    }
                    else if (userType == "Vendor")
                    {
                        SAPbobsCOM.BusinessPartners businessPartners = company.GetBusinessObject(BoObjectTypes.oBusinessPartners);

                        string Code = txtCode.Text;
                        string Name = txtForName.Text;
                        string NameForeign = txtForeign.Text;
                        string Email = txtEmail.Text;
                        string WorkCity = txtAdress.Text;

                        if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
                        {
                            LabelEmpty.Visible = true;
                            LabelEmpty.Text = "Preencha todos os campos obrigatórios.";
                        }
                        else
                        {
                            businessPartners.CardCode = Code;
                            businessPartners.CardName = Name;
                            businessPartners.CardForeignName = NameForeign;
                            businessPartners.City = WorkCity;
                            businessPartners.EmailAddress = Email;

                            if (businessPartners.Add() == 0)
                            {
                                LabelEmpty.Visible = true;
                                LabelEmpty.Text = "Funcionário cadastrado com sucesso";
                            }
                        }
                    }
                }
                else
                {
                    Response.Write($"Falha na conexão. Código de erro: {company.GetLastErrorDescription()}");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"Erro: {ex.Message}");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        protected void rblUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Updatevisibility();

        }

        private void Updatevisibility()
        {
            if (rblUserType.SelectedValue == "Vendor")
            {
                bool Vendor = (rblUserType.SelectedValue == "Vendor");

                txtFname.Visible = !Vendor;
                txtAdress.Visible = Vendor;
                txtJobtitle.Visible = !Vendor;
                txtLname.Visible = !Vendor;
                txtEmail.Visible = Vendor;
                txtForName.Visible = Vendor;
                txtCode.Visible = Vendor;
                txtForeign.Visible = Vendor;
            }
            else
            {
                bool Employee = (rblUserType.SelectedValue == "Employee");
                txtFname.Visible = Employee;
                txtAdress.Visible = Employee;
                txtJobtitle.Visible = Employee;
                txtLname.Visible = Employee;
                txtEmail.Visible = Employee;
                txtForName.Visible = !Employee;
                txtCode.Visible = !Employee;
                txtForeign.Visible = !Employee;
            }
        }
    }
}