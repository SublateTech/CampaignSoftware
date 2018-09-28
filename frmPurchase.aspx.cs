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
using Signature.Reports;
using Infragistics.WebUI.UltraWebGrid;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
        



namespace Signature.Campaign
{
    public partial class frmPurchase : System.Web.UI.Page
    {
        
        Purchase oPurchase;
        MySQL oMySql;
        ReportDocument cryRpt;
        

        protected override void OnPreInit(EventArgs e)
        {
         //   Session["CompanyID"] = "F09";
            
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

            this.txtTeachers.Attributes["onchange"] = "javascript:SetSeasonField();";
            this.txtStudents.Attributes["onchange"] = "javascript:SetStudentField();";

         //   this.warpGrid.AddLinkedRequestTrigger("butAddItem");
            /*
            if (!this.IsPostBack)
            {
                
                txtPurchases.Visible = true;
                LabPurchases.Visible = true;
               // LoadPurchases();
               
            }
            */
            LoadSeasons();
            


        }
        
        private void LoadPurchases()
        {
            //this.Agencies.Attributes["onchange"] = "javascript:SetFields();";

            ListItem oItem = new ListItem("Purchase", "---");
            txtStudents.Items.Add(oItem);

            DataTable dtPurchases = oMySql.GetDataTable(String.Format("Select * from Purchase Where CompanyID='{0}'", txtTeacherID.Value.ToString()));
            
            foreach (DataRow g in dtPurchases.Rows)
            {
              
                oItem = new ListItem(g["PurchaseID"].ToString(), g["PurchaseID"].ToString());
                if (g["PurchaseID"].ToString() == txtStudentID.Value.ToString())
                {
                    oItem.Selected = true;
                    oPurchase = new Purchase(txtTeacherID.Value.ToString(), oMySql);
                    txtPurchaseID.Text = txtStudentID.Value.ToString();
                    LoadPurchase();
                }
                txtStudents.Items.Add(oItem);
            }
            

            if (!IsPostBack)
            {

                //  if (this.Agencies.Rows.Count > 0)
                //      this.ChangeTxtValuesAcc_toSelected(0);

            }

        }

        private void LoadSeasons()
        {

            ListItem oItem = new ListItem("Season", "---");
            txtTeachers.Items.Add(oItem);
            /*
            oItem = new ListItem("GPI12", "GPI12");
            txtTeachers.Items.Add(oItem);
            txtTeacherID.Value = "GPI12";

            return;
            */
            DataTable dtPurchases = oMySql.GetDataTable("Select * from Company Where IsExternal='0' And CompanyID='GPI12' Order By CompanyID Desc");
            
            foreach (DataRow g in dtPurchases.Rows)
            {
                oItem = new ListItem(g["CompanyID"].ToString(), g["CompanyID"].ToString());
                if (txtTeacherID.Value == g["CompanyID"].ToString())
                {
                    oItem.Selected = true;
                    Session["CompanyID"] = txtSeasonID.Value.ToString();
                    LoadPurchases();
                }
                txtTeachers.Items.Add(oItem);
            }

            

        }
       
        private void LoadNotes()
        {
            //Purchase Notes
            txtNotes.Rows.Clear();
            int x = 0;
            foreach (DataRow oRow in oPurchase.Notes.CurrentDetail.Rows)
            {
                    txtNotes.Rows.Add();
                    txtNotes.Rows[x].Cells[0].Text = oRow["PurchaseNoteID"].ToString();
                    txtNotes.Rows[x].Cells[1].Text = oRow["Date"] == DBNull.Value ? "" : ((DateTime)oRow["Date"]).ToString("MM/dd/yyyy") + " " + ((DateTime)oRow["Date"]).ToLongTimeString();
                    txtNotes.Rows[x].Cells[2].Text = oRow["Note"].ToString();
                    txtNotes.Rows[x].Cells[3].Text = "Delete";
                    x++;
                
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
            if (txtNote.Text != "")
            {
                Purchase.Note oNote = new Purchase.Note(txtTeacherID.Value.ToString(), txtStudentID.Value.ToString(), oMySql);
                
                oNote._Note = txtNote.Text;
                oNote.Date = DateTime.Now;
                oNote.Insert();
        
            }
            LoadPurchase();
            txtNote.Text = "";
            
        }

       


        private void LoadPurchase()
        {
            if (oPurchase == null)
            {
                oPurchase = new Purchase(txtTeacherID.Value.ToString(), oMySql);
               // oPurchase.Find(txtStudentID.Value.ToString());
            }

            if (oPurchase.Find(txtStudentID.Value.ToString()))
            {
                txtVendorID.Text = oPurchase.VendID.ToString();
                txtShipDate.Value = oPurchase.LeavingDate;
                txtShipmentDate.Value = oPurchase.LandedDate;
                labTotal.Text = oPurchase.GetTotal().ToString();

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


                        x++;
                    }
                }

                LoadNotes();

            }
         //   LoadPurchases(); 
        }

        protected void txtPurchases_SelectedRowChanged(object sender, Infragistics.WebUI.WebCombo.SelectedRowChangedEventArgs e)
        {
                      
        }

        protected void txtSeasons_SelectedRowChanged(object sender, Infragistics.WebUI.WebCombo.SelectedRowChangedEventArgs e)
        {
            Session["CompanyID"] = txtSeasonID.Value.ToString();
            LoadPurchases();
          //  LoadSeasons();
        }

        protected void txtNotes_ClickCellButton(object sender, CellEventArgs e)
        {
            if (txtNoteID.Value.ToString() != "")
            {
                Purchase.Note oNote = new Purchase.Note(Session["CompanyID"].ToString(), txtIdPurchase.Value.ToString(), oMySql);
                oNote.Find(Convert.ToInt32(txtNoteID.Value.ToString()));
                
            }            
        }

        protected void txtDelete_Click(object sender, EventArgs e)
        {
            if (txtNoteID.Value.ToString() != "")
            {
                Purchase.Note oNote = new Purchase.Note(txtTeacherID.Value.ToString(), txtTeacherID.Value.ToString(), oMySql);
                if (oNote.Find(Convert.ToInt32(txtNoteID.Value.ToString())))
                {
                    oNote.Delete();
                }
            }
            LoadPurchase();
            txtNote.Text = "";
        }

        protected void txtChange_Click(object sender, EventArgs e)
        {
            if (txtNote.Text != "")
            {
                Purchase.Note oNote = new Purchase.Note(txtTeacherID.Value.ToString(), txtStudentID.Value.ToString(), oMySql);
                if (txtNoteID.Value.ToString() != "")
                {
                    oNote.Find(Convert.ToInt32(txtNoteID.Value.ToString()));
                }
                oNote._Note = txtNote.Text;
                oNote.Date = DateTime.Now;
                if (txtNoteID.Value.ToString() != "")
                    oNote.Update();
                else
                    oNote.Insert();

            }
            LoadPurchase();
            txtNote.Text = "";
        }

        protected void txtTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CompanyID"] = txtTeachers.Text.ToString();
            LoadPurchases();
        }

        protected void txtStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            oPurchase = new Purchase(Session["CompanyID"].ToString(), oMySql);
            txtPurchaseID.Text = txtIdPurchase.Value.ToString();
            LoadPurchase();
        }

        protected void butAddItem_Click(object sender, EventArgs e)
        {
            if (oPurchase != null)
            {
                PurchaseOrder cryRpt = new PurchaseOrder();

                oPurchase.Print(cryRpt);

                try
                {
                    ExportOptions CrExportOptions;

                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    ExcelFormatOptions CrFormatTypeOptions = new ExcelFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = Server.MapPath("~/OutputFiles/") + "Purchase-" + oPurchase.ID + ".xls";
                    CrExportOptions = cryRpt.ExportOptions;
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.Excel;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                    cryRpt.Export();
                    cryRpt = null;
                    Response.Redirect("http://" + Request.ServerVariables["SERVER_NAME"] + "/OutputFiles/" + "Purchase-" + oPurchase.ID + ".xls");
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            }
        } //Purchases
    }
}
