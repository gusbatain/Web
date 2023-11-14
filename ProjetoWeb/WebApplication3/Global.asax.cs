using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication3
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            
            bool Resposta = false;
            Company company = new Company();
            company = new Company();
            company.Server = "DESKTOP-73SFH92";
            company.DbServerType = BoDataServerTypes.dst_MSSQL2017;
            company.CompanyDB = "SBO_Car";
            company.UserName = "manager";
            company.Password = "GB45@Lab";
            company.language = BoSuppLangs.ln_English;

            int Resultado = company.Connect(); 

            if (Resultado == 0)
            {
                Resposta = true;
                Application["SAPConnection"] = company;
            }
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}