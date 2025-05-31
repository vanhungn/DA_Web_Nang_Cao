<%@ Page Language="C#" MasterPageFile="~/src/admin/masterAdmin/pageAdmin.master"  AutoEventWireup="true" CodeBehind="pageUser.aspx.cs" Inherits="DA_Web_Nang_Cao.src.admin.pageUser.pageUser" %>


   <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div style="padding-left: 50px; width: 78%; height: 100vh">
        <div class="boxSearchQuery">
            <asp:TextBox runat="server" ID="txt_searchItem" placeholder="Tìm kiếm ..." CssClass="textBoxSearchItem" AutoPostBack="true" OnTextChanged="OnchangeListItem" ></asp:TextBox>
            <div class="boxSelect">
                <asp:Button runat="server" ID="btn_addItem" CausesValidation="false" UseSubmitBehavior="false" CssClass="buttonAddItem" Text="+ Thêm mới" OnClick="OnclickButtonAddItem" />
                <asp:DropDownList ID="d_arrange" runat="server" CssClass="form-controlArrange"  AutoPostBack="true" OnSelectedIndexChanged="OnchangeListItem">
                    <asp:ListItem Text="Sắp Xếp" Value="" />
                    <asp:ListItem Text="Tăng Dần" Value="ASC" />
                    <asp:ListItem Text="Giảm Dần" Value="DESC" />
                </asp:DropDownList>
                 
            </div>
        </div>
        <asp:Panel runat="server" ID="p_DetailItem">
            <dt:Detail runat="server" ID="detail"></dt:Detail>
        </asp:Panel>
        <asp:Panel runat="server" ID="p_UpdateItem">
            <ud:Update runat="server" ID="update"></ud:Update>
        </asp:Panel>
        <asp:Panel runat="server" ID="p_CreateItem">
            <div style="width: 100%; text-align: center; margin: 25px;">
                <asp:Label runat="server" ID="lbl_titleCreateAndFix" CssClass="tileCreateAndFix">Thêm mới sản phẩm</asp:Label>

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
                    <asp:TextBox runat="server" ID="txt_weights" CssClass="txtcreate" placeholder="Cân nặng sản phẩm..."></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_weights" ErrorMessage="⚠️ Bạn vui lòng nhập cân nặng" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>
                    <asp:TextBox runat="server" ID="txt_origin" CssClass="txtcreate" placeholder="Nơi xuất xứ sản phẩm..."></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_origin" ErrorMessage="⚠️ Bạn vui lòng nhập nơi xuất xứ" CssClass="errorFormCreateAndFix"></asp:RequiredFieldValidator>
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
                <asp:Button runat="server" ID="btn_submitCreate" Text="Lưu" CssClass="submitCreate" OnClick="OnclickSubmitCreate" />
                <asp:Button runat="server" ID="bt_submitCancel" UseSubmitBehavior="false" Text="Hủy" CssClass="submitCancel" CausesValidation="false"  OnClick="OnclickCancel"/>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="p_listItem">

        <table style="width: 100%">
            <tr>
                <th>Mã</th>
                <th>Ảnh Sản Phẩm</th>
                <th>Tên Sản Phẩm</th>
                <th>Giá Sản Phẩm</th>
                <th>Khuyến Mãi</th>
                <th>Tổng Số Lượng</th>
                <th>Trạng Thái</th>
                <th></th>
            </tr>
            <asp:UpdatePanel ID="upListItems" runat="server">
    <ContentTemplate>
            <asp:Repeater runat="server" ID="rpt_ListItemsPageAdmin">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("idItem") %></td>
                        <td>
                            <img src='<%# Eval("img0") %>' class="imgProductItemTable" />
                            <img src='<%# Eval("img1") %>' class="imgProductItemTable" />
                            <img src='<%# Eval("img2") %>' class="imgProductItemTable" />
                        </td>
                        <td><%# Eval("nameItem") %></td>
                        <td><%# Eval("price") %>đ</td>
                        <td><%# Eval("promotion") %>%</td>
                        <td><%# Eval("totalQuantity") %></td>


                        <td>
                            <div style="padding: 8px; border-radius: 5px; background-color: #28a745; box-shadow: 0 4px 8px rgba(46, 204, 113, 0.4); text-align: center"><%# Eval("satus") %></div>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btn_edit" Text="Chi Tiết" Style="padding: 8px; background-color: #007bff; border: none; color: white; box-shadow: 0 4px 8px rgba(0, 123, 255, 0.4); border-radius: 5px;cursor:pointer"  CommandName="detail" CommandArgument='<%# Eval("idItem") %>' OnCommand="OnclickDetailItem" CausesValidation="false" UseSubmitBehavior="false"/>
                            <asp:Button runat="server" ID="btn_fix" Text="Sửa" Style="padding: 8px; background-color: #ffc107; border: none; color: black; box-shadow: 0 4px 8px rgba(255, 193, 7, 0.4); border-radius: 5px;cursor:pointer" CommandName="update" CommandArgument='<%# Eval("idItem") %>' OnCommand="OnclickUpdateItem" CausesValidation="false" UseSubmitBehavior="false" />
                            <asp:Button runat="server" ID="btn_delete" Text="Xóa" Style="padding: 8px; background-color: #dc3545; border: none; color: white; box-shadow: 0 4px 8px rgba(220, 53, 69, 0.4); border-radius: 5px;cursor:pointer" CommandName="delete"  CommandArgument='<%# Eval("idItem") %>' OnCommand="OnclickDelete" CausesValidation="false" UseSubmitBehavior="false" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
</asp:UpdatePanel>
        </table>
        <div class="totalPage">
            <asp:Button runat="server" ID="btn_start" Text="<<" CssClass="buttonTotal" OnClick="btnPageFirst" />
            <asp:Repeater runat="server" ID="rpt_totalPage" OnItemDataBound="rptButtons_ItemDataBound" OnItemCommand="rpt_pastPage">
                <ItemTemplate>

                    <asp:Button runat="server" ID="btn_page" Text='<%# Eval("past") %>' CssClass="buttonTotal" CommandName="partPage"
                        CommandArgument='<%# Eval("past") %>' />

                </ItemTemplate>
            </asp:Repeater>
            <asp:Button runat="server" ID="btn_end" Text=">>" CssClass="buttonTotal" OnClick="btnPageLast" />
        </div>
        </asp:Panel>

    </div>
</asp:Content>
