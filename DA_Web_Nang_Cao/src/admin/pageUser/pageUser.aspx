<%@ Page Language="C#" MasterPageFile="~/src/admin/masterAdmin/pageAdmin.master"  AutoEventWireup="true" CodeBehind="pageUser.aspx.cs" Inherits="DA_Web_Nang_Cao.src.admin.pageUser.pageUser" %>
<%@ Register Src="~/src/admin/pageUser/updateUser.ascx" TagPrefix="uc" TagName="updateUser" %>



   <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
       <asp:ScriptManager ID="ScriptManager1" runat="server" />
   
        
        <asp:UpdatePanel ID="up_main" runat="server">
            <ContentTemplate>
                <!-- Kiểm tra quyền truy cập -->
                <asp:Panel ID="p_accessDenied" runat="server" Visible="false" CssClass="alert alert-danger">
                    Bạn không có quyền truy cập trang này.
                </asp:Panel>

                <!-- Thanh tìm kiếm -->
                <div>
                    <asp:TextBox ID="txt_search" runat="server" CssClass="form-control" placeholder="Tìm kiếm tên, username, email, SĐT..." />
                    <asp:Button ID="btn_search" runat="server" Text="Tìm kiếm" OnClick="btn_search_Click" CssClass="btn btn-primary mt-2" />
                    <asp:Button ID="btn_addUser" runat="server" Text="Thêm người dùng" OnClick="btn_addUser_Click" CssClass="btn btn-success mt-2" />
                </div>

                <!-- Danh sách người dùng -->
                <asp:Repeater ID="rpt_users" runat="server">
                    <HeaderTemplate>
                        <table class="table table-bordered mt-3">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Tên</th>
                                    <th>Username</th>
                                    <th>Email</th>
                                    <th>SĐT</th>
                                    <th>Quyền</th>
                                    <th>Tiền</th>
                                    <th>Hành động</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("idUsers") %></td>
                            <td><%# Eval("names") %></td>
                            <td><%# Eval("userNames") %></td>
                            <td><%# Eval("emails") %></td>
                            <td><%# Eval("phones") %></td>
                            <td><%# Eval("roles") %></td>
                            <td><%# Eval("moneys") %> đ</td>
                            <td>
                                <asp:LinkButton ID="lnk_edit" runat="server" Text="Sửa" CommandArgument='<%# Eval("idUsers") %>' OnClick="lnk_edit_Click" CssClass="btn btn-warning btn-sm" />
                                <asp:LinkButton ID="lnk_delete" runat="server" Text="Xóa" CommandArgument='<%# Eval("idUsers") %>' OnClick="lnk_delete_Click" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Bạn có chắc muốn xóa?');" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

                <!-- Panel cập nhật người dùng -->
                <asp:Panel ID="p_update" runat="server" Visible="false" CssClass="mt-4">
                    <uc:updateUser ID="uc_updateUser" runat="server" OnCancelClicked="uc_updateUser_CancelClicked" />
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

</asp:Content>
