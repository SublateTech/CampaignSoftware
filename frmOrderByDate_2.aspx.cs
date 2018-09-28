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
using Infragistics.WebUI.UltraWebGrid;

namespace Signature.Campaign
{
    public partial class frmOrderByDate_2 : System.Web.UI.Page
    {
        Customer oCustomer;
        Order oOrder;
        Teacher oTeacher;
        Student oStudent;

        private void Page_Load(object sender, System.EventArgs e)
        {
         //   this.warpGrid.AddLinkedRequestTrigger("butAddItem");
            
            if (Session["Customer"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                oCustomer = (Customer)(Session["Customer"]);
                oTeacher = new Teacher(oCustomer.CompanyID, oCustomer.ID);
                oStudent = new Student(oCustomer.CompanyID, oCustomer.ID);
                txtName.Text = oCustomer.Name;
            }

            if (Session["Order"] != null)
            {
                oOrder = (Order)Session["Order"];
                oOrder.oCustomer = oCustomer;
                oOrder.CustomerID = oCustomer.ID;

                
            }
            else
            {
                oOrder = null;
            }
            
            //if(warpGrid.IsAsyncPostBack

            

            if (!warpAddItem.IsAsyncPostBack && !warpStudents.IsAsyncPostBack)
            {
                
            }

            LoadTeachers();   
        }
        
        protected virtual void LoadTeachers()
        {
            oCustomer = (Customer)(Session["Customer"]);
           // DataTable dt = Global.oMySql.GetDataTable(String.Format("Select Teacher from Orders Where CompanyID='{0}' And CustomerID='{1}' Group By Teacher", oCustomer.CompanyID, oCustomer.ID), "Teachers");
            DataTable dt = oTeacher.GetAll();
            
            foreach (DataRow row in dt.Rows)
            {
                UltraGridRow _row = new UltraGridRow();
                _row.Cells.Add(new UltraGridCell(row["Name"].ToString()));
                Teachers.Rows.Add(_row);
            }

            if (Session["T_Index"] != null && (Int32)Session["T_Index"] != -1)
            {
                Teachers.SelectedIndex = (Int32)Session["T_Index"];
            }
        }
        protected virtual void LoadOrder()
        {
            if (oOrder != null)
            {
                oStudent.Name = Students.DisplayValue;
                //Grid.DataSource = oStudent.GetOrders(); //oOrder.Items.Table;
               // Grid.DataBind();


                DataTable dtTeachers = oStudent.GetOrders();
                if (dtTeachers != null)
                {
                    Orders.Controls.Add(new LiteralControl(@"<Table Border='0' Width='100%' >"));
                    foreach (DataRow row in dtTeachers.Rows)
                    {
                        Label oName = new Label();
                        oName.Width = 300;
                        oName.Text = row["Date"].ToString();

                        Label oItems = new Label();
                        oItems.Width = 100;
                        oItems.Text = row["Nro_Items"].ToString();


                        Button oButton_1 = new Button();
                        oButton_1.Click +=new EventHandler(oButton_1_Click); 
                        oButton_1.Width = 60;
                        oButton_1.Text = "Delete";
                        oButton_1.CommandArgument = row["OrderID"].ToString();
                        oButton_1.ID = "butd_" + row["OrderID"].ToString();

                        
                        Orders.Controls.Add(new LiteralControl(@"<tr>"));

                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oName);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));

                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oItems);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));

                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oButton_1);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));

                        

                        Orders.Controls.Add(new LiteralControl(@"</tr>"));
                        Orders.Controls.Add(new LiteralControl(@"<BR>"));

                        
                    }
                    Orders.Controls.Add(new LiteralControl(@"</Table>"));
                }

            }
            
        }

        void oButton_1_Click(object sender, EventArgs e)
        {
            labDescription.ForeColor = System.Drawing.Color.Blue;
            labDescription.Text = " New Order!!!!";
            LoadOrder();
        }
        protected virtual void LoadStudents()
        {
            
            
            oCustomer = (Customer)(Session["Customer"]);

            oTeacher.FindByName(Teachers.DisplayValue);
            oStudent.TeacherID = oTeacher._ID;
            
            //DataTable dt = Global.oMySql.GetDataTable(String.Format("Select Student from Orders Where CompanyID='{0}' And CustomerID='{1}' And Teacher='{2}' Group By Student", oCustomer.CompanyID, oCustomer.ID, Teachers.DisplayValue), "Student");

            DataTable dt = oStudent.GetAll();

            if (dt != null)
            {
                Students.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    UltraGridRow _row = new UltraGridRow();
                    _row.Cells.Add(new UltraGridCell(row["Name"].ToString()));
                    Students.Rows.Add(_row);
                }
                if (Session["S_Index"] != null) // && (Int32)Session["S_Index"] != -1)
                {
                    Students.SelectedIndex = (Int32)Session["S_Index"];
                }

            }
        }
        protected void Teachers_SelectedRowChanged(object sender, Infragistics.WebUI.WebCombo.SelectedRowChangedEventArgs e)
        {
            Session["T_Index"] = Teachers.SelectedIndex;
            LoadStudents();
            
        }
        protected void Students_SelectedRowChanged(object sender, Infragistics.WebUI.WebCombo.SelectedRowChangedEventArgs e)
        {
            
            
                Session["S_Index"] = Students.SelectedIndex;
                oCustomer = (Customer)(Session["Customer"]);
                
                if (Session["Order"] != null && oOrder.Student == Students.DisplayValue )
                {
                    return;
                }

                oOrder = new Order(oCustomer.CompanyID);
                oOrder.CustomerID = oCustomer.ID;
                if (oOrder.Find(Teachers.DisplayValue, Students.DisplayValue))
                {
                    
                    Session["Order"] = oOrder;
                    LoadOrder();
                }
            
        }
        protected void butAddItem_Click(object sender, EventArgs e)
        {
            if (Session["Customer"] != null && txtEarlyBirdDate.Value != null && txtQuantity.Text.Length>0)
            {
                oOrder.ID = "0";
                oCustomer = (Customer)Session["Customer"];
             //   labDescription.Text = Students.DisplayValue;
                oOrder.Teacher      = Teachers.DisplayValue;
                oOrder.Student      = Students.DisplayValue;
                oOrder.NoItems      = Convert.ToInt32(txtQuantity.Text);
                oOrder.Date         = Convert.ToDateTime(txtEarlyBirdDate.Value);
                oOrder.Save(OrderType.CampaignSoftware);

                //labTotals.ForeColor = System.Drawing.Color.Red;
                //labTotals.Text = " Order Saved!!!!";

            }
            LoadOrder();
        }
        protected void butSave_Click(object sender, EventArgs e)
        {
            oOrder.Teacher = Teachers.DisplayValue;
            oOrder.Student = Students.DisplayValue;
            oOrder.Save(OrderType.Giftco);
            
            
            Session["Order"] = null;
            oOrder.Items.Clear();
            LoadOrder();


           // labTotals.ForeColor = System.Drawing.Color.Red;
           // labTotals.Text =  " Order Saved!!!!";
            LoadTeachers();
            
            Session["S_Index"] = -1;
            Students.DisplayValue = "";
            LoadStudents();
        }
       
        protected void butDelete_Click(object sender, EventArgs e)
        {
            
        }
     
              
    }
}
