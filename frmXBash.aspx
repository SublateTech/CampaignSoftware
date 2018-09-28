<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmXBash.aspx.cs" Inherits="Signature.Campaign.frmXBash" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>

<%@ Register Assembly="Infragistics2.WebUI.WebCombo.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebCombo" TagPrefix="igcmbo" %>
<%@ Register assembly="Infragistics2.WebUI.UltraWebGrid.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.UltraWebGrid" tagprefix="igtbl" %>


<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="Signature.Web.Controls" Namespace="Signature.Web.Controls"
    TagPrefix="cc1" %>
    
    
    

    <%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
    
    
    

    <html>
    <head>
   
    <style type="text/css">
        .style5
        {
            width: 700px;
        }
        .style6
        {
            width: 55%;
        }
        .style8
        {
            width: 18%;
        }
        .style9
        {
            width: 18%;
            height: 17px;
        }
        .style10
        {
            width: 55%;
            height: 17px;
        }
        .style12
        {
            width: 412px;
        }
    </style>
    
    </head>
 
    

    <form id="form2" runat="server">
        <cc1:Page ID="Page2" runat="server" MenuType= "SigFundMenu" > 
           <tr>
                <td>
                    <div>
                        
                    </div>
                    <cc1:Box ID="Box1" runat="server" Width="100%">
                        <table width="70%" border="0">
                            <tr style="height:40">
                                <td  class="style6" colspan="2">
                                    &nbsp;</td>
                                
                            </tr>
                            <tr align='left'>
                                <td  class="style8" height="50px">
                                    School Name: </td>
                                <td class="style6">
                                    <asp:Label ID="txtName" runat="server" Font-Bold="True" Font-Size="Small" 
                                        Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr align='left'>
                                <td class="style9" >
                                    &nbsp;</td>
                                <td class="style10">
                                    &nbsp;</td>
                            </tr>
                            
                            <tr>
                               <td class="style5" colspan="2">
                                   &nbsp;</td>
                            </tr>
                            <tr>
                               <td  colspan="2">
                                   <table style="width: 100%; ">
                                       <tr>
                                           <td class="style12">
                                               &nbsp;</td>
                                           <td align="right" height="70" valign="middle">
                                               &nbsp;</td>
                                           
                                       </tr>
                                       <tr>
                                           <td  colspan="2">
                                               <CR:CrystalReportViewer ID="ReportViewer" runat="server" 
                                                   AutoDataBind="true" DisplayGroupTree="False" Height="50px" 
                                                    />
                                           </td>
                                           
                                       </tr>
                                   </table>
                               </td>
                            </tr>
                               
                        </table>
                    </cc1:Box>
                </td>
            </tr>
        </cc1:Page>
    </form>
