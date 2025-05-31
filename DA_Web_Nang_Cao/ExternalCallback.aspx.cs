using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using Microsoft.Owin.Security;

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

                // Lấy thông tin từ Google hoặc Facebook
                string email = identity.FindFirst(ClaimTypes.Email)?.Value;
                string name = identity.FindFirst(ClaimTypes.Name)?.Value;
                string oauthId = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                // Kiểm tra email hợp lệ
                if (string.IsNullOrEmpty(email))
                {
                    Response.Redirect("~/src/dangkygangnhap/login.aspx");
                    return;
                }

                // ✅ Lưu vào database nếu chưa có, và lấy idUsers
                int userId = SaveUserToDatabaseAndReturnId(email, name, oauthId);

                // ✅ Lưu idUsers vào cookie để truy cập các trang sau
                HttpCookie cookie = new HttpCookie("loginUser");
                cookie["idUsers"] = userId.ToString();
                cookie.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Add(cookie);

                // Xóa cookie xác thực ngoài của OWIN
                auth.SignOut("ExternalCookie");

                // ✅ Chuyển đến trang chủ
                Response.Redirect("~/src/home/home.aspx");
            }
            else
            {
                Response.Redirect("~/src/home/home.aspx");
            }
        }

        private int SaveUserToDatabaseAndReturnId(string email, string name, string oauthId)
        {
            string DefaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(DefaultConnection))
            {
                conn.Open();

                // Kiểm tra nếu đã tồn tại
                string sqlCheck = "SELECT idUsers FROM USERS WHERE emails = @Email";
                SqlCommand checkCmd = new SqlCommand(sqlCheck, conn);
                checkCmd.Parameters.AddWithValue("@Email", email);

                object result = checkCmd.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result); // Trả lại idUsers đã tồn tại
                }

                // Chưa có thì thêm mới
                string sqlInsert = @"
                    INSERT INTO USERS 
                    (names, phones, emails, userNames, passwords, roles, addresss, moneys)
                    OUTPUT INSERTED.idUsers
                    VALUES 
                    (@Name, @Phone, @Email, @Username, @Password, @Role, @Address, @Money)";

                SqlCommand insertCmd = new SqlCommand(sqlInsert, conn);
                insertCmd.Parameters.AddWithValue("@Name", name ?? "No Name");
                insertCmd.Parameters.AddWithValue("@Phone", ""); // Trống vì chưa có
                insertCmd.Parameters.AddWithValue("@Email", email);
                insertCmd.Parameters.AddWithValue("@Username", email); // Dùng email làm username
                insertCmd.Parameters.AddWithValue("@Password", "");    // Trống vì dùng OAuth
                insertCmd.Parameters.AddWithValue("@Role", "user");
                insertCmd.Parameters.AddWithValue("@Address", "");
                insertCmd.Parameters.AddWithValue("@Money", 0);

                return (int)insertCmd.ExecuteScalar();
            }
        }
    }
    }

