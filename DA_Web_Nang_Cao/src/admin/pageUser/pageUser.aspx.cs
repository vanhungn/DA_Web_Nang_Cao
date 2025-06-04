using DA_Web_Nang_Cao.src.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.admin.pageUser
{
    public partial class pageUser : System.Web.UI.Page
    {

        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData(string keyword = "")
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"SELECT * FROM USERS";

                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " WHERE names LIKE @kw OR emails LIKE @kw OR userNames LIKE @kw ";
                }

                query += " ORDER BY idUsers DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(keyword))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            LoadData(keyword);
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadData();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"INSERT INTO USERS (names, emails, phones, addresss, userNames, passwords, roles, moneys)
                                 VALUES (@names, @emails, @phones, @addresss, @userNames, @passwords, @roles, @moneys)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@names", txtAddNames.Text.Trim());
                cmd.Parameters.AddWithValue("@emails", txtAddEmails.Text.Trim());
                cmd.Parameters.AddWithValue("@phones", txtAddPhones.Text.Trim());
                cmd.Parameters.AddWithValue("@addresss", txtAddAddresss.Text.Trim());
                cmd.Parameters.AddWithValue("@userNames", txtAddUserNames.Text.Trim());
                cmd.Parameters.AddWithValue("@passwords", txtAddPasswords.Text.Trim()); // default password, nên mã hóa
                cmd.Parameters.AddWithValue("@roles", "user"); // mặc định
                cmd.Parameters.AddWithValue("@moneys", txtAddMoneys.Text.Trim());

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        lblMessage.Text = "✅ Thêm người dùng thành công!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        ClearForm();
                        LoadData();
                    }
                    else
                    {
                        lblMessage.Text = "❌ Thêm thất bại!";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "❌ Lỗi: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void ClearForm()
        {
            txtAddNames.Text = "";
            txtAddEmails.Text = "";
            txtAddPhones.Text = "";
            txtAddAddresss.Text = "";

            txtAddUserNames.Text = "";
            txtAddUserNames.Focus();
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            LoadData(txtSearch.Text.Trim());
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            LoadData(txtSearch.Text.Trim());
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvUsers.Rows[e.RowIndex];

            string names = ((TextBox)row.FindControl("txtNames")).Text.Trim();
            string emails = ((TextBox)row.FindControl("txtEmails")).Text.Trim();
            string phones = ((TextBox)row.FindControl("txtPhones")).Text.Trim();
            string addresss = ((TextBox)row.FindControl("txtAddresss")).Text.Trim();
            string userNames = ((TextBox)row.FindControl("txtUserNames")).Text.Trim();
            string passwords = ((TextBox)row.FindControl("txtPasswords")).Text.Trim();
            string moneyText = ((TextBox)row.FindControl("txtMoneys")).Text.Trim();
            decimal moneys = 0;
            decimal.TryParse(moneyText, out moneys);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"UPDATE USERS 
                                 SET names=@names, emails=@emails, phones=@phones, addresss=@addresss, userNames=@userNames , passwords=@passwords, moneys=@moneys
                                 WHERE idUsers=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@names", names);
                cmd.Parameters.AddWithValue("@emails", emails);
                cmd.Parameters.AddWithValue("@phones", phones);
                cmd.Parameters.AddWithValue("@addresss", addresss);
                cmd.Parameters.AddWithValue("@userNames", userNames);
                cmd.Parameters.AddWithValue("@passwords", passwords);
                cmd.Parameters.AddWithValue("@moneys", moneys);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    gvUsers.EditIndex = -1;
                    LoadData(txtSearch.Text.Trim());
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "❌ Cập nhật lỗi: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            LoadData(txtSearch.Text.Trim());
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Xóa tất cả đơn hàng trước
                string deleteOrders = "DELETE FROM ORDERS WHERE idUsers=@id";
                SqlCommand cmdOrders = new SqlCommand(deleteOrders, conn);
                cmdOrders.Parameters.AddWithValue("@id", id);
                cmdOrders.ExecuteNonQuery();

                // Xóa người dùng
                string deleteUser = "DELETE FROM USERS WHERE idUsers=@id";
                SqlCommand cmdUser = new SqlCommand(deleteUser, conn);
                cmdUser.Parameters.AddWithValue("@id", id);
                cmdUser.ExecuteNonQuery();

                lblMessage.Text = "✅ Xóa người dùng và đơn hàng thành công!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                LoadData(txtSearch.Text.Trim());
            }
        }

        protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}