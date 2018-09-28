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
    public partial class Login : System.Web.UI.Page
    {
        
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
            if (Name.Text == "PO MOD" && Password.Text == "PO_MOD*495")
            {   
                Response.Redirect("frmPurchase.aspx");
            }
            else
            {
                Session["Message"] = "Notice, either your username or password was not <br> recognized, please try again.  If you continue to have <br> difficulty,  please call 1-800-645-3863.";
            }
            Server.Transfer("Login.aspx");
        }

    }
}
