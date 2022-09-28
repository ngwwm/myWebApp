<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubDomains.aspx.cs" Inherits="myWebApp.Pages.SubDomains" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gridViewSubDomains" runat="server" ItemType="myWebApp.Model.ReservedSubDomain" selectMethod="GetSubDomains"></asp:GridView>
        </div>
    </form>
</body>
</html>
