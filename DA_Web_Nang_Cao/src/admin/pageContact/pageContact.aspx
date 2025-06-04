<%@ Page Language="C#" MasterPageFile="~/src/admin/masterAdmin/pageAdmin.master" AutoEventWireup="true" CodeBehind="pageContact.aspx.cs" Inherits="DA_Web_Nang_Cao.src.admin.pageContact.pageContact" %>


<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="header"></h2>
    <link href="Contact.css" rel="stylesheet" />
   <!-- Cột trái: Bảng liên hệ -->
<div style="flex: 1; margin-left:50px;">
    <!-- Thanh tìm kiếm nằm trong bảng -->
    <div class="search-container" style="margin-bottom: 10px;">
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control search-box" Placeholder="🔍 Tìm theo họ tên hoặc email hoặc user..." />
        <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" CssClass="btn btn-primary search-button" OnClick="btnSearch_Click" />
        <asp:Button ID="btnReset" runat="server" Text="Làm mới" CssClass="btn btn-secondary" OnClick="btnReset_Click" />
    </div>

    <asp:GridView ID="gvLienHe" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        CssClass="table" AllowPaging="true" PageSize="10"
        PagerSettings-Mode="Numeric" PagerStyle-CssClass="gv-pagination"
        OnRowEditing="gvLienHe_RowEditing"
        OnRowUpdating="gvLienHe_RowUpdating"
        OnRowCancelingEdit="gvLienHe_RowCancelingEdit"
        OnRowDeleting="gvLienHe_RowDeleting"
        OnPageIndexChanging="gvLienHe_PageIndexChanging">
    <Columns>
        <asp:TemplateField HeaderText="Họ tên">
            <ItemTemplate>
                <%# Eval("HoTen") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtHoTen" runat="server" Text='<%# Bind("HoTen") %>' CssClass="form-control" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Email">
            <ItemTemplate>
                <%# Eval("Email") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="SĐT">
            <ItemTemplate>
                <%# Eval("SDT") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtSDT" runat="server" Text='<%# Bind("SDT") %>' CssClass="form-control" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Địa chỉ">
            <ItemTemplate>
                <%# Eval("DiaChi") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDiaChi" runat="server" Text='<%# Bind("DiaChi") %>' CssClass="form-control" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Nội dung">
            <ItemTemplate>
                <%# Eval("NoiDung") %>
</ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtNoiDung" runat="server" Text='<%# Bind("NoiDung") %>' CssClass="form-control" TextMode="MultiLine" Rows="2" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="User">
            <ItemTemplate>
                <%# Eval("userNames") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("userNames") %>' CssClass="form-control" />
            </EditItemTemplate>
        </asp:TemplateField>
                <asp:BoundField DataField="NgayGui" HeaderText="Ngày gửi" ReadOnly="True" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                <asp:CommandField ShowEditButton="true" EditText="✏️ Sửa" UpdateText="💾 Lưu" CancelText="❌ Hủy" />
                <asp:CommandField ShowDeleteButton="true" DeleteText="🗑️ Xóa" />
     </Columns>
     </asp:GridView>
</div>

       <div class="form-container">
        <h3 style="margin-top: 0;">Thêm liên hệ mới</h3>
        <asp:Panel ID="pnlAdd" runat="server">
            <asp:TextBox ID="txtHoTen" runat="server" Placeholder="Họ tên" CssClass="form-control" /><br />
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" CssClass="form-control" /><br />
            <asp:TextBox ID="txtSDT" runat="server" Placeholder="Số điện thoại" CssClass="form-control" /><br />
            <asp:TextBox ID="txtDiaChi" runat="server" Placeholder="Địa chỉ" CssClass="form-control" /><br />
            <asp:TextBox ID="txtNoiDung" runat="server" Placeholder="Nội dung" CssClass="form-control" TextMode="MultiLine" Rows="3" /><br />
            <asp:TextBox ID="txtUserName" runat="server" Placeholder="UserName (nếu có)" CssClass="form-control" /><br />
            <asp:Button ID="btnThem" runat="server" Text="Thêm mới" CssClass="btn btn-success" OnClick="btnThem_Click" />
        </asp:Panel>
        <asp:Label ID="lblMessage" runat="server" CssClass="message-label" />
    </div>
</asp:Content>