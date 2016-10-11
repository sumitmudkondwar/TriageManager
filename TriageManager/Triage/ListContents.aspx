<%@ Page Title="List Contents" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListContents.aspx.cs" Inherits="TriageManager.Triage.ListContents" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <asp:PlaceHolder runat="server">
        <div>
            <asp:GridView ID="grdListContents" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows">
                <Columns>
                    <%--<asp:BoundField DataField="ContentHeading" HeaderText="Content Heading" />--%>
                    <asp:HyperLinkField DataTextField="ContentHeading" 
                         
                        NavigateUrl='<%# Eval("ContentHeading","~/Triage/ContentDetails.aspx?ContentGUID{0}" ) %>'
                        DataNavigateUrlFields="ContentHeading" HeaderText="Content Heading" />
                    <asp:BoundField DataField="EmailId" HeaderText="EmailId" />
                </Columns>
            </asp:GridView>
        </div>
    </asp:PlaceHolder>
</asp:Content>
