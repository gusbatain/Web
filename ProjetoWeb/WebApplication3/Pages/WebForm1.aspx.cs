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
using Antlr.Runtime.Tree;

namespace WebApplication3.Pages
{
    public partial class WebForm1 : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                txtLname.Visible = (rblUserType.SelectedValue == "Employee");
                txtEmail.Visible = (rblUserType.SelectedValue == "Employee");
                LabelEmail.Visible = (rblUserType.SelectedValue == "Employee");
                LabelLastName.Visible = (rblUserType.SelectedValue == "Employee");
                txtEmail.Focus();
            }
            Company company = Application["SAPConnection"] as Company;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Company company = Application["SAPConnection"] as Company;

            try
            {
                SAPbobsCOM.Recordset query = company.GetBusinessObject(BoObjectTypes.BoRecordset);
                string userType = rblUserType.SelectedValue;


                if (company.Connected)
                {

                    if (userType == "Employee")
                    {

                        query.DoQuery($"SELECT empID, WorkCity, JobTitle, firstName FROM OHEM WHERE email = '{txtEmail.Text}' AND lastName = '{txtLname.Text}'");
                    }
                    else if (userType == "Vendor")
                    {

                        query.DoQuery($"SELECT CardCode, E_Mail, CardFName, City FROM OCRD WHERE CardName = '{txtForName.Text}' AND CardCode = '{txtCode.Text}'");

                    }
                }

                if (!query.EoF)
                {
                    if (userType == "Employee")
                    {
                        int empID = int.Parse(query.Fields.Item("empID").Value.ToString());
                        string workCity = query.Fields.Item("WorkCity").Value.ToString();
                        string jobTitle = query.Fields.Item("JobTitle").Value.ToString();
                        string firstName = query.Fields.Item("firstName").Value.ToString();


                        Session["WorkCity"] = workCity;
                        Session["JobTitle"] = jobTitle;
                        Session["firstName"] = firstName;
                        Session["email"] = txtEmail.Text;
                        Session["lastName"] = txtLname.Text;


                        Session["empID"] = empID;
                        Session["UserType"] = userType;
                        Response.Redirect("PosLogin.aspx");
                    }

                    else if (userType == "Vendor")
                    {
                        string Email = query.Fields.Item("E_Mail").Value.ToString();
                        string CardForeignName = query.Fields.Item("CardFName").Value.ToString();
                        string Adress = query.Fields.Item("City").Value.ToString();

                        Session["CardCode"] = txtCode.Text;
                        Session["CardName"] = txtForName.Text;
                        Session["E_Mail"] = Email;
                        Session["CardFName"] = CardForeignName;
                        Session["City"] = Adress;


                        Session["UserType"] = userType;
                        Response.Redirect("PosLogin.aspx");
                    }


                }
                else if (string.IsNullOrEmpty(txtEmail.Text) && string.IsNullOrEmpty(txtLname.Text))
                {
                    LabelEmpty.Visible = true;
                    LabelPass.Visible = false;
                }
                else
                {
                    LabelPass.Visible = true;
                    LabelEmpty.Visible = false;
                    txtEmail.Text = "";
                    txtLname.Text = "";
                }
            }
            catch (Exception ex)
            {
                Texto.Text = "Erro= " + ex.Message;
                Texto.Visible = true; Texto.Text += ex.Message;
            }
        }

        protected void rblUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Updatevisibility();
            txtCode.Focus();
        }

        private void Updatevisibility()
        {
            bool Vendor = (rblUserType.SelectedValue == "Vendor");

            txtLname.Visible = !Vendor;
            txtEmail.Visible = !Vendor;
            LabelEmail.Visible = !Vendor;
            LabelLastName.Visible = !Vendor;
            LabelCardName.Visible = Vendor;
            LabelCardCode.Visible = Vendor;
            txtForName.Visible = Vendor;
            txtCode.Visible = Vendor;

        }
    }
}




