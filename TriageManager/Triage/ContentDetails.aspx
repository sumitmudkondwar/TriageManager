<%@ Page Title="Content Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContentDetails.aspx.cs" Inherits="TriageManager.Triage.ContentDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Label ID="lblTopic" runat="server"></asp:Label></h2>
    <hr />
    <asp:PlaceHolder runat="server">
        <div>
            
        </div>
    </asp:PlaceHolder>
</asp:Content>
