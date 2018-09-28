using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campaign
{
    public partial class frmChairperson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCustomerID.Value = Session["CustomerID"].ToString();
            txtCompanyID.Value = Session["CompanyID"].ToString().Replace("_","");
        }
    }
}
