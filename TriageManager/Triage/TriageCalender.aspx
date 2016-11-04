<%@ Page Title="Triage Calender" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TriageCalender.aspx.cs" Inherits="TriageManager.Triage.TriageCalender" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <!--<h3>Click desired link for detailed report</h3>-->
    <hr />
    <div>
        <asp:GridView ID="grdTriageCalender" AutoGenerateColumns="false" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" >
            <Columns>
                <%--<asp:TemplateField HeaderText = "Contents">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" Text="Link" NavigateUrl='<%# Eval("Triage Date", "~/Triage/Contents.aspx?Id={0}") %>' />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField HeaderText="Triage-Date" DataField="Triage Date" />
                <asp:BoundField HeaderText="Topic" DataField="Topic" />
                <asp:BoundField HeaderText="Team 1 Member" DataField="Team 1" />
                <asp:BoundField HeaderText="Team 2 Member" DataField="Team 2" />
                <asp:BoundField HeaderText="TA" DataField="TA" />
                <asp:BoundField HeaderText="Mentor" DataField="Mentor" />
                <asp:BoundField HeaderText="Triage Status" DataField="IsTriageCompleted" />
                <asp:TemplateField HeaderText = "MyPoll">
                    <ItemTemplate>
                        <asp:Button ID="btnMyPoll" runat="server" Text="Submit Poll" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
