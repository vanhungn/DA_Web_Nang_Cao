using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web; // dùng Cookie

namespace DA_Web_Nang_Cao.src.LienHe
{
    public partial class LienHe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GenerateCaptcha();
            }
        }

        protected void btnTaoLaiCaptcha_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        private void GenerateCaptcha()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var rand = new Random();
            string captcha = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[rand.Next(s.Length)])
                          .ToArray()
            );

            lblCaptcha.Text = captcha;
            Session["Captcha"] = captcha;
        }

        protected void btnGui_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string maCaptcha = Session["Captcha"] as string;
                string nhapCaptcha = txtCaptcha.Text.Trim();

                if (!string.IsNullOrEmpty(maCaptcha) &&
                    nhapCaptcha.Equals(maCaptcha, StringComparison.OrdinalIgnoreCase))
                {
                    string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        string query = @"INSERT INTO LienHe (HoTen, Email, SDT, DiaChi, NoiDung, userNames)
                                 VALUES (@HoTen, @Email, @SDT, @DiaChi, @NoiDung, @userNames)";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text.Trim());

                        string userNames = null;
                        if (Request.Cookies["loginUser"] != null)
                        {
                            userNames = Request.Cookies["loginUser"]["userNames"];
                        }
                        cmd.Parameters.AddWithValue("@userNames", userNames ?? (object)DBNull.Value);

                        try
                        {
                            conn.Open();

                            // ✅ KIỂM TRA TRÙNG EMAIL HOẶC SĐT
                            string checkQuery = "SELECT COUNT(*) FROM LienHe WHERE Email = @Email OR SDT = @SDT";
                            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                            checkCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                            checkCmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());

                            int count = (int)checkCmd.ExecuteScalar();
                            if (count > 0)
                            {
                                lblMessage.Text = "<div class='fail'>❌ Email hoặc số điện thoại đã được sử dụng để gửi liên hệ trước đó!</div>";
                                return;
                            }

                            // ✅ THÊM MỚI DỮ LIỆU
                            string insertQuery = @"INSERT INTO LienHe (HoTen, Email, SDT, DiaChi, NoiDung, userNames)
                           VALUES (@HoTen, @Email, @SDT, @DiaChi, @NoiDung, @userNames)";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@userNames", userNames ?? (object)DBNull.Value);

                            insertCmd.ExecuteNonQuery();

                            lblMessage.Text = "<div class='success'>✅ Gửi thông tin thành công!</div>";
                            ResetFields();
                            GenerateCaptcha();
                        }
                        catch (Exception ex)
                        {
                            lblMessage.Text = $"<div class='fail'>❌ Gửi thông tin thất bại!: {ex.Message}</div>";
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "<div class='fail'>❌ Mã bảo mật không đúng!</div>";
                    GenerateCaptcha();
                }
            }
        }

        protected void btnLamLai_Click(object sender, EventArgs e)
        {
            ResetFields();
            GenerateCaptcha();
        }

        private void ResetFields()
        {
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtNoiDung.Text = "";
            txtCaptcha.Text = "";
        }
    }
}
