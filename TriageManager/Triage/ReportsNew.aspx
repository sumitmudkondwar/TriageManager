<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportsNew.aspx.cs" Inherits="TriageManager.Triage.ReportsNew" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Feedback</h2>
    <style>
        #accordion-resizer {
            padding: 10px;
            width: 85%;
            height: 500px;
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
    <hr />
    <asp:PlaceHolder runat="server">
        <div id="accordion-resizer" class="ui-widget-content">
            <div id="accordion">
                
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
