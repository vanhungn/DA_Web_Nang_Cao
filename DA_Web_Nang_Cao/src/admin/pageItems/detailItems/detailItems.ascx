<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="detailItems.ascx.cs" Inherits="DA_Web_Nang_Cao.src.admin.pageItems.detailItems.detailItems" %>

<div>
    <h1 style="text-align: center">Chi tiết sản phẩm</h1>

    <div class="box_detailItem">
        <div class="box_detailItemLeft">
            <asp:Image runat="server" ID="img0" CssClass="imgDetail" />
            <asp:Image runat="server" ID="img1" CssClass="imgDetail" />
            <asp:Image runat="server" ID="img2" CssClass="imgDetail" />
           
        </div>
        <div class="box_detailItemRight">
            <div>
                <div class="childrentItems">
                    <span class="titleChildrentItems">Mã sản phẩm: </span>
                    <asp:Label runat="server" ID="lbl_id"></asp:Label>
                </div>
                <div class="childrentItems">
                    <span class="titleChildrentItems">Tên sản phẩm: </span>
                    <asp:Label runat="server" ID="lbl_nameItem"></asp:Label>
                </div>
                <div class="childrentItems">
                    <span class="titleChildrentItems">Giá sản phẩm: </span>
                    <asp:Label runat="server" ID="lbl_price"></asp:Label>
                </div>
                <div class="childrentItems">
                    <span class="titleChildrentItems">Khuyến mãi: </span>
                    <asp:Label runat="server" ID="lbl_promotion"></asp:Label>
                </div>
                <div class="childrentItems">
                    <span class="titleChildrentItems">Tổng số lượng: </span>
                    <asp:Label runat="server" ID="lbl_totalQuantity"></asp:Label>
                </div>
            </div>
            <div>
                       <div class="childrentItems">
                <span class="titleChildrentItems">Số lượng đã bán: </span>
                <asp:Label runat="server" ID="lbl_quantitySold"></asp:Label>
            </div>
            <div class="childrentItems">
                <span class="titleChildrentItems">Loại sản phẩm: </span>
                <asp:Label runat="server" ID="lbl_kindOfItem"></asp:Label>
            </div>
            <div class="childrentItems">
                <span class="titleChildrentItems">Cân nặng: </span>
                <asp:Label runat="server" ID="lbl_weights"></asp:Label>
            </div>
            <div class="childrentItems">
                <span class="titleChildrentItems">Trạng thái: </span>
                <asp:Label runat="server" ID="lbl_satus"></asp:Label>
            </div>
            <div class="childrentItems">
                <span class="titleChildrentItems">Xuất xứ: </span>
                <asp:Label runat="server" ID="lbl_origin"></asp:Label>
            </div>
            
            </div>
            <div style="grid-column: 1 / -1;">
                <span class="titleChildrentItems">Miêu tả: </span>
                <asp:Label runat="server" ID="lbl_descs"></asp:Label>
            </div>
        </div>
    </div>
    <div class="box_buttonCancel">
        <asp:Button runat="server" ID="btn_CancelDetail" OnClick="OnclickCancelDetail" CssClass="buttonCancel" Text="Thoát" />
    </div>


</div>
