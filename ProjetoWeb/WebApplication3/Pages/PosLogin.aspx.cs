using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3.Pages
{
    public partial class PosLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["empID"] != null)
            {
                int empID = (int)Session["empID"];

                
                txtAdress.Text = Session["WorkCity"].ToString();
                txtJobtitle.Text = Session["JobTitle"].ToString();
                txtFname.Text = Session["FirstName"].ToString();

            }
        }
    }
}