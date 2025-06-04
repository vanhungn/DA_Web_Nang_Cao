<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="DA_Web_Nang_Cao.src.product.product" %>

<%@ Register Src="../../component/header/headerHome.ascx" TagPrefix="ucc" TagName="Header" %>
<%@ Register Src="../../component/footer/footerHome.ascx" TagPrefix="uxx" TagName="FooterHome" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../component/header/header.css?v=126" />
    <link rel="stylesheet" href="../../component/footer/footer.css" />
    <link rel="stylesheet" href="product.css?v=127" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ucc:Header ID="headerHome1" runat="server" />
            <div class="productBody">
                <div class="topProduct">
                    <asp:HyperLink runat="server" NavigateUrl="/src/pages/home/home" style="text-decoration:none" CssClass="linkHome">TRANG CHỦ  >>  </asp:HyperLink>
                    <span class="linkProduct">SẢN PHẨM</span>
                </div>
                <div class="mainProduct">
                    <div class="leftMainProduct">
                        <h3 style="color: #41464c; font-weight: 500">DANH MỤC SẢN PHẨM</h3>
                        <ul class="categoryMainProduct">
                            <li class="titleCategoryMainProduct"><asp:Label runat="server" ID="titleCategoryProduct1">Bột, Ngũ cốc</asp:Label> <asp:Button runat="server" cssClass="buttonCategoryProduct" CommandName="category" CommandArgument="Bột, Ngũ cốc" OnCommand="OnCommentCategory" /></li>
                            <li class="titleCategoryMainProduct"><asp:Label runat="server" ID="titleCategoryProduct2">Rau củ quả</asp:Label>  <asp:Button runat="server" cssClass="buttonCategoryProduct" CommandName="category1" CommandArgument="Rau củ quả"  OnCommand="OnCommentCategory" /></li>
                            <li class="titleCategoryMainProduct"><asp:Label runat="server" ID="titleCategoryProduct3">Hải sản</asp:Label> <asp:Button runat="server" cssClass="buttonCategoryProduct" CommandName="category2" CommandArgument="Hải Sản"  OnCommand="OnCommentCategory"/></li>
                            <li class="titleCategoryMainProduct"><asp:Label runat="server" ID="titleCategoryProduct4">Thực phẩm đông lạnh</asp:Label> <asp:Button runat="server" cssClass="buttonCategoryProduct" CommandName="category3" CommandArgument="Thực Phẩm Đông Lạnh" OnCommand="OnCommentCategory" /></li>
                            <li class="titleCategoryMainProduct"><asp:Label runat="server" ID="titleCategoryProduct5">Sushi & Sashimi Deli</asp:Label> <asp:Button runat="server" cssClass="buttonCategoryProduct" CommandName="category4" CommandArgument="Sushi & Sashimi Deli" OnCommand="OnCommentCategory"/></li>
                            <li class="titleCategoryMainProduct"><asp:Label runat="server" ID="titleCategoryProduct6">Thịt - cá</asp:Label> <asp:Button runat="server" cssClass="buttonCategoryProduct" CommandName="category5" CommandArgument="Thịt - Cá" OnCommand="OnCommentCategory" /></li>
                        </ul>
                        <div class="newProductMain">
                            <h3 style="color: #41464c; font-weight: 500">SẢN PHẨM MỚI</h3>
                            <asp:Repeater runat="server" ID="rptListEarlyProduct">
                                <ItemTemplate>
                                    <div class="listEarlyProduct">
                                        <div style="padding: 5px; border-radius: 5px; border-bottom: 1px gray solid; display: grid; grid-template-columns: 1fr 1fr; align-items: center">
                                            <img style="width: 150px; height: 125px; border-radius: 5px;" src="<%# Eval("img0") %>" />
                                            <div>
                                                <p style="color: #2d2a6e; font-size: 16px; font-weight: 500"><%# Eval("nameItem") %></p>
                                                
                                                <div style="display: flex; gap: 15px; align-items: center">
                                                    <p style="color: red"><%# Eval("promotion").ToString()=="0"? Eval("price") : Eval("promotion") %>đ</p>
                                                    <p><s style="color: gray; font-size: 12px;"><%# Eval("price") %> đ</s></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="checkboxProduct">
                            <div class="originProduct">
                                <h3 style="color: #41464c; font-weight: 500">XUẤT XỨ</h3>
                                <asp:CheckBoxList ID="checkBocListOrigin" runat="server" CssClass="customCheckboxlist" AutoPostBack="true" OnSelectedIndexChanged="cbLocation_SelectedIndexChanged">
                                    <asp:ListItem Text="Hà Nội" Value="Hà Nội"></asp:ListItem>
                                    <asp:ListItem Value="Hồ Chí Minh" Text="Hồ Chí Minh"></asp:ListItem>
                                    <asp:ListItem Value="Lâm Đồng" Text="Lâm Đồng"></asp:ListItem>
                                    <asp:ListItem Value="Tiên Giang" Text="Tiên Giang"></asp:ListItem>
                                    <asp:ListItem Value="Đắk Lắk" Text="Đắk Lắk"></asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                            <div class="weightsProduct">
                                <h3 style="color: #41464c; font-weight: 500">KHỐI LƯỢNG</h3>
                                <asp:CheckBoxList ID="checkBocListWeight" runat="server" CssClass="customCheckboxlist" AutoPostBack="true" OnSelectedIndexChanged="cbLocation_SelectedIndexChanged">
                                    <asp:ListItem Text="300g" Value="300g"></asp:ListItem>
                                    <asp:ListItem Value="500g" Text="500g"></asp:ListItem>
                                    <asp:ListItem Value="1kg" Text="1kg"></asp:ListItem>
                                    <asp:ListItem Value="1.5kg" Text="1.5kg"></asp:ListItem>
                                    <asp:ListItem Value="2kg" Text="2kg"></asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>

                    <div class="leftMainProduct">
                        <div class="imgRightMainProduct">

                            <p class="contentInProduct">THỰC PHẨM SỨC KHỎE</p>
                            <h2 style="color: #41464c; font-weight: 500; margin: 0 0 0 25px;">THỰC PHẨM TƯƠI SẠCH 100% TỪ THIÊN NHIÊN</h2>
                        </div>
                        <div class="listNewProducts">
                            <asp:Repeater ID="rptProductsItem" runat="server">
                                <ItemTemplate>
                                    <div class="productItems">
                                        <div style="position:relative;width:100%;height:100%">
                                             <img class="imgItemProducts" src="<%# Eval("img0")%>" />
                                            <asp:Button runat="server" CssClass="buttonDetail" CommandArgument='<%# Eval("idItem")%>' CommandName="detailProduct" OnCommand="OnClickDetail"  UseSubmitBehavior="false" CausesValidation="false"/>
                                        </div>
                                        <div class="inforImgItemProducts">
                                            <h4 class="nameNewProducts"><%# Eval("nameItem") %></h4>
                                             <div style="display:flex;justify-content:center">
                                                      <asp:Button runat="server" Text="Mua Ngay"
                                                CssClass="addOrder"
                                                CommandName="Add"
                                                CommandArgument='<%# Eval("idItem") %>'
                                                OnCommand="AddOrder_Command" />
                                                </div>
                                            <div class="priceNewProducts">
                                                <span class="priceSells"><%# Eval("promotion").ToString() == "0" ? Eval("price") : Eval("promotion") %>đ</span>
                                                <span class="priceSelleds">
                                                    <%# Eval("promotion").ToString() == "0" ? "" : "<s>" + Eval("price") + "đ</s>" %>
                                                </span>

                                            </div>
                                        </div>
                                        <div class="pricePromotion">
                                            <span class="p_promotion"><%# Eval("percentPromotion") %>%</span>
                                           
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                        <div class="totalPages">
                            <asp:Button runat="server" ID="btn_starts" Text="<<" CssClass="buttonTotals" OnClick="btnPageFirsts" />
                            <asp:Repeater runat="server" ID="rpt_totalPages" OnItemDataBound="rptButtons_ItemDataBounds" OnItemCommand="rpt_pastPages">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btn_pages" Text='<%# Eval("past") %>' CssClass="buttonTotals" CommandName="partPages"
                                        CommandArgument='<%# Eval("past") %>' />
                                </ItemTemplate>
                            </asp:Repeater>
                          <asp:Button runat="server" ID="btn_ends" Text=">>" CssClass="buttonTotals" OnClick="btnPageLasts" />
                        </div>
                    </div>
                </div>
            </div>
            <uxx:FooterHome ID="footerHome" runat="server" />
        </div>
    </form>
</body>
</html>
