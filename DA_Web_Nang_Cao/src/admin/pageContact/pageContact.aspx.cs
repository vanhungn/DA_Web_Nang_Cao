using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.admin.pageContact
{
    public partial class pageContact : System.Web.UI.Page
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
                string query = @"SELECT * FROM LienHe";

                if (!string.IsNullOrEmpty(keyword))
                {
                    query += " WHERE HoTen LIKE @kw OR Email LIKE @kw OR UserName LIKE @kw ";
                }

                query += " ORDER BY NgayGui DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(keyword))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvLienHe.DataSource = dt;
                gvLienHe.DataBind();
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // 🔍 Kiểm tra trùng email hoặc số điện thoại
                    string checkQuery = "SELECT COUNT(*) FROM LienHe WHERE Email = @Email OR SDT = @SDT";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        lblMessage.Text = "❌ Email hoặc SĐT đã tồn tại!";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    // ✅ Nếu không trùng, thì thêm mới
                    string insertQuery = @"INSERT INTO LienHe (HoTen, Email, SDT, DiaChi, NoiDung, userNames)
                                   VALUES (@HoTen, @Email, @SDT, @DiaChi, @NoiDung, @userNames)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text.Trim());

                    // Lấy userNames từ Cookie nếu có
                    string userNames = null;
                    if (Request.Cookies["loginUser"] != null)
                    {
                        userNames = Request.Cookies["loginUser"]["userNames"];
                    }
                    insertCmd.Parameters.AddWithValue("@userNames", userNames ?? (object)DBNull.Value);

                    int rows = insertCmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        lblMessage.Text = "✅ Thêm liên hệ thành công!";
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
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtNoiDung.Text = "";
            txtUserName.Text = "";
            txtHoTen.Focus();
        }

        protected void gvLienHe_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvLienHe.EditIndex = e.NewEditIndex;
            LoadData();
        }

        protected void gvLienHe_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvLienHe.EditIndex = -1;
            LoadData();
        }

        protected void gvLienHe_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvLienHe.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvLienHe.Rows[e.RowIndex];

            // Sử dụng FindControl lấy dữ liệu trong TemplateField
            string hoTen = ((TextBox)row.FindControl("txtHoTen")).Text.Trim();
            string email = ((TextBox)row.FindControl("txtEmail")).Text.Trim();
            string sdt = ((TextBox)row.FindControl("txtSDT")).Text.Trim();
            string diaChi = ((TextBox)row.FindControl("txtDiaChi")).Text.Trim();
            string noiDung = ((TextBox)row.FindControl("txtNoiDung")).Text.Trim();
            string userName = ((TextBox)row.FindControl("txtUserName")).Text.Trim();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"UPDATE LienHe 
                                 SET HoTen=@HoTen, Email=@Email, SDT=@SDT, DiaChi=@DiaChi, NoiDung=@NoiDung, UserName=@UserName
                                 WHERE Id=@Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@HoTen", hoTen);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    gvLienHe.EditIndex = -1;
                    LoadData();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "❌ Lỗi cập nhật: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void gvLienHe_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvLienHe.DataKeys[e.RowIndex].Value);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM LienHe WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    LoadData();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "❌ Lỗi xóa: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void gvLienHe_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLienHe.PageIndex = e.NewPageIndex;
            LoadData();
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
    }
}