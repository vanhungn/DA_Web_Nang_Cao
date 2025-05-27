using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.dangkygangnhap
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
                string query = "SELECT idUsers FROM Users WHERE userNames = @u AND passwords = @p";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    HttpCookie cookie = new HttpCookie("loginUser");
                    cookie["idUser"]=count.ToString();
                    cookie.Expires = DateTime.Now.AddHours(3);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("~/src/home/home.aspx"); 
                }
                else
                {
                    Response.Write("<script>alert('Sai tên đăng nhập hoặc mật khẩu');</script>");
                }
            }
        }
    }
}