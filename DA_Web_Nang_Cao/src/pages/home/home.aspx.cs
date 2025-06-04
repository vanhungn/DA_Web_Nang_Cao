using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using DA_Web_Nang_Cao.src.component.header;
using DA_Web_Nang_Cao.src.model;
namespace DA_Web_Nang_Cao.src.home
{
    public partial class home : System.Web.UI.Page
    {
        public List<modelItems> ProductsList = new List<modelItems>();
        public List<modelItems> SpecialProduct = new List<modelItems>();
        public List<modelItems> SpecialProductPromotion = new List<modelItems>();
        public List<modelItems> FoodGuide = new List<modelItems>();
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
                LoadData();
            }



        }

        private void LoadData()
        {
            ProductsList = GetProducts();
            SpecialProduct = GetsSpecialProducts();
            SpecialProductPromotion = GetProductPromotion();
            FoodGuide = GetFoodGuide();

            rptProducts.DataSource = ProductsList;
            rptSpecialProduct.DataSource = SpecialProduct;
            rptSpecialProductPromotion.DataSource = SpecialProductPromotion;
            rptFoodGuide.DataSource = FoodGuide;

            rptProducts.DataBind();
            rptSpecialProduct.DataBind();
            rptSpecialProductPromotion.DataBind();
            rptFoodGuide.DataBind();

        }

        private List<modelItems> GetProducts()
        {
            List<modelItems> products = new List<modelItems>();
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"SELECT idItems,img0,price,promotion,nameItem FROM ITEMS WHERE satus='Còn hàng' ORDER BY dates DESC OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";

                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int pri = Convert.ToInt32(reader["price"]);
                        int pro = Convert.ToInt32(reader["promotion"]);
                        int pricePromotion = 0;
                        if (pro > 0)
                        {
                            pricePromotion = (pri * pro) / 100;
                        }
                        modelItems items = new modelItems
                        {
                            idItem = reader["idItems"].ToString(),
                            nameItem = reader["nameItem"].ToString(),
                            price = Convert.ToInt32(reader["price"]),
                            promotion = Convert.ToInt32(pricePromotion),
                            img0 = reader["img0"].ToString()
                        };
                        products.Add(items);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Lỗi: " + ex.Message);
                }
            }

            return products;
        }
        private List<modelItems> GetsSpecialProducts()
        {
            List<modelItems> products = new List<modelItems>();
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(conStr))
            {
                string query = @"select idItems,img0,price,promotion,nameItem,descs,satus,origin FROM ITEMS WHERE satus='Còn hàng' ORDER BY promotion DESC   OFFSET 0 ROWS  FETCH NEXT 1 ROWS ONLY";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int pri = Convert.ToInt32(reader["price"]);
                        int pro = Convert.ToInt32(reader["promotion"]);
                        int pricePromotion = 0;
                        if (pro > 0)
                        {
                            pricePromotion = (pri * pro) / 100;
                        }
                        string[] descSplit = reader["descs"].ToString().Trim().Split('.');
                        modelItems item = new modelItems
                        {
                            idItem = reader["idItems"].ToString(),
                            nameItem = reader["nameItem"].ToString(),
                            price = Convert.ToInt32(reader["price"]),
                            promotion = Convert.ToInt32(pricePromotion),
                            img0 = reader["img0"].ToString(),
                            descs = descSplit[0],
                            satus = reader["satus"].ToString(),
                            origin = reader["origin"].ToString()

                        };
                        products.Add(item);
                    }


                }
                catch (Exception ex)
                {
                    Response.Write("Lỗi: " + ex.Message);
                }
            }
            return products;
        }
        private List<modelItems> GetProductPromotion()
        {
            List<modelItems> products = new List<modelItems>();
            string conTro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conTro))
            {
                string query = @"SELECT idItems,img0,price,promotion,nameItem FROM ITEMS WHERE satus='Còn hàng' AND quantitySold>500   ORDER BY dates OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY ";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int pri = Convert.ToInt32(reader["price"]);
                        int pro = Convert.ToInt32(reader["promotion"]);
                        int pricePromotion = 0;
                        if (pro > 0)
                        {
                            pricePromotion = (pri * pro) / 100;
                        }
                        modelItems items = new modelItems
                        {
                            idItem = reader["idItems"].ToString(),
                            nameItem = reader["nameItem"].ToString(),
                            price = Convert.ToInt32(reader["price"]),
                            promotion = Convert.ToInt32(pricePromotion),
                            img0 = reader["img0"].ToString()
                        };
                        products.Add(items);

                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Lỗi: " + ex.Message);
                }
            }
            return products;
        }
        private List<modelItems> GetFoodGuide()
        {
            List<modelItems> specialProducts = new List<modelItems>();
            string conTro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conTro))
            {
                string query = @"SELECT idItems, img0,nameItem,descs FROM ITEMS WHERE kindOfItem=N'Rau củ quả' AND satus='Còn hàng' ORDER BY dates OFFSET 0 ROWS FETCH NEXT 4 ROWS ONLY";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string spliceDescs = reader["descs"].ToString().Trim().Substring(0, 100);
                        modelItems items = new modelItems
                        {
                            idItem = reader["idItems"].ToString(),
                            nameItem = reader["nameItem"].ToString(),
                            img0 = reader["img0"].ToString(),
                            descs = spliceDescs
                        };
                        specialProducts.Add(items);
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Lỗi: " + ex.Message);
                }
            }
            return specialProducts;
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
        protected void AddOrder_Command(object sender, CommandEventArgs e)
        {
            HttpCookie cookie = Request.Cookies["loginUser"];
            if (cookie == null || cookie["idUsers"] == null)
            {
              
                Response.Redirect("/src/dangkydangnhap/login");
                
            }
            string userId = GetUserIdFromCookie();
            string productId = e.CommandArgument.ToString();
            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            int quantity = 1;

            foreach (RepeaterItem item in rptSpecialProduct.Items)
            {
                DropDownList dropDownListValue = item.FindControl("selectQuantity") as DropDownList;
                quantity = int.Parse(dropDownListValue.SelectedValue);

            }
            using (SqlConnection con = new SqlConnection(contro))
            {
                string query = @"INSERT INTO ORDERS (quantity,idUsers,idItems) VALUES(@quantity,@idUsers,@idItems)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@idUsers", userId); // Tạm thời hard-code user ID là 1
                    cmd.Parameters.AddWithValue("@idItems", productId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            headerHome.LoadOrderList();

        }

    }

}