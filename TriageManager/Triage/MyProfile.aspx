<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="TriageManager.Triage.MyProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    
    <div>
        <div id="divAuthentic" runat="server">
            <div>
                <asp:Label ID="lblAuthentication" runat="server"></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblPrincipleName" runat="server"></asp:Label>
            </div>
            <div>
                <span>
                    <a href="/.auth/logout">Logout</a>
                </span>
            </div>
            <br />
            <div>
                <span>
                    <strong>x-ms-client-principal-name:</strong>
                    <br />
                    <asp:Label ID="lblRequestHeaders" runat="server"></asp:Label>
                </span>
            </div>
            <br />
            <div><strong>Raw Claims</strong></div>
            <table border="1">
                <asp:GridView ID="grdClaimPrinciple" runat="server"></asp:GridView>
            </table>
        </div>
        <div id="divUnauthentic" runat="server">
            <h2>User Unauthenticated</h2>
            <div><span><strong><a href="/.auth/login/aad">Login with AAD</a></strong></span></div>
            <div><span><strong><a href="/.auth/login/facebook">Login with Facebook</a></strong></span></div>
            <div><span><strong><a href="/.auth/login/twitter">Login with Twitter</a></strong></span></div>
            <div><span><strong><a href="/.auth/login/microsoftaccount">Login with Microsoft Account</a></strong></span></div>
            <div><span><strong><a href="/.auth/login/google">Login with Google</a></strong></span></div>
        </div>
    </div>
    <div>
        <div><strong>Raw HTTP Headers</strong></div>
        <table border="1">
            <asp:GridView ID="grdRawHTTPHeaders" runat="server"></asp:GridView>
        </table>
    </div>
</asp:Content>
