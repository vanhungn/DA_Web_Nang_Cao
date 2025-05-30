<%@ Page Language="C#" MasterPageFile="~/src/admin/masterAdmin/pageAdmin.master" AutoEventWireup="true" CodeBehind="pageUserAddEdit.aspx.cs" Inherits="DA_Web_Nang_Cao.src.admin.pageUser.pageUserAddEdit" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContentItem" runat="server">
    <link rel="stylesheet" type="text/css" href="pageUser.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageUserAddEditContainer">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

        <asp:Panel ID="pnlForm" runat="server">
            <table class="formTable">
                <tr>
                    <td><label for="txtName">Tên:</label></td>
                    <td><asp:TextBox ID="txtName" runat="server" CssClass="textBoxInput"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label for="txtPhone">Số điện thoại:</label></td>
                    <td><asp:TextBox ID="txtPhone" runat="server" CssClass="textBoxInput"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label for="txtEmail">Email:</label></td>
                    <td><asp:TextBox ID="txtEmail" runat="server" CssClass="textBoxInput"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label for="txtUsername">Tài khoản:</label></td>
                    <td><asp:TextBox ID="txtUsername" runat="server" CssClass="textBoxInput"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label for="txtPassword">Mật khẩu:</label></td>
                    <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="textBoxInput"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label for="ddlRole">Vai trò:</label></td>
                    <td>
                        <asp:DropDownList ID="ddlRole" runat="server" CssClass="dropdownList">
                            <asp:ListItem Value="user">User</asp:ListItem>
                            <asp:ListItem Value="admin">Admin</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><label for="txtAddress">Địa chỉ:</label></td>
                    <td><asp:TextBox ID="txtAddress" runat="server" CssClass="textBoxInput"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><label for="txtMoney">Số dư:</label></td>
                    <td><asp:TextBox ID="txtMoney" runat="server" CssClass="textBoxInput"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <asp:Button ID="btnSave" runat="server" Text="Lưu" OnClick="btnSave_Click" CssClass="buttonSave" />
                        <asp:Button ID="btnCancel" runat="server" Text="Hủy" OnClick="btnCancel_Click" CssClass="buttonCancel" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
