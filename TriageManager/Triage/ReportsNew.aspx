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
    </script>
    <hr />
    <div id="dvAccordian" style="width:90%">
        <asp:Repeater ID="rptAccordian" runat="server">
            <ItemTemplate>
                <h3>
                    <%# Eval("Topic") %></h3>
                <div>
                    <p style="height:500px">
                        <ItemTemplate>   
                            <asp:GridView ID="grdPollData" runat="server">
                                <%--<Columns>  
                                    <asp:BoundField DataField="Link" HeaderText="Link" />
                                </Columns>--%>
                            </asp:GridView>
                        </ItemTemplate>
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
