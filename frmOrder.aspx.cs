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
using Signature.Data;

namespace Signature.Campaign
{
    public partial class frmOrder : System.Web.UI.Page
    {
        Customer oCustomer;
        Order oOrder;
        Teacher oTeacher;
        Student oStudent;

        private void Page_Load(object sender, System.EventArgs e)
        {
         //   this.warpGrid.AddLinkedRequestTrigger("butAddItem");

             Session["CompanyID"] = "__S10";
             Session["CustomerID"] = "10503";

            if (Session["CustomerID"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
            {

                oCustomer = new Customer(Session["CompanyID"].ToString());
                oCustomer.oMySql = oMySql;
                if (!oCustomer.Find(Session["CustomerID"].ToString()))
                    return;

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
                //Grid.DataSource = oOrder.Items.Table;
                //Grid.DataBind();
            }
            else
            {
                //Grid.DataSource = null;
                //Grid.DataBind();
            }
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
        protected void AddItem(Order oOrder, Product oProduct, Int32 Quantity)
        {
            if (oOrder.Items.Contains(oProduct.ID))
            {
                oOrder.Items[oProduct.ID].Quantity += Quantity;
            }
            else
            {
                Order.Item oItem = new Order.Item(oOrder.oMySql);
                oItem.ProductID = oProduct.ID;
                oItem.Quantity = Quantity;
                oItem.Price = oProduct.ExtendedPrice(oCustomer);
                oItem.Description = oProduct.Description;
                oItem.PackID = oOrder.oProduct.PackID(oCustomer);

                oOrder.Items.Add(oProduct.ID, oItem);
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
            if (Session["Customer"] != null)
            {
                oCustomer = (Customer)Session["Customer"];
                Product oProduct = new Product(oCustomer.CompanyID,oCustomer.oMySql);
                if (oProduct.Find(txtProductID.Text))
                {
                    labDescription.Text = "Description : " + oProduct.Description + "   Price : " + oProduct.ExtendedPrice(oCustomer).ToString();
                    if (txtQuantity.Text == "")
                    {
                        txtQuantity.Focus();
                    }
                    else
                    {
                        if (Session["Order"] == null)
                        {
                            if (oOrder == null)
                            {
                                oOrder = new Order(oCustomer.CompanyID);
                                oOrder.CustomerID = oCustomer.ID;
                                oOrder.Teacher = Teachers.DisplayValue;
                                oOrder.Student = Students.DisplayValue;
                            }
                        }
                        AddItem(oOrder, oProduct, Convert.ToInt32(txtQuantity.Text));
                        oOrder.GetTotals();
                        Session["Order"] = oOrder;
                        labTotals.ForeColor = System.Drawing.Color.Black;
                        labTotals.Text = "Total: " + oOrder.Retail.ToString() + "<br />";
                        labTotals.Text += "# Items: " + oOrder.NoItems.ToString() + "<br />";
                        labTotals.Text += "Prize: " + oOrder.PrizeID + "<br />";
                        LoadOrder();
                    }
                }
                else
                {
                    LoadOrder();
                    txtProductID.Focus();
                }
            }
        }
        protected void butSave_Click(object sender, EventArgs e)
        {
            oOrder.Teacher = Teachers.DisplayValue;
            oOrder.Student = Students.DisplayValue;
            oOrder.Save(OrderType.Giftco);
            
            
            Session["Order"] = null;
            oOrder.Items.Clear();
            LoadOrder();


            labTotals.ForeColor = System.Drawing.Color.Red;
            labTotals.Text =  " Order Saved!!!!";
            LoadTeachers();
            
            Session["S_Index"] = -1;
            Students.DisplayValue = "";
            LoadStudents();
        }
        protected void butNew_Click(object sender, EventArgs e)
        {
            if (Session["Order"] != null)
            {
                Session["Order"] = null;
                oOrder.Items.Clear();
                LoadOrder();
            }

            labTotals.ForeColor = System.Drawing.Color.Blue;
            labTotals.Text = " New Order!!!!";
            LoadTeachers();

            Session["S_Index"] = -1;
            Students.DisplayValue = "";
            LoadStudents();
        }
        protected void butDelete_Click(object sender, EventArgs e)
        {
            if (Session["Order"] != null)
            {
                oOrder.Delete();
                Session["Order"] = null;
                oOrder.Items.Clear();
                LoadOrder();
            }

            labTotals.ForeColor = System.Drawing.Color.Red;
            labTotals.Text = " Order Deleted!!!!";
            LoadTeachers();

            Session["S_Index"] = -1;
            Students.DisplayValue = "";
            LoadStudents();
        }
        protected void Grid_UpdateCell(object sender, CellEventArgs e)
        {
            LoadOrder();
        }
              
    }
}
