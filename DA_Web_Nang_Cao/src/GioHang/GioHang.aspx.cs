using DA_Web_Nang_Cao.src.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.GioHang
{
    public partial class GioHang : System.Web.UI.Page
    {
        public List<modelItems> ListOrderProduct = new List<modelItems>();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string userId = GetUserIdFromCookie();
                if (userId == null)
                {
                    Response.Redirect("/src/dangkydangnhap/login");
                    return;
                }
                pageLoad();
            }
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
        public void pageLoad()
        {
            ListOrderProduct = GetOrderProduct();
            rptListOder.DataSource = ListOrderProduct;
            rptListOder.DataBind();
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

                lblTongTient.Text = tongTien.ToString("N0") + "đ";


            }
            else
            {
                lblTongTient.Text = "0";

            }
        }
        public List<modelItems> GetOrderProduct()
        {
            List<modelItems> modelItens = new List<modelItems>();

            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(contro))
            {

                string query = @"SELECT ITEMS.idItems, ITEMS.img0, ITEMS.promotion, ITEMS.nameItem, ITEMS.price, quantity, idOrders FROM ORDERS

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

                            quantity = quant,
                            idOrder = Convert.ToInt32(reader["idOrders"])
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

        protected void OnclickConFirm(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "updateQuantity")
            {
                // Lấy ra TextBox chứa số lượng
                TextBox txtQty = (TextBox)e.Item.FindControl("txt_Quantity");

                int newQty = 1;
                if (txtQty != null && int.TryParse(txtQty.Text.Trim(), out int parsedQty))
                {
                    newQty = parsedQty;
                }

                string idOrder = e.CommandArgument.ToString();
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE ORDERS SET quantity = @quan WHERE idOrders = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idOrder);
                        cmd.Parameters.AddWithValue("@quan", newQty);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // Gọi lại để hiển thị danh sách mới
                pageLoad();
            }
        }
        public void xoa(object sender, CommandEventArgs e)
        {
            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using(SqlConnection con = new SqlConnection(contro))
            {
                string query = @"DELETE FROM ORDERS WHERE idOrders=@idO";
                SqlCommand cmd = new SqlCommand(query,con);
                cmd.Parameters.AddWithValue("@idO", e.CommandArgument.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                pageLoad();
                headerHome.LoadOrderList();
            }
        }

    }
}