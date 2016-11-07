<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportsNew.aspx.cs" Inherits="TriageManager.Triage.ReportsNew" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Feedback</h2>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("#dvAccordian").accordion();
        });
    </script>
    <style>
        #accordion-resizer {
            padding: 10px;
            width: 85%;
            height: 500px;
        }

        table.gridtable {
            font-family: verdana,arial,sans-serif;
            font-size: 11px;
            color: #333333;
            border-width: 1px;
            border-color: #666666;
            border-collapse: collapse;
        }

            table.gridtable th {
                border-width: 1px;
                padding: 8px;
                border-style: solid;
                border-color: #666666;
                background-color: #dedede;
            }
            table.gridtable td {
                border-width: 1px;
                padding: 8px;
                border-style: solid;
                border-color: #666666;
                background-color: #ffffff;
            }

    </style>
    <hr />
    <div id="dvAccMain" style="width:100%" runat="server">
        <div id="dvAccordian" style="width:90%">
            <asp:Repeater ID="rptAccordian" runat="server" OnItemDataBound="rptAccordian_ItemDataBound">
                <ItemTemplate>
                    <h3>
                        <%# Eval("Topic") %></h3>
                    <div>
                        <div style="height:500px"> 
                            <p>
                                <asp:GridView ID="grdPollData" CssClass="gridtable" runat="server">
                                </asp:GridView>
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div id="dvSETriageReport" runat="server" style="width:90%">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <hr />
        <div>
            <asp:GridView ID="grdSETriageReport" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                    RowStyle-CssClass="rows">
            </asp:GridView>
        </div>
    </div>
</asp:Content>
