using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.thanhtoan
{
    public partial class thanhtoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTinhThanh();
            }
        }
        private void LoadTinhThanh()
        {
            ddlTinh.Items.Add("Hà Nội");
            ddlTinh.Items.Add("TP. Hồ Chí Minh");
            ddlTinh.Items.Add("Đà Nẵng");

            ddlHuyen.Items.Add("--- Chọn quận/huyện ---");
            ddlXa.Items.Add("--- Chọn phường/xã ---");
        }

        protected void btnThanhToan_Click(object sender, EventArgs e)
        {
            string tenNguoiMua = txtTenNguoiMua.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sdtMua = txtSDTMua.Text.Trim();

            string tenNguoiNhan = txtTenNguoiNhan.Text.Trim();
            string sdtNhan = txtSDTNhan.Text.Trim();

            string diaChi = txtDiaChi.Text.Trim();
            string quocGia = ddlQuocGia.SelectedItem.Text;
            string tinh = ddlTinh.SelectedItem.Text;
            string huyen = ddlHuyen.SelectedItem.Text;
            string xa = ddlXa.SelectedItem.Text;

            string ghiChu = txtGhiChu.Text.Trim();

            try
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = @"INSERT INTO DonHang 
                    (TenNguoiMua, Email, SDTMua, TenNguoiNhan, SDTNhan, DiaChi, QuocGia, Tinh, Huyen, Xa, GhiChu, NgayDatHang) 
                    VALUES 
                    (@TenNguoiMua, @Email, @SDTMua, @TenNguoiNhan, @SDTNhan, @DiaChi, @QuocGia, @Tinh, @Huyen, @Xa, @GhiChu, @NgayDatHang)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenNguoiMua", tenNguoiMua);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@SDTMua", sdtMua);
                    cmd.Parameters.AddWithValue("@TenNguoiNhan", tenNguoiNhan);
                    cmd.Parameters.AddWithValue("@SDTNhan", sdtNhan);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                    cmd.Parameters.AddWithValue("@QuocGia", quocGia);
                    cmd.Parameters.AddWithValue("@Tinh", tinh);
                    cmd.Parameters.AddWithValue("@Huyen", huyen);
                    cmd.Parameters.AddWithValue("@Xa", xa);
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                    cmd.Parameters.AddWithValue("@NgayDatHang", DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                // Hiển thị thông báo thành công
                string thongBao = "Cảm ơn bạn đã đặt hàng, " + tenNguoiMua + "! Đơn hàng của bạn đã được ghi nhận.";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{thongBao}');", true);

                // Reset form nếu cần
                // ResetForm();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Lỗi: {ex.Message}');", true);
            }
        }

        private void ResetForm()
        {
            txtTenNguoiMua.Text = "";
            txtEmail.Text = "";
            txtSDTNhan.Text = "";
            txtTenNguoiNhan.Text = "";
            txtSDTMua.Text = "";
            txtDiaChi.Text = "";
            txtGhiChu.Text = "";
            ddlTinh.SelectedIndex = 0;
            ddlHuyen.SelectedIndex = 0;
            ddlXa.SelectedIndex = 0;
        }
    }
}