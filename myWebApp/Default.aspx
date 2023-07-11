<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="myWebApp._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Sample<asp:TextBox ID="txtWebhookURL" runat="server" Font-Size="Small" Width="1182px"></asp:TextBox>
            </h2>
            <p>
                Samples
            </p>
            <p>
                <a class="btn btn-default" href="/Pages/InheritSample.aspx">InheritSample</a>
                <a class="btn btn-default" href="/Pages/StackOverflowUsers.aspx">StackOverflow Users</a>
                <a class="btn btn-default" href="/Pages/SubDomains.aspx">SubDomains</a>
                <asp:Button ID="btnUnhandled" runat="server" OnClick="btnUnhandled_Click" Text="Exception is not handled" />
                <asp:Button ID="btnHandled" runat="server" OnClick="btnHandled_Click" Text="Exception is handled" />
                <asp:Button ID="btnWebhook" runat="server" OnClick="btnWebhook_Click" Text="Fire Webhook!" />
            </p>
        </div>
    </div>
</asp:Content>

