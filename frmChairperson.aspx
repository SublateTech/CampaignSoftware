<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmChairperson.aspx.cs" Inherits="Campaign.frmChairperson" %>



<%@ Register Assembly="Signature.Web.Controls" Namespace="Signature.Web.Controls" TagPrefix="cc1" %>



<head runat="server">
    <title></title>

<script language="javascript" type="text/javascript">
//    setTimeout ( "doSomething()", 1500 );

function doSomething ( )
{
  // (do something here)
    // setTimeout ( "doSomething()", 5000 );
    var textBox = document.getElementById("butGo");
    textBox.submit();
    //alert("Ok");
    
}

function doPost() 
    {
        document.getElementById("TestForm").submit();
    }

</script>

</head>
<body onload="doPost()">
    
    <form id="TestForm" runat="server" action="http://www.signaturefundraising.net/db_chair_main.php" method="post">
        <cc1:Header ID="Header1" runat="server" MenuType= "NoMenu" /> 
        <asp:HiddenField ID="txtCustomerID" runat="server" /> 
        <asp:HiddenField ID="txtCompanyID" runat="server" />
        <cc1:Footer ID="Footer1" runat="server" />
  </form>
</body>

