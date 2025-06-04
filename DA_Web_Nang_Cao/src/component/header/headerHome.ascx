<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headerHome.ascx.cs" Inherits="DA_Web_Nang_Cao.src.component.header.headerHome" %>

<div>
    <div class="topHeader">
        <div class="informOpen">
            <span class="img">
                <img class="imgVN" src="https://demo037187.web30s.vn/assets/images/language/vn.svg" />
            </span>
            <span class="open">Thời gian mở cửa: <b>Hàng ngày (8:00 - 21:00)</b>
            </span>
        </div>
        <div class="checkOrder">
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none"
                stroke="white" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                class="feather feather-clipboard">
                <path d="M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2" />
                <rect x="8" y="2" width="8" height="4" rx="1" ry="1" />
                <line x1="9" y1="12" x2="15" y2="12" />
                <line x1="9" y1="16" x2="15" y2="16" />
            </svg>
            <span class="open">Kiểm Tra Đơn Hàng</span>
        </div>
    </div>
    <div class="headerMain">
        <div>
            <img class="logo" src="https://demo037187.web30s.vn/datafiles/40264/upload/images/logo%281%29.png" />
        </div>
        <div class="linkPage">
            <ul>
                <li>
                    <asp:HyperLink CssClass="hyperLinkHeader" runat="server" ID="lbl_homeLink" NavigateUrl="/src/pages/home/home">TRANG CHỦ</asp:HyperLink>

                </li>
                <li><asp:Label runat="server" ID="lbl_IntroduceLink">GIỚI THIỆU</asp:Label> </li>
                <li><asp:HyperLink CssClass="hyperLinkHeader" runat="server" ID="lbl_ProductLink" NavigateUrl="/src/pages/product/product">SẢN PHẨM</asp:HyperLink>
                   <svg class="iconDown" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#2d2a6e" viewBox="0 0 16 16">
                       <path fill-rule="evenodd" d="M8 1v12.293l3.646-3.647.708.708L8 15l-4.354-4.354.708-.708L8 13.293V1z" />
                   </svg>
                    <div class="categoryProduct">
                        
                            <asp:Button CssClass="ctProduct" Text="Bột, Ngũ cốc" runat="server" CommandName="category" CommandArgument="Bột, Ngũ cốc" OnCommand="OnCommentCategoryHeader" />
                            <asp:Button CssClass="ctProduct" Text="Rau củ quả" runat="server" CommandName="category" CommandArgument="Rau củ quả" OnCommand="OnCommentCategoryHeader" />
                            <asp:Button CssClass="ctProduct" Text="Hải sản" runat="server" CommandName="category" CommandArgument="Hải Sản" OnCommand="OnCommentCategoryHeader" />
                            <asp:Button CssClass="ctProduct" Text="Thực phẩm đông lạnh" runat="server" CommandName="category" CommandArgument="Thực Phẩm Đông Lạnh" OnCommand="OnCommentCategoryHeader" />
                            <asp:Button CssClass="ctProduct" Text="Sushi & Sashimi Deli" runat="server" CommandName="category" CommandArgument="Sushi & Sashimi Deli" OnCommand="OnCommentCategoryHeader" />
                            <asp:Button CssClass="ctProduct" Text="Thịt - Cá" runat="server" CommandName="category" CommandArgument="Thịt - Cá" OnCommand="OnCommentCategoryHeader" />
                       
                    </div>
                </li>
                <li><asp:Label runat="server" ID="lbl_serviceLink">DỊCH VỤ</asp:Label>
                    <svg class="iconDown" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#2d2a6e" viewBox="0 0 16 16">
                        <path fill-rule="evenodd" d="M8 1v12.293l3.646-3.647.708.708L8 15l-4.354-4.354.708-.708L8 13.293V1z" />
                    </svg>
                    <div class="categoryProduct">
                        <p class="ctProduct">Hỗ Trợ Khách Hàng</p>
                        <p class="ctProduct">Dịch vụ khác</p>
                    </div>

                </li>
                <li><asp:Label runat="server" ID="lbl_newsLink">TIN TỨC</asp:Label>
                    
                    <svg class="iconDown" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#2d2a6e" viewBox="0 0 16 16">
                        <path fill-rule="evenodd" d="M8 1v12.293l3.646-3.647.708.708L8 15l-4.354-4.354.708-.708L8 13.293V1z" />
                    </svg>
                    <div class="categoryProduct">
                        <p class="ctProduct">Kiến Thức</p>
                        <p class="ctProduct">Sống Khỏe</p>
                    </div>
                </li>
                <li><asp:Label runat="server" ID="lbl_LibraryLink">THƯ VIỆN</asp:Label>
                   <svg class="iconDown" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#2d2a6e" viewBox="0 0 16 16">
                       <path fill-rule="evenodd" d="M8 1v12.293l3.646-3.647.708.708L8 15l-4.354-4.354.708-.708L8 13.293V1z" />
                   </svg>
                    <div class="categoryProduct">
                        <p class="ctProduct">Thư Viện Ảnh</p>
                        <p class="ctProduct">Video</p>
                    </div>
                </li>
                <li><asp:HyperLink CssClass="hyperLinkHeader" NavigateUrl="/src/LienHe/LienHe" runat="server" ID="lbl_ContactLink">LIÊN HỆ</asp:HyperLink></li>

            </ul>

        </div>
        <div class="toolBar">

            <div class="informOrder">
                <div class="tool1">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none"
                        stroke=" #2d2a6e" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                        class="feather feather-user">
                        <path d="M20 21v-2a4 4 0 0 0-3-3.87" />
                        <path d="M4 21v-2a4 4 0 0 1 3-3.87" />
                        <circle cx="12" cy="7" r="4" />
                    </svg>

                </div>
                <div class="payOrder" style="width: 190px; padding: 0; cursor: pointer">
                    <p class="ctProduct">Đăng ký</p>
                    <p class="ctProduct">Đăng nhập</p>
                </div>
            </div>
            <div class="informOrder">
                <asp:Panel runat="server" ID="p_opendBoxSearch" class="tool2">
                    <asp:Button runat="server" ID="btn_opendSearch" OnClick="OnclickOpendSearch" CssClass="buttonOpendSearch" />
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none"
                        stroke="#2d2a6e" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                        class="feather feather-search">
                        <circle cx="11" cy="11" r="8" />
                        <line x1="21" y1="21" x2="16.65" y2="16.65" />
                    </svg>

                </asp:Panel>
                <asp:Panel runat="server" ID="p_boxSearch" CssClass="boxSearch">
                    <asp:TextBox runat="server" ID="txt_search" CssClass="txt_searchCss" placeholder="Nhập từ khóa tìm kiếm..."></asp:TextBox>
                    <div>
                        <asp:Panel runat="server" CssClass="p_search">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none"
                                stroke="#2d2a6e" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                                class="feather feather-search">
                                <circle cx="11" cy="11" r="8" />
                                <line x1="21" y1="21" x2="16.65" y2="16.65" />
                            </svg>
                        </asp:Panel>
                        <asp:Button runat="server" OnClick="OnclickSearchProduct" CssClass="buttonSearchProduct" />
                    </div>
                </asp:Panel>
            </div>

            <div class="informOrder">
                <div class="tool3">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none"
                        stroke="#2d2a6e" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                        class="feather feather-shopping-bag">
                        <path d="M6 2l1.5 6h9L18 2" />
                        <path d="M3 6h18v14a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V6z" />
                        <line x1="9" y1="10" x2="9" y2="16" />
                        <line x1="15" y1="10" x2="15" y2="16" />
                    </svg>
               
                <div class="inform">

                    <asp:Label runat="server" ID="lblInform"></asp:Label>


                </div>
                
                <div class="payOrder">

                    <asp:Label runat="server" ID="lblCorrect" Style="text-align: center; font-size: 14px; margin-bottom: 25px"></asp:Label>
                    <asp:Repeater runat="server" ID="rptListOder">
                        <ItemTemplate>
                            <div class="listOrdered">
                                <div class="ordered" style="padding: 5px; border-radius: 5px; border-bottom: 1px gray solid; display: grid; grid-template-columns: 1fr 2fr; align-items: center">
                                    <img class="imgOdered" style="width: 70px; height: 70px; border-radius: 5px;" src="<%# Eval("img0") %>" />
                                    <div>
                                        <p class="nameOrdered" style="color: #2d2a6e; font-size: 16px; font-weight: 500; margin: 0"><%# Eval("nameItem") %></p>
                                        <div class="priceAndQuantity" style="display: grid; grid-template-columns: 3fr 1fr; align-items: center">
                                            <p class="priceOrdered" style="color: red"><%# Eval("promotion").ToString()=="0"? Eval("price").ToString() : Eval("promotion").ToString() %>đ</p>
                                            <div style="width: 20px; height: 20px; color: #fff; border-radius: 100%; display: flex; justify-content: center; align-items: center; background-color: #2d2a6e" class="quantityOrdered"><%# Eval("quantity") %></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                    <div class="totalPay">
                        <span>Tổng tiền:</span>
                        <asp:Label runat="server" ID="totalMoney" Style="color: #A4B465"></asp:Label>
                    </div>
                    <asp:Button runat="server" ID="buttonShoppingCart" CssClass="buttonShoppingCart" Text="Giỏ hàng" OnClick="OnclickGioHang" />

                    <asp:Button runat="server" ID="buttonPay" CssClass="buttonPay" Text="Thanh toán"  OnClick="OnclickThanhToan"/>
                </div>
            </div>

                <asp:Repeater runat="server" ID="rptTotalMony">
                     <ItemTemplate>
                        <span class="totalMonmey" style=" margin-left:12px;font-size:14px;"><%# Eval("moneys") %></span>
                     </ItemTemplate>
                </asp:Repeater>
        </div>
    </div>

</div>

</div>