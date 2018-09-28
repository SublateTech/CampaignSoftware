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
using Signature.Data;
using Signature.Classes;
using Infragistics.WebUI.UltraWebGrid;

namespace Signature.Campaign
{
    public partial class frmCustomer : System.Web.UI.Page
    {
        MySQL oMySql;
        Customer oCustomer;
        Customer.CustomerCS oCustomerCS;
        Brochure oBrochure;
        
        private void Page_Load(object sender, System.EventArgs e)
        {
         //   this.warpGrid.AddLinkedRequestTrigger("butAddItem");
            
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {   
                oMySql = new MySQL(ConnectionType.NonUnique);

                oCustomer = new Customer(Session["CompanyID"].ToString(),oMySql);
                oCustomer.Find(Session["CustomerID"].ToString());

                oCustomerCS = new Customer.CustomerCS(oCustomer.CompanyID,oMySql);
                oCustomerCS.Find(oCustomer.ID);
                oBrochure = new Brochure(oCustomer.CompanyID,oMySql);
                oBrochure.oMySql = oMySql;

                if (!this.IsPostBack)
                {
                    if (oCustomerCS.Goal == 0)
                        txtGoal.Text = "10";
                    else
                        txtGoal.Text = oCustomerCS.Goal.ToString();

                    if (oCustomerCS.EarlyBirdDate == Global.DNull)
                        txtEarlyBirdDate.Value = oCustomer.StartDate.AddDays(7);
                    else
                        txtEarlyBirdDate.Value = oCustomerCS.EarlyBirdDate.ToString("MM/dd/yyyy");
                }
                txtName.Text = oCustomer.Name;
                txtAddress.Text = oCustomer.Address + " " + oCustomer.City + " " + oCustomer.State + ", " + oCustomer.ZipCode;
                txtChairperson.Text = oCustomer.Chairperson;
                txteMail.Text = oCustomer.eMail;
                txtFax.Text = oCustomer.FaxNumber!=""? string.Format("{0:(###)-###-####}", double.Parse(oCustomer.FaxNumber)):"";
                txtPhone.Text = oCustomer.PhoneNumber!=""?string.Format("{0:(###)-###-####}", double.Parse(oCustomer.PhoneNumber)):""; 
                oBrochure.Find(oCustomer.BrochureID);
                txtBrochure.Text = oCustomer.BrochureID + " - " + oBrochure.Description;
                txtProfit.Text = oCustomer.ProfitPercent.ToString();
                txtStartDate.Text = (oCustomer.StartDate == Global.DNull)?"":oCustomer.StartDate.ToString("MM/dd/yyyy");
                txtEndDate.Text = (oCustomer.EndDate == Global.DNull) ? "" : oCustomer.EndDate.ToString("MM/dd/yyyy");
                txtPickUpDate.Text = (oCustomer.PickUpDate == Global.DNull) ? "" : oCustomer.PickUpDate.ToString("MM/dd/yyyy");
                txtDeliveryDate.Text = (oCustomer.DeliveryDate == Global.DNull) ? "" : oCustomer.DeliveryDate.ToString("MM/dd/yyyy");
                txtParentPickUpDate.Text = (oCustomer.ParentPickUpDate == Global.DNull) ? "" : oCustomer.ParentPickUpDate.ToString("MM/dd/yyyy");
               // txtItemsDelivery.Text = oCustomer.NoItems.ToString();

               // oMySql.Dispose();
            }

            if (Page.Request["Import"] != null && Page.Request["Import"] == "OK")
                {
                    Message.Text = "Congratulations, your upload is complete.";
                }
        }

        protected void butSave_Click(object sender, EventArgs e)
        {
         //   oCustomer.Goal = Convert.ToInt32(txtGoal.Text);
         //   oCustomer.SetGoal(Convert.ToInt32(txtGoal.Text));
           // oCustomer.SetEarlyBirdDate(Convert.ToDateTime(txtEarlyBirdDate.Text));
            
          //  oCustomer.EarlyBirdDate = Convert.ToDateTime(txtEarlyBirdDate.Value);
          //  oCustomer.SetEarlyBirdDate(Convert.ToDateTime(txtEarlyBirdDate.Value));

            oCustomerCS.EarlyBirdDate = Convert.ToDateTime(txtEarlyBirdDate.Value);
            oCustomerCS.Goal = Convert.ToInt32(txtGoal.Text);
            oCustomerCS.Save();
            oMySql.Dispose();
        }
         
        
    }
}
