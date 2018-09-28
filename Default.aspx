<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Signature.Campaign.Main" %>

<%@ Register Assembly="Signature.Web.Controls" Namespace="Signature.Web.Controls" TagPrefix="cc1" %>
        		
        <html>
    	<cc1:Head ID="Head1" runat="server" />
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
                <script>
                        function __doPostBack(eventTarget, eventArgument) {
                            document.Form1.__EVENTTARGET.value = eventTarget;
                            document.Form1.__EVENTARGUMENT.value = eventArgument;
                            document.Form1.submit();
                        }
                </script>
            </head>
            <body>
        <form id="Form1" runat="server">
        <input type =hidden name ="__EVENTTARGET" value ="">
        <input type =hidden name ="__EVENTARGUMENT" value ="">
        <cc1:Header ID="Header1" runat="server" MenuType= "NoMenu" /> 
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
                                       Season:
                                    
                                       </td>
                                   <td class="style3">
                                       <asp:DropDownList ID="Season" runat="server" Height="20px" Width="164px" AppendDataBoundItems="true">
                                        <asp:ListItem value="__F12">
                                              Fall 2012
                                        </asp:ListItem>
                                        <asp:ListItem  value="__S12">
                                              Spring 2012
                                        </asp:ListItem>
                                        <asp:ListItem value="__F11">
                                              Fall 2011
                                        </asp:ListItem>
                                        <asp:ListItem  value="__S11">
                                              Spring 2011
                                        </asp:ListItem>
                                           <asp:ListItem value="__F10">
                                              Fall 2010
                                        </asp:ListItem>
                                           <asp:ListItem  value="__S09">
                                              Spring 2009
                                        </asp:ListItem>
                                           <asp:ListItem value="__F09">
                                              Fall 2009
                                        </asp:ListItem>
                                           <asp:ListItem value="__S10">
                                              Spring 2010
                                        </asp:ListItem>
                                           
                                       </asp:DropDownList>
                                   </td>
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
        </body>
        </html>