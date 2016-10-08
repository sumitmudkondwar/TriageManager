<%@ Page Title="Add New Content" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewContent.aspx.cs" Inherits="TriageManager.Triage.NewContent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:PlaceHolder runat="server">
        <div>

        </div>
    </asp:PlaceHolder>
</asp:Content>
