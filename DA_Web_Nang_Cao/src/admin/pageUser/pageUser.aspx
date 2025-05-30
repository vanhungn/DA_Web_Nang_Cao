<%@ Page Language="C#" MasterPageFile="~/src/admin/masterAdmin/pageAdmin.master" AutoEventWireup="true" CodeBehind="pageUser.aspx.cs" Inherits="DA_Web_Nang_Cao.src.admin.pageUser.pageUser" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContentItem" runat="server">
    <link rel="stylesheet" type="text/css" href="pageUser.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pageUserContainer">
        <div class="boxSearchQuery">
            <input type="text" id="txtSearchUser" runat="server" class="textBoxSearchItem" placeholder="Tìm người dùng..." onserverchange="txtSearchUser_ServerChange" />
            <asp:Button ID="btnAddUser" runat="server" Text="Thêm người dùng" CssClass="buttonAddItem" OnClick="btnAddUser_Click" />
        </div>

        <asp:Label ID="lblMessage" runat="server" CssClass="messageLabel" ForeColor="Red"></asp:Label>

        <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False"
            CssClass="userTable"
            AllowPaging="true" PageSize="10"
            OnPageIndexChanging="gvUser_PageIndexChanging"
            OnRowCommand="gvUser_RowCommand"
            DataKeyNames="ID">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Tên" />
                <asp:BoundField DataField="Phone" HeaderText="SĐT" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Username" HeaderText="Tài khoản" />
                <asp:BoundField DataField="Password" HeaderText="Mật khẩu" />
                <asp:BoundField DataField="Role" HeaderText="Vai trò" />
                <asp:BoundField DataField="Address" HeaderText="Địa chỉ" />
                <asp:BoundField DataField="Money" HeaderText="Số dư" DataFormatString="{0:N0} đ" />
                <asp:BoundField DataField="CreateDate" HeaderText="Ngày tạo" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="LastLogin" HeaderText="Lần đăng nhập" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                <asp:TemplateField HeaderText="Hành động">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("ID") %>' CssClass="buttonLook">Sửa</asp:LinkButton> |
                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' CssClass="buttonLook" OnClientClick="return confirm('Bạn có chắc chắn muốn xoá người dùng này?');">Xoá</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
