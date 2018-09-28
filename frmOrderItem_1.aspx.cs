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
    public partial class frmOrderItem_1 : System.Web.UI.Page
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
            else
            {
                this.AddKeepAlive();
                using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
                {

                    oCustomer = new Customer(Session["CompanyID"].ToString());
                    oCustomer.oMySql = oMySql;
                    oCustomer.Find(Session["CustomerID"].ToString());
                    oTeacher = new Teacher(oCustomer.CompanyID, oCustomer.ID);
                    oTeacher.oMySql = oMySql;
                    oStudent = new Student(oCustomer.CompanyID, oCustomer.ID);
                    oStudent.oMySql = oMySql;
                    oOrder = new Order(oCustomer.CompanyID);
                    oOrder.oMySql = oMySql;
                    txtName.Text = oCustomer.Name;

                    LoadTeachers();
                    if (Session["T_Index"] != null)
                    {
                        LoadStudents();
                    }
                    if (Session["S_Index"] != null)
                    {
                        //   LoadOrder();
                    }

                    if (!IsPostBack)
                        txtDate.Value = DateTime.Today;
                }
            }
        }
        
        protected virtual void LoadTeachers()
        {
          //  oCustomer = (Customer)(Session["Customer"]);
           // DataTable dt = Global.oMySql.GetDataTable(String.Format("Select Teacher from Orders Where CompanyID='{0}' And CustomerID='{1}' Group By Teacher", oCustomer.CompanyID, oCustomer.ID), "Teachers");
            using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
            {
                oTeacher.oMySql = oMySql;
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
        }
        protected virtual void LoadOrder1()
        {
            using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
            {
                oStudent.oMySql = oMySql;
                oStudent.Name = Students.DisplayValue;
                //Grid.DataSource = oStudent.GetOrders(); //oOrder.Items.Table;
                // Grid.DataBind();

                oStudent.FindByName(Students.DisplayValue, oTeacher._ID);
                
                Orders.Controls.Clear();
                DataTable dtTeachers = oStudent.GetOrders();
                if (dtTeachers != null)
                {
                    int i = 1;
                    Int32 nItems = 0;
                    Double nOrdered = 0;
                    Double nCollected = 0;
                    Orders.Controls.Add(new LiteralControl(@"<br><br><Table Border='1' Width='100%' >"));
                    if (dtTeachers.Rows.Count > 0)
                    {
                        Orders.Controls.Add(new LiteralControl(@"<tr " + " bgcolor='" + row_color(i) + "'>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@""));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"<b>Items<br>Ordered</b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"<b>$ Ordered</b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"<b>$Collected<br> from Student</b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@"<b>$ Amount<br>Due</b>"));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(new LiteralControl(@""));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));
                        Orders.Controls.Add(new LiteralControl(@"</tr>"));
                        i++;
                    }

                    foreach (DataRow row in dtTeachers.Rows)
                    {
                        Label oName = new Label();
                        oName.Width = 200;
                        oName.Text = ((DateTime)row["Date"]).ToString("MM/dd/yyyy");

                        Label oItems = new Label();
                        oItems.Width = 100;
                        oItems.Text = row["Nro_Items"].ToString();

                        Label oOrdered = new Label();
                        oOrdered.Width = 100;
                        oOrdered.Text = "$ " + row["Retail"].ToString();

                        Label oCollected = new Label();
                        oCollected.Width = 100;
                        oCollected.Text = "$ " + row["Collected"].ToString();

                        nOrdered += (Double)row["Retail"];
                        nItems += (Int32)row["Nro_Items"];
                        nCollected += (Double)row["Collected"];

                        Button oButton_1 = new Button();
                        oButton_1.Click += new EventHandler(oButton_1_Click);
                        oButton_1.Width = 60;
                        oButton_1.Text = "Delete";
                        oButton_1.CommandArgument = row["OrderID"].ToString();
                        oButton_1.ID = "butd_" + row["OrderID"].ToString();


                        Orders.Controls.Add(new LiteralControl(@"<tr" + " bgcolor='" + row_color(i) + "'>"));

                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oName);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));

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
                        Orders.Controls.Add(new LiteralControl(@""));
                        Orders.Controls.Add(new LiteralControl(@"</td>"));

                        Orders.Controls.Add(new LiteralControl(@"<td>"));
                        Orders.Controls.Add(oButton_1);
                        Orders.Controls.Add(new LiteralControl(@"</td>"));



                        Orders.Controls.Add(new LiteralControl(@"</tr>"));
                        //  Orders.Controls.Add(new LiteralControl(@"<BR>"));

                        i++;
                    }
                    Label oItems1 = new Label();
                    oItems1.Width = 100;
                    oItems1.Text = nItems.ToString();
                    oItems1.Font.Bold = true;

                    Label oName1 = new Label();
                    oName1.Width = 200;
                    oName1.Text = "Total:";
                    oName1.Font.Bold = true;

                    Label oOrdered1 = new Label();
                    oOrdered1.Width = 100;
                    oOrdered1.Text = "$ " + nOrdered.ToString();
                    oOrdered1.Font.Bold = true;

                    Label oCollected1 = new Label();
                    oCollected1.Width = 100;
                    oCollected1.Text = "$ " + nCollected.ToString();
                    oCollected1.Font.Bold = true;

                    Label oDiff = new Label();
                    oDiff.Width = 100;
                    oDiff.Text = "$ " + (nOrdered - nCollected).ToString();
                    oDiff.Font.Bold = true;

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
                    Orders.Controls.Add(oDiff);
                    Orders.Controls.Add(new LiteralControl(@"</td>"));
                    Orders.Controls.Add(new LiteralControl(@"</tr>"));
                    //Orders.Controls.Add(new LiteralControl(@"<BR>"));
                    Orders.Controls.Add(new LiteralControl(@"</Table><br><br>"));
                }
                else
                {
                    Orders.Controls.Clear();
                    Session["S_Index"] = null;
                    this.Page.Response.Redirect("frmOrderItem.aspx");
                }
            }
            
        }
        protected virtual void LoadOrder()
        {
            if (oOrder != null)
            {
                txtItems.DataSource = oOrder.Items.Table;
                txtItems.DataBind();
            }
            else
            {
                txtItems.DataSource = null;
                txtItems.DataBind();
            }
        }

        void oButton_1_Click(object sender, EventArgs e)
        {
            if (oOrder == null)
                oOrder = new Order(oCustomer.CompanyID);

            using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
            {
                oOrder.oMySql = oMySql;
                if (oOrder.Find(Convert.ToInt32(((Button)sender).CommandArgument)))
                    oOrder.Delete();

                LoadOrder();
                labDescription.ForeColor = System.Drawing.Color.Red;
                labDescription.Text = " Order " + ((Button)sender).CommandArgument + " Deleted!!!!";
            }
        }
        protected virtual void LoadStudents()
        {
            
            
       //     oCustomer = (Customer)(Session["Customer"]);
            using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
            {
                oTeacher.oMySql = oMySql;
                oTeacher.FindByName(Teachers.DisplayValue);
                oStudent.oMySql = oMySql;
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
                        LoadOrder();
                    }

                }
            }
        }
        protected void Teachers_SelectedRowChanged(object sender, Infragistics.WebUI.WebCombo.SelectedRowChangedEventArgs e)
        {
            Session["T_Index"] = Teachers.SelectedIndex;
            Session["S_Index"] = null;
            LoadStudents();
            this.Page.Response.Redirect("frmOrderItem.aspx");
        }
        protected void Students_SelectedRowChanged(object sender, Infragistics.WebUI.WebCombo.SelectedRowChangedEventArgs e)
        {
            
            
                Session["S_Index"] = Students.SelectedIndex;
                //oCustomer = (Customer)(Session["Customer"]);
                
                LoadOrder();
        }
        protected void butMoney_Click(object sender, EventArgs e)
        {
            if (Session["CustomerID"] != null && txtDate.Value != null && ( txtQuantity.Text.Length > 0 || txtTurnedIn.Text.Length >0))
            {
                using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
                {
                  //  oOrder = new Order(oCustomer.CompanyID);
                    oOrder.oMySql = oMySql;
                    oOrder.CustomerID = oCustomer.ID;

                    oOrder.ID = "0";
                    oCustomer = (Customer)Session["Customer"];
                    //   labDescription.Text = Students.DisplayValue;
                    oOrder.Teacher = Teachers.DisplayValue;
                    oOrder.Student = Students.DisplayValue;

                    oTeacher.FindByName(oOrder.Teacher);
                    oStudent.FindByName(oOrder.Student, oTeacher._ID);

                    oOrder.TeacherID = oTeacher._ID;
                    oOrder.StudentID = oStudent.StudentID;
                    oOrder.Date = Convert.ToDateTime(txtDate.Text);
                    oOrder.NoItems = txtQuantity.Text.Length == 0 ? 0 : Convert.ToInt32(txtQuantity.Text);
                    oOrder.Retail = txtOrdered.Text.Length == 0 ? 0 : Convert.ToDouble(txtOrdered.Text);
                    oOrder.Collected = txtTurnedIn.Text.Length == 0 ? 0 : Convert.ToDouble(txtTurnedIn.Text);
                    oOrder.Save(OrderType.CampaignSoftware);

                    txtQuantity.Text = "";
                    txtOrdered.Text = "";
                    txtTurnedIn.Text = "";
                }
            }
            LoadOrder();
        }
        protected void butSave_Click(object sender, EventArgs e)
        {
            using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
            {
                oOrder.oMySql = oMySql;
                oOrder.Teacher = Teachers.DisplayValue;
                oOrder.Student = Students.DisplayValue;
                oOrder.Save(OrderType.Giftco);


                Session["Order"] = null;
                oOrder.Items.Clear();
                LoadOrder();
            }

           // labTotals.ForeColor = System.Drawing.Color.Red;
           // labTotals.Text =  " Order Saved!!!!";
            LoadTeachers();
            
            Session["S_Index"] = -1;
            Students.DisplayValue = "";
            LoadStudents();
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
        protected void butAddItem_Click(object sender, EventArgs e)
        {
            if (Session["CustomerID"] != null)
            {

                using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
                {
                    oCustomer.oMySql = oMySql;
                    oCustomer.Find(Session["CustomerID"].ToString()); //(Customer)Session["Customer"];
                    Product oProduct = new Product(oCustomer.CompanyID, oCustomer.oMySql);
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
        }
    }
}
