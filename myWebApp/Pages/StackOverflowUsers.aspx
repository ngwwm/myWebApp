<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StackOverflowUsers.aspx.cs" Inherits="myWebApp.Pages.StackOverflowUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                  <asp:GridView ID="gridViewStackOverflowUser" runat="server" ItemType="myWebApp.Model.StackOverflowUser"
            selectMethod="GetUsers"></asp:GridView>
        </div>
    </form>
</body>
</html>
