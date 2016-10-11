<%@ Page Title="Contents Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContentDetails.aspx.cs" Inherits="TriageManager.Triage.ContentDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <asp:PlaceHolder runat="server">
        <div>
            
        </div>
    </asp:PlaceHolder>
</asp:Content>
