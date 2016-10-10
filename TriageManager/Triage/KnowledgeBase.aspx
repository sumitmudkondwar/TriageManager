<%@ Page Title="Knowledge Base" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="KnowledgeBase.aspx.cs" Inherits="TriageManager.Triage.KnowledgeBase" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <asp:PlaceHolder runat="server">
        <div>
            <ul style="list-style:none">
                <li><a runat="server" class="form-control" style="width:20%; text-decoration:none" href="~/Triage/NewContent">Add New Content</a></li>
                <br />
                <li><a runat="server" class="form-control" style="width:20%; text-decoration:none" href="~/Triage/NewContent">Content List</a></li>
            </ul>
        </div>
    </asp:PlaceHolder>
</asp:Content>
