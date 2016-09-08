<%@ Page Title="Your Feedback Pending For" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FeedBackPending.aspx.cs" Inherits="TriageManager.Triage.FeedBackPending" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div>
        <asp:GridView ID="grdFeedBackPending" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                RowStyle-CssClass="rows">
            <Columns>
                <asp:BoundField DataField="Triage Date" HeaderText="Date" />
                <asp:BoundField DataField="TriageTopic" HeaderText="Topic" />
                <asp:BoundField DataField="Team1 Member" HeaderText="Team 1" />
                <asp:BoundField DataField="Team2 Member" HeaderText="Team 2" />
                <asp:BoundField DataField="TA Member" HeaderText="TA" />
                <asp:BoundField DataField="Triage Mentor" HeaderText="Mentor" />
                <asp:TemplateField HeaderText="Feedback">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# Eval("Triage Date", "~/Triage/MyPoll.aspx?TriageDate={0}") %>' Text="Submit" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contents">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# Eval("Triage Date", "~/Triage/Contents.aspx?TriageDate={0}") %>' Text="Contents" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

