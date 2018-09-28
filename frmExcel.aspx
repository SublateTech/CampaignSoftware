<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="frmExcel.aspx.cs" Inherits="Signature.Campaign.frmExcel" %>


<%@ Register Assembly="Signature.Web.Controls" Namespace="Signature.Web.Controls"
    TagPrefix="cc1" %>

<head>
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
        }
        .style2
        {
            color: #FF0000;
            font-size: larger;
        }
        #form1
        {
            font-size: large;
        }
    </style>
</head>

<form id="form1" runat="server">
        <cc1:Header ID="Header1" runat="server" MenuType= "CampaigneMenu" /> 
           <tr>
                <td>
                    <div>
                        
                    </div>
                    <cc1:Box ID="Box1" runat="server" Width="100%">        
            <table cellpadding="2" cellspacing="1">
            <tr>
                <td colspan="3" align="center" style="text-align: left">
                    <b><span class="style1">Step1.</span> </b>&nbsp;<span lang="EN" 
                        style="font-size: 12.0pt; font-family: 'Times New Roman',&quot;serif&quot;; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; mso-ansi-language: EN; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">Create 
                    an MS Excel file that is set up like the sample below.<span 
                        style="mso-spacerun:yes">&nbsp; </span>Cell may contain numbers and names, but 
                    the
                    <br />
                    column must have the title Teacher for the teacher names and Student for the 
                    student names.<span style="mso-spacerun:yes">&nbsp; </span>Save the file in a 
                    location
                    <br />
                    that can be accessed easily for uploading.</span><br />
&nbsp;</td>
            </tr>
                <tr>
                    <td align="center" colspan="3">
                        &nbsp;
                        <img src="Excel.jpg" />
                        
                        </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="text-align: left">
                        <b style="text-decoration: underline">Step 2. </b>
                        <span lang="EN" style="font-size:12.0pt;font-family:
&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:Calibri;mso-fareast-theme-font:
minor-latin;mso-ansi-language:EN;mso-fareast-language:EN-US;mso-bidi-language:
AR-SA">Once the MS Excel file has been created, click the Browse button below and select the path to the 
                        created file.<span style="mso-spacerun:yes">&nbsp;<br />
                        </span>Once the file is found, click on the file and select Open in the browse 
                        window.<span style="mso-spacerun:yes">&nbsp; </span>At this point, the browse window 
                        closes
                        <br />
                        and your file path will be seen in the Browse File box below.<span 
                            style="mso-spacerun:yes">&nbsp; </span>Click Upload and the process will be 
                        complete in a minute
                        <br />
                        or 2 depending on your file size and internet connection speed<b 
                            style="text-decoration: underline">.</b></span></td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <span class="style2" 
                            style="font-family: &quot;Times New Roman&quot;,&quot;serif&quot;; mso-fareast-font-family: Calibri; mso-fareast-theme-font: minor-latin; mso-ansi-language: EN-US; mso-fareast-language: EN-US; mso-bidi-language: AR-SA">
                        Do not forget, if you import the teacher and student names,
                        <br />
                        go into the Teacher/Student Input screen for each Teacher
                        <br />
                        and enter the number of students in each class.</span></td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <strong><span style="color: #339933">Upload Excel File Teacher/Student </span>
                        </strong>
                    </td>
                </tr>
            <tr>
                <td>
                    Browse File
                </td>
                <td>
                    <asp:FileUpload ID="fpFile" runat="server" />
                    
                </td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    


                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                    <asp:RegularExpressionValidator 
                        id="FileUpLoadValidator" runat="server" 
                        ErrorMessage="Upload excel file 2003/2007 version only." 
                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.xls|.XLS|.xlsx|.XLSX)$" 
                        ControlToValidate="fpFile">
                        </asp:RegularExpressionValidator>
                 </td>
            </tr>
            <tr>
                <td colspan ="3" align ="center">
                    <asp:GridView ID="GridView1" runat="server" Width="356px">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan ="3" align ="center">
                    &nbsp;</td>
            </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Label ID="txtOutput" runat="server"></asp:Label>
                    </td>
                </tr>
        </table>
    
</cc1:Box>
                </td>
            </tr>
        <cc1:Footer ID="Footer1" runat="server" />
    </form>
    