<%@ Page Title="Triage Calender" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TriageCalender.aspx.cs" Inherits="TriageManager.Triage.TriageCalender" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <!--<h3>Click desired link for detailed report</h3>-->
    <hr />
    <div style="width:100%">
        <asp:GridView ID="grdTriageCalender" AutoGenerateColumns="false" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" Width="100%" >
            <Columns>
                <%--<asp:TemplateField HeaderText = "Contents">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" Text="Link" NavigateUrl='<%# Eval("Triage Date", "~/Triage/Contents.aspx?Id={0}") %>' />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:BoundField HeaderText="Triage Date" DataField="Triage Date" ItemStyle-Width="10%" />
                <asp:BoundField HeaderText="Topic" DataField="Topic" ItemStyle-Width="30%" />
                <asp:BoundField HeaderText="Team 1 Member" DataField="Team 1" ItemStyle-Width="13%" />
                <asp:BoundField HeaderText="Team 2 Member" DataField="Team 2" ItemStyle-Width="13%" />
                <asp:BoundField HeaderText="Mentor" DataField="Mentor" ItemStyle-Width="16%" />
                <asp:BoundField HeaderText="Triage Status" DataField="IsTriageCompleted" ItemStyle-Width="12%" />
                <asp:TemplateField HeaderText = "MyPoll" ItemStyle-Width="6%" >
                    <ItemTemplate>
                        <asp:Button ID="btnMyPoll" runat="server" Text="Submit Poll" OnClick="btnMyPoll_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
