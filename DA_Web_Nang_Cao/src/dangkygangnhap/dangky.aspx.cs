using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace DA_Web_Nang_Cao.src.dangkygangnhap
{
    public partial class dangky : System.Web.UI.Page
    {
        private void GenerateCaptcha()
        {
            string captcha = GenerateRandomCaptchaCode();
            lblCaptcha.Text = captcha;
            Session["Captcha"] = captcha;
        }
        private string GenerateRandomCaptchaCode()
        {
            string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            Random rand = new Random();
            char[] result = new char[5];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = chars[rand.Next(chars.Length)];
            }
            return new string(result);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtCaptcha.Text != Session["Captcha"].ToString())
            {
                lblMessage.Text = "Mã bảo mật không đúng!";
                GenerateCaptcha(); 
                return;
            }

            string name = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string address = txtAddress.Text.Trim();
            string role = txtConfirmPassword.Text.Trim();

            string DefaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(DefaultConnection))
            {
                string sql = @"INSERT INTO USERS (names, phones, emails, userNames, passwords, roles, addresss, moneys)
                           VALUES (@name, @phone, @email, @username, @password, @role, @address, @money)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); 
                cmd.Parameters.AddWithValue("@role", role);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@money", 0);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Đăng ký thành công! <a href='Login.aspx'>Đăng nhập</a>";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Lỗi: " + ex.Message;
                }
            }
        }

        protected void btnRefreshCaptcha_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtConfirmPassword.Text = "";
            txtEmail.Text = "";
            txtFullName.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
            txtUsername.Text = "";
            GenerateCaptcha(); 
        }
    }
}