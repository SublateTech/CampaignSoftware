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
    public partial class frmExcelShow : System.Web.UI.Page
    {
        //Customer oCustomer;
        String filename = "Spec Sheet rough.xls";

        protected void Page_Load(object sender, EventArgs e)
        {
           // Session["CompanyID"] = "__S10";
          //  Session["CustomerID"] = "10503";
            /*
            MySQL oMySql = new MySQL(ConnectionType.NonUnique);
            oCustomer = new Customer(Session["CompanyID"].ToString(),oMySql);
            oCustomer.Find(Session["CustomerID"].ToString());
            oMySql.Dispose();
            */

            CopyFile("Spec Sheet rough.xls", Server.MapPath(""), Server.MapPath(@"~\OutputFiles\"));
            LoadGrid("Spec Sheet rough.xls", Server.MapPath(@"~\OutputFiles\"));
        }
        protected void btnUpload_Click(object sender, EventArgs e)  
        {
           
          //  String filename =  fpFile.PostedFile.FileName.ToString();

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
            /*

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
            */
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void CopyFile(string fileName, string sourcePath, string targetPath)
        {
            //fileName = "Spec Sheet rough.xls";
            //sourcePath =  Server.MapPath(""); //@"C:\Users\Public\TestFolder";
            //targetPath = Server.MapPath(@"~\OutputFiles\"); //@"C:\Users\Public\TestFolder\SubDir";

            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
           //     System.IO.Directory.CreateDirectory(targetPath);
            }

            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);
            /*
            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
            */
            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
         //   Console.ReadKey();
        }
        protected void LoadGrid(string fileName, string sourcePath)
        {
            

            String[] sheetNames = new String[100];

            filename = System.IO.Path.Combine(sourcePath, fileName);

            sheetNames = ExcelHelper.getExcelSheets(filename);

            // loop through worksheet names
            DataSet ds = new DataSet();
            
            if (sheetNames.Length == 0)
                return;

            ds = ExcelHelper.getXLData(sheetNames[0], filename, " ");
            
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}