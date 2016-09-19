<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="TriageManager.Triage.Reports" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Feedback</h2>
    <hr />
    <div>
        <div id="dvSelectEngineer" runat="server">
            <div>
                <asp:Label runat="server" ID="lblErrorMessage" ForeColor="Red"></asp:Label>
            </div>
            <br />
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
        <asp:Button runat="server" ID="btnSendMailforPollSubmit" ToolTip="Send Mail to All the Enginees, informing to Submit their Poll." Text="Send Mail to Engineers" Width="15%" CssClass="form-control" OnClick="btnSendMailforPollSubmit_Click" />
        <br />
        <div>
            <asp:GridView ID="grdReport" runat="server" AutoGenerateColumns="false" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                RowStyle-CssClass="rows">
                <Columns>
                    <asp:BoundField DataField="List of Engineers Not Submitted Poll" HeaderText="List of Engineers Not Submitted Poll" />
                    <asp:BoundField DataField="Email ID" HeaderText="Email ID" />
                    <asp:BoundField DataField="Alias" HeaderText="Alias" />
                    <%--<asp:ButtonField ButtonType="Button" Text="Send Mail" ControlStyle-CssClass="form-control" HeaderText="Send Mail" />--%>
                </Columns>
            </asp:GridView>
        </div>
        <br />
    </div>
</asp:Content>
