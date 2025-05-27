using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.dangkygangnhap
{
    public partial class ExternalCallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var auth = Context.GetOwinContext().Authentication;
            var result = auth.AuthenticateAsync("ExternalCookie").Result;

            if (result != null && result.Identity != null && result.Identity.IsAuthenticated)
            {
                var identity = result.Identity;

                string email = identity.FindFirst(ClaimTypes.Email)?.Value;
                string name = identity.FindFirst(ClaimTypes.Name)?.Value;
                string id = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Lưu vào session
                Session["username"] = email;
                Session["fullname"] = name;
                Session["oauth_id"] = id;

                // Lưu vào CSDL nếu chưa có
                SaveUserToDatabase(email, name, id);

                // Xóa cookie xác thực ngoài
                auth.SignOut("ExternalCookie");

                // Chuyển về trang chủ
                Response.Redirect("~/src/home/home.aspx");
            }
            else
            {
                Response.Redirect("~/src/dangkygangnhap/login.aspx");
            }
        }

        private void SaveUserToDatabase(string email, string name, string oauthId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sqlCheck = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand checkCmd = new SqlCommand(sqlCheck, conn);
                checkCmd.Parameters.AddWithValue("@Email", email);

                int exists = (int)checkCmd.ExecuteScalar();

                if (exists == 0)
                {
                    string sqlInsert = "INSERT INTO Users (Email, FullName, Role, OAuthId) VALUES (@Email, @FullName, @Role, @OAuthId)";
                    SqlCommand insertCmd = new SqlCommand(sqlInsert, conn);
                    insertCmd.Parameters.AddWithValue("@Email", email);
                    insertCmd.Parameters.AddWithValue("@FullName", name ?? "No Name");
                    insertCmd.Parameters.AddWithValue("@Role", "user");
                    insertCmd.Parameters.AddWithValue("@OAuthId", oauthId ?? "");

                    insertCmd.ExecuteNonQuery();
                }
            }
        }
    }
}