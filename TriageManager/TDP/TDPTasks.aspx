<%@ Page Title="" Language="C#" MasterPageFile="~/TDP/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="TDPTasks.aspx.cs" Inherits="TriageManager.TDP.TDPTasks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TDPContent" runat="server">
    <br />
<br />
<asp:Panel ID="pnlAdd" runat="server">
    <table style="align-content:center">
        <tr>
            <td>
                <asp:Label ID="lblTopic" runat="server" Text="Topic "></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:TextBox ID="txtTopic" runat="server" Width="800px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTask" runat="server" Text="Tasks to perform "></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:TextBox ID="txtTask" runat="server" TextMode="MultiLine" Width="800px" Rows="10" Wrap="False"></asp:TextBox>
            </td>
        </tr>        
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add New Task" OnClick="btnAdd_Click" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblComment" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr> 
    </table>
</asp:Panel>
<br />
<br />
    <asp:GridView ID="grdTasks" runat="server" OnRowDataBound="grdTasks_RowDataBound">
</asp:GridView>
<br />
<br />
</asp:Content>
