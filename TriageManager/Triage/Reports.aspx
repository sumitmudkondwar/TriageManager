<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="TriageManager.Triage.Reports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Feedback</h3>
    <hr />
    <div>
        <div>
            <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="True" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                RowStyle-CssClass="rows">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
