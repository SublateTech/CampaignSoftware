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
using Signature.Data;
using Infragistics.WebUI.UltraWebGrid;

namespace Signature.Campaign
{
    public partial class frmTeacher : System.Web.UI.Page
    {
        Customer oCustomer;
        Teacher oTeacher;
        
        
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
                using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
                {

                    oCustomer = new Customer(Session["CompanyID"].ToString(),oMySql);
                    oCustomer.Find(Session["CustomerID"].ToString());

                    oTeacher = new Teacher(oCustomer.CompanyID, oCustomer.ID,oMySql);
                    

                    //if (!this.IsPostBack)
                    {
                        //txtGoal.Text = oCustomer.Goal.ToString();
                        // txtEarlyBirdDate.Value = oCustomer.EarlyBirdDate.ToString("MM/dd/yyyy");
                        txtName.Text = oCustomer.Name;
                    }




                    DataTable dtStudents = oTeacher.GetAll();

                    if (dtStudents != null)
                    {
                        int i = 1;
                        foreach (DataRow row in dtStudents.Rows)
                        {
                            Label oName = new Label();
                            oName.Width = 400;
                            oName.Text = row["Name"].ToString();

                            Button oButton = new Button();
                            oButton.BorderStyle = BorderStyle.Solid;
                            oButton.Click += new EventHandler(oButton_Click);
                            oButton.Width = 60;
                            oButton.Text = "Students";
                            oButton.CommandArgument = row["TeacherID"].ToString();
                            oButton.ID = "but_" + row["TeacherID"].ToString();

                            Button oButton_1 = new Button();
                            oButton_1.Click += new EventHandler(oButton_1_Click);
                            oButton_1.Width = 50;
                            oButton_1.Text = "Delete";
                            oButton_1.CommandArgument = row["TeacherID"].ToString();
                            oButton_1.ID = "butd_" + row["TeacherID"].ToString();


                            Button oButton_2 = new Button();
                            oButton_2.Click += new EventHandler(oButton_2_Click);
                            oButton_2.Width = 50;
                            if (Page.Request["Edit"] != null && row["TeacherID"].ToString() == Page.Request["Edit"])
                            {
                                oButton_2.Text = "Save";
                                oButton_2.Attributes["onclick"] = "javascript:SetField();";
                            }
                            else
                                oButton_2.Text = "Edit";

                            oButton_2.CommandArgument = row["TeacherID"].ToString();
                            oButton_2.ID = "bute_" + row["TeacherID"].ToString();

                            Teachers.Controls.Add(new LiteralControl(@"<Table Border='0' Width='100%' >"));
                            Teachers.Controls.Add(new LiteralControl(@"<tr " + "bgcolor='" + row_color(i) + "'>"));

                            Teachers.Controls.Add(new LiteralControl(@"<td>"));
                            if (Page.Request["Edit"] != null && row["TeacherID"].ToString() == Page.Request["Edit"])
                            {
                                TextBox oNameEdit = new TextBox();
                                oNameEdit.ID = "txtNameEdit";
                                oNameEdit.Width = 400;
                                oNameEdit.Text = row["Name"].ToString();
                                Teachers.Controls.Add(oNameEdit);
                                oNameEdit.Focus();
                            }
                            else
                            {
                                Teachers.Controls.Add(oName);
                            }
                            Teachers.Controls.Add(new LiteralControl(@"</td>"));

                            Teachers.Controls.Add(new LiteralControl(@"<td>"));
                            Teachers.Controls.Add(oButton);
                            Teachers.Controls.Add(new LiteralControl(@"</td>"));
                            
                            Teachers.Controls.Add(new LiteralControl(@"<td>"));
                            Teachers.Controls.Add(oButton_2);
                            Teachers.Controls.Add(new LiteralControl(@"</td>"));
                            
                            Teachers.Controls.Add(new LiteralControl(@"<td>"));
                            Teachers.Controls.Add(new LiteralControl(@"&nbsp;"));
                            Teachers.Controls.Add(new LiteralControl(@"&nbsp;"));
                            Teachers.Controls.Add(new LiteralControl(@"&nbsp;"));
                            Teachers.Controls.Add(new LiteralControl(@"&nbsp;"));
                            Teachers.Controls.Add(new LiteralControl(@"</td>"));

                            Teachers.Controls.Add(new LiteralControl(@"<td>"));
                            Teachers.Controls.Add(oButton_1);
                            Teachers.Controls.Add(new LiteralControl(@"</td>"));


                            

                            Teachers.Controls.Add(new LiteralControl(@"</tr>"));

                            Teachers.Controls.Add(new LiteralControl(@"</Table>"));

                            i++;
                        }
                        Teachers.Controls.Add(new LiteralControl(@"<BR>"));
                    }

                    /*
                    TextBox oTextBox = new TextBox();

                    for (int x = 1; x < 10; x++)
                    {
                        Teachers.Controls.Add(new TextBox());
                        Button oButton = new Button();
                        oButton.Click += new EventHandler(oButton_Click);
                        oButton.ID = "but_" + x.ToString();
                        Teachers.Controls.Add(oButton);
                        Teachers.Controls.Add(new Button());
                        Teachers.Controls.Add(new LiteralControl(@"<BR>"));
                    }
                    */
                }
            }

        }

        void oButton_1_Click(object sender, EventArgs e)
        {
            /*
            TextBox oTextBox = new TextBox();
            oTextBox.Text = ((Button)sender).CommandArgument;
            Teachers.Controls.Add(oTextBox);
            */

            using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
            {
                oTeacher._ID = Convert.ToInt32(((Button)sender).CommandArgument);
                oTeacher.oMySql = oMySql;
                oTeacher.Delete();
            }
                this.Page.Response.Redirect("frmTeacher.aspx");
            
        }

        void oButton_Click(object sender, EventArgs e) //Students Button
        {
            /*
            TextBox oTextBox = new TextBox();
            oTextBox.Text = ((Button)sender).CommandArgument;
            Teachers.Controls.Add(oTextBox);
             */
            Session["TeacherID"] =  ((Button)sender).CommandArgument;
            this.Page.Response.Redirect("frmStudent.aspx");
        }
        void oButton_2_Click(object sender, EventArgs e)
        {
            /*
            TextBox oTextBox = new TextBox();
            oTextBox.Text = ((Button)sender).ID;
            Teachers.Controls.Add(oTextBox);
            */
            /*
            
            */
            if (((Button)sender).Text == "Edit")
                this.Page.Response.Redirect("frmTeacher.aspx?Edit=" + ((Button)sender).CommandArgument);
            else
            {
                using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
                {
                    oTeacher.oMySql = oMySql;
                    oTeacher.Find(Convert.ToInt32(((Button)sender).CommandArgument));
                    oTeacher.Name = txtTName.Value;
                    oTeacher.Update();
                }
                this.Page.Response.Redirect("frmTeacher.aspx");
            }

        }

        protected void butSave_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                MySQL oMySql = new MySQL(ConnectionType.NonUnique);
                
                    oTeacher.oMySql = oMySql;

                    if (!oTeacher.FindByName(txtTeacherName.Text) && txtTeacherName.Text.Length > 0)
                    {
                        oTeacher.Name = txtTeacherName.Text;
                        oTeacher.Save();
                        oMySql.Dispose();
                        this.Page.Response.Redirect("frmTeacher.aspx");
                    }
                

            }
        }

        		// Displays alternate table row colors 
		protected String row_color(Int32 row)
			{ 
			    String bg1 = "#EEEEEE"; // color one     
			    String bg2 = "#DDDDDD"; // color two 

                Int32 rest = 0;
                Math.DivRem(row,2, out rest );
				if ( rest == 0 )  
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

        protected void butImport_Excel(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("frmExcel.aspx");
        }
              
    }
}
