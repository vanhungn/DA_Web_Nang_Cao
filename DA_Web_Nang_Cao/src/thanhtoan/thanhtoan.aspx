<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thanhtoan.aspx.cs" Inherits="DA_Web_Nang_Cao.src.thanhtoan.thanhtoan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Thanh Toán</title>
    <link href="Styles/style.css" rel="stylesheet" />
      <style>
      body {
            font-family: Arial, sans-serif;
            background-color: #f8f8f8;
            padding: 30px;
        }

        .main-container {
            display: flex;
            gap: 30px;
            max-width: 1200px;
            margin: auto;
        }

        .left-column {
            flex: 3;
            background-color: #fff;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.05);
        }

        .right-column {
            flex: 2;
            background-color: #fff;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.05);
        }

        h3, h4 {
            margin-top: 0;
            color: #333;
        }

        .row-flex {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            margin-bottom: 20px;
        }

        .col-half {
            flex: 1;
            min-width: 300px;
        }

        .input {
            width: 100%;
            padding: 10px;
            margin-bottom: 12px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 6px;
        }

        .submit-btn {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 12px 20px;
            border-radius: 6px;
            font-size: 16px;
            cursor: pointer;
        }

        .submit-btn:hover {
            background-color: #218838;
        }

        .order-summary {
            border-top: 1px solid #ddd;
            padding-top: 15px;
            margin-top: 15px;
        }

        .order-item {
            display: flex;
            justify-content: space-between;
            margin-bottom: 10px;
        }

        .total {
            font-weight: bold;
            font-size: 18px;
            color: #e53935;
        }
</style>
</head>
<body>
    <form id="form1" runat="server">
            <div class="main-container">
            <!-- Cột trái: Thông tin khách hàng -->
            <div class="left-column">
                <h3>Thông Tin Khách Hàng</h3>

                <div class="row-flex">
                    <!-- Người mua -->
                    <div class="col-half">
                        <h4>Người mua hàng</h4>
                        <asp:TextBox ID="txtTenNguoiMua" runat="server" CssClass="input" placeholder="Họ và tên người mua" />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input" placeholder="Email" />
                        <asp:TextBox ID="txtSDTMua" runat="server" CssClass="input" placeholder="Số điện thoại người mua" />
                    </div>

                    <!-- Người nhận -->
                    <div class="col-half">
                        <h4>Người nhận hàng</h4>
                        <asp:TextBox ID="txtTenNguoiNhan" runat="server" CssClass="input" placeholder="Họ và tên người nhận" />
                        <asp:TextBox ID="txtSDTNhan" runat="server" CssClass="input" placeholder="Số điện thoại người nhận" />
                    </div>
                </div>

                <!-- Địa chỉ -->
                <h4>Địa chỉ nhận hàng</h4>
                <asp:TextBox ID="txtDiaChi" runat="server" CssClass="input" placeholder="Số nhà, tên đường" />
                <asp:DropDownList ID="ddlQuocGia" runat="server" CssClass="input">
                    <asp:ListItem Text="Việt Nam" Value="VN" />
                </asp:DropDownList>
                <asp:DropDownList ID="ddlTinh" runat="server" CssClass="input" />
                <asp:DropDownList ID="ddlHuyen" runat="server" CssClass="input" />
                <asp:DropDownList ID="ddlXa" runat="server" CssClass="input" />

                <!-- Ghi chú -->
                <asp:TextBox ID="txtGhiChu" runat="server" CssClass="input" TextMode="MultiLine" Rows="3" placeholder="Ghi chú (nếu có)..." />
            </div>

            <!-- Cột phải: Thông tin đơn hàng -->
            <div class="right-column">
                <h3>Thông Tin Đơn Hàng</h3>

                <div class="order-summary">
                    <div class="order-item">
                        <span>Sản phẩm A x1</span>
                        <span>200.000₫</span>
                    </div>
                    <div class="order-item">
                        <span>Sản phẩm B x2</span>
                        <span>400.000₫</span>
                    </div>
                    <div class="order-item total">
                        <span>Tổng cộng:</span>
                        <span>600.000₫</span>
                    </div>
                </div>

                <asp:Button ID="btnThanhToan" runat="server" Text="Thanh Toán" CssClass="submit-btn" OnClick="btnThanhToan_Click" />
            </div>
        </div>
    </form>
</body>
</html>