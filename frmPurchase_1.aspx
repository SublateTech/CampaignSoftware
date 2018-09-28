<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPurchase_1.aspx.cs" Inherits="Signature.Campaign.frmPurchase" %>


<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="Signature.Web.Controls" Namespace="Signature.Web.Controls"
    TagPrefix="cc2" %>
    

<%@ Register assembly="Infragistics2.WebUI.UltraWebGrid.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.UltraWebGrid" tagprefix="igtbl" %>
<%@ Register assembly="Infragistics2.WebUI.WebDateChooser.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.WebSchedule" tagprefix="igsch" %>
    
<%@ Register Assembly="Infragistics2.WebUI.WebCombo.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebCombo" TagPrefix="igcmbo" %>   
     
     
    
     <style type="text/css">
         .style1
         {
             width: 20%;
             height: 17px;
         }
         .style3
         {
             height: 17px;
             width: 18px;
         }
         .style4
         {
             width: 18px;
         }
     </style>
    
     <script type="text/javascript" id="Infragistics">

         function SetPurchase() {

             var value = igcmbo_getComboById("txtPurchases").getGrid().getActiveRow().DataKey;
             var textBox = document.getElementById("txtIdPurchase");
             textBox.value = value;
             //   alert(value);
             return;

         }



function txtAlerts_ClickCellButtonHandler(gridName, cellId){
    //Add code to handle your event here.

    var value = igtbl_getGridById(gridName).getActiveRow().getCell(0).getValue();
    
    var textBox = document.getElementById("txtCoverVisitId"); 
    textBox.value = value;

    
    

    //Get reference to column object using ultrawebgrid utility function    
    var oColumn = igtbl_getColumnById(cellId);

    //Get reference to row object owning the cell 
    var oRow = igtbl_getRowById(cellId);

    var textAction = document.getElementById("txtAction");
    textAction.value = oColumn.Key;

    //alert(oColumn.Key);
    
     return;
    
    //return;
}

</script>

    <form id="form2" runat="server">
        <cc2:Header ID="Header1" runat="server"  MenuType= "NoMenu" /> 
           <tr>
                <td>
                    <div>
                        
                    </div>
                    <cc2:Box ID="Box1" runat="server" Width="100%">
                        <table style="width: 100%">
                                <tr>
                                    <td class="style1">
                                        </td>
                                    <td class="style1" >
                                        </td>
                                    <td class="style3">
                                        </td>
                                    <td style="width:150" >
                                        &nbsp;</td>
                                    <td class="style1">
                                        </td>
                                </tr>
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td >
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td >
                                        <asp:Label ID="txtMessage" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    <td class="style4">
                                        &nbsp;
                                        
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;
                                     </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="txtIdPurchase" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label ID="LabPurchases" runat="server" Text="Purchases :"></asp:Label>
                                    </td>
                                    <td colspan="2" class="style4">
                                        <igcmbo:WebCombo ID="txtPurchases" runat="server" BackColor="White" 
                                            BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" Editable="True" 
                                            ForeColor="Black" Height="21px" SelBackColor="DarkBlue" SelForeColor="White" 
                                            Version="4.00" Width="394px" 
                                            onselectedrowchanged="txtPurchases_SelectedRowChanged">
                                            <Columns>
                                                <igtbl:UltraGridColumn Width="200px">
                                                    <Header Caption="Purchase Order">
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
                                            
                                            <ClientSideEvents AfterSelectChange="SetPurchase" />
                                            
                                        </igcmbo:WebCombo>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:Label ID="Label20" runat="server" Text="Type of Modification"></asp:Label>
                                        :</td>
                                    <td class="style4">
                                        <asp:RadioButton ID="bNew" runat="server" Text="New" 
                                            oncheckedchanged="bNew_CheckedChanged" AutoPostBack="True" 
                                            GroupName="Group01" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:RadioButton ID="bEdit" runat="server" AutoPostBack="True" 
                                            GroupName="Group01" oncheckedchanged="bNew_CheckedChanged" Text="Edit" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="left">
                                        Purchase Order #:</td>
                                    <td class="style4">
                                        <asp:TextBox ID="txtPurchaseID" runat="server" Height="18px" Width="105px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Shipment Port:</td>
                                    <td>
                                        <igsch:WebDateChooser ID="txtShipmentDate" runat="server" NullDateLabel="">
                                        </igsch:WebDateChooser>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        </td>
                                    <td align="left">
                                        Vendor ID :
                                    </td>
                                    <td class="style4">
                                        <asp:TextBox ID="txtVendorID" runat="server" Height="18px" Width="105px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Delivery to Signature:</td>
                                    <td>
                                        <igsch:WebDateChooser ID="txtShipDate" runat="server" NullDateLabel="">
                                        </igsch:WebDateChooser>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="4" >
                                        <table border="0" width="100%">
                                            <tr>
                                               <td style="width:20%">
                                                     Item #:
                                               </td>
                                               <td style="width:20%">
                                                     <asp:TextBox ID="txtPurchaseID0" runat="server" Height="18px" Width="105px"></asp:TextBox>
                                               </td>
                                               <td style="width:20%">
                                                     Cases:
                                               </td>
                                               <td style="width:20%">
                                                    <asp:TextBox ID="txtPurchaseID1" runat="server" Height="18px" Width="105px"></asp:TextBox>
                                               </td>
                                               
                                            </tr>
                                            <tr>
                                               <td style="width:20%">
                                                     Units #:
                                               </td>
                                               <td style="width:20%">
                                                     <asp:TextBox ID="txtPurchaseID2" runat="server" Height="18px" Width="105px"></asp:TextBox>
                                               </td>
                                               <td style="width:20%">
                                                     Note:
                                               </td>
                                               <td style="width:20%">
                                                    <asp:TextBox ID="txtPurchaseID3" runat="server" Height="56px" Width="209px" 
                                                        TextMode="MultiLine"></asp:TextBox>
                                               </td>
                                               
                                            </tr>
                                            <tr>
                                               <td align="center" colspan="4" style="width:20%">
                                                    <asp:Button ID="txtAdd" runat="server" Height="24px" onclick="txtAdd_Click" 
                                            Text="Add" Width="110px" />         
                                               </td>
                                               
                                               
                                            </tr>
                                        </table>
                                            
                                        
                                    </td>
                                    
                                    
                                    
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="3" align="center">
                                        
                                    </td>
                                    <td align="center">
                                        &nbsp;</td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td align="center" colspan="2">
                                        &nbsp;</td>
                                    <td align="center">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="4">
                                        <asp:HiddenField ID="txtCoverVisitId" runat="server" />
                                        <asp:HiddenField ID="txtAction" runat="server" />
                                        <igtbl:UltraWebGrid ID="txtAlerts" runat="server" Height="148px" 
                                            onclickcellbutton="txtAlerts_ClickCellButton" Width="850px">
                                            <bands>
                                                <igtbl:UltraGridBand ColHeadersVisible="Yes" GroupByColumnsHidden="Yes">
                                                    <Columns>
                                                        <igtbl:UltraGridColumn AllowUpdate="Yes" BaseColumnName="ItemID" 
                                                            Key="ProductID" Width="70px">
                                                            <header caption="Item ID">
                                                            </header>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn AllowUpdate="No" BaseColumnName="Price" 
                                                            IsBound="True" Key="Price" Width="70px">
                                                            <header caption="Price">
                                                                <rowlayoutcolumninfo originx="1" />
                                                            </header>
                                                            <footer>
                                                                <rowlayoutcolumninfo originx="1" />
                                                            </footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn AllowUpdate="Yes" BaseColumnName="Cases" Key="Cases" 
                                                            Width="70px">
                                                            <header caption="Cases">
                                                                <rowlayoutcolumninfo originx="1" />
                                                            </header>
                                                            <footer>
                                                                <rowlayoutcolumninfo originx="1" />
                                                            </footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:TemplatedColumn Key="Units" AllowUpdate="Yes" BaseColumnName="Units" 
                                                            Width="70px" DataType="System.Int32">
                                                            <header caption="Units">
                                                                <rowlayoutcolumninfo originx="3" />
                                                            </header>
                                                            <footer>
                                                                <rowlayoutcolumninfo originx="3" />
                                                            </footer>
                                                        </igtbl:TemplatedColumn>
                                                        <igtbl:UltraGridColumn Key="InvCode" Width="90px">
                                                            <header caption="InvCode">
                                                                <rowlayoutcolumninfo originx="4" />
                                                            </header>
                                                            <footer>
                                                                <rowlayoutcolumninfo originx="4" />
                                                            </footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn Key="CasePack" Width="60px">
                                                            <Header Caption="CasePack">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn Key="Description" Width="150px">
                                                            <Header Caption="Description">
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn Key="Note" Width="150px" AllowUpdate="Yes" 
                                                            CellMultiline="Yes">
                                                            <Header Caption="Note">
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn CellButtonDisplay="Always" Key="Delete" Type="Button">
                                                            <CellButtonStyle Width="100px">
                                                            </CellButtonStyle>
                                                            <Header Caption="" Title="">
                                                                <RowLayoutColumnInfo OriginX="8" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="8" />
                                                            </Footer>
                                                        </igtbl:UltraGridColumn>
                                                    </Columns>
                                                    <addnewrow view="NotSet" visible="NotSet">
                                                    </addnewrow>
                                                </igtbl:UltraGridBand>
                                            </bands>
                                            <displaylayout allowcolsizingdefault="Free" allowcolumnmovingdefault="OnServer" 
                                                allowdeletedefault="Yes" allowsortingdefault="OnClient" 
                                                allowupdatedefault="Yes" bordercollapsedefault="Separate" 
                                                headerclickactiondefault="SortMulti" name="UltraWebGrid1" 
                                                rowheightdefault="20px" rowselectorsdefault="No" 
                                                selecttyperowdefault="Extended" stationarymargins="Header" 
                                                stationarymarginsoutlookgroupby="True" tablelayout="Fixed" version="4.00" 
                                                viewtype="OutlookGroupBy">
                                                <framestyle backcolor="Window" bordercolor="InactiveCaption" 
                                                    borderstyle="Solid" borderwidth="1px" font-names="Microsoft Sans Serif" 
                                                    font-size="8.25pt" height="148px" width="850px">
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
                                    
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                        </table>
                    </cc2:Box>
                </td>
            </tr>
        <cc2:Footer ID="Footer1" runat="server" />
    </form>
