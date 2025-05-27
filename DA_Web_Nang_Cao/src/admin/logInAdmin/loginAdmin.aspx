<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginAdmin.aspx.cs" Inherits="DA_Web_Nang_Cao.src.admin.logInAdmin.loginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="loginAdmin.css?v=124" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="backgroudAdmin">
            <div class="blurBackgound">
                  <div class="form_loginAdmin">
                <h1 class="title_loginAdmin">Wellcome</h1>
                <asp:TextBox CssClass="txtAdmin" runat="server" ID="txt_userNameAdmin" placeholder="Tài khoản..."></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" CssClass="validateUserNameAdmin" ControlToValidate="txt_userNameAdmin" ErrorMessage="⚠️ Bạn vui lòng nhập tài khoản!"></asp:RequiredFieldValidator>
                <asp:TextBox  CssClass="txtAdmin"  runat="server" ID="txt_passwordAdmin" TextMode="Password" placeholder="Mật khẩu..." ></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" CssClass="validateUserNameAdmin" ControlToValidate="txt_passwordAdmin" ErrorMessage="⚠️ Bạn vui lòng nhập mật khẩu!"></asp:RequiredFieldValidator>
                <br /><asp:Label runat="server" ID="lbl_errorUnsuccessful" CssClass="errorUnsuccessful" ></asp:Label>
                <asp:Button runat="server" ID="btn_loginAdmin" Text="Đăng nhập" CssClass="buttonLogin" OnClick="OnclickLoginAdmin" />
            </div>
            </div>
          
        </div>
    </form>
</body>
</html>
