<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Signature.Campaign.Login" %>

<%@ Register Assembly="Signature.Web.Controls" Namespace="Signature.Web.Controls" TagPrefix="cc1" %>
    		
    		<head>
                <style type="text/css">
                    .style1
                    {
                        width: 104px;
                    }
                    .style2
                    {
                        width: 104px;
                        height: 26px;
                    }
                    .style3
                    {
                        height: 26px;
                    }
                    .style4
                    {
                        width: 104px;
                        height: 35px;
                    }
                    .style5
                    {
                        height: 35px;
                    }
                    .style6
                    {
                        width: 104px;
                        height: 42px;
                    }
                    .style7
                    {
                        height: 42px;
                    }
                    .style8
                    {
                        width: 104px;
                        height: 33px;
                    }
                    .style9
                    {
                        height: 33px;
                    }
                </style>
            </head>
        <form id="Form1" runat="server">
        <cc1:Header ID="Header1" runat="server" MenuType= "NoMenu" Banner="NoBanner" /> 
    		<tr>
    		   <td align="center" >
                        <cc1:Box ID="Box1" runat="server" BackColor="White" BorderColor="White"  HorizontalAlign="Center" ScrollBars="Vertical"  >
                        
                           <table border='0'>
                            <tr align='left'>
                                <td class="style2" >
                                    &nbsp;</td>
                                <td class="style3"  >
                                    &nbsp;</td>
                                
                            </tr>
                               <tr align="left">
                                   <td class="style2">
                                       &nbsp;</td>
                                   <td class="style3">
                                       &nbsp;</td>
                               </tr>
                               <tr align="left">
                                   <td class="style2">
                                       &nbsp;</td>
                                   <td class="style3">
                                       &nbsp;</td>
                               </tr>
                               <tr align="left">
                                   <td class="style2">
                                       <asp:Label runat="server" Text="User Name : "></asp:Label>
                                   </td>
                                   <td class="style3">
                                       <asp:TextBox runat="server" Width="266px" ID="Name"></asp:TextBox>
                                   </td>
                               </tr>
                            <tr>
                                <td class="style1" >
                                    <asp:Label runat="server" Text="Password : "></asp:Label>
                                </td>
                                <td  >
                                    <asp:textbox runat="server" Width="110px" ID="Password" TextMode="Password"></asp:textbox>
                                </td>
                            </tr>
                               <tr>
                                   <td class="style4">
                                       </td>
                                   <td class="style5">
                                   </td>
                               </tr>
                               <tr>
                                   <td class="style1" height="50">
                                       &nbsp;</td>
                                   <td height="50">
                                       <asp:Button ID="butLogIn" runat="server" Height="24px" onclick="butLogIn_Click" 
                                           Text="Log In" Width="109px" />
                                   </td>
                               </tr>
                               <tr>
                                   <td class="style6">
                                   </td>
                                   <td align="justify" class="style7">
                                       <asp:Label ID="txtMessage" runat="server" ForeColor="Red"></asp:Label>
                                   </td>
                               </tr>
                               <tr>
                                   <td class="style8">
                                   </td>
                                   <td class="style9">
                                   </td>
                               </tr>
                               <tr>
                                   <td colspan="2" width="100%">
                                       <b>For best performance please use IE 7 or IE8</td></b>
                                   
                               </tr>
                            </table>
                        </cc1:Box>
               </td>
			</tr>
        <cc1:Footer ID="Footer1" runat="server" />
        </form>