<%@ Page Title="My Poll" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyPoll.aspx.cs" Inherits="TriageManager.Triage.MyPoll" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Help future SME's in improving their skills!!!</h3>
    <hr />
    <div id="dvErrorBlock" runat="server">
        <asp:Label ForeColor="Red" ID="lblErrorMessage" runat="server"></asp:Label>
        <hr />
    </div>
    <div id="dvSuccessMessage" runat="server">
        <asp:Label ForeColor="Green" ID="lblSuccessMessage" runat="server"></asp:Label>
        <hr />
    </div>
    <div class="form-group">
        <table>
            <tr>
                <td>
                    Have you Attended last Triage on (<asp:Label ID="lblIsTriageAttended" runat="server" ForeColor="Red"></asp:Label>) :
                </td>
                <td>
                    <asp:RadioButton CssClass="form-control" ID="rdbIsAttendedYes" GroupName="IsAttended" runat="server" AutoPostBack="true" Text="Yes" OnCheckedChanged="rdbIsAttendedYes_CheckedChanged" />
                </td>
                <td>
                    <asp:RadioButton CssClass="form-control" ID="rdbIsAttendedNo" GroupName="IsAttended" runat="server" AutoPostBack="true" Text="No" OnCheckedChanged="rdbIsAttendedNo_CheckedChanged" />
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td colspan="3">
                    <div id="dvAttendedYes" runat="server" class="form-group">
                        <table>
                            <tr>
                                <td>Triage Level</td>
                                <td style="width: 30px">:</td>
                                <td>
                                    <asp:RadioButton CssClass="form-control" ID="rdbTriageLevel1" GroupName="Triagelevel" runat="server" Text="100" />
                                </td>
                                <td>
                                    <asp:RadioButton CssClass="form-control" ID="rdbTriageLevel2" GroupName="Triagelevel" runat="server" Text="200" />
                                </td>
                                <td>
                                    <asp:RadioButton CssClass="form-control" ID="rdbTriageLevel3" GroupName="Triagelevel" runat="server" Text="300" />
                                </td>
                                <td>
                                    <asp:RadioButton CssClass="form-control" ID="rdbTriageLevel4" GroupName="Triagelevel" runat="server" Text="400" />
                                </td>
                            </tr>
                            <tr>
                                <td>Triage Quality
                                </td>
                                <td style="width: 30px">:
                                </td>
                                <td>
                                    <asp:RadioButton ID="rdbTriageQuality1" GroupName="TriageQuality" runat="server" Text="Above Expectation" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="rdbTriageQuality2" GroupName="TriageQuality" runat="server" Text="Met Expectation" CssClass="form-control" />
                                </td>
                                <td colspan="2">
                                    <asp:RadioButton ID="rdbTriageQuality3" GroupName="TriageQuality" runat="server" Text="Below Expectation" CssClass="form-control" />
                                </td>
                            </tr>
                            <tr>
                                <td>Presentation</td>
                                <td style="width: 30px">:</td>
                                <td>
                                    <asp:RadioButton ID="rdbPresentation1" GroupName="Presentation" runat="server" Text="Good" CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="rdbPresentation2" GroupName="Presentation" runat="server" Text="Average" CssClass="form-control" />
                                </td>
                                <td colspan="2">
                                    <asp:RadioButton ID="rdbPresentation3" GroupName="Presentation" runat="server" Text="Need Improvement" CssClass="form-control" />
                                </td>
                            </tr>
                            <tr>
                                <td style="color:red; width:150px">Please suggest some useful suggestions for your colleague</td>
                                <td style="width: 30px">:</td>
                                <td colspan="4">
                                    <asp:TextBox Height="120px" CssClass="form-control" ID="txtComments" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="6" style="color:red">
                                    Hello Team, please do not ignore the textbox for suggestions to your colleague this is anonymous suggestion you can give your colleague to inprove in future.
                                </td>
                            </tr>--%>
                        </table>
                    </div>
                    <div id="dvAttendedNo" runat="server" class="form-group">
                        <table>
                            <tr>
                                <td>Reason:</td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="txtReason" runat="server" TextMode="MultiLine" Width="500px" Height="150px" ></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnReset" Text="Reset" OnClick="btnReset_Click" CssClass="form-control" />
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" CssClass="form-control" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
