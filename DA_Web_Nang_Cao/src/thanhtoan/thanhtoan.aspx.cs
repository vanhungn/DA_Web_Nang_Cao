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
        private Dictionary<string, List<string>> tinhThanhToHuyen = new Dictionary<string, List<string>>()
        {
            { "Hà Nội", new List<string> { "Quận Ba Đình", "Quận Hoàn Kiếm" } },
            { "Hồ Chí Minh", new List<string> { "Quận 1", "Quận 3" } }
        };

        private Dictionary<string, List<string>> huyenToXa = new Dictionary<string, List<string>>()
        {
            // Quận Ba Đình - Hà Nội
            { "Quận Ba Đình", new List<string> {
                "Phường Phúc Xá", "Phường Trúc Bạch", "Phường Vĩnh Phúc", "Phường Cống Vị",
                "Phường Liễu Giai", "Phường Nguyễn Trung Trực", "Phường Quán Thánh",
                "Phường Điện Biên", "Phường Đội Cấn", "Phường Ngọc Hà", "Phường Thành Công"
            }},

            // Quận Hoàn Kiếm - Hà Nội
            { "Quận Hoàn Kiếm", new List<string> {
                "Phường Chương Dương", "Phường Hàng Bạc", "Phường Hàng Bồ", "Phường Hàng Đào",
                "Phường Hàng Gai", "Phường Hàng Trống", "Phường Lý Thái Tổ", "Phường Cửa Đông",
                "Phường Cửa Nam", "Phường Đồng Xuân", "Phường Hàng Buồm", "Phường Phan Chu Trinh"
            }},

            // Quận 1 - Hồ Chí Minh
            { "Quận 1", new List<string> {
                "Phường Tân Định", "Phường Đa Kao", "Phường Bến Nghé"
            }},

            // Quận 3 - Hồ Chí Minh
            { "Quận 3", new List<string> {
                "Phường Võ Thị Sáu", "Phường Phường 7", "Phường Phường 8"
            }},
        };

      

   

        protected void ddlHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlXa.Items.Clear();
            ddlXa.Items.Add("--- Chọn phường/xã ---");

            string selectedHuyen = ddlHuyen.SelectedValue;

            if (huyenToXa.ContainsKey(selectedHuyen))
            {
                foreach (var xa in huyenToXa[selectedHuyen])
                {
                    ddlXa.Items.Add(xa);
                }
            }
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