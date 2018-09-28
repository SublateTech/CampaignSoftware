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
    public partial class ClassCollectionSheetByDate : System.Web.UI.Page
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
                if (!IsPostBack)
                     txtEarlyBirdDate.Value = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd"));
                
                using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
                {
                    oCustomer = new Customer(Session["CompanyID"].ToString(),oMySql);
                    oCustomer.Find(Session["CustomerID"].ToString());
                    txtName.Text = oCustomer.Name;

                }
                butSave_Click(null, null);
            }
        }

        protected void butSave_Click(object sender, EventArgs e)
        {
            using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
            {
                oCustomer = new Customer(Session["CompanyID"].ToString(),oMySql);
                oCustomer.oMySql = oMySql;
                oCustomer.Find(Session["CustomerID"].ToString());
                

                //ReportViewer.Width = 700;
                //ReportViewer.ToolbarImagesFolderUrl = "../Reports/images/toolbar/";
                //txtName.Text = ReportViewer.ToolbarImagesFolderUrl;
                ReportViewer.DisplayGroupTree = false;
                ReportViewer.HasCrystalLogo = false;
                ReportViewer.HasToggleGroupTreeButton = false;
                // ReportViewer.Width  = 700;
                ReportViewer.Height = 400;
                ReportViewer.BestFitPage = true;
                //oCustomer.PrintDailyStudentTotals(ReportViewer, Convert.ToDateTime(txtEarlyBirdDate.Value));
                oCustomer.PrintClassCollectionSheetByDate(ReportViewer, Convert.ToDateTime(txtEarlyBirdDate.Value));
            }
        }
              
    }
}
