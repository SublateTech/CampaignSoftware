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
    public partial class frmPurchase : System.Web.UI.Page
    {
        
        Purchase oPurchase;
        MySQL oMySql;
        

        protected override void OnPreInit(EventArgs e)
        {
            Session["CompanyID"] = "F09";
            
            if (Session["Message"] != null)
            {
                txtMessage.Text = Session["Message"].ToString();
                Session["Message"] = null;
            }
            base.OnPreInit(e);

        }
        
        private void Page_Load(object sender, System.EventArgs e)
        {
            oMySql = new MySQL(ConnectionType.NonUnique);
            oPurchase = new Purchase(Session["CompanyID"].ToString(), oMySql);


         //   this.warpGrid.AddLinkedRequestTrigger("butAddItem");

            if (!this.IsPostBack)
            {
                bNew.Checked = true;
                bNew_CheckedChanged(null, null);
            }   



        }
        
        private void LoadPurchases()
        {
            //this.Agencies.Attributes["onchange"] = "javascript:SetFields();";


            DataTable dtPurchases = oMySql.GetDataTable(String.Format("Select * from Purchase Where CompanyID='{0}'", Session["CompanyID"].ToString()));
            
            foreach (DataRow g in dtPurchases.Rows)
            {
              
                UltraGridRow _row = new UltraGridRow();

                int i = _row.Cells.Add(new UltraGridCell(g["PurchaseID"].ToString()));
                _row.DataKey = g["PurchaseID"].ToString();

                txtPurchases.Rows.Add(_row);
            }
            

            if (!IsPostBack)
            {

                //  if (this.Agencies.Rows.Count > 0)
                //      this.ChangeTxtValuesAcc_toSelected(0);

            }

        }
        
        protected void txtCancel_Click(object sender, EventArgs e)
        {
            //Session["IdRequest"] = null;
            //Server.Transfer("frmProfessionalInbox.aspx");
        }

        protected void txtSave_Click(object sender, EventArgs e)
        {
            
        }

        protected void txtAdd_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void txtAlerts_ClickCellButton(object sender, Infragistics.WebUI.UltraWebGrid.CellEventArgs e)
        {
                      
        }

        protected void bNew_CheckedChanged(object sender, EventArgs e)
        {
            if (bNew.Checked)
            {
                txtPurchases.Visible = false;
                LabPurchases.Visible = false;
                txtPurchaseID.Text = oPurchase.GetNextNumber();
                txtShipDate.Value = DateTime.Today;
                txtShipmentDate.Value = DateTime.Today;
                txtVendorID.Text = "";
            }
            else if (bEdit.Checked)
            {
                txtPurchases.Visible = true;
                LabPurchases.Visible = true;
                LoadPurchases();
            }
            else
            {
            //    labAgencyName.Visible = false;
            //    Agencies.Visible = false;
            }
        }

        protected void txtPurchases_SelectedRowChanged(object sender, Infragistics.WebUI.WebCombo.SelectedRowChangedEventArgs e)
        {
           txtPurchaseID.Text = txtIdPurchase.Value.ToString();
           if (oPurchase.Find(txtIdPurchase.Value.ToString()))
           {
               txtVendorID.Text = oPurchase.VendID.ToString();
               txtShipDate.Value = oPurchase.LeavingDate;
               txtShipmentDate.Value = oPurchase.LandedDate;

               //Purchase Detail
               txtAlerts.Rows.Clear();
               int x = 0;
               foreach (DataRow oRow in oPurchase.Items.dtItems.Rows)
               {
                   if (oRow["ProductID"].ToString() != "")
                   {
                       txtAlerts.Rows.Add();
                       txtAlerts.Rows[x].Cells[0].Text = oRow["ProductID"].ToString();
                       txtAlerts.Rows[x].Cells[1].Text = oRow["Price"].ToString();
                       txtAlerts.Rows[x].Cells[2].Text = oRow["Cases"].ToString();
                       txtAlerts.Rows[x].Cells[3].Text = oRow["Units"].ToString();
                       txtAlerts.Rows[x].Cells[4].Text = oRow["InvCode"].ToString();
                       txtAlerts.Rows[x].Cells[5].Text = oRow["Size"].ToString();
                       txtAlerts.Rows[x].Cells[6].Text = oRow["Description"].ToString();
                       txtAlerts.Rows[x].Cells[7].Text = oRow["Note"].ToString();
                       if (oRow["ProductID"].ToString() != "")
                           txtAlerts.Rows[x].Cells[8].Text = "Delete";
                       else
                           txtAlerts.Rows[x].Cells[8].Text = "Add";

                       x++;
                   }
               }



           }
        }
    }
}
