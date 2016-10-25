<%@ Page Title="" Language="C#" MasterPageFile="~/TDP/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="TriageManager.TDP.Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TDPContent" runat="server">
    <style type="text/css">
  .hiddencol
  {
    display: none;
  }
</style>
    <br />
<br />
    <asp:Panel ID="pnlGrid" runat="server" Width="100%">
    <table>
        <tr>
            <td style="width:200PX">

            </td>
            <td>
                <asp:GridView ID="grdTasks" runat="server" HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" AutoGenerateColumns="false" OnSelectedIndexChanged="grdTasks_SelectedIndexChanged" OnRowDataBound="grdTasks_RowDataBound" CellSpacing="5" >
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowCancelButton="False" ShowSelectButton="True" />                          
                        <asp:BoundField DataField="TaskID" ItemStyle-CssClass="hiddencol" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="hiddencol" HeaderText="TaskID">
                        <HeaderStyle CssClass="hiddencol" HorizontalAlign="Center" />
                        <ItemStyle CssClass="hiddencol" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Topic" HeaderText="Topic" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Priority" HeaderText="Priority" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ETA" HeaderText="ETA" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Assigned" HeaderText="Assigned" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TA" HeaderText="TA" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Comments" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="Comments" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                        <HeaderStyle CssClass="hiddencol" HorizontalAlign="Center" />
                        <ItemStyle CssClass="hiddencol" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Task" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" HeaderText="Task" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                        <HeaderStyle CssClass="hiddencol" HorizontalAlign="Center" />
                        <ItemStyle CssClass="hiddencol" HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                </asp:GridView>
            </td>
            <td style="width:200PX">

            </td>
        </tr>
    </table>
        </asp:Panel>
<br />
<br />
            <asp:Panel ID="pnlStatus" runat="server" Visible="false">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblTask" runat="server" Text="Task Selected "  Width="120px"></asp:Label>
                <asp:HiddenField ID="hidID" runat="server" />
            </td>
            <td></td>
            <td>
                <asp:Label ID="lblTaskName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDetail" runat="server" Text="Task Details "></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:Label ID="lblDetailInfo" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" Text="Status "></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem>Assigned</asp:ListItem>
                    <asp:ListItem>InProgress</asp:ListItem>
                    <asp:ListItem>Completed</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>        
        <tr>
            <td>
                <asp:Label ID="lblComment1" runat="server" Text="Details "></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="800px" Height="100px" Enabled="false"></asp:TextBox>
            </td>
        </tr>    
        <tr>
            <td>
                <asp:Label ID="lblNewUpdate" runat="server" Text="New Update "></asp:Label>
            </td>
            <td></td>
            <td>
                <asp:TextBox ID="txtUpdate" runat="server" TextMode="MultiLine" Height="100px" Width="800px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Update Task" OnClick="btnUpdate_Click" />
            </td>
            <td></td>
        </tr>
    </table>
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
<br />
<br />
</asp:Content>
