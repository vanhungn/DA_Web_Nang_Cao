<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="DA_Web_Nang_Cao.src.home.home" %>

<%@ Register Src="../component/header/headerHome.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="../component/footer/footerHome.ascx" TagPrefix="ux" TagName="FooterHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../component/header/header.css" />
    <link rel="stylesheet" href="../component/footer/footer.css" />
    <link rel="stylesheet" href="home.css" />

</head>
<body>
    <form id="form1" runat="server">
        <uc:Header ID="headerHome" runat="server" />

        <div class="bodyHome">
            <div class="topDeal">
                <h2 class="deal">TOP DEAL</h2>
                <h2 class="titleVegetable">Rau, Củ, Quả, sạch Giảm giá lớn </h2>
                <p class="save">Tiết kiệm lên đến 50% cho đơn hàng đầu tiên</p>
                <button class="homeProduct">Sản phẩm</button>
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
<asp:Repeater ID="rptProducts" runat="server" >
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
                <asp:Button runat="server" ID="btnAddOrder" Text="Mua"
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
                            <%
                                foreach (var items in SpecialProduct)
                                {
                            %>
                            <img class="imgItemProduct" src="<%=items.img0%>" />
                            <div class="inforImgItemProduct">
                                <h2 class="titleSpecialItems"><%=items.nameItem %></h2>
                                <div class="priceNewItemsProduct">
                                    <span class="priceSellItemProduct"><%= items.promotion==0?items.price:items.promotion %>đ </span>
                                    <span class="priceSelledItemProduct">
                                        <%= items.promotion == 0 ? "" : "<s>" + items.price + "đ</s>" %>
                                    </span>
                                </div>
                                <p style="margin-top: 15px"><b>Trạng thái:</b><span style="color: #96ae00; font-weight: 600; font-size: 16px"> <%= items.satus %></span></p>
                                <p><b>Xuất sứ:</b> <%=items.origin %></p>
                                <p><b>Mã mặt hàng:</b> <%=items.idItem %> </p>
                                <p><i><%=items.descs %></i></p>
                                <div class="addItemsProduct">
                                    <div>
                                        <span><b>Số lượng: </b></span>
                                        <select id="Select1">
                                            <option value="0">0</option>
                                            <option value="1">1</option>
                                            <option value="2">2</option>
                                            <option value="3">3</option>
                                            <option value="4">4</option>
                                            <option value="5">5</option>
                                            <option value="6">6</option>
                                        </select>
                                    </div>

                                    <button id="buttonAddNewOrderHome">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="#fff" viewBox="0 0 24 24">
                                            <path d="M7 18c-1.1 0-1.99.9-1.99 2S5.9 22 7 22s2-.9 2-2-.9-2-2-2zm10 
                                          0c-1.1 0-1.99.9-1.99 2S15.9 22 17 22s2-.9 
                                          2-2-.9-2-2-2zM7.16 14.26l.03.01L7.16 
                                          14.26zm12.38-2.45L19.6 13H7.59l-.94-2h12.89zm2.16-3.59c-.19-.24-.48-.38-.79-.38H5.21l-.94-2H1v2h2l3.6 
                                          7.59-1.35 2.44C4.52 17.37 5.48 19 7 19h12v-2H7.42c-.14 
                                          0-.25-.11-.25-.25l.03-.12.9-1.63h9.45c.75 
                                          0 1.41-.41 1.75-1.03l3.58-6.49c.13-.23.11-.52-.06-.74z" />
                                        </svg>
                                        THÊM VÀO GIỎ HÀNG</button>
                                </div>
                            </div>
                            <%}
                            %>
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
                            <% foreach (var item in SpecialProductPromotion)
                                { %>
                            <div class="productItem">
                                <img class="imgNewProduct" src="<%= item.img0 %>" />
                                <div style="display: grid; grid-template-columns: 1fr; grid-template-rows: 1fr">
                                    <h4 class="nameNewProduct"><%= item.nameItem %></h4>
                                    <div class="priceNewProduct">
                                        <span class="priceSell"><%= item.promotion==0?item.price:item.promotion %>đ </span>
                                        <span class="priceSelled">
                                            <%= item.promotion == 0 ? "" : "<s>" + item.price + "đ</s>" %>
                                        </span>
                                        <div class="addOrder">
                                            <svg class="iconAddOder" xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="#FA812F" viewBox="0 0 24 24">
                                                <path d="M7 18c-1.1 0-1.99.9-1.99 2S5.9 22 7 22s2-.9 2-2-.9-2-2-2zm10 
                                          0c-1.1 0-1.99.9-1.99 2S15.9 22 17 22s2-.9 
                                          2-2-.9-2-2-2zM7.16 14.26l.03.01L7.16 
                                          14.26zm12.38-2.45L19.6 13H7.59l-.94-2h12.89zm2.16-3.59c-.19-.24-.48-.38-.79-.38H5.21l-.94-2H1v2h2l3.6 
                                          7.59-1.35 2.44C4.52 17.37 5.48 19 7 19h12v-2H7.42c-.14 
                                          0-.25-.11-.25-.25l.03-.12.9-1.63h9.45c.75 
                                          0 1.41-.41 1.75-1.03l3.58-6.49c.13-.23.11-.52-.06-.74z" />
                                            </svg>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <% } %>
                        </div>
                        <div class="foodGuide">
                            <p class="food">Thực phẩm sạch</p>
                            <h3 class="newProduct">Cẩm Nang Chọn Thực phẩm</h3>
                            <div class="foodSelectionHuide">

                                <% foreach (var item in FoodGuide)
                                    { %>
                                <div class="productItem">
                                    <img class="imgNewProduct" src="<%= item.img0 %>" />
                                    <div style="padding: 10px; display: grid; grid-template-columns: 1fr; grid-template-rows: 1fr">
                                        <h4 class="nameNewProduct"><%= item.nameItem %></h4>
                                        <p><i style="color: #2d2a6e"><%=item.descs%></i></p>
                                        <p class="learnMore">Tìm hiểu thêm</p>
                                    </div>
                                </div>
                                <% } %>
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
