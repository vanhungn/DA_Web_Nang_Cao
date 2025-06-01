<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="DA_Web_Nang_Cao.src.home.home"%>

<%@ Register Src="../../component/header/headerHome.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="../../component/footer/footerHome.ascx" TagPrefix="ux" TagName="FooterHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../component/header/header.css?v=123" />
    <link rel="stylesheet" href="../../component/footer/footer.css" />
    <link rel="stylesheet" href="home.css?v=125" />

</head>
<body>
    <form id="form1" runat="server">
        <uc:Header ID="headerHome" runat="server" />

        <div class="bodyHome">
            <div class="topDeal">
                <h2 class="deal">TOP DEAL</h2>
                <h2 class="titleVegetable">Rau, Củ, Quả, sạch Giảm giá lớn </h2>
                <p class="save">Tiết kiệm lên đến 50% cho đơn hàng đầu tiên</p>
                 <asp:HyperLink runat="server" CssClass="homeProduct" Text="Sản phẩm" NavigateUrl="/src/pages/product/product.aspx"></asp:HyperLink>
            </div>
            <div class="showItemProduct">

                <div class="listCategoryProduct">
                    <div class="category">
                        <img class="imgCa" src="https://demo037187.web30s.vn/datafiles/40264/upload/files/category-1.png" />
                        <h4 class="titleCategoryProduct">Bột, Ngũ cốc</h4>
                    </div>
                    <div class="category">
                        <img class="imgCa" src="https://demo037187.web30s.vn/datafiles/40264/upload/files/category-9.png" />
                        <h4 class="titleCategoryProduct">Rau Củ</h4>
                    </div>
                    <div class="category">
                        <img class="imgCa" src="https://demo037187.web30s.vn/datafiles/40264/upload/files/category-10.png" />
                        <h4 class="titleCategoryProduct">Hải Sản</h4>
                    </div>
                    <div class="category">
                        <img class="imgCa" src="https://demo037187.web30s.vn/datafiles/40264/upload/files/category-6.png" />
                        <h4 class="titleCategoryProduct">Thực Phẩm Đông Lạnh</h4>
                    </div>
                    <div class="category">
                        <img class="imgCa" src="https://demo037187.web30s.vn/datafiles/40264/upload/files/category-8.png" />
                        <h4 class="titleCategoryProduct">Sushi & Sashimi Deli</h4>
                    </div>
                    <div class="category">
                        <img class="imgCa" src="https://demo037187.web30s.vn/datafiles/40264/upload/files/category-3.png" />
                        <h4 class="titleCategoryProduct">Thịt - Cá</h4>
                    </div>
                </div>
                <div class="cleanFood">
                    <p class="food">Thực phẩm sạch</p>
                    <h3 class="newProduct">Sản Phẩm Mới</h3>
                    <div class="listNewProduct">
                        <asp:Repeater ID="rptProducts" runat="server">
                            <ItemTemplate>
                                <div class="productItem">
                                    <img class="imgItemProduct" src="<%# Eval("img0")%>" />
                                    <div class="inforImgItemProduct">
                                        <h4 class="nameNewProduct"><%# Eval("nameItem") %></h4>
                                        <div class="priceNewProduct">
                                            <span class="priceSell"><%# Eval("promotion").ToString() == "0" ? Eval("price") : Eval("promotion") %>đ</span>
                                            <span class="priceSelled">
                                                <%# Eval("promotion").ToString() == "0" ? "" : "<s>" + Eval("price") + "đ</s>" %>
                                            </span>
                                            <asp:Button runat="server" Text="Mua"
                                                CssClass="addOrder"
                                                CommandName="Add"
                                                CommandArgument='<%# Eval("idItem") %>'
                                                OnCommand="AddOrder_Command" />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <div class="specialProduct">
                        <div class="titleTimeSpecialProduct">
                            <div class="titleSpecialProduct">
                                <h2 class="titleSP">Sản phẩm ưu đãi <u style="color: #96ae00">trong tuần!</u></h2>
                                <p style="text-align: end">A virtual assistant collects the products from your list</p>
                            </div>
                            <div class="timeSpecialProduct">
                                <div class="timeSell">
                                    <p style="font-size: 30px; font-weight: 600">0</p>
                                    <p>Ngày</p>
                                </div>
                                <div class="timeSell">
                                    <p style="font-size: 30px; font-weight: 600">0</p>
                                    <p>Giờ</p>
                                </div>
                                <div class="timeSell">
                                    <p style="font-size: 30px; font-weight: 600">0</p>
                                    <p>Phút</p>
                                </div>
                                <div class="timeSell">
                                    <p style="font-size: 30px; font-weight: 600">0</p>
                                    <p>Giây</p>
                                </div>
                            </div>
                        </div>
                        <div class="itemProduct">

                            <asp:Repeater ID="rptSpecialProduct" runat="server">
                                <ItemTemplate>
                                    <img class="imgItemProduct" src="<%# Eval("img0")%>" />
                                    <div class="inforImgItemProduct">
                                        <h2 class="titleSpecialItems"><%# Eval("nameItem") %></h2>
                                        <div class="priceNewItemsProduct">
                                            <span class="priceSellItemProduct"><%# Eval("promotion").ToString()=="0"?Eval("price"):Eval("promotion")%>đ </span>
                                            <span class="priceSelledItemProduct">
                                                <%# Eval("promotion").ToString() == "0" ? "" : "<s>" + Eval("price") + "đ</s>" %>
                                            </span>
                                        </div>
                                        <p style="margin-top: 15px"><b>Trạng thái:</b><span style="color: #96ae00; font-weight: 600; font-size: 16px"> <%# Eval("satus") %></span></p>
                                        <p><b>Xuất sứ:</b> <%# Eval("origin") %></p>
                                        <p><b>Mã mặt hàng:</b> <%# Eval("idItem") %> </p>
                                        <p><i><%# Eval("descs") %></i></p>
                                        <div class="addItemsProduct">
                                            <div>
                                                <span><b>Số lượng: </b></span>
                                                <asp:DropDownList ID="selectQuantity" runat="server" Style="padding: 5px 10px; border-radius: 5px;">
                                                    <asp:ListItem Text="Số lượng" Value="1" />
                                                    <asp:ListItem Text="1" Value="1" />
                                                    <asp:ListItem Text="2" Value="2" />
                                                    <asp:ListItem Text="3" Value="3" />
                                                    <asp:ListItem Text="4" Value="4" />
                                                    <asp:ListItem Text="5" Value="5" />
                                                    <asp:ListItem Text="6" Value="6" />
                                                    <asp:ListItem Text="7" Value="7" />
                                                    <asp:ListItem Text="8" Value="8" />
                                                </asp:DropDownList>

                                            </div>

                                            <asp:Button runat="server"
                                                CssClass="buttonAddNewOrderHome"
                                                Style="cursor: pointer; border: none; font-size: 14px; font-weight: 500; color: #fff; padding: 10px 20px; background-color: #2d2a6e; transition: 1s; border-radius: 20px;"
                                                Text="THÊM VÀO GIỎ HÀNG"
                                                CommandArgument='<%# Eval("idItem") %>'
                                                OnCommand="AddOrder_Command" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                     
                    <div class="freshHome">
                        <div class="freshFood1">
                            <h2 class="titleFreshHome">THỰC PHẨM TƯƠI 
                                <br />
                                100% TỪ THIÊN NHIÊN</h2>
                            <button class="buttonFreshHome">SẢN PHẨM</button>
                        </div>
                        <div class="freshFood2">
                            <h2 class="titleFreshHome">LÀM BỮA SÁNG CỦA BẠN
                                <br />
                                KHỎE MẠNH & NHẸ NHÀNG</h2>
                            <button class="buttonFreshHome">SẢN PHẨM</button>
                        </div>
                        <div class="freshFood3">
                            <h2 class="titleFreshHome">SẢN PHẨM HỮU CƠ HÀM
                                <br />
                                LƯỢNG DINH DƯỠNG CAO NHẤT</h2>
                            <button class="buttonFreshHome">SẢN PHẨM</button>
                        </div>
                    </div>
                    <div class="cleanFood">
                        <p class="food">Thực phẩm sạch</p>
                        <h3 class="newProduct">Sản phẩm bán chạy</h3>
                        <div class="listNewProduct">
                            <asp:Repeater ID="rptSpecialProductPromotion" runat="server">
                                <ItemTemplate>
                                    <div class="productItem">
                                        <img class="imgNewProduct" src="<%# Eval("img0") %>" />
                                        <div style="display: grid; grid-template-columns: 1fr; grid-template-rows: 1fr">
                                            <h4 class="nameNewProduct"><%# Eval("nameItem") %></h4>
                                            <div class="priceNewProduct">
                                                <span class="priceSell"><%# Eval("promotion").ToString()=="0"?Eval("price"):Eval("promotion") %>đ </span>
                                                <span class="priceSelled">
                                                    <%# Eval("promotion").ToString()== "0" ? "" : "<s>" + Eval("price") + "đ</s>" %>
                                                </span>
                                                <asp:Button runat="server" Text="Mua"
                                                    CssClass="addOrder"
                                                    CommandName="Add"
                                                    CommandArgument='<%# Eval("idItem") %>'
                                                    OnCommand="AddOrder_Command" />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="foodGuide">
                            <p class="food">Thực phẩm sạch</p>
                            <h3 class="newProduct">Cẩm Nang Chọn Thực phẩm</h3>
                            <div class="foodSelectionHuide">

                                <asp:Repeater ID="rptFoodGuide" runat="server">

                                    <ItemTemplate>
                                        <div class="productItem">
                                            <img class="imgNewProduct" src="<%# Eval("img0") %>" />
                                            <div style="padding: 10px; display: grid; grid-template-columns: 1fr; grid-template-rows: 1fr">
                                                <h4 class="nameNewProduct"><%# Eval("nameItem") %></h4>
                                                <p><i style="color: #2d2a6e"><%# Eval("descs")%></i></p>
                                                <p class="learnMore">Tìm hiểu thêm</p>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <ux:FooterHome ID="footerHome" runat="server" />
    </form>
</body>
</html>
