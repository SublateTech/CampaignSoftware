using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Signature.Classes;
using Signature.Data;

namespace Signature.Campaign
{
    public partial class frmPdfDoc : System.Web.UI.Page
    {
        Customer oCustomer;

        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["CompanyID"] = "__S10";
          //  Session["CustomerID"] = "10503";
            MySQL oMySql = new MySQL(ConnectionType.NonUnique);
            oCustomer = new Customer(Session["CompanyID"].ToString(),oMySql);
            oCustomer.Find(Session["CustomerID"].ToString());
            oMySql.Dispose();

            
        }
        
        
    }
}