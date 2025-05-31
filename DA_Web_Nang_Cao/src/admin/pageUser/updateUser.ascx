<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="updateUser.ascx.cs" Inherits="DA_Web_Nang_Cao.src.admin.pageUser.updateUser" %>
<asp:Panel ID="pnlForm" runat="server" CssClass="form-container">
    <h3><asp:Label ID="lblTitle" runat="server" Text="Thêm / Cập nhật người dùng"></asp:Label></h3>

    <table class="table-form">
        <tr>
            <td>Họ tên:</td>
            <td><asp:TextBox ID="txt_names" runat="server" CssClass="form-control" /></td>
        </tr>
        <tr>
            <td>Số điện thoại:</td>
            <td><asp:TextBox ID="txt_phones" runat="server" CssClass="form-control" MaxLength="10" /></td>
        </tr>
        <tr>
            <td>Email:</td>
            <td><asp:TextBox ID="txt_emails" runat="server" CssClass="form-control" /></td>
        </tr>
        <tr>
            <td>Tên đăng nhập:</td>
            <td><asp:TextBox ID="txt_userNames" runat="server" CssClass="form-control" /></td>
        </tr>
        <tr>
            <td>Mật khẩu:</td>
            <td><asp:TextBox ID="txt_passwords" runat="server" CssClass="form-control" TextMode="Password" /></td>
        </tr>
        <tr>
            <td>Quyền:</td>
            <td>
                <asp:DropDownList ID="ddl_roles" runat="server" CssClass="form-control">
                    <asp:ListItem Text="user" Value="user" />
                    <asp:ListItem Text="admin" Value="admin" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Địa chỉ:</td>
            <td><asp:TextBox ID="txt_addresss" runat="server" CssClass="form-control" /></td>
        </tr>
        <tr>
            <td>Số dư (VNĐ):</td>
            <td><asp:TextBox ID="txt_moneys" runat="server" CssClass="form-control" Text="0" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:right">
                <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="btn btn-success" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Hủy" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>