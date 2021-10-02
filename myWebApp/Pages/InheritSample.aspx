<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InheritSample.aspx.cs" Inherits="myWebApp.Pages.InheritSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
          <table>
            <tr>
                  <th>Server Variable</th>
                  <th>Value</th>
            </tr>
            <tr>
                  <td>Original URL: </td>
                  <td><%= Request.ServerVariables["HTTP_X_ORIGINAL_URL"] %></td>
            </tr>
            <tr>
                  <td>Final URL: </td>
                  <td><%= Request.ServerVariables["SCRIPT_NAME"] + "?" + Request.ServerVariables["QUERY_STRING"] %></td>
            </tr>
            <tr>
                  <td>HTTP_HOST: </td>
                  <td><%= Request.ServerVariables["HTTP_HOST"] %></td>
            </tr>
              <tr>
                  <td>Google Auth</td>
                  <td>
                    <asp:HyperLink ID="MyHyperLink" runat="server" NavigateUrl="https://google.com" Target="_blank">HyperLink</asp:HyperLink>
                  </td>
              </tr>
      </table>

    <form id="form1" runat="server">
        <div>Hello World!
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <asp:GridView ID="GridViewSalesPerson" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
        <asp:GridView ID="GV2" runat="server" ItemType="myWebApp.Model.SalesPerson"
            selectMethod="GetSalesPerson"></asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </form>
                <table style="width:100%;">
                    <tr>
                        <td>SessionID</td>
                        <td>
                            <asp:Label ID="lblSessionId" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>ServiceID&nbsp;</td>
                        <td>
                            <asp:Label ID="lblServiceID" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td> </td>
                    </tr>
                </table>
</body>
</html>
