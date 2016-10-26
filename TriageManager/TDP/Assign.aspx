<%@ Page Title="" Language="C#" MasterPageFile="~/TDP/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Assign.aspx.cs" Inherits="TriageManager.TDP.Assign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TDPContent" runat="server">
        
 <script type="text/javascript">
     function AddItem() {
         var name = document.getElementById("MainContent_TDPContent_ddlEngineer").value;
         var topic = document.getElementById("MainContent_TDPContent_ddlTopic").value;
         var priority = document.getElementById("MainContent_TDPContent_ddlPriority").value;
         var level = '<%= rdlLevel.SelectedValue %>';
         var calendarDate = '<%= calETA.SelectedDate %>';
         var message = "Selected values are: \n Engineer: " + name + "\n Topic: " + topic + "\n Priority: " + priority
             + "\n Level: " + level + "\n ETA: " + calendarDate;
         
    if (confirm(message)) {

                return true;
            }
            return false;
        }
 </script>
    <br />
<br />
    <table>
        <asp:Panel id="pnlAdd" runat="server">
        <tr>
            <td>
                <asp:Label ID="lblEngineer" runat="server" Text="Engineer"></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:DropDownList ID="ddlEngineer" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTopic" runat="server" Text="Topic"></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:DropDownList ID="ddlTopic" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPriority" runat="server" Text="Priority"></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:DropDownList ID="ddlPriority" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblLevel" runat="server" Text="Initial TA Assessment"></asp:Label>
            </td>
            <td></td>
            <td>
                    <asp:RadioButtonList ID="rdlLevel" runat="server" RepeatDirection="Horizontal" CellSpacing="10">
                        <asp:ListItem Selected="True">0</asp:ListItem>
                        <asp:ListItem>100</asp:ListItem>
                        <asp:ListItem>200</asp:ListItem>
                        <asp:ListItem>300</asp:ListItem>
                        <asp:ListItem>400</asp:ListItem>
                    </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAssessment" runat="server" Text="Initial TDP Assessment "></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:TextBox ID="txtAssessment" runat="server" TextMode="MultiLine" Width="800px" Rows="10"></asp:TextBox>
            </td>
        </tr>        
        <tr>
            <td>
                <asp:Label ID="lblETA" runat="server" Text="ET Completion"></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:Calendar ID="calETA" runat="server" OnSelectionChanged="calETA_SelectionChanged" OnDayRender="calETA_DayRender"></asp:Calendar>                                               
                <asp:Label ID="lblSelectedDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Add Task to Engineer" OnClick="btnAdd_Click" onclientclick="return AddItem()"  />
            </td>
            <td></td>
        </tr>
        </asp:Panel>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblComment" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr> 
    </table>
<br />
<br />
</asp:Content>
