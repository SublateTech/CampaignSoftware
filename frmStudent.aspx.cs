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
    public partial class frmStudent : System.Web.UI.Page
    {
        Customer oCustomer;
        Teacher oTeacher;
        Student oStudent;
        
        
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
                    oStudent = new Student(oCustomer.CompanyID, oCustomer.ID,oMySql);
                    

                    txtName.Text = oCustomer.Name;

                    String TeacherID = Session["TeacherID"].ToString();

                    if (oTeacher.Find(Convert.ToInt32(TeacherID)))
                    {
                        txtTeacherName.Text = oTeacher.Name;
                        if (!this.IsPostBack)
                            txtNoStudents.Text = oTeacher.NoStudents.ToString();
                    }

                    oStudent.TeacherID = Convert.ToInt32(TeacherID);

                    DataTable dtStudents = oStudent.GetAll();

                    if (dtStudents != null)
                    {
                        Int16 i = 1;
                        foreach (DataRow row in dtStudents.Rows)
                        {
                            

                            Label oName = new Label();
                            oName.Width = 500;
                            oName.Text = row["Name"].ToString();
                            
                            Button oButton = new Button();
                            oButton.Click += new EventHandler(oButton_Click);
                            oButton.Width = 60;
                            oButton.Text = "Students";
                            oButton.CommandArgument = row["StudentID"].ToString();
                            oButton.ID = "but_" + row["StudentID"].ToString();

                            Button oButton_1 = new Button();
                            oButton_1.Click += new EventHandler(oButton_1_Click);
                            oButton_1.Width = 60;
                            oButton_1.Text = "Delete";
                            oButton_1.CommandArgument = row["StudentID"].ToString();
                            oButton_1.ID = "butd_"  + row["StudentID"].ToString();

                            Button oButton_2 = new Button();
                            oButton_2.Click += new EventHandler(oButton_2_Click);
                            oButton_2.Width = 60;
                            if (Page.Request["Edit"] != null && row["StudentID"].ToString() == Page.Request["Edit"])
                            {
                                oButton_2.Text = "Save";
                                oButton_2.Attributes["onclick"] = "javascript:SetField();";
                            }
                            else
                                oButton_2.Text = "Edit";

                            
                            oButton_2.CommandArgument = row["StudentID"].ToString();
                            oButton_2.ID = "bute_" + row["StudentID"].ToString();

                            Teachers.Controls.Add(new LiteralControl(@"<Table Border='0' Width='200px' >"));

                            Teachers.Controls.Add(new LiteralControl(@"<tr " + "bgcolor='" + row_color(i) + "'>"));

                            Teachers.Controls.Add(new LiteralControl(@"<td>"));

                            if (Page.Request["Edit"] != null && row["StudentID"].ToString() == Page.Request["Edit"])
                            {
                                TextBox oNameEdit = new TextBox();
                                oNameEdit.ID = "txtNameEdit";
                                oNameEdit.Width = 500;
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
                            Teachers.Controls.Add(oButton_2);
                            Teachers.Controls.Add(new LiteralControl(@"</td>"));
                            
                            Teachers.Controls.Add(new LiteralControl(@"<td>"));
                            Teachers.Controls.Add(oButton_1);
                            Teachers.Controls.Add(new LiteralControl(@"</td>"));
                            /*
                            Teachers.Controls.Add(new LiteralControl(@"<td>"));
                            Teachers.Controls.Add(oButton);
                            Teachers.Controls.Add(new LiteralControl(@"</td>"));
                            */
                            Teachers.Controls.Add(new LiteralControl(@"</tr>"));


                            Teachers.Controls.Add(new LiteralControl(@"</Table>"));

                            i++;
                        }
                        Teachers.Controls.Add(new LiteralControl(@"<BR>"));
                        Teachers.Controls.Add(new LiteralControl(@"<BR>"));
                    }
                }
            }
            if (Page.Request["Edit"] == null)
                txtStudentName.Focus();

        }

        void oButton_1_Click(object sender, EventArgs e)
        {
            /*
            TextBox oTextBox = new TextBox();
            oTextBox.Text = ((Button)sender).ID;
            Teachers.Controls.Add(oTextBox);
            */
            using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
            {
                oStudent.oMySql = oMySql;
                oStudent.StudentID = Convert.ToInt32(((Button)sender).CommandArgument);
                oStudent.Delete();
            }
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
                this.Page.Response.Redirect("frmStudent.aspx?Edit=" + ((Button)sender).CommandArgument);
            else
            {
                using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
                {
                    oStudent.oMySql = oMySql;
                    oStudent.Find(Convert.ToInt32(((Button)sender).CommandArgument));
                    oStudent.Name = txtSName.Value;
                    oStudent.Update();
                }
                this.Page.Response.Redirect("frmStudent.aspx");
            }

        }

        

        void oButton_Click(object sender, EventArgs e)
        {
            TextBox oTextBox = new TextBox();
            oTextBox.Text = ((Button) sender).CommandArgument;
            Teachers.Controls.Add(oTextBox);
        }

        protected void butSave_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                MySQL oMySql = new MySQL(ConnectionType.NonUnique);
                oStudent.oMySql = oMySql;
                if (!oStudent.FindByName(txtStudentName.Text, oTeacher._ID) && txtStudentName.Text.Length > 0)
                {
                    oStudent.Name = txtStudentName.Text;
                    oStudent.Save();
                    oMySql.Dispose();
                    this.Page.Response.Redirect("frmStudent.aspx");
                }
                oMySql.Dispose();
            }
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

        protected void butBack_Click(object sender, EventArgs e)
        {
            this.Page.Response.Redirect("frmTeacher.aspx");
        }

        protected void butApply_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (txtNoStudents.Text.Trim() == "")
                    txtNoStudents.Text = "0";
            //    if (oTeacher.Find(Convert.ToInt32(Session["TeacherID"].ToString())))
                {
                    using (MySQL oMySql = new MySQL(ConnectionType.NonUnique))
                    {
                        oTeacher.oMySql = oMySql;
                        oTeacher.NoStudents = Convert.ToInt32(txtNoStudents.Text);
                        oTeacher.Save();
                    }
                }
            }
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
    }
}
