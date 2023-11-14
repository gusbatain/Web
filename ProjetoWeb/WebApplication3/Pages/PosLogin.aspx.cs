using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace WebApplication3.Pages
{
    public partial class PosLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Company company = Application["SAPConnection"] as Company;


            if (company != null && company.Connected)
            {
                if (Session["UserType"] != null)
                {
                    string userType = Session["UserType"].ToString();

                    if (userType == "Employee")
                    {
                        if (Session["empID"] != null)
                        {
                            int empID = (int)Session["empID"];
                            txtAdress.Text = Session["WorkCity"].ToString();
                            txtJobtitle.Text = Session["JobTitle"].ToString();
                            txtFname.Text = Session["firstName"].ToString();
                            txtEmail.Text = Session["email"].ToString();
                            TxtNomeC.Text = Session["firstName"] + " " + Session["lastName"].ToString();
                            txtUsuario.Text = "Employee";

                        }
                    }
                    else if (userType == "Vendor")
                    {
                        if (Session["CardCode"] != null)
                        {
                            string cardCode = Session["CardCode"].ToString();
                            string cardName = Session["CardName"].ToString();
                            string cardForeignName = Session["CardFName"].ToString();
                            string cardEmail = Session["E_Mail"].ToString();
                            string City = Session["City"].ToString();
                            txtJobtitle.Text = cardCode;
                            txtAdress.Text = cardName;
                            txtEmail.Text = cardEmail;
                            txtAdress.Text = City;
                            txtFname.Text = cardForeignName;
                            TxtNomeC.Text = cardName +" " + cardForeignName;
                            txtUsuario.Text = "Vendor";
                        }

                    }
                }
                else
                {
                    Response.Redirect("WebForm1.aspx");
                }
            }

        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("WebForm1.aspx");

        }
    }

}
