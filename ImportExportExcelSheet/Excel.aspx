<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Excel.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Import and Export to Excelsheet </title> 
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="2" cellspacing="1">
            <tr>
                <td colspan="3" align="center">
                    <strong><span style="color: #339933">
                    Upload Excel File Concept </span></strong>
                </td>
            </tr>
            <tr>
                <td>
                    Browse File
                </td>
                <td>
                    <asp:FileUpload ID="fpFile" runat="Server" />
                </td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan ="3" align ="center">
                    <strong><span style="color: #009933">
                    Export to Multiple Work Sheet </span></strong>
                </td>
            </tr>
            <tr>
                <td colspan ="3" align ="center">
                    <asp:Button ID="btnExport" Text = "Export to WorkSheet" runat ="server" OnClick="btnExport_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    <hr />
   Copyright © <a href="www.sgnanaprakash.com">Gnana Prakash</a>
    
    </form>
</body>
</html>
