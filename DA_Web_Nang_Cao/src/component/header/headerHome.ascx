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
                <li>TRANG CHỦ</li>
                <li>GIỚI THIỆU</li>
                <li>SẢN PHẨM
                   <svg class="iconDown" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#2d2a6e" viewBox="0 0 16 16">
                       <path fill-rule="evenodd" d="M8 1v12.293l3.646-3.647.708.708L8 15l-4.354-4.354.708-.708L8 13.293V1z" />
                   </svg>
                    <div class="categoryProduct">
                        <p class="ctProduct">Bột, Ngũ cốc</p>
                        <p class="ctProduct">Rau củ quả</p>
                        <p class="ctProduct">Hải sản</p>
                        <p class="ctProduct">Thực phẩm đông lạnh</p>
                        <p class="ctProduct">Sushi & Sashimi Deli</p>
                        <p class="ctProduct">Thịt - Cá</p>
                    </div>
                </li>
                <li>DỊCH VỤ
                    <svg class="iconDown" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#2d2a6e" viewBox="0 0 16 16">
                        <path fill-rule="evenodd" d="M8 1v12.293l3.646-3.647.708.708L8 15l-4.354-4.354.708-.708L8 13.293V1z" />
                    </svg>
                    <div class="categoryProduct">
                        <p class="ctProduct">Hỗ Trợ Khách Hàng</p>
                        <p class="ctProduct">Dịch vụ khác</p>
                    </div>

                </li>
                <li>TIN TỨC
                    
                    <svg class="iconDown" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#2d2a6e" viewBox="0 0 16 16">
                        <path fill-rule="evenodd" d="M8 1v12.293l3.646-3.647.708.708L8 15l-4.354-4.354.708-.708L8 13.293V1z" />
                    </svg>
                    <div class="categoryProduct">
                        <p class="ctProduct">Kiến Thức</p>
                        <p class="ctProduct">Sống Khỏe</p>
                    </div>
                </li>
                <li>THƯ VIỆN
                   <svg class="iconDown" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="#2d2a6e" viewBox="0 0 16 16">
                       <path fill-rule="evenodd" d="M8 1v12.293l3.646-3.647.708.708L8 15l-4.354-4.354.708-.708L8 13.293V1z" />
                   </svg>
                    <div class="categoryProduct">
                        <p class="ctProduct">Thư Viện Ảnh</p>
                        <p class="ctProduct">Video</p>
                    </div>
                </li>
                <li>LIÊN HỆ</li>

            </ul>

        </div>
        <div class="toolBar">
            <div class="tool1">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none"
                    stroke=" #2d2a6e" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                    class="feather feather-user">
                    <path d="M20 21v-2a4 4 0 0 0-3-3.87" />
                    <path d="M4 21v-2a4 4 0 0 1 3-3.87" />
                    <circle cx="12" cy="7" r="4" />
                </svg>

            </div>
            <div class="tool2">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none"
                    stroke="#2d2a6e" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                    class="feather feather-search">
                    <circle cx="11" cy="11" r="8" />
                    <line x1="21" y1="21" x2="16.65" y2="16.65" />
                </svg>

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
                </div>
                <div class="inform">0</div>
                <div class="payOrder">
                    <p style="text-align:center; font-size:14px; margin-bottom:25px">Không có thông tin cho loại dữ liệu này</p>
                    <div class="totalPay">
                        <span>Tổng tiền:</span>
                        <span style="color:#A4B465">0đ</span>
                    </div>
                    <button class="buttonShoppingCart">Giỏ hàng</button>
                    <button class="buttonPay">Thanh toán</button>
                </div>
            </div>
            <span class="totalMonmey">1.000.000.000 đ</span>
        </div>
    </div>
    </div>

