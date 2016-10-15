<%@ Page Title="Add New Content" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewContent.aspx.cs" Inherits="TriageManager.Triage.NewContent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%: Title %>.</h3>
    <hr />
    <asp:PlaceHolder runat="server">
        <div>
            <asp:Label ID="lblErrorMessage" ForeColor="Red" runat="server"></asp:Label>
            <asp:Label ID="lblSuccessMessage" ForeColor="Green" runat="server"></asp:Label>
        </div>
        <br />
        <div>
            Topic:<b style="color: red">*</b>
            <p>
                <asp:DropDownList ID="ddlHeading" runat="server" CssClass="form-control" Width="60%" ToolTip="Select the subject for which you want to share your knowledge with everyone."></asp:DropDownList>
            </p>
        </div>
        <div>
            Content Level:<b style="color:red">*</b>
            <p>
                <asp:DropDownList ID="ddlContentLevel" ToolTip="Select the level of content e.g. 100 for 'How to do this' topic" runat="server" CssClass="form-control" Width="60%">
                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                    <asp:ListItem Text="200" Value="200"></asp:ListItem>
                    <asp:ListItem Text="300" Value="300"></asp:ListItem>
                    <asp:ListItem Text="400" Value="400"></asp:ListItem>
                </asp:DropDownList>
            </p>
        </div>
        <div>
            Description:
            <p>
                <asp:TextBox ID="txtDescription" CssClass="form-control" ToolTip="You can add some short description here for your topic" TextMode="MultiLine" Width="60%" Height="100px" runat="server"></asp:TextBox>
            </p>
        </div>
        <div>
            <p>
                <asp:FileUpload ID="flupNewFiles" AllowMultiple="true" runat="server" ToolTip="You can upload multiple files here to share with everyone in the team." />
            </p>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" ToolTip="Click to Share your Contents..." runat="server" Text="Submit" Width="100%" CssClass="form-control" OnClick="btnSubmit_Click" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnClear" runat="server" Text="Clear All" ToolTip="Click to Clear this form." Width="100%" CssClass="form-control" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:PlaceHolder>
</asp:Content>
