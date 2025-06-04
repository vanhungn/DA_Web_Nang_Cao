<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LienHe.aspx.cs" Inherits="DA_Web_Nang_Cao.src.LienHe.LienHe" %>

<%@ Register Src="../component/header/headerHome.ascx" TagPrefix="uc" TagName="Header" %>
<%@ Register Src="../component/footer/footerHome.ascx" TagPrefix="ux" TagName="FooterHome" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Liên Hệ</title>
    <link href="LienHe.css" rel="stylesheet" />
    <link rel="stylesheet" href="../component/header/header.css" />
    <link rel="stylesheet" href="../component/footer/footer.css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:Header ID="headerHome" runat="server" />
        <div class="message-box">
            <asp:Literal ID="lblMessage" runat="server" EnableViewState="false" />
        </div>
        <div class="wrapper">
            <div class="form-section">
                <h2>GỬI THÔNG TIN CHO CHÚNG TÔI!</h2>
                <hr />
                <div class="form-row">
                    <div class="form-group">
                        <label>Họ và tên *</label>
                        <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ControlToValidate="txtHoTen" runat="server"
                            ErrorMessage="Vui lòng nhập họ tên!" CssClass="text-danger" Display="Dynamic" />
                    </div>
                    <div class="form-group">
                        <label>Email *</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ControlToValidate="txtEmail" runat="server"
                            ErrorMessage="Vui lòng nhập email!" CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ControlToValidate="txtEmail" runat="server"
                            ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"
                            ErrorMessage="Email không hợp lệ!" CssClass="text-danger" Display="Dynamic" />
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group">
                        <label>Số điện thoại *</label>
                        <asp:TextBox ID="txtSDT" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ControlToValidate="txtSDT" runat="server"
                            ErrorMessage="Vui lòng nhập SĐT!" CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ControlToValidate="txtSDT" runat="server"
                            ValidationExpression="^(0|\+84|84)(3|5|7|8|9)\d{8}$"
                            ErrorMessage="Số điện thoại không hợp lệ!" CssClass="text-danger" Display="Dynamic" />
                    </div>
                    <div class="form-group">
                        <label>Địa chỉ *</label>
                        <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ControlToValidate="txtDiaChi" runat="server"
                        ErrorMessage="Vui lòng nhập địa chỉ!" CssClass="text-danger" Display="Dynamic" />
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group" style="flex: 1 1 100%;">
                        <label>Nội dung *</label>
                        <asp:TextBox ID="txtNoiDung" runat="server" CssClass="textarea-control" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator ControlToValidate="txtNoiDung" runat="server"
                            ErrorMessage="Vui lòng nhập nội dung!" CssClass="text-danger" Display="Dynamic" />
                    </div>
                </div>

                <div class="form-row">
                    <div class="form-group" style="flex: 1 1 100%;">
                        <label>Mã bảo mật *</label>
                        <div class="captcha-box">
                            <asp:TextBox ID="txtCaptcha" runat="server" CssClass="captcha-input" />
                            <asp:Label ID="lblCaptcha" runat="server" CssClass="captcha-code" />
                            <asp:Button ID="btnTaoLaiCaptcha" runat="server" Text="↻" CssClass="refresh-btn" OnClick="btnTaoLaiCaptcha_Click" CausesValidation="false" />
                        </div>
                        <asp:RequiredFieldValidator ControlToValidate="txtCaptcha" runat="server"
                            ErrorMessage="Vui lòng nhập mã bảo mật!" CssClass="text-danger" Display="Dynamic" />
                    </div>
                </div>

                <div class="btn-row">
                    <asp:Button ID="btnGui" runat="server" Text="GỬI ĐI" CssClass="btn submit" OnClick="btnGui_Click" />
                    <asp:Button ID="btnLamLai" runat="server" Text="LÀM LẠI" CssClass="btn reset" OnClick="btnLamLai_Click" CausesValidation="false" />
                </div>
            </div>
            <!-- ✅ Phần ảnh liên hệ và thông tin -->
            <div class="info-section">
                <img src="anh lien he.jpg" alt="Liên hệ" />
                <ul>
                    <li>📍 344 Huỳnh Tấn Phát, Q.7, TP.HCM</li>
                    <li>📞 1900 9477</li>
                    <li>📧 admin@demo037187.web30s.vn</li>
                </ul>
            </div>
        </div>
        <ux:FooterHome ID="footerHome" runat="server" />
    </form>
</body>
</html>
