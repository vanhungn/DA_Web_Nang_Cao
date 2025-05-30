using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.admin.pageUser
{
    public partial class pageUserAddEdit : System.Web.UI.Page
    {
        private string UserId => Request.QueryString["id"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(UserId))
                {
                    LoadUserData(UserId);
                }
            }
        }

        private void LoadUserData(string id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM USERS WHERE idUsers = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtName.Text = reader["names"].ToString();
                    txtPhone.Text = reader["phones"].ToString();
                    txtEmail.Text = reader["emails"].ToString();
                    txtUsername.Text = reader["userNames"].ToString();
                    // Mật khẩu không load ra (bảo mật)
                    ddlRole.SelectedValue = reader["roles"].ToString();
                    txtAddress.Text = reader["addresss"].ToString();
                    txtMoney.Text = reader["moneys"].ToString();
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        private bool IsEmailExist(string email, string excludeUserId = null)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT COUNT(*) FROM USERS WHERE emails = @Email";
                if (!string.IsNullOrEmpty(excludeUserId))
                    query += " AND idUsers <> @UserId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                if (!string.IsNullOrEmpty(excludeUserId))
                    cmd.Parameters.AddWithValue("@UserId", excludeUserId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            // Validate cơ bản
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblMessage.Text = "Vui lòng nhập đầy đủ thông tin bắt buộc.";
                return;
            }

            // Kiểm tra email trùng
            if (IsEmailExist(txtEmail.Text.Trim(), UserId))
            {
                lblMessage.Text = "Email này đã tồn tại, vui lòng dùng email khác.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                if (string.IsNullOrEmpty(UserId)) // Thêm mới
                {
                    string insertQuery = @"INSERT INTO USERS 
                        (names, phones, emails, userNames, passwords, roles, addresss, moneys, createDate) 
                        VALUES (@Name, @Phone, @Email, @Username, @Password, @Role, @Address, @Money, @CreateDate)";

                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());

                    if (string.IsNullOrEmpty(txtPassword.Text))
                    {
                        lblMessage.Text = "Vui lòng nhập mật khẩu.";
                        return;
                    }
                    cmd.Parameters.AddWithValue("@Password", HashPassword(txtPassword.Text.Trim()));

                    cmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    decimal moneyVal = 0;
                    decimal.TryParse(txtMoney.Text.Trim(), out moneyVal);
                    cmd.Parameters.AddWithValue("@Money", moneyVal);

                    cmd.Parameters.AddWithValue("@CreateDate", DateTime.Now);

                    cmd.ExecuteNonQuery();
                    Response.Redirect("pageUser.aspx");
                }
                else // Sửa
                {
                    string updateQuery = @"UPDATE USERS SET 
                        names = @Name, phones = @Phone, emails = @Email, userNames = @Username,
                        roles = @Role, addresss = @Address, moneys = @Money
                        {0}
                        WHERE idUsers = @UserId";

                    string pwdSet = "";
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        pwdSet = ", passwords = @Password";
                    }

                    updateQuery = string.Format(updateQuery, pwdSet);

                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    decimal moneyVal = 0;
                    decimal.TryParse(txtMoney.Text.Trim(), out moneyVal);
                    cmd.Parameters.AddWithValue("@Money", moneyVal);

                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        cmd.Parameters.AddWithValue("@Password", HashPassword(txtPassword.Text.Trim()));
                    }

                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    cmd.ExecuteNonQuery();
                    Response.Redirect("pageUser.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("pageUser.aspx");
        }
    }
}