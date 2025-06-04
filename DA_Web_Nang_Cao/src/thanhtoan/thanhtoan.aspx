<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thanhtoan.aspx.cs" Inherits="DA_Web_Nang_Cao.src.thanhtoan.thanhtoan" %>
<%@ Register Src="../component/header/headerHome.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="../component/footer/footerHome.ascx" TagPrefix="ux" TagName="FooterHome" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thanh Toán</title>

    <link href="Styles/style.css" rel="stylesheet" />
     <link rel="stylesheet" href="../component/header/header.css" />
    <link rel="stylesheet" href="../component/footer/footer.css" />

    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f8f8;
           
        }

        .main-container {
          
           
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
        }

        order-summary {
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
        .btn-primary{
            background-color:blue;
            text-align:center;
            color:white;
            padding:8px;
            border:none;
            cursor:pointer;
            border-radius:3px;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
          <uc:Header ID="headerHome" runat="server" />
        <div class="main-container">
            <div style="margin:30px 0;  display: flex;
            gap: 30px;">
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

                    </div>

                    <asp:TextBox ID="txtSDTNhan" runat="server" CssClass="input" placeholder="Số điện thoại người nhận" />

                </div>

                <!-- Địa chỉ -->

                <h4>Địa chỉ nhận hàng</h4>

                <asp:TextBox ID="txtDiaChi" runat="server" CssClass="input" placeholder="Số nhà, tên đường" />

                <asp:DropDownList ID="ddlQuocGia" runat="server" CssClass="input">

                    <asp:ListItem Text="Việt Nam" Value="VN" />

                </asp:DropDownList>

                <asp:DropDownList ID="ddlTinh" runat="server" CssClass="input" AutoPostBack="true" OnSelectedIndexChanged="ddlTinh_SelectedIndexChanged" />

                <asp:DropDownList ID="ddlHuyen" runat="server" CssClass="input" AutoPostBack="true" OnSelectedIndexChanged="ddlHuyen_SelectedIndexChanged" />

                <asp:DropDownList ID="ddlXa" runat="server" CssClass="input" AutoPostBack="true" />

                <!-- Ghi chú -->

                <asp:TextBox ID="txtGhiChu" runat="server" CssClass="input" TextMode="MultiLine" Rows="3" placeholder="Ghi chú (nếu có)..." />

            </div>

            <!-- Cột phải: Thông tin đơn hàng -->

            <div class="right-column">

                <h3>Thông Tin Đơn Hàng</h3>

                <asp:Repeater runat="server" ID="rptListoder">

                    <ItemTemplate>

                        <div class="listOrdered">

                            <div class="ordered" style="padding: 5px; border-radius: 5px; border-bottom: 1px gray solid; display: grid; grid-template-columns: 1fr 2fr; align-items: center">

                                <img class="imgOdered" style="width: 70px; height: 70px; border-radius: 5px;" src="<%# Eval("img0") %>" />

                                <div>

                                    <p class="nameOrdered" style="color: #2d2a6e; font-size: 16px; font-weight: 500"><%# Eval("nameItem")%> </p>

                                    <div class="priceAndQuantity" style="display: grid; grid-template-columns: 3fr 1fr; align-items: center">
                                        <p class="priceOrdered" style="color: red"><%# Eval("promotion").ToString()=="0"? Eval("price").ToString(): Eval("promotion").ToString()%>đ</p>

                                        <div style="width: 20px; height: 20px; color: #fff; border-radius: 100%; display: flex; justify-content: center; align-items: center; background-color: #2d2a6e" class="quantityOrdered"><%# Eval("quantity") %></div>

                                    </div>

                                </div>

                            </div>

                        </div>

                    </ItemTemplate>

                </asp:Repeater>
                <div class="totalPay">

                    <span>Tổng tiến:</span>

                    <asp:Label runat="server" ID="totalMoney" Style="color: #A4B465"></asp:Label>

                </div>
                <div style="display:flex;justify-content:flex-end;padding:5px;">
                <asp:Button ID="btnThanhToan" runat="server" Text="thanh toán" OnClick="btnThanhToan_Click" CssClass="btn-primary" />

                </div>

            </div>
                </div>
        </div>
          <ux:FooterHome ID="footerHome" runat="server" />
    </form>

</body>
</html>
