using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Signature.Classes;
using Signature.Data;

namespace Signature.Campaign
{
    public partial class frmExcel : System.Web.UI.Page
    {
        Customer oCustomer;

        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["CompanyID"] = "__S10";
          //  Session["CustomerID"] = "10503";
            MySQL oMySql = new MySQL(ConnectionType.NonUnique);
            oCustomer = new Customer(Session["CompanyID"].ToString(),oMySql);
            oCustomer.Find(Session["CustomerID"].ToString());
            oMySql.Dispose();

            
        }
        protected void btnUpload_Click(object sender, EventArgs e)  
        {
           
            String filename =  fpFile.PostedFile.FileName.ToString();

            try
            {
                ExcelHelper.uploadXLFile(fpFile, Server.MapPath("~/OutputFiles/"));
            }
            catch (Exception ex)
            {
                txtOutput.Text = "Error saving : <br>" + Server.MapPath("~/OutputFiles/") + fpFile.FileName.ToString(); 
            }
            
            String[] sheetNames = new String[100];

            filename = Server.MapPath("~/OutputFiles/") + fpFile.FileName.ToString(); ;

            sheetNames = ExcelHelper.getExcelSheets( filename);

            // loop through worksheet names
            DataSet ds = new DataSet();
            /*
            foreach (string shtname in sheetNames)
            {
                ds = ExcelHelper.getXLData(shtname,  filename, " ");

                GridView1.DataSource = ds;
                GridView1.DataBind();

                //BulkCopy
                //ExcelHelper.BulkCopy(ds.Tables[0]);

            }

            */
            if (sheetNames.Length == 0)
                return;

            ds = ExcelHelper.getXLData(sheetNames[0], filename, " ");


            MySQL oMySql = new MySQL(ConnectionType.NonUnique);
            Teacher oTeacher = new Teacher(Session["CompanyID"].ToString(), Session["CustomerID"].ToString(),oMySql);
            oTeacher.oMySql = oMySql;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                //Page.Response.Write(row["Teacher"].ToString());
                //Page.Response.Write(row["Student"].ToString());

                if (!oTeacher.FindByName(row["Teacher"].ToString()) && row["Teacher"].ToString().Length > 0)
                {
                    oTeacher.Name = row["Teacher"].ToString();
                    oTeacher.Save();
                    
                }
                
                Student oStudent = new Student(oCustomer.CompanyID, oCustomer.ID,oMySql);
                oStudent.oMySql = oMySql;

                if (!oStudent.FindByName(row["Student"].ToString(), oTeacher._ID) && row["Student"].ToString().Length > 0)
                {
                    oStudent.TeacherID = oTeacher._ID;
                    oStudent.Name = row["Student"].ToString();
                    oStudent.Save();
                    
                }
            }
            oMySql.Dispose();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            System.IO.File.Delete(filename);
            Response.Redirect("frmCustomer.aspx?Import=OK");
            
        }
        
    }
}