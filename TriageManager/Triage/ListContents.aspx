<%@ Page Title="List Contents" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListContents.aspx.cs" Inherits="TriageManager.Triage.ListContents" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <hr />
    <style>
      #accordion-resizer {
        padding: 10px;
        width: 60%;
        height: 350px;
      }
    </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#accordion").accordion({
                heightStyle: "fill"
            });

            $("#accordion-resizer").resizable({
                minHeight: 140,
                minWidth: 200,
                resize: function () {
                    $("#accordion").accordion("refresh");
                }
            });
        });
    </script>
    <asp:PlaceHolder runat="server">
        <div>
            Select Topic:
            <p>
                <asp:DropDownList ID="ddlHeading" runat="server" CssClass="form-control" Width="60%" OnSelectedIndexChanged="ddlHeading_SelectedIndexChanged" AutoPostBack="true" ToolTip="Select the subject for which you want to learn."></asp:DropDownList>
            </p>
        </div>
        <div id="accordion-resizer" class="ui-widget-content">
            <div id="accordion">
                <h3>Level 100</h3>
                <div>
                    <p>
                        <asp:GridView ID="grd100" Width="100%" AutoGenerateColumns="false" runat="server" GridLines="None" ShowHeader="false">
                            <Columns>
                                <%--<asp:BoundField DataField="Row" HeaderText="" />--%>
                                <asp:HyperLinkField DataTextField="FileList" ControlStyle-ForeColor="Blue" DataNavigateUrlFormatString="https://aztriagestorage.blob.core.windows.net/mycontainer/{0}" DataNavigateUrlFields="FilePath"
                                    HeaderText="File List" />
                            </Columns>
                        </asp:GridView>
                    </p>
                </div>
                <h3>Level 200</h3>
                <div>
                    <p>
                        <asp:GridView ID="grd200" Width="100%" AutoGenerateColumns="false" runat="server" GridLines="None" ShowHeader="false">
                            <Columns>
                                <%--<asp:BoundField DataField="Row" HeaderText="" />--%>
                                <asp:HyperLinkField DataTextField="FileList" ControlStyle-ForeColor="Blue" DataNavigateUrlFormatString="https://aztriagestorage.blob.core.windows.net/mycontainer/{0}" DataNavigateUrlFields="FilePath" />
                            </Columns>
                        </asp:GridView>
                    </p>
                </div>
                <h3>Level 300</h3>
                <div>
                    <p>
                        <asp:GridView ID="grd300" Width="100%" AutoGenerateColumns="false" runat="server" GridLines="None" ShowHeader="false">
                            <Columns>
                                <%--<asp:BoundField DataField="Row" HeaderText="" />--%>
                                <asp:HyperLinkField DataTextField="FileList" ControlStyle-ForeColor="Blue" DataNavigateUrlFormatString="https://aztriagestorage.blob.core.windows.net/mycontainer/{0}" DataNavigateUrlFields="FilePath" />
                            </Columns>
                        </asp:GridView>
                    </p>
                </div>
                <h3>Level 400</h3>
                <div>
                    <p>
                        <asp:GridView ID="grd400" Width="100%" AutoGenerateColumns="false" runat="server" GridLines="None" ShowHeader="false">
                            <Columns>
                                <%--<asp:BoundField DataField="Row" HeaderText="" />--%>
                                <asp:HyperLinkField DataTextField="FileList" ControlStyle-ForeColor="Blue" DataNavigateUrlFormatString="https://aztriagestorage.blob.core.windows.net/mycontainer/{0}" DataNavigateUrlFields="FilePath"
                                    HeaderText="File List" />
                            </Columns>
                        </asp:GridView>
                    </p>
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
