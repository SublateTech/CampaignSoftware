<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOrderItem.aspx.cs" Inherits="Signature.Campaign.frmOrderItem" %>

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
        .style26
        {
            width: 27px;
        }
        .style27
        {
            width: 171px;
        }
        .style28
        {
            width: 108px;
            height: 37px;
        }
        .style29
        {
            width: 171px;
            height: 37px;
        }
        .style30
        {
            width: 90px;
            height: 37px;
        }
        .style31
        {
            width: 106px;
            height: 37px;
        }
        .style32
        {
            width: 108px;
            height: 17px;
        }
        .style33
        {
            height: 17px;
        }
        .style34
        {
            width: 106px;
            height: 17px;
        }
    </style>
    
    
    
    </head>
 
    

    <form id="form2" runat="server">
        <cc1:Header ID="Header1" runat="server" MenuType= "CampaigneMenu" /> 
           <tr>
                <td>
                    <div>
                        
                    </div>
                    <cc1:Box ID="Box1" runat="server" Width="100%">
                        <table border="0">
                            <tr style="height:40">
                                <td class="style4" >
                                    &nbsp;</td>
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
                                        Editable="True">
                                        
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
                                           SelBackColor="DarkBlue" SelForeColor="White" Version="4.00" 
                                        Editable="True" Width="300px" onselectedrowchanged="Students_SelectedRowChanged" >
                                        
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
                            
                            <tr>
                               <td align="center" colspan="3" valign="top" >
                                   <table border="0">
                                        <tr>
                                            <td valign="top" align="center">
                                                <asp:placeholder ID='Orders' runat="server">
                                                </asp:placeholder>
                                                
                                            </td>
                                       </tr>
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
                                           
                                           <td class="style28">
                                               </td>
                                           <td align="center" class="style29">
                                               </td>
                                           <td align="center" class="style30">
                                               
                                               </td>
                                       
                                           <td align="right" class="style31">
                                               </td>
                                           <td class="style30">
                                               </td>
                                           <td align="center" class="style31">
                                               </td>
                                       </tr>
                                       
                                       <tr>
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td align="right" colspan="5">
                                               
                                                   <table style="width: 100%; height: 35px;">
                                                       <tr>
                                                           <td class="style7" style="width: 80px;">
                                                               Item # :</td>
                                                           <td class="style24">
                                                               <igcmbo:WebCombo ID="txtItemID" runat="server" BackColor="White" 
                                                                   BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" DataSourceID="SqlDataSource1" 
                                                                   DataTextField="ProductID" DataValueField="ProductID" DisplayValue="" 
                                                                   Editable="True" EnableXmlHTTP="True" ForeColor="Black" Height="18px" 
                                                                   SelBackColor="DarkBlue" SelForeColor="White" Version="4.00" Width="92px">
                                                                   <Columns>
                                                                       <igtbl:UltraGridColumn BaseColumnName="ProductID" IsBound="True" 
                                                                           Key="ProductID">
                                                                           <Header Caption="ProductID">
                                                                           </Header>
                                                                       </igtbl:UltraGridColumn>
                                                                       <igtbl:UltraGridColumn BaseColumnName="Description" IsBound="True" 
                                                                           Key="Description">
                                                                           <Header Caption="Description">
                                                                               <RowLayoutColumnInfo OriginX="1" />
                                                                           </Header>
                                                                           <Footer>
                                                                               <RowLayoutColumnInfo OriginX="1" />
                                                                           </Footer>
                                                                       </igtbl:UltraGridColumn>
                                                                   </Columns>
                                                                   <ExpandEffects ShadowColor="LightGray" />
                                                                   <DropDownLayout BaseTableName="" BorderCollapse="Separate" 
                                                                       DropdownHeight="200px" DropdownWidth="400px" RowHeightDefault="20px" 
                                                                       Version="4.00" XmlLoadOnDemandType="Accumulative" AllowSorting="Yes">
                                                                       <FrameStyle BackColor="Silver" BorderStyle="Ridge" BorderWidth="2px" 
                                                                           Cursor="Default" Font-Names="Verdana" Font-Size="10pt" Height="200px" 
                                                                           Width="400px">
                                                                       </FrameStyle>
                                                                       <HeaderStyle BackColor="LightGray" BorderStyle="Solid">
                                                                       <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" 
                                                                           WidthTop="1px" />
                                                                       </HeaderStyle>
                                                                       <Pager MinimumPagesForDisplay="5" AllowPaging="False">
                                                                       </Pager>
                                                                       <RowStyle BackColor="White" BorderColor="Gray" BorderStyle="Solid" 
                                                                           BorderWidth="1px">
                                                                       <BorderDetails WidthLeft="0px" WidthTop="0px" />
                                                                       </RowStyle>
                                                                       <SelectedRowStyle BackColor="DarkBlue" ForeColor="White" />
                                                                   </DropDownLayout>
                                                               </igcmbo:WebCombo>
                                                           </td>
                                                           <td align="center" class="style25">
                                                               Quantity :</td>
                                                           <td align="center" class="style11">
                                                               <asp:TextBox ID="txtQuantity" runat="server" Height="20px" Width="86px"></asp:TextBox>
                                                           </td>
                                                           <td align="right">
                                                               <asp:Button ID="butAddItem" runat="server" onclick="butAddItem_Click" 
                                                                   text="Add Item" />
                                                           </td>
                                                       </tr>
                                                   </table>
                                               
                                           </td>
                                           <td align="center" class="style22">
                                               &nbsp;</td>
                                       </tr>
                                       <tr>
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td align="right" class="style27">
                                               &nbsp;</td>
                                           <td align="center" class="style26">
                                               &nbsp;</td>
                                           <td align="right" class="style12">
                                               &nbsp;</td>
                                           <td align="center" class="style19">
                                               &nbsp;</td>
                                           <td align="right" class="style22">
                                               &nbsp;</td>
                                           <td class="style19">
                                               &nbsp;</td>
                                           
                                       </tr>
                                       <tr>
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td colspan="5" align="left" >
                                               
                                               <asp:ScriptManager ID="ScriptManager1" runat="server">
                                               </asp:ScriptManager>
                                               <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                                   ConnectionString="<%$ ConnectionStrings:sigdataConnectionString %>" 
                                                   ProviderName="<%$ ConnectionStrings:sigdataConnectionString.ProviderName %>" 
                                                   SelectCommand="SELECT ProductID,Description FROM product WHERE CompanyID = '__F10' ORDER BY ProductID">
                                                   <SelectParameters>
                                                       <asp:Parameter DefaultValue="__S07" Name="CompanyID" Type="String" />
                                                   </SelectParameters>
                                               </asp:SqlDataSource>
                                               
                                           </td>
                                           <td align="center" class="style22">
                                               &nbsp;</td>
                                       </tr>
                                       
                                       <tr>
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td align="center" colspan="5">
                                               <asp:PlaceHolder ID="txtOrderDetail" runat="server"></asp:PlaceHolder>
                                               <br />
                                               <igtbl:UltraWebGrid ID="txtDetail" runat="server" Height="148px" 
                                                    Width="639px">
                                                   <bands>
                                                       <igtbl:UltraGridBand ColHeadersVisible="Yes" GroupByColumnsHidden="Yes">
                                                           <Columns>
                                                               <igtbl:UltraGridColumn AllowUpdate="No" BaseColumnName="ProductID" 
                                                                   IsBound="True" Key="ProductID">
                                                                   <valuelist datamember="ProductID" displaymember="ProductID">
                                                                   </valuelist>
                                                                   <header caption="Item #">
                                                                   </header>
                                                               </igtbl:UltraGridColumn>
                                                               <igtbl:UltraGridColumn AllowUpdate="No" BaseColumnName="Description" 
                                                                   IsBound="True" Key="Description" Width="300px">
                                                                   <valuelist datamember="Description" displaymember="Description">
                                                                   </valuelist>
                                                                   <header caption="Description">
                                                                       <rowlayoutcolumninfo originx="1" />
                                                                   </header>
                                                                   <footer>
                                                                       <rowlayoutcolumninfo originx="1" />
                                                                   </footer>
                                                               </igtbl:UltraGridColumn>
                                                               <igtbl:UltraGridColumn Key="Quantity" Format="#####" FieldLen="3" DataType="System.Int32" AllowUpdate="Yes">
                                                                   <Header Caption="Quantity">
                                                                       <RowLayoutColumnInfo OriginX="3" />
                                                                   </Header>
                                                                   <Footer>
                                                                       <RowLayoutColumnInfo OriginX="3" />
                                                                   </Footer>
                                                               </igtbl:UltraGridColumn>
                                                               <igtbl:TemplatedColumn CellButtonDisplay="Always" Key="Update" Type="Button">
                                                                   <cellbuttonstyle width="80px">
                                                                   </cellbuttonstyle>
                                                                   <header caption="Action" title="Date Sent">
                                                                       <rowlayoutcolumninfo originx="2" />
                                                                   </header>
                                                                   <footer>
                                                                       <rowlayoutcolumninfo originx="2" />
                                                                   </footer>
                                                               </igtbl:TemplatedColumn>
                                                               
                                                           </Columns>
                                                           <addnewrow view="NotSet" visible="NotSet">
                                                           </addnewrow>
                                                       </igtbl:UltraGridBand>
                                                   </bands>
                                                   <displaylayout allowcolsizingdefault="Free" allowcolumnmovingdefault="OnServer" 
                                                       allowdeletedefault="No" allowsortingdefault="OnClient" 
                                                       allowupdatedefault="Yes" bordercollapsedefault="Separate" 
                                                       headerclickactiondefault="SortMulti" name="UltraWebGrid1" 
                                                       rowheightdefault="20px" rowselectorsdefault="No" 
                                                       selecttyperowdefault="Extended" stationarymargins="Header" 
                                                       stationarymarginsoutlookgroupby="True" tablelayout="Fixed" version="4.00" 
                                                       viewtype="OutlookGroupBy">
                                                       <framestyle backcolor="Window" bordercolor="InactiveCaption" 
                                                           borderstyle="Solid" borderwidth="1px" font-names="Microsoft Sans Serif" 
                                                           font-size="8.25pt" height="148px" width="639px">
                                                       </framestyle>
                                                       <clientsideevents clickcellbuttonhandler="txtAlerts_ClickCellButtonHandler" />
                                                       <pager minimumpagesfordisplay="2">
                                                           <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                           <borderdetails colorleft="White" colortop="White" widthleft="1px" 
                                                               widthtop="1px" />
                                                           </PagerStyle>
                                                       </pager>
                                                       <editcellstyledefault borderstyle="None" borderwidth="0px">
                                                       </editcellstyledefault>
                                                       <footerstyledefault backcolor="LightGray" borderstyle="Solid" borderwidth="1px">
                                                           <borderdetails colorleft="White" colortop="White" widthleft="1px" 
                                                               widthtop="1px" />
                                                       </footerstyledefault>
                                                       <headerstyledefault backcolor="LightGray" borderstyle="Solid" 
                                                           horizontalalign="Left">
                                                           <borderdetails colorleft="White" colortop="White" widthleft="1px" 
                                                               widthtop="1px" />
                                                       </headerstyledefault>
                                                       <rowstyledefault backcolor="Window" bordercolor="Silver" borderstyle="Solid" 
                                                           borderwidth="1px" font-names="Microsoft Sans Serif" font-size="8.25pt">
                                                           <padding left="3px" />
                                                           <borderdetails colorleft="Window" colortop="Window" />
                                                       </rowstyledefault>
                                                       <groupbyrowstyledefault backcolor="Control" bordercolor="Window">
                                                       </groupbyrowstyledefault>
                                                       <groupbybox hidden="True">
                                                           <boxstyle backcolor="ActiveBorder" bordercolor="Window">
                                                           </boxstyle>
                                                       </groupbybox>
                                                       <addnewbox hidden="False">
                                                           <boxstyle backcolor="Window" bordercolor="InactiveCaption" borderstyle="Solid" 
                                                               borderwidth="1px">
                                                               <borderdetails colorleft="White" colortop="White" widthleft="1px" 
                                                                   widthtop="1px" />
                                                           </boxstyle>
                                                       </addnewbox>
                                                       <activationobject bordercolor="" borderwidth="">
                                                       </activationobject>
                                                       <filteroptionsdefault>
                                                           <filterdropdownstyle backcolor="White" bordercolor="Silver" borderstyle="Solid" 
                                                               borderwidth="1px" customrules="overflow:auto;" 
                                                               font-names="Verdana,Arial,Helvetica,sans-serif" font-size="11px" height="300px" 
                                                               width="200px">
                                                               <padding left="2px" />
                                                           </filterdropdownstyle>
                                                           <filterhighlightrowstyle backcolor="#151C55" forecolor="White">
                                                           </filterhighlightrowstyle>
                                                           <filteroperanddropdownstyle backcolor="White" bordercolor="Silver" 
                                                               borderstyle="Solid" borderwidth="1px" customrules="overflow:auto;" 
                                                               font-names="Verdana,Arial,Helvetica,sans-serif" font-size="11px">
                                                               <padding left="2px" />
                                                           </filteroperanddropdownstyle>
                                                       </filteroptionsdefault>
                                                   </displaylayout>
                                               </igtbl:UltraWebGrid>
                                           </td>
                                           <td align="center" class="style22">
                                               &nbsp;</td>
                                       </tr>
                                       <tr>
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td align="right" colspan="3">
                                               <b>Totals:</b></td>
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td align="left" >
                                               <asp:Label ID="labTotals" runat="server" Text="Label"></asp:Label>
                                           </td>
                                            <td align="right" >
                                               &nbsp;</td>
                                          
                                       </tr>
                                       <tr>
                                          
                                           <td class="style32">
                                               </td>
                                           <td align="right" colspan="5" bgcolor="White" class="style33">
                                               </td>
                                           <td align="center" class="style34">
                                               </td>
                                       </tr>
                                       <tr>
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td align="left" bgcolor="White" colspan="5">
                                               <b>Money Collected:</b></td>
                                           <td align="center" class="style22">
                                               &nbsp;</td>
                                       </tr>
                                       <tr>
                                          
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td align="left" class="style27" valign="bottom">
                                                Date  : 
                                               <igsch:WebDateChooser ID="txtDate" runat="server" Height="22px" 
                                                   NullDateLabel="" Value="" Width="91px">
                                               </igsch:WebDateChooser>
                                           </td>
                                           <td align="left" class="style26" valign="bottom">
                                               Number&nbsp;of Items: 
                                               <asp:TextBox ID="txtQuantity1" runat="server" Height="20px" Width="86px"></asp:TextBox>
                                           </td>
                                           <td align="left" class="style12" valign="bottom">
                                               $ Min. Donation Amount: 
                                               <asp:TextBox ID="txtOrdered" runat="server" Height="20px" Width="86px"></asp:TextBox>
                                           </td>
                                           <td align="left" class="style19" valign="bottom">
                                               $ Turned In:
                                               <asp:TextBox ID="txtTurnedIn" runat="server" Height="20px" Width="86px"></asp:TextBox>
                                           </td>
                                           <td align="right" class="style22" valign="bottom">
                                               <asp:Button ID="butAddMoney" runat="server" onclick="butAddMoney_Click" 
                                                   text="Add" Width="63px" />
                                           </td>
                                           <td class="style19">
                                               &nbsp;</td>
                                           
                                       </tr>
                                       <tr>
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td align="left" class="style27" valign="bottom">
                                               &nbsp;</td>
                                           <td align="left" class="style26" valign="bottom">
                                               &nbsp;</td>
                                           <td align="left" class="style12" valign="bottom">
                                               &nbsp;</td>
                                           <td align="left" class="style19" valign="bottom">
                                               &nbsp;</td>
                                           <td align="right" class="style22" valign="bottom">
                                               &nbsp;</td>
                                           <td class="style19">
                                               &nbsp;</td>
                                       </tr>
                                       <tr>
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td align="center" colspan="5">
                                               &nbsp;</td>
                                           <td align="center" class="style22">
                                               &nbsp;</td>
                                       </tr>
                                       <tr>
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td align="right" colspan="5">
                                               &nbsp;</td>
                                           <td align="center" class="style22">
                                               &nbsp;</td>
                                       </tr>
                                        
                                       <tr>
                                           <td class="style18">
                                               &nbsp;</td>
                                           <td align="right" colspan="5">
                                               &nbsp;</td>
                                           <td align="center" class="style22">
                                               &nbsp;</td>
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
