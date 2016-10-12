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
            KB Subject:<b style="color: red">*</b>
            <p>
                <asp:TextBox runat="server" CssClass="form-control" Width="100%" ID="txtHeading"></asp:TextBox>
            </p>
        </div>
        <div>
            Description:<b style="color: red">*</b>
            <p>
                <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" Width="60%" Height="200px" runat="server"></asp:TextBox>
            </p>
        </div>
        <div>
            <p>
                <asp:FileUpload ID="flupNewFiles" AllowMultiple="true" runat="server" />
            </p>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="100%" CssClass="form-control" OnClick="btnSubmit_Click" />
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:Button ID="btnClear" runat="server" Text="Clear All" Width="100%" CssClass="form-control" OnClick="btnClear_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:PlaceHolder>
</asp:Content>
