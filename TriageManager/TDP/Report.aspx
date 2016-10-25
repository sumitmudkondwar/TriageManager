<%@ Page Title="" Language="C#" MasterPageFile="~/TDP/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="TriageManager.TDP.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TDPContent" runat="server">
<asp:Panel ID="pnlReport" runat="server">
<br />
<br />
    <h3>Initial Engineer Assessment</h3>
<br />
    <asp:GridView ID="grdEngAssess" runat="server">
    </asp:GridView>
<br />
<br />
    <h3>Initial TA Assessment</h3>
<br />
    <asp:GridView ID="grdTAAssess" runat="server">
    </asp:GridView>
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
</asp:Panel>
<br />
<br />
    <table>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblComment" runat="server" ForeColor="Red"></asp:Label>
            </td>
            </tr>
        </table>
</asp:Content>
