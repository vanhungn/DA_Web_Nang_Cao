using DA_Web_Nang_Cao.src.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.admin.pageUser
{
    public partial class pageUser1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void GetDetailItem(int id)
        {
            List<modelItems> modelItem = new List<modelItems>();
            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contro))
            {
                try
                {
                    string query = @"SELECT * FROM ITEMS WHERE idItems=@idItems";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@idItems", id);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        lbl_id.Text = reader["idItems"].ToString();
                        lbl_nameItem.Text = reader["nameItem"].ToString();
                        lbl_price.Text = reader["price"].ToString();
                        lbl_promotion.Text = reader["promotion"].ToString();
                        lbl_totalQuantity.Text = reader["totalQuantity"].ToString();
                        lbl_quantitySold.Text = reader["quantitySold"].ToString();
                        lbl_kindOfItem.Text = reader["kindOfItem"].ToString();
                        lbl_satus.Text = reader["satus"].ToString();
                        img0.ImageUrl = "../" + reader["img0"].ToString();
                        img1.ImageUrl = "../" + reader["img1"].ToString();
                        img2.ImageUrl = "../" + reader["img2"].ToString();
                        lbl_descs.Text = reader["descs"].ToString();
                        lbl_weights.Text = reader["weights"].ToString();
                        lbl_origin.Text = reader["origin"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("loi:" + ex.Message);
                }
            }

        }
        public event EventHandler CancelClickedDetail;

        // Gọi sự kiện khi click Cancel
        protected void OnclickCancelDetail(object sender, EventArgs e)
        {
            if (CancelClickedDetail != null)
            {
                CancelClickedDetail(this, EventArgs.Empty);
            }
        }

    }
}