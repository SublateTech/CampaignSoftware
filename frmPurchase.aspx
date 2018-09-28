<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPurchase.aspx.cs" Inherits="Signature.Campaign.frmPurchase" %>


<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="Signature.Web.Controls" Namespace="Signature.Web.Controls"
    TagPrefix="cc2" %>
    

<%@ Register assembly="Infragistics2.WebUI.UltraWebGrid.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.UltraWebGrid" tagprefix="igtbl" %>
<%@ Register assembly="Infragistics2.WebUI.WebDateChooser.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.WebUI.WebSchedule" tagprefix="igsch" %>
    
<%@ Register Assembly="Infragistics2.WebUI.WebCombo.v9.1, Version=9.1.20091.1015, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebCombo" TagPrefix="igcmbo" %>   
     
 
    
     <%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
     
 
    
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
         .style5
         {
             height: 17px;
         }
        /* #display {width:500px; border:10px ridge blue; padding:20px}*/
        .hiddenControl {display:none}
        .showControl {display:inline}

     </style>
    
     <script type="text/javascript" id="Infragistics">
<!--


         function SetPurchase() {

             var value = igcmbo_getComboById("txtPurchases").getGrid().getActiveRow().DataKey;
             var textBox = document.getElementById("txtIdPurchase");
             textBox.value = value;
             
             //   alert(value);
             return;

         }

         function SetSeason() {

             var value = igcmbo_getComboById("txtSeasons").getGrid().getActiveRow().DataKey;
             var textBox = document.getElementById("txtSeasonID");
             textBox.value = value;
         //       alert(value);
             return;

         }

         function SetSeasonField() {

             var statusList = document.getElementById("txtTeachers");


             var selectedStatus = statusList.options[statusList.selectedIndex].value; //statusList.selectedIndex;


             var textBox = document.getElementById("txtTeacherID");
             //textBox.appendChild = selectedStatus;

             textBox.value = selectedStatus;
             // alert(selectedStatus);
         }
         
         function SetStudentField() {

             var statusList = document.getElementById("txtStudents");


             var selectedStatus = statusList.options[statusList.selectedIndex].value; //statusList.selectedIndex;  

             var textBox = document.getElementById("txtStudentID");
             //textBox.appendChild = selectedStatus;

             textBox.value = selectedStatus;
             // alert(selectedStatus);
         }

function txtAlerts_ClickCellButtonHandler(gridName, cellId){
    //Add code to handle your event here.

    var value = igtbl_getGridById(gridName).getActiveRow().getCell(0).getValue();
    
    var textBox = document.getElementById("txtNoteID"); 
    textBox.value = value;

   // alert(value);
    
  /*  

    //Get reference to column object using ultrawebgrid utility function    
    var oColumn = igtbl_getColumnById(cellId);

    //Get reference to row object owning the cell 
    var oRow = igtbl_getRowById(cellId);

    var textAction = document.getElementById("txtAction");
    textAction.value = oColumn.Key;
*/
    //alert(oColumn.Key);
    
     return;
    
    //return;
}


function txtNotes_AfterCellUpdateHandler(gridName, cellId){
    //Add code to handle your event here.
    //alert("Ok");
    var answer = confirm("Are you having fun?")
    if (answer)
        alert("Woo Hoo! So am I.")
    else
        alert("Darn. Well, keep trying then.")


}

function txtNotes_ActiveRowHandler(gridName, cellId) {


    var value = igtbl_getGridById(gridName).getActiveRow().getCell(0).getValue();
    var textBox = document.getElementById("txtNoteID");
    textBox.value = value;

    value = igtbl_getGridById(gridName).getActiveRow().getCell(2).getValue();
    textBox = document.getElementById("txtNote");
    textBox.value = value;

    textBox = document.getElementById("txtChange");
    //textBox.value = "Change";
    //textBox.setAttribute("Visible", false);
   // textBox.className = "showControl";

    textBox = document.getElementById("txtDelete");
    //textBox.value = "Change";
    //textBox.setAttribute("Visible", false);
  //  textBox.className = "showControl";


    seccion1.style.display = "inline";

   // alert(value);
    
    /*
    igcmbo_getComboById("txtNote").setValue(value);

    value = igtbl_getGridById(gridName).getActiveRow().getCell(4).getValue();
    textBox = igdrp_getComboById("txtNote");
    textBox.setValue(value);

    value = igtbl_getGridById(gridName).getActiveRow().getCell(5).getValue();
    textBox = igdrp_getComboById("txtDateTo");
    textBox.setValue(value);

    textBox = document.getElementById("txtAdd");
    textBox.value = "Change";

    value = igtbl_getGridById(gridName).getActiveRow().getCell(0).getValue();
    textBox = document.getElementById("txtVisitId");
    textBox.value = value;
*/
    return;
}
// -->
</script>

    <form id="form2" runat="server">
        <cc2:Header ID="Header1" runat="server"  MenuType= "NoMenu" Banner="NoBanner" /> 
           <tr>
                <td>
                    <div>
                        
                    </div>
                    <cc2:Box ID="Box2" runat="server" Width="100%">
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
                                        <asp:HiddenField ID="txtSeasonID" runat="server" />
                                    </td>
                                    <td >
                                        Season :</td>
                                    <td class="style4">
                                        
                                        <asp:DropDownList ID="txtTeachers" runat="server" AutoPostBack="True" 
                                            Height="21px" 
                                            Width="80px" onselectedindexchanged="txtTeachers_SelectedIndexChanged" >
                                           
                                        </asp:DropDownList>
                                    
                                        <asp:HiddenField ID="txtTeacherID" runat="server" Value="-1" />
                                        
                                    </td>
                                    <td>
                                        <asp:Button ID="butAddItem" runat="server" onclick="butAddItem_Click" 
                                            TabIndex="7" text="Export to Excel" Width="120px" />
                                    </td>
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
                                        
                                        <asp:HiddenField ID="txtStudentID" runat="server" Value="-1" />
                                        <asp:DropDownList ID="txtStudents" runat="server" AutoPostBack="True" 
                                         Height="21px" 
                                         Width="301px" >
                                         
                                     </asp:DropDownList>
                                    </td>
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
                                    <td class="style5">
                                        </td>
                                    <td class="style5">
                                        Total:</td>
                                    <td class="style3">
                                        $<asp:Label ID="labTotal" runat="server" Font-Bold="True" Text="0.00"></asp:Label>
                                    </td>
                                    <td class="style5">
                                        </td>
                                    <td class="style5">
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
                                        <igtbl:UltraWebGrid ID="txtAlerts" runat="server" Height="208px" 
                                             Width="754px" >
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
                                                        <igtbl:UltraGridColumn Key="InvCode" Width="90px" Hidden="True">
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
                                                        <igtbl:UltraGridColumn Key="Note" Width="250px" AllowUpdate="Yes" 
                                                            CellMultiline="Yes">
                                                            <Header Caption="Note">
                                                                <RowLayoutColumnInfo OriginX="7" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="7" />
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
                                                    font-size="8.25pt" height="208px" width="754px">
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
                                    <td colspan="4" >
                                        <table border="0" width="100%">
                                            
                                            <tr>
                                               <td >
                                                     Note:
                                               </td>
                                               <td >
                                                    <asp:TextBox ID="txtNote" runat="server" Height="87px" Width="712px" 
                                                        TextMode="MultiLine"></asp:TextBox>
                                               </td>
                                               
                                            </tr>
                                            <tr>
                                               <td align="center" colspan="2" style="width:30%" >
                                                    <div id="seccion1" style="display:none">
                                                       <asp:Button ID="txtDelete" runat="server" Height="24px" onclick="txtDelete_Click"   
                                                        Text="Delete" Width="110px"  />         
                                                    <asp:Button ID="txtChange" runat="server" Height="24px" onclick="txtChange_Click" 
                                                        Text="Change" Width="110px" />
                                                    </div> 
                                                    <asp:Button ID="txtAdd" runat="server" Height="24px" onclick="txtAdd_Click" 
                                                        Text="Add Note" Width="110px" />
                                               </td>
                                               
                                               
                                            </tr>
                                        </table>
                                            
                                        
                                    </td>
                                    
                                    
                                    
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Notes:</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="txtNoteID" runat="server" />
                                    </td>
                                    <td colspan="4">
                                        <igtbl:UltraWebGrid ID="txtNotes" runat="server" Height="277px" Width="780px" 
                                            onclickcellbutton="txtNotes_ClickCellButton" >
                                            <bands>
                                                <igtbl:UltraGridBand ColHeadersVisible="Yes" GroupByColumnsHidden="Yes">
                                                    <Columns>
                                                        <igtbl:UltraGridColumn AllowUpdate="No" 
                                                            Key="NoteID" Width="70px" Hidden="True">
                                                            <header caption="Note ID">
                                                            </header>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn Key="User" Width="150px" AllowUpdate="No">
                                                            <header caption="Date">
                                                                <rowlayoutcolumninfo originx="1" />
                                                            </header>
                                                            <footer>
                                                                <rowlayoutcolumninfo originx="1" />
                                                            </footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn Key="Note" 
                                                            Width="590px" CellMultiline="Yes" AllowUpdate="No">
                                                            <header caption="Note">
                                                                <rowlayoutcolumninfo originx="1" />
                                                            </header>
                                                            <SelectedCellStyle Height="60px" Wrap="True">
                                                            </SelectedCellStyle>
                                                            <footer>
                                                                <rowlayoutcolumninfo originx="1" />
                                                            </footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn CellButtonDisplay="Always" Key="Save" Type="Button" 
                                                            Width="70px" Hidden="True" >
                                                            <Header>
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <CellButtonStyle Height="25px" Width="60px">
                                                            </CellButtonStyle>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                        </igtbl:UltraGridColumn>
                                                    </Columns>
                                                    <addnewrow view="NotSet" visible="NotSet">
                                                    </addnewrow>
                                                </igtbl:UltraGridBand>
                                            </bands>
                                            <displaylayout allowcolsizingdefault="Free" allowcolumnmovingdefault="OnServer" 
                                                allowdeletedefault="NotSet" allowsortingdefault="OnClient" bordercollapsedefault="Separate" 
                                                headerclickactiondefault="SortMulti" name="UltraWebGrid1" 
                                                rowheightdefault="60px" rowselectorsdefault="No" 
                                                selecttyperowdefault="Extended" stationarymargins="Header" 
                                                stationarymarginsoutlookgroupby="True" tablelayout="Fixed" version="4.00" 
                                                viewtype="OutlookGroupBy" SelectTypeCellDefault="Extended" 
                                                RowSizingDefault="Free">
                                                <framestyle backcolor="Window" bordercolor="InactiveCaption" 
                                                    borderstyle="Solid" borderwidth="1px" font-names="Microsoft Sans Serif" 
                                                    font-size="8.25pt" height="277px" width="780px">
                                                </framestyle>
                                                <clientsideevents 
                                                    AfterRowActivateHandler="txtNotes_ActiveRowHandler" 
                                                     />
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
                                                    horizontalalign="Left" Height="20px">
                                                    <borderdetails colorleft="White" colortop="White" widthleft="1px" 
                                                        widthtop="1px" />
                                                </headerstyledefault>
                                                <rowstyledefault backcolor="Window" bordercolor="Silver" borderstyle="Solid" 
                                                    borderwidth="1px" font-names="Microsoft Sans Serif" font-size="8.25pt" 
                                                    Height="60px">
                                                    <padding left="3px" />
                                                    <borderdetails colorleft="Window" colortop="Window" />
                                                </rowstyledefault>
                                                <groupbyrowstyledefault backcolor="Control" bordercolor="Window">
                                                </groupbyrowstyledefault>
                                                <SelectedRowStyleDefault Height="60px">
                                                </SelectedRowStyleDefault>
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
                        </table>
                    </cc2:Box>
                </td>
            </tr>
        <cc2:Footer ID="Footer1" runat="server" />
    </form>
