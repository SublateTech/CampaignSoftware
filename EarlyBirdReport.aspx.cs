using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Signature.Classes;
using Signature.Data;
using Infragistics.WebUI.UltraWebGrid;

namespace Signature.Campaign
{
    public partial class EarlyBirdReport : System.Web.UI.Page
    {
        Customer oCustomer;
        Customer.CustomerCS oCustomerCS;

        protected override void OnInit(EventArgs e)
        {
          //  base.OnInit(e);
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
                {
                    oCustomer = new Customer(Session["CompanyID"].ToString(),oMySql);
                    oCustomer.oMySql = oMySql;
                    oCustomer.Find(Session["CustomerID"].ToString());
                    txtName.Text = oCustomer.Name;

                    oCustomerCS = new Customer.CustomerCS(oCustomer.CompanyID,oMySql);
                    oCustomerCS.oMySql = oMySql;
                    oCustomerCS.Find(oCustomer.ID);

                    //ReportViewer.Width = 700;
                    ReportViewer.DisplayGroupTree = false;
                    ReportViewer.HasCrystalLogo = false;
                    ReportViewer.HasToggleGroupTreeButton = false;
                    // ReportViewer.Width  = 700;
                    ReportViewer.Height = 400;
                    ReportViewer.BestFitPage = true;
                    oCustomer.PrintEarlyBird(ReportViewer, oCustomerCS.EarlyBirdDate);
                }
            }
        }
      
    }
}
