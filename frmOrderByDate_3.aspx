<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOrderByDate_3.aspx.cs" Inherits="Signature.Campaign.frmOrderByDate_3" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>

<%@ Register Assembly="Infragistics2.WebUI.WebCombo.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebCombo" TagPrefix="igcmbo" %>
<%@ Register assembly="Infragistics2.WebUI.UltraWebGrid.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.UltraWebGrid" tagprefix="igtbl" %>


<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="Signature.Web.Controls" Namespace="Signature.Web.Controls"
    TagPrefix="cc1" %>
<%@ Register assembly="Infragistics2.WebUI.WebDateChooser.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.WebSchedule" tagprefix="igsch" %>

    

    <html>
    <head>
    
   
    <style type="text/css">
        .style4
        {
            width: 72px;
        }
        .style5
        {
            height: 43px;
        }
        .style12
        {
            width: 134px;
        }
        .style15
        {
            width: 13px;
        }
        .style16
        {
            width: 41px;
        }
        .style18
        {
            width: 108px;
        }
        .style19
        {
            width: 90px;
        }
        .style22
        {
            width: 106px;
        }
        .style23
        {
            width: 128px;
        }
    </style>
    
     
    
    </head>
 
    <body>

    <form id="form2" runat="server">
        <cc1:Header ID="Header1" runat="server" MenuType= "CampaigneMenu" /> 
           <tr>
                <td>
                    <div>
                        
                    </div>
                    <cc1:Box ID="Box1" runat="server" Width="100%">
                        <table width="90%" border="0">
                            <tr style="height:40">
                                <td class="style4" >
                                    &nbsp;
                                 </td>
                                <td valign="middle">
                                    School Name:
                                </td>
                                <td>
                                    <asp:Label ID="txtName" runat="server" Text="Label" Font-Size="Small"></asp:Label>
                                    <br />
                                    
                                </td>
                            </tr>
                            <tr align='left'>
                                <td  class="style4" height="50px">
                                    &nbsp;</td>
                                <td>
                                    Teachers:
                                </td>
                                <td >
                                    
                                     
                                    <igcmbo:WebCombo ID="Teachers" runat="server" BackColor="White" 
                                         BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                                         SelBackColor="DarkBlue" SelForeColor="White" Version="4.00" Height="23px" 
                                         Width="301px" onselectedrowchanged="Teachers_SelectedRowChanged" 
                                        TabIndex="10">
                                        
                                         <Columns>
                                             <igtbl:UltraGridColumn>
                                                 <Header Caption="Teacher">
                                                 </Header>
                                             </igtbl:UltraGridColumn>
                                         </Columns>
                                         <ExpandEffects ShadowColor="LightGray" />
                                         <DropDownLayout BorderCollapse="Separate" RowHeightDefault="20px" 
                                             Version="4.00">
                                             <FrameStyle BackColor="Silver" BorderStyle="Ridge" BorderWidth="2px" 
                                                 Cursor="Default" Font-Names="Verdana" Font-Size="10pt" Height="130px" 
                                                 Width="325px">
                                             </FrameStyle>
                                             <HeaderStyle BackColor="LightGray" BorderStyle="Solid">
                                             <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" 
                                                 WidthTop="1px" />
                                             </HeaderStyle>
                                             <RowStyle BackColor="White" BorderColor="Gray" BorderStyle="Solid" 
                                                 BorderWidth="1px">
                                             <BorderDetails WidthLeft="0px" WidthTop="0px" />
                                             </RowStyle>
                                             <SelectedRowStyle BackColor="DarkBlue" ForeColor="White" />
                                         </DropDownLayout>
                                    </igcmbo:WebCombo>
                                    
                                </td>
                            </tr>
                            <tr align='left'>
                                <td class="style4" >
                                    &nbsp;</td>
                                <td>
                                    Students:
                                </td>
                                <td >
                                      
                                     <igcmbo:WebCombo ID="Students" runat="server" BackColor="White" 
                                           BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                                           SelBackColor="DarkBlue" SelForeColor="White" Version="4.00" Width="300px" 
                                         onselectedrowchanged="Students_SelectedRowChanged" TabIndex="11" >
                                        
                                           <Columns>
                                               <igtbl:UltraGridColumn Width="200px">
                                                   <header caption="Student Name">
                                                   </header>
                                               </igtbl:UltraGridColumn>
                                           </Columns>
                                           <ExpandEffects ShadowColor="LightGray" />
                                           <DropDownLayout BorderCollapse="Separate" RowHeightDefault="20px" 
                                               Version="4.00">
                                               <FrameStyle BackColor="Silver" BorderStyle="Ridge" BorderWidth="2px" 
                                                   Cursor="Default" Font-Names="Verdana" Font-Size="10pt" Height="130px" 
                                                   Width="325px">
                                               </FrameStyle>
                                               <HeaderStyle BackColor="LightGray" BorderStyle="Solid">
                                               <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" 
                                                   WidthTop="1px" />
                                               </HeaderStyle>
                                               <RowStyle BackColor="White" BorderColor="Gray" BorderStyle="Solid" 
                                                   BorderWidth="1px">
                                               <BorderDetails WidthLeft="0px" WidthTop="0px" />
                                               </RowStyle>
                                               <SelectedRowStyle BackColor="DarkBlue" ForeColor="White" />
                                           </DropDownLayout>
                                       </igcmbo:WebCombo>
                                    
                                     
                                    
                                </td>
                            </tr>
                            <tr align="left">
                                <td class="style4">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr align="left">
                                <td class="style4">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                               <td align="center" colspan="3" valign="top" >
                                 
                                   
                               </td>
                            </tr>
                            <tr>
                               <td align="center" colspan="3" valign="top" >
                                   <table border="0">
                                       <tr>
                                                    <td  width="100%">
                                                <asp:Label ID="labDescription" runat="server"></asp:Label>
                                            </td>
                                            
                                       </tr>
                                   
                                   </table>
                                   
                               </td>
                            </tr>
                            <tr>
                               <td class="style5" colspan="3">
                                   
                                   
                                   <table style="width: 100%; height: 35px;">
                                       <tr>
                                           <td class="style16">
                                               Date&nbsp; :</td>
                                           <td class="style18">
                                               <igsch:WebDateChooser ID="txtDate" runat="server" Value="" Height="22px" 
                                                   Width="91px" NullDateLabel="" TabIndex="1">
                                               </igsch:WebDateChooser>
                                           </td>
                                           <td align="right" class="style23">
                                               Number of Items :</td>
                                           <td align="center" class="style18">
                                               <asp:textBox ID="txtQuantity" runat="server" Height="20px" Width="86px" 
                                                   TabIndex="2"></asp:textBox>
                                           </td>
                                       
                                           <td align="center" class="style15">
                                               &nbsp;</td>
                                           <td align="right" class="style12">
                                               $ Amount Ordered:</td>
                                           <td align="center" class="style19">
                                               <asp:TextBox ID="txtOrdered" runat="server" Height="20px" Width="86px" 
                                                   TabIndex="3"></asp:TextBox>
                                           </td>
                                       
                                           <td align="right" class="style22">
                                               $ Turned In:</td>
                                           <td class="style19">
                                               <asp:TextBox ID="txtTurnedIn" runat="server" Height="20px" Width="86px" 
                                                   TabIndex="4"></asp:TextBox>
                                           </td>
                                           <td align="center" class="style22">
                                               <asp:Button ID="butAddItem" runat="server" onclick="butAddItem_Click" 
                                                   text="Add" Width="63px" TabIndex="5" />
                                           </td>
                                       </tr>
                                   </table>
                                   
                               </td>
                            </tr>
                            <tr>
                               <td align="center" colspan="3" valign="top" >
                                   <table border="0">
                                        <tr>
                                            <td valign="top" align="center">
                                                <asp:placeholder ID='Orders' runat="server">
                                                </asp:placeholder>
                                                
                                            </td>
                                       </tr>
                                   </table>
                                   
                               </td>
                            </tr>
                            
                               
                        </table>
                    </cc1:Box>
                </td>
            </tr>
        <cc1:Footer ID="Footer1" runat="server" />
    </form>
    </body>
    </html>