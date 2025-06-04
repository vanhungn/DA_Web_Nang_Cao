<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DA_Web_Nang_Cao.src.dangkydangnhap.login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title></title>
    <style>
        body {
            font-family: Arial;
            background: #f4f4f4;
        }
        .login-box {
            width: 400px;
            margin: 60px auto;
            background: #fff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 0 10px #ccc;
            text-align: center;
        }
        .login-box input[type="text"],
        .login-box input[type="password"] {
            width: 90%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        .btn-login {
            background-color: #88b011;
            color: white;
            padding: 10px 20px;
            border: none;
            font-weight: bold;
            border-radius: 4px;
            cursor: pointer;
        }
        .link {
            margin-top: 10px;
            color: #f57c00;
            text-decoration: none;
        }
        .social-login button {
            padding: 10px 15px;
            margin: 5px;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-weight: bold;
        }
        .facebook { background-color: #3b5998; }
        .google { background-color: #db4437; }
        .zalo { background-color: #0078ff; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="login-box">
            <asp:TextBox ID="txtUsername" runat="server" Placeholder="* Tên truy cập" /><br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="* Mật khẩu" /><br />
            <asp:Button ID="btnLogin" runat="server" CssClass="btn-login" Text="ĐĂNG NHẬP" OnClick="btnLogin_Click" /><br />

            <div style="margin-top: 10px;">
                <a href="ForgotPassword.aspx" class="link">Bạn quên mật khẩu?</a><br />
                <span> Bạn chưa có tài khoản? </span>
                <a href="dangky.aspx" style="color:#f57c00; font-weight:bold; text-decoration:none;">Đăng ký ngay</a>
            </div>

            <div class="social-login" style="margin-top:20px;">
                <button type="button" class="facebook" onclick="location.href='ExternalLogin.aspx?provider=Facebook'">
                     <img src="https://cdn.tgdd.vn/2020/03/GameApp/Facebook-200x200.jpg" alt="facebook Icon" style="height:16px; vertical-align:middle;" /> Đăng nhập với facebook
                </button>
               <button type="button" class="google" onclick="location.href='ExternalLogin.aspx?provider=Google'">
            <img src="https://img.idesign.vn/2023/02/idesign_logogg_1.jpg" alt="Google Icon" style="height:16px; vertical-align:middle;" /> Đăng nhập với Google
        </button>
        <button type="button" class="zalo">
     <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Icon_of_Zalo.svg/2048px-Icon_of_Zalo.svg.png" alt="zalo Icon" style="height:16px; vertical-align:middle;" /> Đăng nhập với zalo
                </button>
            </div>
        </div>
    </form>
</body>
</html>
