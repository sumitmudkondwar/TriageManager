<%@ Page Title="" Language="C#" MasterPageFile="~/TDP/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Self.aspx.cs" Inherits="TriageManager.TDP.Self" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TDPContent" runat="server">
    <asp:Panel ID="pnlAssess" runat="server" Visible="false">
        <table >
            <tr>
                <td>
                    <h5><b>0 - Do not know to setup/configure feature</b></h5>
                </td>
                <td style="width:20px">
                </td>
                <td>
                    <h5><b>100 - Know basics but need help most of the time</b></h5>
                </td>
            </tr>
            <tr>
                <td>
                    <h5><b>200 - Handle all related issues independently with minimal help from TAs</b></h5>
                </td>
                <td style="width:20px">
                </td>
                <td>
                    <h5><b>300 - Expert. TA level. Can help others to resolve complex issues</b></h5>
                </td>
            </tr>
            <tr>
                <td>
                    <h5><b>400 - I should be EE now</b></h5>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table >
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Availability/Performance "></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label2" runat="server" Text="VNET/Hybrid "></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label3" runat="server" Text="ASE"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label4" runat="server" Text="Mobile Apps"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label5" runat="server" Text="WebJobs/Functions "></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList5" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label6" runat="server" Text="WebApps on Linux"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList6" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label7" runat="server" Text="Deployment"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label8" runat="server" Text="Easy Authentication "></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label9" runat="server" Text="AutoScale/Alerts"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label10" runat="server" Text="Swap/Slots "></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList10" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label11" runat="server" Text="BYOD/App Service Certificate "></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList11" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label12" runat="server" Text="Powershell/ARM APIs "></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList12" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                    <asp:Label ID="Label13" runat="server" Text="OSS"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList13" runat="server" RepeatDirection="Horizontal"  CellSpacing="10" Width="400px">
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
                </td>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" Text="Self Assessment" OnClick="btnUpdate_Click" />
                </td>
                <td></td>
            </tr>
        </table>
    </asp:Panel>

    <table>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblComment" runat="server" ForeColor="Red"></asp:Label>
            </td>
            </tr>
        </table>
</asp:Content>
