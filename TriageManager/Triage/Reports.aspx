<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="TriageManager.Triage.Reports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Feedback</h2>
    <hr />
    <div>
        <div id="dvSelectEngineer" runat="server">
            <b>Report Type:</b>
            <asp:DropDownList ID="ddlReportType" Width="25%" CssClass="form-control" runat="server">
                <%--<asp:ListItem Text="Engineers Attended Triage" Value="1"></asp:ListItem>
                <asp:ListItem Text="Engineers Not Attended Triage" Value="2"></asp:ListItem>--%>
                <asp:ListItem Text="Engineers Submitted Poll" Value="1"></asp:ListItem>
                <asp:ListItem Text="Engineers Not Submitted Poll" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <b>Select Engineer:</b>
            <asp:DropDownList ID="ddlEngineerName" AutoPostBack="true" OnSelectedIndexChanged="ddlEngineerName_SelectedIndexChanged" Width="25%" CssClass="form-control" runat="server"></asp:DropDownList>
            <br />
            <b>Select Triage Date:</b>
            <asp:DropDownList ID="ddlTriageDates" Width="25%" CssClass="form-control" runat="server"></asp:DropDownList>
            <br />
            <asp:Button runat="server" ID="btnGetReport" Text="Submit" Width="10%" OnClick="btnGetReport_Click" CssClass="form-control" />
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <div>
            <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="True" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                RowStyle-CssClass="rows">
            </asp:GridView>
        </div>
        <br />
    </div>
</asp:Content>
