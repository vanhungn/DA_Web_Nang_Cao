using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DA_Web_Nang_Cao.src.model;

namespace DA_Web_Nang_Cao.src.component.header
{
    public partial class headerHome : System.Web.UI.UserControl
    {
        public List<modelItems> ListOrderProduct = new List<modelItems>();
        public List<modelUsers> totalMonyProduct = new List<modelUsers>();
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
                GetOrderProduct();
                LoadOrderList();
                p_boxSearch.Visible = false;
               

            }
            string url = Request.Url.AbsolutePath;
            if(url == "/src/pages/home/home")
            {
                lbl_homeLink.CssClass = "linkPageChoose";
            }
            else if(url == "/src/pages/product/product")
            {
                lbl_ProductLink.CssClass = "linkPageChoose";
            }
            else if( url == "/src/LienHe/LienHe")
            {
                lbl_ContactLink.CssClass = "linkPageChoose";
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
        public void OnclickOpendSearch(object sender, EventArgs e)
        {
            if (p_boxSearch.Visible == true)
            {
                p_boxSearch.Visible = false;
            }
            else
            {
                p_boxSearch.Visible = true;
            }

        }
        public void LoadOrderList()
        {
            ListOrderProduct = GetOrderProduct();
            rptListOder.DataSource = ListOrderProduct;
            rptListOder.DataBind();
            totalMonyProduct = GetTotalMony();
            rptTotalMony.DataSource = totalMonyProduct;
            rptTotalMony.DataBind();
            lblCorrect.Text = "Không có thông tin cho loại dữ liệu này";
            if (ListOrderProduct.Count > 0)
            {
                lblInform.Text = ListOrderProduct.Count.ToString();
                lblCorrect.Text = "";
                int tongTien = 0;


                foreach (modelItems item in ListOrderProduct)
                {
                    if (item.promotion == 0)
                    {
                        tongTien += item.price * item.quantity;
                    }
                    tongTien += item.promotion * item.quantity;
                }

                totalMoney.Text = tongTien.ToString("N0") + "đ";


            }
            else
            {
                lblInform.Text = "0";
              
            }
        }
        public List<modelUsers> GetTotalMony()
        {
            List<modelUsers> user = new List<modelUsers>();
            try
            {
                string userId = GetUserIdFromCookie();
                string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(contro))
                {
                    string query = @" SELECT moneys FROM USERS WHERE idUsers=@idUser";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idUser", userId);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            modelUsers modelUsers = new modelUsers
                            {
                                moneys = Convert.ToInt32(reader["moneys"]),
                            };
                            user.Add(modelUsers);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Lỗi: " + ex.Message);

            }
            return user;
        }
        public List<modelItems> GetOrderProduct()
        {
            List<modelItems> modelItems = new List<modelItems>();

            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(contro))
            {
                string userId = GetUserIdFromCookie();
                string query = @"SELECT ITEMS.idItems, ITEMS.img0, ITEMS.promotion, ITEMS.nameItem, ITEMS.price,quantity FROM ORDERS
                                JOIN ITEMS ON ORDERS.idItems = ITEMS.idItems 
                                JOIN USERS ON ORDERS.idUsers = USERS.idUsers WHERE USERS.idUsers=@USERSidUsers ORDER BY ITEMS.dates";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@USERSidUsers", userId);
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

                        modelItems.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Lỗi: " + ex.Message);

                }
            }

            return modelItems;
        }
        public class SearchEventArgs : EventArgs
        {
            public string search { get; set; }

            public SearchEventArgs(string searchs)
            {
                search = searchs;
            }
        }
        public event EventHandler<SearchEventArgs> searchProduct;
        public void OnclickSearchProduct(object sender, EventArgs e)
        {
            if (searchProduct != null)
            {
                searchProduct(this, new SearchEventArgs(txt_search.Text));

            }
            if (Request.Url.AbsolutePath != "/src/pages/product/product"|| Request.Url.AbsolutePath != "/src/pages/product/product?search=" + Server.UrlEncode(txt_search.Text))
            {
                Response.Redirect("/src/pages/product/product.aspx?search=" + Server.UrlEncode(txt_search.Text));
            }

        }
        public class SearchEventArgsCategory : EventArgs
        {
            public string category { get; set; }

            public SearchEventArgsCategory(string categorys)
            {
                category = categorys;
            }
        }
        public event EventHandler<SearchEventArgsCategory> categoryProduct;
        public void OnCommentCategoryHeader(object sender, CommandEventArgs e)
        {
            if (categoryProduct != null)
            {
                categoryProduct(this, new SearchEventArgsCategory(e.CommandArgument.ToString()));
            }
           
            if(Request.Url.AbsolutePath != "/src/pages/product/product")
            {
                Response.Redirect("/src/pages/product/product.aspx?category=" + Server.UrlEncode(e.CommandArgument.ToString()));
            }

        }
        public void OnclickGioHang(object sender, EventArgs e)
        {
            Response.Redirect("/src/GioHang/GioHang");

        }
        public void OnclickThanhToan(object sender, EventArgs e)
        {
            Response.Redirect("/src/thanhtoan/thanhtoan");
        }

    }
}