<%@ Page Title="" Language="C#" MasterPageFile="~/TDP/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="TriageManager.TDP.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TDPContent" runat="server">
<br />
<br />
    <h3>TA Status Report</h3>
<br />
    <asp:GridView ID="grdTA" runat="server">
    </asp:GridView>
<br />
<br />
    <h3>Engineer Status Report</h3>
<br />
    <asp:GridView ID="grdEngineer" runat="server">
    </asp:GridView>
<br />
<br />
</asp:Content>
