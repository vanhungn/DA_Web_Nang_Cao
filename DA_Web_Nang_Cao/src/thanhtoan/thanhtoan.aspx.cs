using DA_Web_Nang_Cao.src.model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace DA_Web_Nang_Cao.src.thanhtoan
{
    public partial class thanhtoan : System.Web.UI.Page
    {
        public List<modelItems> ListOrderProduct = new List<modelItems>();

        private Dictionary<string, List<string>> tinhThanhToHuyen = new Dictionary<string, List<string>>()

        {

            { "Hà Nội", new List<string> { "Quận Ba Đình", "Quận Hoàn Kiếm" } },

             { "Hồ Chí Minh", new List<string> { "Quận 1", "Quận 3" } }
        };

        private Dictionary<string, List<string>> huyenToXa = new Dictionary<string, List<string>>()

{

{ "Quận Ba Đình", new List<string> {

"Phường Phúc Xá", "Phường Trúc Bạch", "Phường Vĩnh Phúc", "Phường Cống Vị", "Phường Liễu Giai", "Phường Nguyễn Trung Trực", "Phường Quán Thánh", "Phường Điện Biên", "Phường Đội Cấn", "Phường Ngọc Hà", "Phường Thành Công"

}},

{ "Quận Hoàn Kiếm", new List<string> {

"Phường Chương Dương", "Phường Hàng Bạc", "Phường Hàng Bồ", "Phường Hàng Đào", "Phường Hàng Gai", "Phường Hàng Trống", "Phường Lý Thái Tổ", "Phường Cửa Đông", "Phường Cửa Nam", "Phường Đồng Xuân", "Phường Hàng Buồm", "Phường Phan Chu Trinh" ,

}},

{ "Quận 1", new List<string> {

"Phường Tân Định", "Phường Đa Kao", "Phường Bến Nghé"

}},

{ "Quận 3", new List<string> {

"Phường Võ Thị Sáu", "Phường Phường 7", "Phường Phường 8"
}},
};
        protected void Page_Load(object sender, EventArgs e)
        {
            string userId = GetUserIdFromCookie();

            if (userId == null)

            {
                Response.Redirect("/src/dangkydangnhap/login");

                return;

            }

            if (!IsPostBack)

            {

                LoadTinh();
            }
        }

        private void LoadTinh()

        {

            ListOrderProduct = GetOrderProduct();

            rptListoder.DataSource = ListOrderProduct;

            rptListoder.DataBind();

            ddlTinh.Items.Clear();

            ddlTinh.Items.Add("--- Chọn tỉnh/thành phố ---");

            foreach (var tinh in tinhThanhToHuyen.Keys)
            {

                ddlTinh.Items.Add(tinh);
            }

            LoadOrderList();

        }

        private string GetUserIdFromCookie()
        {
            HttpCookie cookie = Request.Cookies["loginUser"];
            if (cookie != null && cookie["idUsers"] != null)
            {
                return cookie["idUsers"];
            }
            return null;
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

            ddlHuyen.Items.Clear();

            ddlXa.Items.Clear();

            ddlHuyen.Items.Add("--- Chọn quận/huyện ---");

            ddlXa.Items.Add("--- Chọn phường/xã ---");

        }
        public void LoadOrderList()

        {

            ListOrderProduct = GetOrderProduct();

            rptListoder.DataSource = ListOrderProduct;

            rptListoder.DataBind();

            if (ListOrderProduct.Count > 0)
            {

                int tongTien = 0;

                foreach (modelItems item in ListOrderProduct)
                {
                    
                    if (item.promotion == 0)
                    {
                        tongTien += item.price * item.quantity;
                    }
                    tongTien += item.promotion * item.quantity;
                }
                totalMoney.Text = tongTien.ToString("N0") + "d";
            }
            else
            {
                totalMoney.Text = "0d";

            }
        }
        public List<modelItems> GetOrderProduct()
        {
            List<modelItems> modelItens = new List<modelItems>();

            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(contro))
            {

                string query = @"SELECT ITEMS.idItems, ITEMS.img0, ITEMS.promotion, ITEMS.nameItem, ITEMS.price, quantity FROM ORDERS

                            JOIN ITEMS ON ORDERS.idItems = ITEMS.idItems
                            JOIN USERS ON ORDERS.idUsers = USERS.idUsers
                            WHERE ORDERS.idUsers = @userId
                            ORDER BY ITEMS.dates";

                SqlCommand cmd = new SqlCommand(query, con);
                string userId = GetUserIdFromCookie();
                cmd.Parameters.AddWithValue("@userId", userId);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {

                        int pri = Convert.ToInt32(reader["price"]);

                        int pro = Convert.ToInt32(reader["promotion"]);

                        string[] name = reader["nameItem"].ToString().Trim().Split(' ');

                        int quant = Convert.ToInt32(reader["quantity"]);
                        string displayName = name.Length >= 3

                                ? $"{name[0]} {name[1]} {name[2]}..."

                                 : reader["nameItem"].ToString();

                        int pricePromotion = pro > 0 ? (pri - ((pri * pro) / 100)) * quant : 0;
                        modelItems item = new modelItems
                        {

                            idItem = reader["idItems"].ToString(),

                            nameItem = displayName,

                            price = pri,

                            promotion = pricePromotion,
                            img0 = reader["img0"].ToString(),

                            quantity = quant
                        };
                        modelItens.Add(item);
                    }
                }
                catch (Exception ex)

                {
                    Response.Write("Lỗi: " + ex.Message);
                }
            }
            return modelItens;
        }

        protected void ddlTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlHuyen.Items.Clear();
            ddlHuyen.Items.Add("-- Chọn quận/huyện --");
            string selectedTinh = ddlTinh.SelectedValue;
            if (tinhThanhToHuyen.ContainsKey(selectedTinh))

            {


                foreach (var huyen in tinhThanhToHuyen[selectedTinh])
                {

                    ddlHuyen.Items.Add(huyen);
                }
            }
            ddlXa.Items.Clear();
            ddlXa.Items.Add("-- Chọn phường/xã --");
        }
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

            string DefaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
            ListOrderProduct = GetOrderProduct();
            int tongTien = 0;

            foreach (modelItems item in ListOrderProduct)

            {
                if (item.promotion > 0)

                {
                    tongTien += item.promotion;
                }
                else

                {
                    tongTien += item.price * item.quantity;
                }
            }
            using (SqlConnection conn = new SqlConnection(DefaultConnection))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand getMoneyCmd = new SqlCommand("SELECT moneys FROM USERS WHERE idUsers = @idUsers", conn, transaction);
                    string userId = GetUserIdFromCookie();
                    getMoneyCmd.Parameters.AddWithValue("@idUsers", userId);
                    object result = getMoneyCmd.ExecuteScalar();
                    int soDu = Convert.ToInt32(result);
                    if (soDu < tongTien)
                    {
                        Response.Write("<script>alert('Bạn không đủ tiền để thanh toán.');</script>");
                   
                        return;
                    }
                    int togn = soDu - tongTien;
                    SqlCommand updateMoneyCmd = new SqlCommand("UPDATE USERS SET moneys = @total WHERE idUsers = @idUsers", conn, transaction);
                    updateMoneyCmd.Parameters.AddWithValue("@total", togn);
                    updateMoneyCmd.Parameters.AddWithValue("@idUsers", userId);
                    updateMoneyCmd.ExecuteNonQuery();
                    SqlCommand deleteOrdersCmd = new SqlCommand("DELETE FROM ORDERS WHERE idUsers = @idUsers", conn, transaction);
                    deleteOrdersCmd.Parameters.AddWithValue("@idUsers", userId);
                    deleteOrdersCmd.ExecuteNonQuery();
                    transaction.Commit();
                    LoadOrderList();
                    Response.Write("<script>alert('Thanh toán thành công!');</script>");
                    Response.Redirect("/src/pages/home/home");
                }
                catch (Exception ex)
                {

                 

                    Response.Write("<script>alert('Lỗi: " + ex.Message + " ');</script>");
                }
            }
        }
       
    }

}