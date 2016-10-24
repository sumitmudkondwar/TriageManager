<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportsNew.aspx.cs" Inherits="TriageManager.Triage.ReportsNew" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Feedback</h2>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("#dvAccordian").accordion();
        });

        $(function () {
            $("dvDateAccordian").accordion();
        })

    </script>
    <hr />
    <div id="dvAccordian" style="width:90%">
        <asp:Repeater ID="rptAccordian" runat="server" OnItemDataBound="rptAccordian_ItemDataBound">
            <ItemTemplate>
                <h3>
                    <%# Eval("Name") %></h3>
                <div>
                    <p style="height:500px">
                        <div id="dvDateAccordian" style="width:90%">
                            <asp:Repeater ID="rptDateAccordian" runat="server">
                                <ItemTemplate>
                                    <h3>
                                        <%# Eval("TriageDate") %>
                                    </h3>
                                    <div>
                                        <p>
                                            Sumit
                                        </p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
