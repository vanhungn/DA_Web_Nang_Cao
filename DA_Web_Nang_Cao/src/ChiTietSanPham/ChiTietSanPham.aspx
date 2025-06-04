<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietSanPham.aspx.cs" Inherits="DA_Web_Nang_Cao.src.ChiTietSanPham.ChiTietSanPham" %>
<%@ Register Src="../component/header/headerHome.ascx" TagPrefix="ucd" TagName="Header" %>
<%@ Register Src="../component/footer/footerHome.ascx" TagPrefix="uxd" TagName="FooterHome" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Chi tiết sản phẩm</title>
    <link href="ChiTietSanPham.css?v=123" rel="stylesheet" />
    <link rel="stylesheet" href="../component/header/header.css?v=126" />
    <link rel="stylesheet" href="../component/footer/footer.css" />
</head>
<body>
    <form id="form1" runat="server">
         <ucd:Header ID="headerHome2" runat="server" />
        <div>

      
        <div class="product-container">
            <div class="left">
                <asp:Image ID="img00" runat="server" CssClass="main-image" />
                <div class="thumbs">
                    <asp:Image ID="img11" runat="server" CssClass="thumb" />
                    <asp:Image ID="img22" runat="server" CssClass="thumb" />
                </div>
            </div>

            <div class="right">
                <h2><asp:Label ID="lblTen" runat="server" /></h2>
                <p class="gia"><asp:Label ID="lblGia" runat="server" /></p>
                <p class="giagoc">Giá gốc: <asp:Label ID="lblGiaGoc" runat="server" /></p>
                <p><strong>Trạng thái:</strong> <asp:Label ID="lblTinhTrang" runat="server" /></p>
                <p><strong>Thương hiệu:</strong> <asp:Label ID="lblThuongHieu" runat="server" /></p>
                <p><strong>Mã sản phẩm:</strong> <asp:Label ID="lblMaSP" runat="server" /></p>
                <p>
                    <label for="txtSoLuong">Số lượng: </label>
                    <asp:TextBox ID="txtSoLuong" runat="server" Text="1" Width="40" MaxLength="3" />
                </p>
                <div class="cart-actions">
                    <asp:Button ID="btnAddToCart" runat="server" Text="🛒 Thêm vào giỏ" CssClass="btn-cart" OnClick="btnAddToCart_Click" />
                </div>
                <div class="tags">
                    <strong>Tags:</strong> <asp:Label ID="lblTags" runat="server" />
                </div>
            </div>
        </div>

        <div class="tab">
            <h3>📘 Mô tả sản phẩm</h3>
            <asp:Literal ID="litMoTa" runat="server" />
        </div>
        <div class="tab">
            <h3>📘 Mô tả chi tiết</h3>
            <asp:Literal ID="litChiTiet" runat="server" />
        </div>

        <div class="thongtin">
            <h3>📄 Thông tin sản phẩm</h3>
            <table>
                <tr><td>Thương hiệu</td><td><asp:Label ID="lblBrand" runat="server" /></td></tr>
                <tr><td>Xuất xứ</td><td><asp:Label ID="lblXuatXu" runat="server" /></td></tr>
                <tr><td>Sản xuất tại</td><td><asp:Label ID="lblNoiSX" runat="server" /></td></tr>
                <tr><td>SKU</td><td><asp:Label ID="lblSKU" runat="server" /></td></tr>
                <tr><td>Hạn sử dụng</td><td><asp:Label ID="lblHSD" runat="server" /></td></tr>
                <tr><td>Hướng dẫn sử dụng</td><td><asp:Label ID="lblHDSD" runat="server" /></td></tr>
                <tr><td>Bảo quản</td><td><asp:Label ID="lblHDBQ" runat="server" /></td></tr>
            </table>
        </div>

        <div class="related">
            <h3>🔗 Sản phẩm liên quan</h3>
            <asp:Repeater ID="rptRelated" runat="server">
                <ItemTemplate>
                    <div class="related-item">
                        <img src='<%# Eval("img0") %>' alt="Ảnh sản phẩm" />
                        <p><%# Eval("nameItem") %></p>
                        <span><%# string.Format("{0:N0}", Eval("price")) %> đ</span>
                        <br />
                       
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
              </div>
         <uxd:FooterHome ID="footerHome" runat="server" />
    </form>
</body>
</html>
