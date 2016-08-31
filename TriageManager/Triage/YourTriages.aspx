<%@ Page Title="Your Triages" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YourTriages.aspx.cs" Inherits="TriageManager.Triage.YourTriages" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>List of Triages belongs to you...</h3>
    <hr />
    <div>
        <asp:GridView ID="grdYourTriages" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows"></asp:GridView>
    </div>
</asp:Content>
