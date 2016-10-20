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
                        <asp:GridView ID="grd100" Width="100%" AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:HyperLinkField HeaderText="Level 100 Contents" DataTextField="FileList" ControlStyle-ForeColor="Blue" DataNavigateUrlFormatString="{0}" Target="_blank" DataNavigateUrlFields="FilePath" />
                                <asp:TemplateField HeaderText = "Update Content Level">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTriageLevel100" runat="server">
                                            <asp:ListItem Text="100" Value="100" Selected="True" Enabled="false"></asp:ListItem>
                                            <asp:ListItem Text="200" Value="200"></asp:ListItem>
                                            <asp:ListItem Text="300" Value="300"></asp:ListItem>
                                            <asp:ListItem Text="400" Value="400"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnTriageLevel100" runat="server" Text="Update" OnClick="btnTriageLevel100_Click"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </p>
                </div>
                <h3>Level 200</h3>
                <div>
                    <p>
                        <asp:GridView ID="grd200" Width="100%" AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:HyperLinkField HeaderText="Level 200 Contents" DataTextField="FileList" ControlStyle-ForeColor="Blue" DataNavigateUrlFormatString="{0}" Target="_blank" DataNavigateUrlFields="FilePath" />
                                <asp:TemplateField HeaderText = "Update Content Level">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTriageLevel200" runat="server">
                                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                            <asp:ListItem Text="200" Value="200" Selected="True" Enabled="false"></asp:ListItem>
                                            <asp:ListItem Text="300" Value="300"></asp:ListItem>
                                            <asp:ListItem Text="400" Value="400"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnTriageLevel200" runat="server" Text="Update" OnClick="btnTriageLevel200_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </p>
                </div>
                <h3>Level 300</h3>
                <div>
                    <p>
                        <asp:GridView ID="grd300" Width="100%" AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:HyperLinkField HeaderText="Level 300 Contents" DataTextField="FileList" ControlStyle-ForeColor="Blue" DataNavigateUrlFormatString="{0}" Target="_blank" DataNavigateUrlFields="FilePath" />
                                <asp:TemplateField HeaderText = "Update Content Level">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTriageLevel300" runat="server">
                                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                            <asp:ListItem Text="200" Value="200"></asp:ListItem>
                                            <asp:ListItem Text="300" Value="300" Selected="True" Enabled="false"></asp:ListItem>
                                            <asp:ListItem Text="400" Value="400"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnTriageLevel300" runat="server" Text="Update" OnClick="btnTriageLevel300_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </p>
                </div>
                <h3>Level 400</h3>
                <div>
                    <p>
                        <asp:GridView ID="grd400" Width="100%" AutoGenerateColumns="false" runat="server">
                            <Columns>
                                <asp:HyperLinkField HeaderText="Level 400 Contents" DataTextField="FileList" ControlStyle-ForeColor="Blue" DataNavigateUrlFormatString="{0}" Target="_blank" DataNavigateUrlFields="FilePath" />
                                <asp:TemplateField HeaderText = "Update Content Level">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlTriageLevel400" runat="server">
                                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                            <asp:ListItem Text="200" Value="200"></asp:ListItem>
                                            <asp:ListItem Text="300" Value="300"></asp:ListItem>
                                            <asp:ListItem Text="400" Value="400" Selected="True" Enabled="false"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:Button ID="btnTriageLevel400" runat="server" Text="Update" OnClick="btnTriageLevel400_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </p>
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
