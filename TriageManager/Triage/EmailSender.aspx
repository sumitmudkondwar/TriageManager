<%@ Page Title="Email Sender" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmailSender.aspx.cs" Inherits="TriageManager.Triage.EmailSender" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:PlaceHolder runat="server">
        <div>

        </div>
    </asp:PlaceHolder>
</asp:Content>
