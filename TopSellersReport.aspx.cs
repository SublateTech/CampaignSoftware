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
    public partial class TopSellersReport : System.Web.UI.Page
    {
        Customer oCustomer;
        
        private void Page_Load(object sender, System.EventArgs e)
        {
            
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


                    //ReportViewer.Width = 700;
                    ReportViewer.DisplayGroupTree = false;
                    ReportViewer.HasCrystalLogo = false;
                    ReportViewer.HasToggleGroupTreeButton = false;
                    // ReportViewer.Width  = 700;
                    ReportViewer.Height = 400;
                    ReportViewer.BestFitPage = true;
                    oCustomer.PrintTopSelllersReport(ReportViewer, DateTime.Now);
                }
            }
        }
              
    }
}
