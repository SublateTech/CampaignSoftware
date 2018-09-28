using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        String filename = fpFile.PostedFile.FileName.ToString();
        ExcelHelper.uploadXLFile(fpFile, Server.MapPath("~/OutputFiles/"));
        String[] sheetNames = new String[100];
        sheetNames = ExcelHelper.getExcelSheets(Server.MapPath("~/OutputFiles/")+filename );  

        // loop through worksheet names

        foreach (string shtname in sheetNames)
        {
            DataSet ds = new DataSet();

            ds = ExcelHelper.getXLData(shtname, Server.MapPath("~/OutputFiles/") + filename, " ");  

            //BulkCopy
            ExcelHelper.BulkCopy(ds.Tables[0]);   

        }


    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //downloadToXLMultipleSheets();
        string fileSuffix;
        fileSuffix = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
        string strSqlSelect = "Select * from TableNAme";
        string outputname = Server.MapPath("~/OutputFiles/") + "Output" + fileSuffix + ".xls";
        ExcelHelper.ImportToMultipleXLSheets(strSqlSelect, outputname);
    }
}
