<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmOrderByDate_2.aspx.cs" Inherits="Signature.Campaign.frmOrderByDate_2" %>

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
        .style3
        {
            width: 164px;
        }
        .style4
        {
            width: 72px;
        }
        .style5
        {
            height: 43px;
        }
    </style>
    
    <script id="igClientScript" type="text/javascript">
           
    </script> 
    
        <script type="text/javascript" id="Infragistics">
<!--

<!--

<!--


function Teachers_EditKeyDown(webComboId, newValue, keyCode) {
            var warp = ig$('<%# warpTeachers.ClientID %>');
            if (!warp)
                return;
            //   combo.setDisplayValue(combo.getValue());
            //   warp.refresh();
            

}
// -->

function warpTeachers_RefreshRequest(oPanel,oEvent,id){
    // cancel request when Button1 was clicked
	 if (id == 'Teachers')
	 {  
        //oEvent.cancel = true;
       // alert("canceled");
        }
     if (id == 'Students')
	 {
        oEvent.cancel = true;
        alert("canceled");
     }
    // keep request, but cancel response: notify 
    // server about Button2 click
    
     //   oEvent.cancelResponse = true;
    // trigger full postback instead of asynchronous 
    // when Button3 was clicked
    if (id == 'Button3')
        oEvent.fullPostBack = true;

}
// -->

function Students_BeforeCloseUp(webComboId){
       // alert("warp refresh()");
        var warp = ig$('<%# warpStudents.ClientID %>');
            if (!warp)
                return;
            //   combo.setDisplayValue(combo.getValue());
        warp.refresh();
       // alert("warp refresh()");
	
}
// -->
</script> 
    </head>
 
    

    <form id="form2" runat="server">
        <cc1:Header ID="Header1" runat="server" MenuType= "CampaigneMenu" /> 
           <tr>
                <td>
                    <div>
                        
                    </div>
                    <cc1:Box ID="Box1" runat="server" Width="100%">
                        <table width="70%" border="0">
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
                                    <igmisc:WebAsyncRefreshPanel ID="warpTeachers" runat="server" Height="20px"
                                        Width="100%" RefreshRequest="warpTeachers_RefreshRequest" 
                                        RefreshTargetIDs="warpStudents">
                                     
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
                                     </igmisc:WebAsyncRefreshPanel>
                                </td>
                            </tr>
                            <tr align='left'>
                                <td class="style4" >
                                    &nbsp;</td>
                                <td>
                                    Students:
                                </td>
                                <td >
                                    <igmisc:WebAsyncRefreshPanel ID="warpStudents" runat="server" Height="20px"
                                        Width="80px" RefreshRequest="warpTeachers_RefreshRequest" 
                                        >
                                      
                                     <igcmbo:WebCombo ID="Students" runat="server" BackColor="White" 
                                           BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" 
                                           SelBackColor="DarkBlue" SelForeColor="White" Version="4.00" 
                                        Editable="True" Width="300px" onselectedrowchanged="Students_SelectedRowChanged" >
                                        <ClientSideEvents BeforeCloseUp="Students_BeforeCloseUp" />
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
                                    
                                     
                                    </igmisc:WebAsyncRefreshPanel>
                                </td>
                            </tr>
                            
                            <tr  height="50px"  >
                               <td align="center" colspan="3" valign="top" height="50PX">
                                    <igmisc:WebAsyncRefreshPanel ID="warpGrid" runat="server" Height="20px"
                                       Width="100%" TriggerControlIDs="butAddItem,Students">
                                   <table>
                                        <tr>
                                            <td  width="100%">
                                                <asp:Label ID="labDescription" runat="server"></asp:Label>
                                            </td>
                                       </tr>
                                       <tr>
                                            <td align="center">
                                                <asp:placeholder ID='Orders' runat="server">
                                                </asp:placeholder>
                                                
                                            </td>
                                       </tr>
                                   
                                   </table>
                                   </igmisc:WebAsyncRefreshPanel>
                               </td>
                            </tr>
                            <tr>
                               <td class="style5" colspan="3">
                                   <igmisc:WebAsyncRefreshPanel ID="warpAddItem" runat="server" Width="100%">           
                                   
                                   <table style="width: 100%; height: 35px;">
                                       <tr>
                                           <td style="width: 80px;" class="style7">
                                               Date&nbsp; :</td>
                                           <td class="style3">
                                               <igsch:WebDateChooser ID="txtEarlyBirdDate" runat="server" Value="">
                                               </igsch:WebDateChooser>
                                           </td>
                                           <td align="center" class="style9">
                                               Items :</td>
                                           <td align="center" class="style11">
                                               <asp:textBox ID="txtQuantity" runat="server" Height="20px" Width="86px"></asp:textBox>
                                           </td>
                                       
                                           <td>
                                               <asp:button ID="butAddItem" runat="server" text="Add" 
                                                   onclick="butAddItem_Click" Width="63px" />
                                           </td>
                                       </tr>
                                   </table>
                                    </igmisc:WebAsyncRefreshPanel>        
                               </td>
                            </tr>
                            
                               
                        </table>
                    </cc1:Box>
                </td>
            </tr>
        <cc1:Footer ID="Footer1" runat="server" />
    </form>
