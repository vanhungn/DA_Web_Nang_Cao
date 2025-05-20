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

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadOrderList();
                p_boxSearch.Visible = false;
                
            }
          
        }
        public void OnclickOpendSearch(object sender, EventArgs e)
        {
            if(p_boxSearch.Visible==true) { 
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
            lblCorrect.Text = "Không có thông tin cho loại dữ liệu này";
            if (ListOrderProduct.Count > 0)
            {
                lblInform.Text = ListOrderProduct.Count.ToString();
                lblCorrect.Text = "";
                int tongTien = 0;
                

                foreach (modelItems item in ListOrderProduct)
                {
                    if (item.promotion==0)
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
                rptListOder.Visible = false;
            }
        }
        public  List<modelItems> GetOrderProduct()
        {
            List<modelItems> modelItems = new List<modelItems>();

            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(contro))
            {
                string query = @"SELECT ITEMS.idItems, ITEMS.img0, ITEMS.promotion, ITEMS.nameItem, ITEMS.price, quantity 
                                 FROM ORDERS
                                 JOIN ITEMS ON ORDERS.idItems = ITEMS.idItems 
                                 JOIN USERS ON ORDERS.idUsers = USERS.idUsers 
                                 ORDER BY ITEMS.dates";

                SqlCommand cmd = new SqlCommand(query, con);

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

    }
}