<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTeacher.aspx.cs" Inherits="Signature.Campaign.frmTeacher" %>

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
    
    
    

<cc1:Head ID="Head1" runat="server" />
   
    <style type="text/css">
        .style6
        {
            width: 55%;
        }
        .style12
        {
            width: 797px;
        }
        .style13
        {
            width: 98px;
            height: 39px;
        }
        .style15
        {
            width: 98px;
            height: 17px;
        }
        .style16
        {
            width: 55%;
            height: 17px;
        }
        .style21
        {
            width: 98px;
            height: 30px;
        }
        .style22
        {
            width: 55%;
            height: 30px;
        }
        .style26
        {
            height: 25px;
            width: 797px;
        }
        .style27
        {
            width: 131px;
        }
        .style31
        {
            height: 20px;
            width: 797px;
        }
        .style32
        {
            width: 131px;
            height: 39px;
        }
        .style33
        {
            width: 131px;
            height: 17px;
        }
        .style34
        {
            width: 131px;
            height: 30px;
        }
        </style>
        <script language="javascript" type="text/javascript">

        function SetField() {

            var statusList = document.getElementById("txtNameEdit");


            var selectedStatus = statusList.value;  //statusList.options[statusList.selectedIndex].value;

            
            var textBox = document.getElementById("txtTName");
            //textBox.appendChild = selectedStatus;

            textBox.value = selectedStatus;
           // alert(selectedStatus);
        }
        
    </script>
    
    </head>
 
    <body>

    <form id="form2" runat="server">
        <cc1:Header ID="Header1" runat="server" MenuType= "CampaigneMenu" /> 
           <tr>
                <td>
                    <div>
                        
                    </div>
                    <cc1:Box ID="Box1" runat="server" Width="100%">
                        <table width="70%" border="0" style="color:Blue" >
                        <tr>
                            <td>
                            <table width="100%" border="0" >
                            <tr style="height:40">
                                <td  class="style27">
                                    &nbsp;</td>
                                
                                <td class="style6">
                                    &nbsp;</td>
                                
                            </tr>
                            <tr align='left'>
                                <td  class="style32">
                                    &nbsp;</td>
                                <td class="style13" align="right">
                                    &nbsp;</td>
                                <td >
                                    &nbsp;</td>
                                <td>
                                   To import data from a MS Excel file, please click the Excel Import tab</td>
                            </tr>
                            
                            
                                <tr align="left">
                                    <td class="style32">
                                        &nbsp;</td>
                                    <td align="right" class="style13">
                                        School Name:
                                    </td>
                                    <td>
                                        <asp:Label ID="txtName" runat="server" Font-Bold="True" Font-Size="Small" 
                                            Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Button ID="butSave0" runat="server" onclick="butImport_Excel" 
                                            text="Excel Import" Width="83px" />
                                    </td>
                                </tr>
                            
                            
                            <tr align='left'>
                                <td class="style33" >
                                    &nbsp;</td>
                                <td class="style15">
                                </td>
                                <td class="style16">
                                    &nbsp;
                                    </td>
                            </tr>
                            
                            
                            <tr align="left">
                                <td class="style34">
                                    &nbsp;</td>
                                <td class="style21" align="right">
                                    Teacher Name:</td>
                                <td class="style22">
                                    <asp:TextBox ID="txtTeacherName" runat="server" Width="410px"></asp:TextBox>
                                </td>
                                <td class="style22">
                                    
                                    <asp:Button ID="butSave" runat="server" onclick="butSave_Click" text="Add" 
                                        Width="83px" />
                                    
                                </td>
                            </tr>
                            
                            <tr>
                               
                                <td align="center" colspan="4">
                                    <table style="width: 100%; height: 93px;">
                                        <tr>
                                            <td >
                                            </td>
                                            <td align="right" class="style26" valign="middle">
                                                <asp:HiddenField ID="txtTName" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:10%" ></td>
                                            <td  style="color: #000000; font-weight: bold" class="style31">
                                                Current Teachers
                                            </td>
                                            <td style="width:10%" ></td>
                                        </tr>
                                        <tr>
                                            <td style="width:10%" ></td>
                                            <td class="style12" >
                                                <asp:PlaceHolder ID="Teachers" runat="server"></asp:PlaceHolder>
                                            </td>
                                            <td style="width:10%" ></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                               <td class="style27">
                                  
                                   &nbsp;</td>
                                <td colspan="2">
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
    </body>
    </html>
