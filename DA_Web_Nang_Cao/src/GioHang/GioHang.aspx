<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="DA_Web_Nang_Cao.src.GioHang.GioHang" %>

<%@ Register Src="../component/header/headerHome.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="../component/footer/footerHome.ascx" TagPrefix="ux" TagName="FooterHome" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giỏ Hàng</title>
    <link href="GioHang.css?v123" rel="stylesheet" />
    <link rel="stylesheet" href="../component/header/header.css" />
    <link rel="stylesheet" href="../component/footer/footer.css" />
</head>
<body>

    <form id="form1" runat="server">
        <uc:Header ID="headerHome" runat="server" />
        <div style="margin:30px 0;">

       
        <div class="cart-container">
            <div >
                   <asp:Repeater runat="server" ID="rptListOder"  OnItemCommand="OnclickConFirm">

                    <ItemTemplate>

                        <div class="listOrdered">

                            <div class="ordered" style="padding: 5px; border-radius: 5px; border-bottom: 1px gray solid; display: flex;gap:10px; align-items: center">

                                <img class="imgOdered" style="width: 70px; height: 70px; border-radius: 5px;" src="<%# Eval("img0") %>" />

                                <div>

                                    <p class="nameOrdered" style="color: #2d2a6e; font-size: 16px; font-weight: 500"><%# Eval("nameItem")%> </p>

                                    <div class="priceAndQuantity" style="display: grid; grid-template-columns: 1fr 0.5fr 1fr 1fr;gap:9px; align-items: center">
                                        <p class="priceOrdered" style="color: red"><%# Eval("promotion").ToString()=="0"? Eval("price").ToString(): Eval("promotion").ToString()%>đ</p>

                                        <asp:TextBox runat="server" ID="txt_Quantity" style="text-align:center ;width:30px;height:30px" class="quantityOrdered" Text='<%# Eval("quantity") %>'></asp:TextBox>
                                        <asp:Button style="cursor:pointer;padding:5px;border:none;border-radius:5px;background-color:#2d2a6e;width:fit-content;color:#fff" runat="server" Text="Xác nhận" CommandArgument='<%# Eval("idOrder") %>'  CommandName="updateQuantity" />
                                        <asp:Button style="cursor:pointer;padding:5px;border:none;border-radius:5px;background-color:red;width:fit-content;color:#fff" Text="Xóa" runat="server" CommandArgument='<%# Eval("idOrder") %>' OnCommand="xoa" CommandName="delete" UseSubmitBehavior="false" CausesValidation="false"/>

                                    </div>

                                </div>

                            </div>

                        </div>

                    </ItemTemplate>

                </asp:Repeater>
            </div>

            <div class="cart-footer">
                <div class="total-amount">
                   <span>Tổng tiền:</span>
                    <asp:Label  CssClass="amount" ID="lblTongTient" runat="server"></asp:Label>
                </div>
                <div class="cart-buttons">
                    <asp:Button ID="btnXemThem" runat="server" Text="XEM THÊM SẢN PHẨM" CssClass="btn-green"  />
                    <asp:Button ID="btnThanhToan" runat="server" Text="THANH TOÁN" CssClass="btn-orange" />
                </div>
            </div>
        </div>
             </div>
        <ux:FooterHome ID="footerHome" runat="server" />
    </form>
</body>
</html>
