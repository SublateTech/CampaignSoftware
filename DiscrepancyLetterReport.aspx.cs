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
    public partial class DiscrepancyLetterReport : System.Web.UI.Page
    {
        Customer oCustomer;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Request["CustomerID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
                {
                    String CompanyID = Request["SeasonID"].ToString();
                    oCustomer = new Customer(CompanyID, oMySql);
                    oCustomer.Find(Request["CustomerID"].ToString());
                    txtName.Text = oCustomer.Name;

                    
                    //ReportViewer.Width = 700;
                    ReportViewer.DisplayGroupTree = false;
                    ReportViewer.HasCrystalLogo = false;
                    ReportViewer.HasToggleGroupTreeButton = false;
                    //ReportViewer.Width  = 700;
                    ReportViewer.Height = 400;
                    ReportViewer.BestFitPage = true;

                    oCustomer.PrintDiscrepancyLetter(ReportViewer, Convert.ToInt32(Request["OrderID"].ToString()));
                }
            }


        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            
         
        }

        private void Page_Load(object sender, System.EventArgs e)
        {
        }
              
    }
}
