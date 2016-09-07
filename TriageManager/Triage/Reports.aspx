<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="TriageManager.Triage.Reports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Feedback</h2>
    <hr />
    <div>
        <div id="dvSelectEngineer" runat="server">
            <b>Select Engineer:</b>
            <asp:DropDownList ID="ddlEngineerName" AutoPostBack="true" OnSelectedIndexChanged="ddlEngineerName_SelectedIndexChanged" Width="20%" CssClass="form-control" runat="server"></asp:DropDownList>
            <br />
            <b>Select Triage Date:</b>
            <asp:DropDownList ID="ddlTriageDates" Width="20%" CssClass="form-control" runat="server"></asp:DropDownList>
            <br />
            <asp:Button runat="server" ID="btnGetReport" Text="Submit" Width="10%" OnClick="btnGetReport_Click" CssClass="form-control" />
        </div>
        <br />
        <br />
        <div>
            <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="True" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                RowStyle-CssClass="rows">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
