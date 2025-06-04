<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="updateItem.ascx.cs" Inherits="DA_Web_Nang_Cao.src.admin.pageItems.updateItem.updateItem" %>
 <div style="width: 100%; text-align: center; margin: 25px;">
                <asp:Label runat="server" ID="lbl_titleCreateAndFix" CssClass="tileCreateAndFix" Text="Sửa thông tin sản phẩm"></asp:Label>
            </div>
            <div class="formCreateAndFix">
                <div class="formCreateAndFixLeft">
                    <asp:TextBox runat="server" ID="txt_nameItem" CssClass="txtcreate" placeholder="Tên sản phẩm..."></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_nameItem" ErrorMessage="⚠️ Bạn vui lòng nhập tên sản phẩm" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="txt_price" TextMode="Number" CssClass="txtcreate" placeholder="Giá sản phẩm..."></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_price" ErrorMessage="⚠️ Bạn vui lòng nhập giá sản phẩm" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="txt_promotion" TextMode="Number" CssClass="txtcreate" placeholder="Khuyến mãi sản phẩm..."></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_promotion" ErrorMessage="⚠️ Bạn vui lòng nhập giá khuyến mãi" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="txt_totalQuantity" TextMode="Number" CssClass="txtcreate" placeholder="Tổng số lượng sản phẩm..."></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_totalQuantity" ErrorMessage="⚠️ Bạn vui lòng nhập tổng số lượng" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="txt_quantitySold" CssClass="txtcreate" placeholder="Sản phẩm đã bán..."></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_quantitySold" ErrorMessage="⚠️ Bạn vui lòng nhập số lượng đã bán" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>
                    <asp:DropDownList runat="server" ID="d_kindOfItem" CssClass="txtcreate">
                        <asp:ListItem Text="Loại mặt hàng" Value="" />
                        <asp:ListItem Text="Bột, Ngũ ốc" Value="Bột, Ngũ ốc" />
                        <asp:ListItem Text="Rau củ quả" Value="Rau củ quả" />
                        <asp:ListItem Text="Hải sản" Value="Hải sản" />
                        <asp:ListItem Text="Thực phẩm đông lạnh" Value="Thực phẩm đông lạnh" />
                        <asp:ListItem Text="Sushi & Sashimi Deli" Value="Sushi & Sashimi Deli" />
                        <asp:ListItem Text="Thịt - Cá" Value="Thịt - Cá" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="d_kindOfItem" ErrorMessage="⚠️ Bạn vui lòng nhập loại mặt hàng" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>
                    <asp:DropDownList runat="server" ID="d_statusCreate" CssClass="txtcreate">
                        <asp:ListItem Text="Trạng thái" Value="" />
                        <asp:ListItem Text="Còn hàng" Value="Còn hàng" />
                        <asp:ListItem Text="Hết hàng" Value="Hết hàng" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="d_statusCreate" ErrorMessage="⚠️ Bạn vui lòng nhập trạng thái mặt hàng" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>

                </div>
                <div class="formCreateAndFixRight">
                    <asp:DropDownList runat="server" ID="d_weightCreate" CssClass="txtcreate">
                        <asp:ListItem Text="Khối lượng" Value="" />
                        <asp:ListItem Text="300g" Value="300g"></asp:ListItem>
                        <asp:ListItem Value="500g" Text="500g"></asp:ListItem>
                        <asp:ListItem Value="1kg" Text="1kg"></asp:ListItem>
                        <asp:ListItem Value="1.5kg" Text="1.5kg"></asp:ListItem>
                        <asp:ListItem Value="2kg" Text="2kg"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="d_weightCreate" ErrorMessage="⚠️ Bạn vui lòng nhập cân nặng" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>
                    <asp:DropDownList runat="server" ID="d_originCreate" CssClass="txtcreate">
                        <asp:ListItem Text="Xuất xứ" Value="" />
                        <asp:ListItem Text="Hà Nội" Value="Hà Nội"></asp:ListItem>
                        <asp:ListItem Value="Hồ Chí Minh" Text="Hồ Chí Minh"></asp:ListItem>
                        <asp:ListItem Value="Lâm Đồng" Text="Lâm Đồng"></asp:ListItem>
                        <asp:ListItem Value="Tiên Giang" Text="Tiên Giang"></asp:ListItem>
                        <asp:ListItem Value="Đắk Lắk" Text="Đắk Lắk"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="d_originCreate" ErrorMessage="⚠️ Bạn vui lòng nhập nơi xuất xứ" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>
                    <div class="chooseImg">
                        <div>
                            <div>
                                <asp:Label runat="server" AssociatedControlID="fu_img0" Text="Chọn ảnh 1: " CssClass="pastChooseImg" />
                                <asp:FileUpload runat="server" ID="fu_img0" CssClass="hideInput" />
                            </div>
                            <div>
                                <asp:Image runat="server" ID="Img0" Width="90px" Height="90px" Style="border: 1px gray solid" />
                                <asp:Button runat="server" CssClass="buttonLook" ID="btn_lookPicture1" Text="Xem ảnh" OnClick="ClickLookPicture1" UseSubmitBehavior="false" CausesValidation="false" />
                            </div>
                        </div>
                        <div>
                            <div>
                                <asp:Label runat="server" AssociatedControlID="fu_img1" Text="Chọn ảnh 2: " CssClass="pastChooseImg" />
                                <asp:FileUpload runat="server" ID="fu_img1" CssClass="hideInput" />
                            </div>
                            <div>
                                <asp:Image runat="server" ID="Img1" Width="90px" Height="90px" Style="border: 1px gray solid" />
                                <asp:Button runat="server" CssClass="buttonLook" ID="btn_lookPicture2" Text="Xem ảnh" OnClick="ClickLookPicture2" UseSubmitBehavior="false" CausesValidation="false"/>
                            </div>

                        </div>
                        <div>
                            <div>
                                <asp:Label runat="server" AssociatedControlID="fu_img2" Text="Chọn ảnh 3: " CssClass="pastChooseImg" />
                                <asp:FileUpload runat="server" ID="fu_img2" CssClass="hideInput" />
                            </div>
                            <div>
                                <asp:Image runat="server" ID="Img2"  Width="90px" Height="90px" Style="border: 1px gray solid" />
                                <asp:Button runat="server" CssClass="buttonLook" ID="btn_lookPicture3" Text="Xem ảnh" OnClick="ClickLookPicture3" UseSubmitBehavior="false" CausesValidation="false"/>

                            </div>

                        </div>
                    </div>
                    <asp:TextBox runat="server" ID="txt_descs" TextMode="MultiLine" Rows="11" Columns="80" placeholder="Miêu tả sản phẩm..." CssClass="textBoxMultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_descs" ErrorMessage="⚠️ Bạn vui lòng nhập miêu tả sản phẩm" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="butonSubmitAndCancel">
                <asp:Button runat="server" ID="btn_submitCreate" Text="Lưu" CssClass="submitCreate" OnClick="OnclickUpdate" />
                <asp:Button runat="server" ID="bt_submitCancel" UseSubmitBehavior="false" Text="Hủy" CssClass="submitCancel" CausesValidation="false" OnClick="btnCancel_Click" />
            </div>