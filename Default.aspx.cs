using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Signature.Web.Controls;
using Signature.Data;
using Signature.Classes;


namespace Signature.Campaign
{
    public partial class Main : System.Web.UI.Page
    {
        MySQL oMySql;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["Message"] != null)
            {
                txtMessage.Text = Session["Message"].ToString();
                Session["Message"] = null;
            }
        }

        protected void butLogIn_Click(object sender, EventArgs e)
        {
            /*Global.oMySql.Close();
            Global.oMySql.connectionType = ConnectionType.NonUnique;
            Global.oMySql.Open();
             */
               // Global.oMySql.Close();
                oMySql = new MySQL(ConnectionType.NonUnique);
               // Global.oMySql = oMySql;
                
            
                Customer oCustomer = new Customer(Season.Items[Season.SelectedIndex].Value,oMySql);
                
                if (oCustomer.FindByChairperson(Name.Text, Password.Text))
                {
                    Session["CompanyID"] = oCustomer.CompanyID;
                    Session["CustomerID"] = oCustomer.ID;
                    oMySql.Dispose();
                    Response.Redirect("frmCustomer.aspx");
                }
                else
                {
                    Session["Message"] = "Notice, either your username or password was not <br> recognized, please try again.  If you continue to have <br> difficulty,  please call 1-800-645-3863.";
                }

                oMySql.Dispose();
                Server.Transfer("Default.aspx");
        }

    }
}
