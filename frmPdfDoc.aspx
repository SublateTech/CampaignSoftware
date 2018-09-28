<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="frmPdfDoc.aspx.cs" Inherits="Signature.Campaign.frmPdfDoc" %>


<%@ Register Assembly="Signature.Web.Controls" Namespace="Signature.Web.Controls"
    TagPrefix="cc1" %>

<head>
    <style type="text/css">
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
                    &nbsp;</td>
            </tr>
                <tr>
                    <td align="center" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="text-align: left">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        &nbsp;</td>
                </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:FileUpload ID="fpFile" runat="server" />
                    
                </td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    


                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan ="3" align ="center">
                    &nbsp;</td>
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
    