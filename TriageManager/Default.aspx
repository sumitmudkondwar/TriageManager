<%@ Page Title="Home Page - Azure App Service SME Program" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TriageManager._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Azure App Service SME Program</h1>
        <p class="lead">Become SME and contribute towards learning of self, peers locally and globally to exceed customer expectations and grow into next level.</p>
        <%--<p><a href="" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
        <div>
        </div>
    </div>
    <div style="margin-left: 10%">
        <div>
            <a runat="server" href="~/Triage/YourTriages">Your Triages</a>
        </div>
        <div id="dvFeedBackPending" runat="server">
            <br />
            <br />
            <br />
            <a runat="server" style="color: red" href="~/Triage/FeedBackPending">Your Feedback is Pending!!!</a>
        </div>
        <br />
        <br />
        <br />
        <asp:GridView ID="grdDashboard" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Triage" HeaderText="" />
                <asp:BoundField DataField="Triage Date" HeaderText="Date" />
                <asp:BoundField DataField="TriageTopic" HeaderText="Topic" />
                <asp:BoundField DataField="Team1 Member" HeaderText="Team 1" />
                <asp:BoundField DataField="Team2 Member" HeaderText="Team 2" />
                <asp:BoundField DataField="TA Member" HeaderText="TA" />
                <asp:BoundField DataField="Triage Mentor" HeaderText="Mentor" />
                <%--<asp:TemplateField HeaderText="Feedback">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# Eval("Triage Date", "~/Triage/MyPoll.aspx?Id={0}") %>' Text="Submit" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contents">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# Eval("Triage Date", "~/Triage/Contents.aspx?Id={0}") %>' Text="Contents" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
    </div>

</asp:Content>
