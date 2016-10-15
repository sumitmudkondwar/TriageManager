<%@ Page Title="List Contents" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListContents.aspx.cs" Inherits="TriageManager.Triage.ListContents" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <asp:PlaceHolder runat="server">
        <div>
            <%--<asp:GridView ID="grdListContents" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows">
                <Columns>
                    <asp:BoundField DataField="Contributor" HeaderText="Contributor" />
                    <asp:HyperLinkField DataTextField="ContentHeading" DataNavigateUrlFormatString="~/Triage/ContentDetails.aspx?GUID={0}&ContentHeading={1}"
                        DataNavigateUrlFields="contentGUID,ContentHeading" HeaderText="Topic to Learn" />
                </Columns>
            </asp:GridView>--%>
            Select Topic:
            <p>
                <asp:DropDownList ID="ddlHeading" runat="server" CssClass="form-control" Width="60%" OnSelectedIndexChanged="ddlHeading_SelectedIndexChanged" AutoPostBack="true" ToolTip="Select the subject for which you want to learn."></asp:DropDownList>
            </p>
        </div>
        <div>
            <table border="1" style="width:100%">
                <tr>
                    <td style="width:10%; text-align:center">
                        <b>Level</b>
                    </td>
                    <td style="width:90%;">
                        <b>Content</b>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%; text-align:center">
                        100
                    </td>
                    <td>
                        <asp:GridView ID="grd100"  AutoGenerateColumns="false" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                            RowStyle-CssClass="rows">
                            <Columns>
                                <asp:HyperLinkField DataTextField="FileList" DataNavigateUrlFormatString="https://aztriagestorage.blob.core.windows.net/mycontainer/{0}" DataNavigateUrlFields="FilePath"
                                    HeaderText="File List" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%; text-align:center">
                        200
                    </td>
                    <td>
                        <asp:GridView ID="grd200"  AutoGenerateColumns="false" runat="server" col>
                            <Columns>
                                <asp:HyperLinkField DataTextField="FileList" DataNavigateUrlFormatString="https://aztriagestorage.blob.core.windows.net/mycontainer/{0}" DataNavigateUrlFields="FilePath" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%; text-align:center">
                        300
                    </td>
                    <td>
                        <asp:GridView ID="grd300"  AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:HyperLinkField DataTextField="FileList" DataNavigateUrlFormatString="https://aztriagestorage.blob.core.windows.net/mycontainer/{0}" DataNavigateUrlFields="FilePath" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width:10%; text-align:center">
                        400
                    </td>
                    <td>
                        <asp:GridView ID="grd400"  AutoGenerateColumns="false" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
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
