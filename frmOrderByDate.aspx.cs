using System;
using System.Drawing;
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
    public partial class frmOrderByDate : System.Web.UI.Page
    {
        Customer oCustomer;
        Order oOrder;
        Teacher oTeacher;
        Student oStudent;
        MySQL oMySql;
        
        TextBox tbItems;
        TextBox tbOrdered;
        TextBox tbTurnedIn;
        TextBox tbCheckIn;
        TextBox tbNotes;

        private void Page_Load(object sender, System.EventArgs e)
        {
           // Session["CustomerID"] = "10000";
           // Session["CompanyID"] = "__S09";

            this.txtTeachers.Attributes["onchange"] = "javascript:SetField();";
            this.txtStudents.Attributes["onchange"] = "javascript:SetStudentField();";
         
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
              //  this.AddKeepAlive();
                oMySql = new MySQL(ConnectionType.NonUnique);
                

                    oCustomer = new Customer(Session["CompanyID"].ToString(),oMySql);
                    oCustomer.Find(Session["CustomerID"].ToString());
                    oTeacher = new Teacher(oCustomer.CompanyID, oCustomer.ID,oMySql);
                    oStudent = new Student(oCustomer.CompanyID, oCustomer.ID,oMySql);
                    oOrder = new Order(oCustomer.CompanyID,oMySql);
                    txtName.Text = oCustomer.Name;

                    if (txtAction.Value.ToString()=="Edit")
                    {   
                        if (oOrder.Find(Convert.ToInt32(txtValue.Value.ToString())))
                        {
                            txtTeacherID.Value = oOrder.TeacherID.ToString();
                            txtStudentID.Value = oOrder.StudentID.ToString();
                        }
                    }

                    LoadTeachers();
                    if (Page.IsPostBack || txtAction.Value.ToString() == "Edit")
                    {
                        if (IsPostBack && Request.Form["__EVENTTARGET"].ToString() == "txtTeachers")
                        {
                            txtStudentID.Value = "";
                        }
                        LoadStudents();
                        LoadOrder();
                        txtAction.Value = "";
                    }
                    
                    
                
                    if (IsPostBack)
                    {
                        
                        if (Request.Form["__EVENTTARGET"].ToString() == "txtTeachers")
                        {
                            if (txtTeachers.Items[0].Value.ToString() == "-1")
                                txtTeachers.Items.RemoveAt(0);
                        }
                        
                        if (Request.Form["__EVENTTARGET"].ToString() == "txtStudents" )
                        {
                            DeleteFirstItem();
                            
                        }
                        
                    }
                
                    if (!IsPostBack)
                        txtDate.Value = DateTime.Today;
                
            }
        }
        private void Page_UnLoad(object sender, System.EventArgs e)
        {
            if (oMySql != null)
                oMySql.Dispose();   

        }
        protected virtual void LoadTeachers()
        {
          //  oCustomer = (Customer)(Session["Customer"]);
           // DataTable dt = Global.oMySql.GetDataTable(String.Format("Select Teacher from Orders Where CompanyID='{0}' And CustomerID='{1}' Group By Teacher", oCustomer.CompanyID, oCustomer.ID), "Teachers");

            //txtTeachers.SelectedIndex = -1;
                DataTable dt = oTeacher.GetAll();

                
                foreach (DataRow row in dt.Rows)
                {
                    ListItem oItem = new ListItem(row["Name"].ToString(), row["TeacherID"].ToString());
                    if (row["TeacherID"].ToString() == txtTeacherID.Value.ToString())
                    {
                        oItem.Selected = true;
                    }
                    txtTeachers.Items.Add(oItem);
                }
            
        }
        protected virtual void LoadStudents()
        {
            oTeacher.oMySql = oMySql;
            oTeacher.FindByName(txtTeachers.SelectedItem.Text);
            oStudent.oMySql = oMySql;
            oStudent.TeacherID = oTeacher._ID;

            DataTable dt = oStudent.GetAll();

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ListItem oItem = new ListItem(row["Name"].ToString(), row["StudentID"].ToString());
                    if (row["StudentID"].ToString() == txtStudentID.Value.ToString())
                        oItem.Selected = true;

                    txtStudents.Items.Add(oItem);
                }

            }
        }
        protected virtual void LoadOrder()
        {
                
            
                oStudent.Name = txtStudents.SelectedItem.Text;
                if (!oStudent.FindByName(txtStudents.SelectedItem.Text, oTeacher._ID))
                {
                    Orders.Controls.Clear();
                    butAddItem.Focus();
                    return;
                }


                
                Orders.Controls.Clear();
                DataTable dtTeachers = oStudent.GetOrders();
                if (dtTeachers != null)
                {
                    int i = 1;
                    Int32 nItems = 0;
                    Double nOrdered = 0;
                    Double nCollected = 0;
                    Double nCheckAmount = 0;
                    Orders.Controls.Add(new LiteralControl(@"<br><br><Table Border='1' Width='100%' >"));
                    if (dtTeachers.Rows.Count > 0)
                    {   
                        Orders.Controls.Add(new LiteralControl(@"<tr " + " bgcolor='" + row_color(i) + "'>"));
                        Orders.Controls.Add(new LiteralControl(@"<td width='95px'>"));
                        Orders.Controls.Add(new LiteralControl(@""));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td width='80px'>"));
                        Orders.Controls.Add(new LiteralControl(@"<b>Items</b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td width='80px'>"));
                        Orders.Controls.Add(new LiteralControl(@"<b>$ Ordered</b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td colspan='2' align='center' >"));
                        Orders.Controls.Add(new LiteralControl(@"<b>$ Turned In"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td width='200px'>"));
                        Orders.Controls.Add(new LiteralControl(@"<b>Notes</b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td >"));
                        Orders.Controls.Add(new LiteralControl(@""));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td colspan='3'>"));
                        Orders.Controls.Add(new LiteralControl(@""));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"</tr>"));

                        
                        Orders.Controls.Add(new LiteralControl(@"<tr " + " bgcolor='" + row_color(i) + "'>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@""));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"<b>Ordered</b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"<b></b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td width='80px'>"));
                        Orders.Controls.Add(new LiteralControl(@"<b>Cash</b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td width='80px' >"));
                        Orders.Controls.Add(new LiteralControl(@"<b> Check</b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td  width='80px' >"));
                        Orders.Controls.Add(new LiteralControl(@"<b></b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@""));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td colspan='3' >"));
                        Orders.Controls.Add(new LiteralControl(@""));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"</tr>"));
                        i++;
                    }

                    
                    short x = 20;
                    foreach (DataRow row in dtTeachers.Rows)
                    {
                        Label oName = new Label();
                     //   oName.Width = 120;
                        oName.Text = ((DateTime)row["Date"]).ToString("MM/dd/yyyy");

                        Label oItems = new Label();
                        //oItems.Width = 100;
                        oItems.Text = row["Nro_Items"].ToString();

                        Label oOrdered = new Label();
                        //oOrdered.Width = 100;
                        oOrdered.Text = "$ " + row["Retail"].ToString();

                        Label oCollected = new Label();
                        //oCollected.Width = 100;
                        oCollected.Text = "$ " + row["Collected"].ToString();

                        Label oCheckAmount = new Label();
                        //oCollected.Width = 100;
                        oCheckAmount.Text = "$ " + row["CheckAmount"].ToString();

                        Label oNotes = new Label();
                        //oCollected.Width = 100;
                        oNotes.Text = row["Notes"].ToString();

                        nOrdered += (Double)row["Retail"];
                        nItems += (Int32)row["Nro_Items"];
                        nCollected += (Double)row["Collected"];
                        nCheckAmount += (Double)row["CheckAmount"];

                        Button oButton_1 = new Button();
                        oButton_1.ID = "butd_" + row["OrderID"].ToString();
                        oButton_1.Width = 60;
                        oButton_1.Text = "Delete";
                        oButton_1.CommandArgument = row["OrderID"].ToString();
                        oButton_1.Click += new EventHandler(oButton_1_Click);
                        oButton_1.TabIndex = x++;


                        Button oButton_2 = new Button();
                        oButton_2.ID = "bute_" + row["OrderID"].ToString();
                        oButton_2.Click += new EventHandler(oButton_2_Click);
                        oButton_2.Width = 40;
                        oButton_2.CommandArgument = row["OrderID"].ToString();

                        if (txtValue.Value.ToString() == row["OrderID"].ToString() && txtAction.Value.ToString() == "Edit")
                        {
                            oButton_2.Text = "Save";
                            oButton_2.Attributes["onclick"] = "javascript:SetEditField('" + "Save" + "','" + row["OrderID"].ToString() + "');";
                        }
                        else
                        {
                            oButton_2.Text = "Edit";
                            oButton_2.Attributes["onclick"] = "javascript:SetEditField('" + "Edit" +"','" + row["OrderID"].ToString() + "');";
                        }


                        Orders.Controls.Add(new LiteralControl(@"<tr" + " bgcolor='" + row_color(i) + "'>"));

                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oName);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));

                        
                        //Orders.Controls.Add(oItems);

                        if (txtValue.Value.ToString() == row["OrderID"].ToString() && txtAction.Value.ToString()=="Edit")
                        {
                            Orders.Controls.Add(new LiteralControl(@"<td>"));
                            TextBox oItemsEdit = new TextBox();
                            oItemsEdit.ID = "txtItemsEdit";
                            oItemsEdit.Width = 80;
                            oItemsEdit.Text = row["Nro_Items"].ToString();
                            Orders.Controls.Add(oItemsEdit);
                            tbItems = oItemsEdit;
                            Orders.Controls.Add(new LiteralControl(@"</td>"));

                            Orders.Controls.Add(new LiteralControl(@"<td>"));
                            oItemsEdit = new TextBox();
                            oItemsEdit.ID = "txtOrderedEdit";
                            oItemsEdit.Width = 80;
                            oItemsEdit.Text = row["Retail"].ToString();
                            Orders.Controls.Add(oItemsEdit);
                            tbOrdered = oItemsEdit;
                            Orders.Controls.Add(new LiteralControl(@"</td>"));

                            Orders.Controls.Add(new LiteralControl(@"<td>"));
                            oItemsEdit = new TextBox();
                            oItemsEdit.ID = "txtTurnedInEdit";
                            oItemsEdit.Width = 80;
                            oItemsEdit.Text = row["Collected"].ToString();
                            Orders.Controls.Add(oItemsEdit);
                            tbTurnedIn = oItemsEdit;
                            Orders.Controls.Add(new LiteralControl(@"</td>"));

                            Orders.Controls.Add(new LiteralControl(@"<td>"));
                            oItemsEdit = new TextBox();
                            oItemsEdit.ID = "txtCheckAmountEdit";
                            oItemsEdit.Width = 80;
                            oItemsEdit.Text = row["CheckAmount"].ToString();
                            Orders.Controls.Add(oItemsEdit);
                            tbCheckIn = oItemsEdit;
                            Orders.Controls.Add(new LiteralControl(@"</td>"));

                            Orders.Controls.Add(new LiteralControl(@"<td>"));
                            oItemsEdit = new TextBox();
                            oItemsEdit.ID = "txtNotesEdit";
                            oItemsEdit.Width = 200;
                            oItemsEdit.Text = row["Notes"].ToString();
                            Orders.Controls.Add(oItemsEdit);
                            tbNotes = oItemsEdit;
                            Orders.Controls.Add(new LiteralControl(@"</td>"));


                        }
                        else
                        {
                            Orders.Controls.Add(new LiteralControl(@"<td>"));
                            Orders.Controls.Add(oItems);
                            Orders.Controls.Add(new LiteralControl(@"</td>"));

                            Orders.Controls.Add(new LiteralControl(@"<td>"));
                            Orders.Controls.Add(oOrdered);
                            Orders.Controls.Add(new LiteralControl(@"</td>"));

                            Orders.Controls.Add(new LiteralControl(@"<td>"));
                            Orders.Controls.Add(oCollected);
                            Orders.Controls.Add(new LiteralControl(@"</td>"));

                            Orders.Controls.Add(new LiteralControl(@"<td>"));
                            Orders.Controls.Add(oCheckAmount);
                            Orders.Controls.Add(new LiteralControl(@"</td>"));

                            Orders.Controls.Add(new LiteralControl(@"<td>"));
                            Orders.Controls.Add(oNotes);
                            Orders.Controls.Add(new LiteralControl(@"</td>"));
                        }
                          
                        

                        

                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@""));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));

                        
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oButton_2);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));

                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"&nbsp;"));
                        Orders.Controls.Add(new LiteralControl(@"&nbsp;"));
                        Orders.Controls.Add(new LiteralControl(@"&nbsp;"));
                        Orders.Controls.Add(new LiteralControl(@"&nbsp;"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oButton_1);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));



                        Orders.Controls.Add(new LiteralControl(@"</tr>"));
                        //  Orders.Controls.Add(new LiteralControl(@"<BR>"));

                        i++;
                    }
                    Label oItems1 = new Label();
                   // oItems1.Width = 100;
                    oItems1.Text = nItems.ToString();
                    oItems1.Font.Bold = true;

                    Label oName1 = new Label();
                    //oName1.Width = 200;
                    oName1.Text = "Total:";
                    oName1.Font.Bold = true;

                    Label oName2 = new Label();
                    //oName1.Width = 200;
                    oName2.Text = "Amount Due:";
                    oName2.Font.Bold = true;

                    Label oOrdered1 = new Label();
                   // oOrdered1.Width = 100;
                    oOrdered1.Text = "$ " + nOrdered.ToString();
                    oOrdered1.Font.Bold = true;

                    Label oCollected1 = new Label();
                   // oCollected1.Width = 100;
                    oCollected1.Text = "$ " + nCollected.ToString();
                    oCollected1.Font.Bold = true;

                    Label oCheckAmount1 = new Label();
                    // oCollected1.Width = 100;
                    oCheckAmount1.Text = "$ " + nCheckAmount.ToString();
                    oCheckAmount1.Font.Bold = true;

                    Label oDiff = new Label();
                   // oDiff.Width = 100;
                    oDiff.Text = "$ " + (nOrdered - (nCollected+nCheckAmount)).ToString();
                    oDiff.Font.Bold = true;

                    if (dtTeachers.Rows.Count > 0)
                    {

                        Orders.Controls.Add(new LiteralControl(@"<tr>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oName1);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oItems1);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oOrdered1);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oCollected1);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oCheckAmount1);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"</tr>"));

                        Orders.Controls.Add(new LiteralControl(@"<tr>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oName2);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oDiff);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"</tr>"));

                        //Orders.Controls.Add(new LiteralControl(@"<BR>"));
                        Orders.Controls.Add(new LiteralControl(@"</Table><br><br>"));
                    }
                }
                else
                {
                    Orders.Controls.Clear();
                   // this.Page.Response.Redirect("frmOrderByDate.aspx");
                }
                if (txtAction.Value.ToString() == "Edit")
                    tbItems.Focus();
                else
                    txtQuantity.Focus();
                   // butAddItem.Focus();
            
            
        }

        void oButton_1_Click(object sender, EventArgs e)
        {
            if (oOrder == null)
                oOrder = new Order(oCustomer.CompanyID,oMySql);

            
                if (oOrder.Find(Convert.ToInt32(((Button)sender).CommandArgument)))
                    oOrder.Delete();

                LoadOrder();
                labDescription.ForeColor = System.Drawing.Color.Red;
                labDescription.Text = " Order " + ((Button)sender).CommandArgument + " Deleted!!!!";
                butAddItem.Focus();
                DeleteFirstItem();
        }
        void oButton_2_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "Edit")
         //   if (txtAction.Value.ToString()=="Save")
            {
               // using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
                try
                {
                    oOrder.oMySql = oMySql;
                    oOrder.Find(Convert.ToInt32(((Button)sender).CommandArgument));
                    oOrder.NoItems = Convert.ToInt32(txtQuantity.Text);
                    oOrder.Retail = Convert.ToDouble(txtOrdered.Text);
                    oOrder.Collected = Convert.ToDouble(txtTurnedIn.Text);
                    oOrder.CheckAmount = txtCheckAmount.Text.Length == 0 ? 0 : Convert.ToDouble(txtCheckAmount.Text);
                    oOrder.Notes = txtNotes.Text;
                    oOrder.Update();
                    txtQuantity.Text = "";
                    txtOrdered.Text = "";
                    txtTurnedIn.Text = "";
                    txtCheckAmount.Text = "";
                    txtNotes.Text = "";

                }
                catch (Exception ex)
                {
                    String Message = ex.Message;
                    labDescription.ForeColor = System.Drawing.Color.Red;
                    labDescription.Text = " Wrong value fields...try again";
                    txtQuantity.Text = "";
                    txtOrdered.Text = "";
                    txtTurnedIn.Text = "";
                    txtCheckAmount.Text = "";
                    txtNotes.Text = "";
                }

                LoadOrder();
            }
            DeleteFirstItem();
        }
        protected void butAddItem_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Value.ToString() != "-1" && txtTeacherID.Value.ToString() != "-1")
            {
                if (Session["CustomerID"] != null && txtDate.Value != null && (txtQuantity.Text.Length > 0 || txtTurnedIn.Text.Length > 0))
                {
                    
                        
                        oOrder.CustomerID = oCustomer.ID;

                        oOrder.ID = "0";
                        oCustomer = (Customer)Session["Customer"];
                        //   labDescription.Text = Students.DisplayValue;
                        oOrder.Teacher = txtTeachers.SelectedItem.Text;
                        oOrder.Student = txtStudents.SelectedItem.Text;

                        oTeacher.FindByName(oOrder.Teacher);
                        oStudent.FindByName(oOrder.Student, oTeacher._ID);
                        if (oStudent.StudentID == 0)
                        {
                            LoadOrder();
                            DeleteFirstItem();
                            return;
                        }
                    try
                        {

                            oOrder.TeacherID = oTeacher._ID;
                            oOrder.StudentID = oStudent.StudentID;
                            oOrder.Date = Convert.ToDateTime(txtDate.Text);
                            oOrder.NoItems = txtQuantity.Text.Length == 0 ? 0 : Convert.ToInt32(txtQuantity.Text);
                            oOrder.Retail = txtOrdered.Text.Length == 0 ? 0 : Convert.ToDouble(txtOrdered.Text);
                            oOrder.Collected = txtTurnedIn.Text.Length == 0 ? 0 : Convert.ToDouble(txtTurnedIn.Text);
                            oOrder.CheckAmount = txtCheckAmount.Text.Length == 0 ? 0 : Convert.ToDouble(txtCheckAmount.Text);
                            oOrder.Notes = txtNotes.Text;
                            oOrder.Save(OrderType.CampaignSoftware);
                        
                        txtQuantity.Text = "";
                        txtOrdered.Text = "";
                        txtTurnedIn.Text = "";
                        txtCheckAmount.Text = "";
                        txtNotes.Text = "";
                        }
                        catch (Exception ex)
                        {
                            String Message = ex.Message;
                        }
                    }
            }
            LoadOrder();
            DeleteFirstItem();
        }
        protected void txtTeachers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void txtStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        
        protected String row_color(Int32 row)
        {
            String bg1 = "#EEEEEE"; // color one     
            String bg2 = "#DDDDDD"; // color two 

            Int32 rest = 0;
            Math.DivRem(row, 2, out rest);
            if (rest == 0)
                return bg1;
            else
                return bg2;

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

            window.setInterval('Reconnect()'," + int_MilliSecondsTimeOut.ToString() + @"); 

        </script>

";

            this.Page.RegisterClientScriptBlock("Reconnect", str_Script);

        }
        private void DeleteFirstItem()
        {
            if (txtTeachers.Items[0].Value.ToString() == "-1")
                txtTeachers.Items.RemoveAt(0);
            if (txtStudents.Items[0].Value.ToString() == "-1")
                txtStudents.Items.RemoveAt(0);
        }
 

        
    }
}
