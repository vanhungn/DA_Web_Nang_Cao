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

namespace DA_Web_Nang_Cao.src.home
{
    public partial class home : System.Web.UI.Page
    {
        public List<specialProduct> ProductsList = new List<specialProduct>();
        public List<specialProduct> SpecialProduct = new List<specialProduct>();
        public List<specialProduct> SpecialProductPromotion = new List<specialProduct>();
        public List<specialProduct> FoodGuide = new List<specialProduct>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            rptProducts.DataBind();
        }
        public class specialProduct
        {
            public string idItem { get; set; }
            public string nameItem { get; set; }
            public string descs { get; set; }
            public string img0 { get; set; }
            public string img1 { get; set; }
            public string img2 { get; set; }
            public int price { get; set; }
            public int promotion { get; set; }
            public string satus { get; set; }
            public string origin { get; set; }
            public string weights { get; set; }
            public int totalQuantity { get; set; }
            public int quantitySold { get; set; }
            public string kindOfItem { get; set; }

        }
        private List<specialProduct> GetProducts()
        {
            List<specialProduct> products = new List<specialProduct>();
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"SELECT idItems,img0,price,promotion,nameItem FROM ITEMS ORDER BY dates OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY";

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
                        specialProduct items = new specialProduct
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
        private List<specialProduct> GetsSpecialProducts()
        {
            List<specialProduct> products = new List<specialProduct>();
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(conStr))
            {
                string query = @"select idItems,img0,price,promotion,nameItem,descs,satus,origin FROM ITEMS ORDER BY promotion DESC   OFFSET 0 ROWS  FETCH NEXT 1 ROWS ONLY";
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
                        specialProduct item = new specialProduct
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
        private List<specialProduct> GetProductPromotion()
        {
            List<specialProduct> products = new List<specialProduct>();
            string conTro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conTro))
            {
                string query = @"SELECT idItems,img0,price,promotion,nameItem FROM ITEMS WHERE quantitySold>500   ORDER BY dates OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY ";
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
                        specialProduct items = new specialProduct
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
        private List<specialProduct> GetFoodGuide()
        {
            List<specialProduct> specialProducts = new List<specialProduct>();
            string conTro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conTro))
            {
                string query = @"SELECT idItems, img0,nameItem,descs FROM ITEMS WHERE kindOfItem=N'Rau củ quả' ORDER BY dates OFFSET 0 ROWS FETCH NEXT 4 ROWS ONLY";
                SqlCommand cmd = new SqlCommand(query, con);
                try {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string spliceDescs = reader["descs"].ToString().Trim().Substring(0, 100);
                        specialProduct items = new specialProduct
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
        protected void AddOrder_Command(object sender, CommandEventArgs e)
        {
           string productId = e.CommandArgument.ToString();
            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contro))
            {
                string query = @"INSERT INTO ORDERS (quantity,idUsers,idItems) VALUES(@quantity,@idUsers,@idItems)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@quantity", 1);
                    cmd.Parameters.AddWithValue("@idUsers", "1"); // Tạm thời hard-code user ID là 1
                    cmd.Parameters.AddWithValue("@idItems", productId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();


        }
    }
    
}