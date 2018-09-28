<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmStudent.aspx.cs" Inherits="Signature.Campaign.frmStudent" %>

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
            width: 577px;
            height: 29px;
        }
        .style14
        {
            width: 127px;
            height: 39px;
        }
        .style16
        {
            width: 127px;
            height: 17px;
        }
        .style17
        {
            width: 577px;
            height: 22px;
        }
        .style19
        {
            width: 577px;
            height: 13px;
        }
        .style21
        {
            width: 577px;
            height: 31px;
        }
        .style27
        {
            height: 6px;
        }
        .style28
        {
            width: 115px;
            height: 6px;
        }
        .style29
        {
            width: 72px;
            height: 31px;
        }
        .style30
        {
            width: 72px;
            height: 22px;
        }
        .style31
        {
            width: 72px;
            height: 13px;
        }
        .style32
        {
            width: 72px;
            height: 29px;
        }
        .style33
        {
            width: 435px;
            height: 39px;
        }
        .style34
        {
            width: 435px;
            height: 17px;
        }
        .style35
        {
            width: 127px;
        }
        .style36
        {
            width: 416px;
            height: 39px;
        }
        .style37
        {
            width: 416px;
            height: 17px;
        }
        </style>
        <script language="javascript" type="text/javascript">

        function SetField() {

            var statusList = document.getElementById("txtNameEdit");


            var selectedStatus = statusList.value;  //statusList.options[statusList.selectedIndex].value;

            
            var textBox = document.getElementById("txtSName");
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
                        <table width="80%" border="0" style="color:Blue" >
                        <tr>
                            <td>
                            <table border="0" >
                            <tr  style="height:40px; width:20%">
                                <td   colspan="2">
                                    &nbsp;</td>
                                
                                <td class="style35">
                                    &nbsp;</td>
                                
                            </tr>
                            <tr align='left'>
                                <td >
                                    School Name: </td>
                                <td >
                                    <asp:Label ID="txtName" runat="server" Font-Bold="True" Font-Size="Small" 
                                        Text="Label"></asp:Label>
                                </td>
                                <td >
                                    &nbsp;</td>
                            </tr>
                            
                            
                                <tr>
                                    <td >
                                        Teacher Name:</td>
                                    <td >
                                        <asp:Label ID="txtTeacherName" runat="server" Font-Bold="True" 
                                            Font-Size="X-Small" Text="Label"></asp:Label>
                                    </td>
                                    <td >
                                        &nbsp;</td>
                                </tr>
                            
                            
                            <tr align='left'>
                                <td >
                                </td>
                                <td >
                                    &nbsp;</td>
                                <td >
                                    &nbsp;</td>
                            </tr>
                            
                            
                            <tr align="left">
                                <td >
                                    Student Name:</td>
                                <td >
                                    <asp:TextBox ID="txtStudentName" runat="server" Width="410px"></asp:TextBox>
                                </td>
                                <td >
                                    <asp:Button ID="butSave" runat="server" onclick="butSave_Click" text="Add" 
                                        Width="83px" />
                                </td>
                            </tr>
                            
                            <tr align="left">
                               <td >
                                  
                                   Number of Students:</td>
                                <td >
                                    <asp:TextBox ID="txtNoStudents" runat="server" Width="72px"></asp:TextBox>
                                </td>
                                <td >
                                    <asp:Button ID="butApply" runat="server" onclick="butApply_Click" text="Apply" 
                                        Width="83px" />
                                </td>
                                </tr>
                                <tr align="left">
                                    <td >
                                        &nbsp;</td>
                                    <td >
                                        <span>Please enter the number of students in this class and enter APPLY</span></td>
                                    <td >
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <table style="width: 108%;">
                                            <tr>
                                                <td colspan="2" class="style28" style="color: #000000; font-weight: bold">
                                                    &nbsp;</td>
                                                <td align="right" class="style27" style="color: #000000; font-weight: bold" 
                                                    valign="middle">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    &nbsp;</td>
                                                <td >
                                                    <asp:HiddenField ID="txtSName" runat="server" />
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    &nbsp;</td>
                                                <td >
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  style="color: #000000; font-weight: bold">
                                                    &nbsp;</td>
                                                <td  style="color: #000000; font-weight: bold">
                                                    Current Students</td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    &nbsp;</td>
                                                <td >
                                                    <asp:PlaceHolder ID="Teachers" runat="server"></asp:PlaceHolder>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td >
                                                    &nbsp;</td>
                                                <td >
                                                    &nbsp;<asp:Button ID="butBack" runat="server" Height="22px" onclick="butBack_Click" 
                                                        text="Back" Width="77px" />
                                                </td>
                                            </tr>
                                        </table>
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