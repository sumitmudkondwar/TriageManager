<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contents.aspx.cs" Inherits="TriageManager.Triage.Contents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:PlaceHolder runat="server">
    <div>
        <br />
        <br />
        <br />
        <br />
    <table style="vertical-align:bottom"><tr><td>
    <%--<link href="//amp.azure.net/libs/amp/1.3.0/skins/amp-default/azuremediaplayer.min.css" rel="stylesheet" />

    <script src= "//amp.azure.net/libs/amp/1.3.0/azuremediaplayer.min.js"></script>    
       --%>     
    <video id="azuremediaplayer"  class="azuremediaplayer amp-default-skin amp-big-play-centered" controls autoplay style="vertical-align:middle;" width="640" height="400" poster="" data-setup='{"nativeControlsForTouch": false}' tabindex="0">
        <source src="https://aztriagestorage.blob.core.windows.net/mycontainer/sample.mp4" type="video/mp4" />
        <p class="amp-no-js">To view this video please enable JavaScript, and consider upgrading to a web browser that supports HTML5 video</p>
    </video>
        </td>
        <td>
            
        <asp:GridView ID="grdTriageCalender" runat="server" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AutoGenerateColumns="false" >
            
            <Columns>
                <asp:BoundField DataField="topic" HeaderText="Topic" />
                <asp:BoundField DataField="type" HeaderText="Type" />
                <asp:TemplateField HeaderText = "URL">
                    <ItemTemplate>
                        <asp:HyperLink runat="server"  NavigateUrl='<%# Eval("url") %>' Text='<%# Eval("url") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </td>
        </tr>
        </table>
        </div>
        </asp:PlaceHolder>
</asp:Content>
