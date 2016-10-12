<%@ Page Title="Content Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContentDetails.aspx.cs" Inherits="TriageManager.Triage.ContentDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Label ID="lblTopic" runat="server"></asp:Label></h2>
    <hr />
    <asp:PlaceHolder runat="server">
        <div>
            <table style="width: 100%">
                <tr style="width: 100%">
                    <td style="width: 60%">
                        <b>Contributor:</b>
                        <asp:Label ID="lblContributor" runat="server"></asp:Label>
                        <p>&nbsp;</p>
                        <b>Topic Description:</b>
                        <p>
                            <asp:TextBox ID="txtDescription" ReadOnly="true" CssClass="form-control" TextMode="MultiLine" Width="80%" Height="200px" runat="server"></asp:TextBox>
                        </p>
                    </td>
                    <td style="width: 40%">
                        <asp:GridView ID="grdListFiles" AutoGenerateColumns="false" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                            RowStyle-CssClass="rows">
                            <Columns>
                                <asp:HyperLinkField DataTextField="FileList" DataNavigateUrlFormatString="https://aztriagestorage.blob.core.windows.net/mycontainer/{0}" DataNavigateUrlFields="FilePath"
                                    HeaderText="File List" />
                            </Columns>
                        </asp:GridView>

                        
                    </td>
                </tr>
            </table>

        </div>
    </asp:PlaceHolder>
</asp:Content>
