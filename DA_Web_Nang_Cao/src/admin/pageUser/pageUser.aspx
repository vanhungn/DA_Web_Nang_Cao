<%@ Page Language="C#" MasterPageFile="~/src/admin/masterAdmin/pageAdmin.master"  AutoEventWireup="true" CodeBehind="pageUser.aspx.cs" Inherits="DA_Web_Nang_Cao.src.admin.pageUser.pageUser" %>




   <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="form" >
    <link href="pageUser.css" rel="stylesheet" />
    <div style="flex: 1;margin-left:50px">
        <div class="search-container" style="margin-bottom: 10px;">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control search-box" Placeholder="🔍 Tìm theo tên hoặc email hoặc username..." />
            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" CssClass="btn btn-primary search-button" OnClick="btnSearch_Click" />
            <asp:Button ID="btnReset" runat="server" Text="Làm mới" CssClass="btn btn-secondary" OnClick="btnReset_Click" />
        </div>

        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="idUsers"
            CssClass="table" AllowPaging="true" PageSize="10"
            PagerSettings-Mode="Numeric" PagerStyle-CssClass="gv-pagination"
            OnRowEditing="gvUsers_RowEditing"
            OnRowUpdating="gvUsers_RowUpdating"
            OnRowCancelingEdit="gvUsers_RowCancelingEdit"
            OnRowDeleting="gvUsers_RowDeleting"
            OnPageIndexChanging="gvUsers_PageIndexChanging" OnSelectedIndexChanged="gvUsers_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Họ tên">
                    <ItemTemplate><%# Eval("names") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtNames" runat="server" Text='<%# Bind("names") %>' CssClass="form-control" /></EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate><%# Eval("emails") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtEmails" runat="server" Text='<%# Bind("emails") %>' CssClass="form-control" /></EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="SĐT">
                    <ItemTemplate><%# Eval("phones") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtPhones" runat="server" Text='<%# Bind("phones") %>' CssClass="form-control" /></EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Username">
                    <ItemTemplate><%# Eval("userNames") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtUserNames" runat="server" Text='<%# Bind("userNames") %>' CssClass="form-control" /></EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Password">
                    <ItemTemplate><%# Eval("passwords") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtPasswords" runat="server" Text='<%# Bind("passwords") %>' CssClass="form-control" /></EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Quyền">
                    <ItemTemplate><%# Eval("roles") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtRoles" runat="server" Text='<%# Bind("roles") %>' CssClass="form-control" /></EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Địa chỉ">
                    <ItemTemplate><%# Eval("addresss") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtAddresss" runat="server" Text='<%# Bind("addresss") %>' CssClass="form-control" /></EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Số dư (VNĐ)">
                    <ItemTemplate><%# Eval("moneys", "{0:N0}") %></ItemTemplate>
                    <EditItemTemplate><asp:TextBox ID="txtMoneys" runat="server" Text='<%# Bind("moneys") %>' CssClass="form-control" /></EditItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowEditButton="true" EditText="✏️ Sửa" UpdateText="💾 Lưu" CancelText="❌ Hủy" />
                <asp:CommandField ShowDeleteButton="true" DeleteText="🗑️ Xóa" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="form-container">
        <h3 style="margin-top: 0;">Thêm người dùng mới</h3>
        <asp:Panel ID="pnlAdd" runat="server">
            <asp:TextBox ID="txtAddNames" runat="server" Placeholder="Họ tên" CssClass="form-control" /><br />
            <asp:TextBox ID="txtAddEmails" runat="server" Placeholder="Email" CssClass="form-control" /><br />
            <asp:TextBox ID="txtAddPhones" runat="server" Placeholder="Số điện thoại" CssClass="form-control" /><br />
            <asp:TextBox ID="txtAddUserNames" runat="server" Placeholder="Tên đăng nhập" CssClass="form-control" /><br />
            <asp:TextBox ID="txtAddPasswords" runat="server" Placeholder="Mật khẩu" CssClass="form-control"  /><br />
            <asp:TextBox ID="txtAddRoles" runat="server" Placeholder="Quyền (admin/user...)" CssClass="form-control" /><br />
            <asp:TextBox ID="txtAddAddresss" runat="server" Placeholder="Địa chỉ" CssClass="form-control" /><br />
            <asp:TextBox ID="txtAddMoneys" runat="server" Placeholder="Số dư" CssClass="form-control" TextMode="Number" /><br />
            <asp:Button ID="btnThem" runat="server" Text="Thêm mới" CssClass="btn btn-success" OnClick="btnThem_Click" />
        </asp:Panel>
        <asp:Label ID="lblMessage" runat="server" CssClass="message-label" />
        </div>
    </div>
      
</asp:Content>