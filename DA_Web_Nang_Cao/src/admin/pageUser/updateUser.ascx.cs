using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.admin.pageUser
{
    public partial class updateUser : System.Web.UI.UserControl
    {
        private int idUser
        {
            get { return ViewState["idUser"] != null ? (int)ViewState["idUser"] : 0; }
            set { ViewState["idUser"] = value; }
        }

        public event EventHandler CancelClicked;
        public event EventHandler SavedClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearForm();
            }
        }

        // Load dữ liệu người dùng theo id, gọi khi edit
        public void GetUser(int id)
        {
            idUser = id;
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT names, phones, emails, userNames, passwords, roles, addresss, moneys FROM USERS WHERE idUsers=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txt_names.Text = reader["names"].ToString();
                    txt_phones.Text = reader["phones"].ToString();
                    txt_emails.Text = reader["emails"].ToString();
                    txt_userNames.Text = reader["userNames"].ToString();
                    txt_passwords.Text = reader["passwords"].ToString();
                    ddl_roles.SelectedValue = reader["roles"].ToString();
                    txt_addresss.Text = reader["addresss"].ToString();
                    txt_moneys.Text = reader["moneys"] != DBNull.Value ? reader["moneys"].ToString() : "0";
                }
                else
                {
                    ClearForm();
                }
            }
        }
       

        // Clear form để nhập mới hoặc sau hủy
        public void ClearForm()
        {
            idUser = 0;
            txt_names.Text = "";
            txt_phones.Text = "";
            txt_emails.Text = "";
            txt_userNames.Text = "";
            txt_passwords.Text = "";
            ddl_roles.SelectedIndex = 0;
            txt_addresss.Text = "";
            txt_moneys.Text = "0";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query;
                if (idUser == 0)
                {
                    // Thêm mới
                    query = @"INSERT INTO USERS (names, phones, emails, userNames, passwords, roles, addresss, moneys) 
                              VALUES (@names, @phones, @emails, @userNames, @passwords, @roles, @addresss, @moneys)";
                }
                else
                {
                    // Cập nhật
                    query = @"UPDATE USERS SET names=@names, phones=@phones, emails=@emails, userNames=@userNames, passwords=@passwords, 
                              roles=@roles, addresss=@addresss, moneys=@moneys WHERE idUsers=@idUsers";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@names", txt_names.Text.Trim());
                cmd.Parameters.AddWithValue("@phones", txt_phones.Text.Trim());
                cmd.Parameters.AddWithValue("@emails", txt_emails.Text.Trim());
                cmd.Parameters.AddWithValue("@userNames", txt_userNames.Text.Trim());
                cmd.Parameters.AddWithValue("@passwords", txt_passwords.Text.Trim());
                cmd.Parameters.AddWithValue("@roles", ddl_roles.SelectedValue);
                cmd.Parameters.AddWithValue("@addresss", txt_addresss.Text.Trim());
                int moneyValue = 0;
                int.TryParse(txt_moneys.Text.Trim(), out moneyValue);
                cmd.Parameters.AddWithValue("@moneys", moneyValue);

                if (idUser != 0)
                {
                    cmd.Parameters.AddWithValue("@idUsers", idUser);
                }

                con.Open();
                cmd.ExecuteNonQuery();
            }

            // Gửi sự kiện đã lưu để pageUser.aspx bắt và làm mới danh sách
            if (SavedClicked != null)
            {
                SavedClicked(this, EventArgs.Empty);
            }

            ClearForm();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            if (CancelClicked != null)
            {
                CancelClicked(this, EventArgs.Empty);
            }
        }
    }
 }
