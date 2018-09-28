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
    public partial class frmDailyStudentTotals : System.Web.UI.Page
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
                this.AddKeepAlive();
                
                oMySql = new MySQL(ConnectionType.NonUnique);

                oCustomer = new Customer(Session["CompanyID"].ToString());
                oCustomer.oMySql = oMySql;
                oCustomer.Find(Session["CustomerID"].ToString());

                oCustomerCS = new Customer.CustomerCS(oCustomer.CompanyID,oMySql);
                oCustomerCS.oMySql = oMySql;
                oCustomerCS.Find(oCustomer.ID);
                oBrochure = new Brochure(oCustomer.CompanyID);
                oBrochure.oMySql = oMySql;

                    
                txtEarlyBirdDate.Value = DateTime.Today.ToString("MM/dd/yyyy");
                
                txtName.Text = oCustomer.Name;
                
                oMySql.Dispose();
            }

        }

        protected void butPrint_Click(object sender, EventArgs e)
        {
         //   oCustomer.Goal = Convert.ToInt32(txtGoal.Text);
         //   oCustomer.SetGoal(Convert.ToInt32(txtGoal.Text));
           // oCustomer.SetEarlyBirdDate(Convert.ToDateTime(txtEarlyBirdDate.Text));
            
          //  oCustomer.EarlyBirdDate = Convert.ToDateTime(txtEarlyBirdDate.Value);
          //  oCustomer.SetEarlyBirdDate(Convert.ToDateTime(txtEarlyBirdDate.Value));

            oMySql = new MySQL(ConnectionType.NonUnique);
            oCustomer.oMySql = oMySql;
            //oCustomer.PrintDailyStudentTotals(this.txt
            oMySql.Dispose();
        }
         
        private void AddKeepAlive()
        {
        int int_MilliSecondsTimeOut = (this.Session.Timeout * 60000) - 30000;
            string str_Script = @"
        <script type='text/javascript'>
        //Number of Reconnects
        var count=0;
        //Maximum reconnects setting
        var max = 5;
        function Reconnect(){

        count++;
        if (count < max)
            {
            window.status = 'Link to Server Refreshed ' + count.toString()+' time(s)' ;

            var img = new Image(1,1);

            img.src = 'Reconnect.aspx';

            }
            }

            window.setInterval('Reconnect()',"+ int_MilliSecondsTimeOut.ToString()+ @"); 

        </script>

";

this.Page.RegisterClientScriptBlock("Reconnect", str_Script);

        }
    }
}
