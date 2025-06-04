using DA_Web_Nang_Cao.src.component.header;
using DA_Web_Nang_Cao.src.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.ChiTietSanPham
{
    public partial class ChiTietSanPham : System.Web.UI.Page
    {
        
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

        public void LoadData()
        {
            string id = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(id))
            {
                LoadSanPham();
                LoadSanPhamLienQuan(id);
            }
          
        }
        private void LoadSanPham()
        {
          
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                int idProduct=Convert.ToInt32(Request.QueryString["id"]);
                string query = " SELECT idItems, img0, nameItem,price,descs,img1,img2,satus,origin FROM ITEMS WHERE  idItems = @id ORDER BY ITEMS.dates";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idProduct);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                        lblMaSP.Text = dr["idItems"].ToString();
                        lblTen.Text = dr["nameItem"].ToString();
                        litMoTa.Text = dr["descs"].ToString();
                        img00.ImageUrl = dr["img0"].ToString();
                        img11.ImageUrl = dr["img1"].ToString();
                        img22.ImageUrl = dr["img2"].ToString();
                        lblTinhTrang.Text = dr["satus"].ToString();
                        lblGiaGoc.Text = dr["price"].ToString();
                        lblXuatXu.Text = dr["origin"].ToString();
                    
                }
            }
           
        }

        private void LoadSanPhamLienQuan(string id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT TOP 5 * FROM ITEMS  ORDER BY dates";
                SqlCommand cmd = new SqlCommand(query, conn);
               
                conn.Open();
                rptRelated.DataSource = cmd.ExecuteReader();
                rptRelated.DataBind();
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
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["loginUser"];
            if (cookie == null || cookie["idUsers"] == null)
            {

                Response.Redirect("/src/dangkydangnhap/login");

            }
            string userId = GetUserIdFromCookie();
            string productId = Request.QueryString["id"];
            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
          

            
            using (SqlConnection con = new SqlConnection(contro))
            {
                string query = @"INSERT INTO ORDERS (quantity,idUsers,idItems) VALUES(@quantity,@idUsers,@idItems)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(txtSoLuong.Text));
                    cmd.Parameters.AddWithValue("@idUsers", userId); 
                    cmd.Parameters.AddWithValue("@idItems", productId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LoadData();
            headerHome2.LoadOrderList();
        }
    }
}