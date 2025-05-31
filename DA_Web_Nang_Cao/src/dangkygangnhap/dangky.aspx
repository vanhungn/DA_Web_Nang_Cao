<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dangky.aspx.cs" Inherits="DA_Web_Nang_Cao.src.dangkygangnhap.dangky" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet" />
    <title>Đăng ký tài khoản</title>
    <style>
        body {
            font-family: Arial;
            background-color: #f2f2f2;
        }

        .form-container {
            background-color: white;
            width: 80%;
            margin: 50px auto;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 10px gray;
        }

        .form-row {
            display: flex;
            gap: 30px;
        }

        .form-column {
            flex: 1;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        input[type="text"],
        input[type="password"],
        input[type="email"],
        input[type="tel"],
        .form-column input,
        .form-column .captcha {
            width: 100%;
            padding: 8px;
            box-sizing: border-box;
            border-radius: 5px;
            border: 1px solid #ccc;
        }

        .captcha {
            font-weight: bold;
            font-size: 18px;
            background: #eee;
            padding: 5px;
            display: inline-block;
            width: auto;
        }

        .refresh-btn {
            margin-left: 10px;
            padding: 5px 10px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .button-group {
            text-align: center;
            margin-top: 20px;
        }

        .button-group input {
            padding: 10px 20px;
            background-color: #88b011;
            color: white;
            border: none;
            border-radius: 5px;
            margin-right: 10px;
            cursor: pointer;
        }
        .captcha-container {
    display: flex;
    align-items: center;
    margin-top: 5px;
}

.captcha {
    font-weight: bold;
    font-size: 18px;
    background: #eee;
    padding: 5px 10px;
    border-radius: 4px;
    margin-right: 10px;
}

.refresh-icon {
    font-size: 20px;
    color: #007bff;
    text-decoration: none;
    cursor: pointer;
}

.refresh-icon:hover {
    color: #0056b3;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2 style="text-align:center;">Đăng ký tài khoản</h2>
            <div class="form-row">
                <div class="form-column">
                    <div class="form-group">
                        <label>Họ và tên</label>
                        <asp:TextBox ID="txtFullName" runat="server" Placeholder="* họ tên" />
                        <asp:RequiredFieldValidator runat="server" ID="rfvFullName" EnableClientScript="true" ForeColor="red" ControlToValidate="txtFullName" ErrorMessage="Bạn không được để trống ô nay, nhập lại">

</asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label>Điện thoại</label>
                        <asp:TextBox ID="txtPhone" runat="server"  />
                                                <asp:RequiredFieldValidator runat="server" ID="rfvphone" EnableClientScript="true" ForeColor="red" ControlToValidate="txtphone" ErrorMessage="Bạn không được để trống ô nay, nhập lại">

</asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label>Địa chỉ</label>
                        <asp:TextBox ID="txtAddress" runat="server" />
                          <asp:RequiredFieldValidator runat="server" ID="rfvAddress" EnableClientScript="true" ForeColor="red" ControlToValidate="txtAddress" ErrorMessage="Bạn không được để trống ô nay, nhập lại">

</asp:RequiredFieldValidator>

                    </div>
                    <div class="form-group">
                        <label>Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"  />
                     <asp:RequiredFieldValidator runat="server" ID="rfvEmail" EnableClientScript="true" ForeColor="red" ControlToValidate="txtEmail" ErrorMessage="Bạn không được để trống ô nay, nhập lại">

</asp:RequiredFieldValidator>

                    </div>
                </div>

                <div class="form-column">
                    <div class="form-group">
                        <label>Tên truy cập</label>
                        <asp:TextBox ID="txtUsername" runat="server" />
                                             <asp:RequiredFieldValidator runat="server" ID="rfvUsername" EnableClientScript="true" ForeColor="red" ControlToValidate="txtUsername" ErrorMessage="Bạn không được để trống ô nay, nhập lại">

</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Mật khẩu</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                  <asp:RequiredFieldValidator runat="server" ID="rfvPassword" EnableClientScript="true" ForeColor="red" ControlToValidate="txtPassword" ErrorMessage="Bạn không được để trống ô nay, nhập lại">

</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label>Xác nhận mật khẩu</label>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"  />
                  <asp:RequiredFieldValidator runat="server" ID="rfvConfirmPassword" EnableClientScript="true" ForeColor="red" ControlToValidate="txtConfirmPassword" ErrorMessage="Bạn không được để trống ô nay, nhập lại">

</asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
    <label>Mã bảo mật</label>
    <asp:TextBox ID="txtCaptcha" runat="server" />

    <div class="captcha-container">
        <asp:Label ID="lblCaptcha" runat="server" CssClass="captcha" />
        <asp:LinkButton ID="btnRefreshCaptcha" runat="server" OnClick="btnRefreshCaptcha_Click" CssClass="refresh-icon" ToolTip="Đổi mã">
            <i class="fa fa-sync-alt"></i> <!-- Font Awesome icon -->
        </asp:LinkButton>
    </div>
</div>
                </div>
            </div>

            <div style="text-align:center; margin-top:20px;">
                Bạn đã có tài khoản?
                <a href="Login.aspx" style="color:#88b011; font-weight:bold; text-decoration:none;">Đăng nhập</a>
            </div>

            <div class="button-group">
                <asp:Button ID="btnRegister" runat="server" Text="Đăng ký" OnClick="btnRegister_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Làm lại" OnClientClick="document.getElementById('form1').reset(); return false;" OnClick="btnReset_Click" />
            </div>

            <asp:Label ID="lblMessage" runat="server" ForeColor="red" />
        </div>
    </form>
</body>
</html>

