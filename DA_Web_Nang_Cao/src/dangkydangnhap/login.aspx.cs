using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.dangkydangnhap
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string DefaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(DefaultConnection))
            {
                string query = "SELECT idUsers,userNames FROM USERS WHERE userNames = @u AND passwords = @p";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                conn.Open();
                object result = cmd.ExecuteScalar(); // Lấy idUsers (nếu có)

                if (result != null) // Nếu tìm thấy tài khoản
                {
                    int userId = Convert.ToInt32(result);

                    HttpCookie cookie = new HttpCookie("loginUser");
                    cookie["idUsers"] = userId.ToString();
                    cookie.Expires = DateTime.Now.AddDays(1);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    Response.Redirect("~/src/pages/home/home.aspx");
                }
                else
                {
                    // Đăng nhập thất bại
                    Response.Write("<script>alert('Sai tên đăng nhập hoặc mật khẩu');</script>");
                }
            }

        }
    }
}