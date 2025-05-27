using DA_Web_Nang_Cao.src.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.admin.pageItems.updateItem
{
    public partial class updateItem : System.Web.UI.UserControl
    {
        private string imgUpdoad0
        {
            get { return ViewState["imgUpdoad0"] as string ?? ""; }
            set { ViewState["imgUpdoad0"] = value; }
        }
        private string imgUpdoad1
        {
            get { return ViewState["imgUpdoad1"] as string ?? ""; }
            set { ViewState["imgUpdoad1"] = value; }
        }
        private string imgUpdoad2
        {
            get { return ViewState["imgUpdoad2"] as string ?? ""; }
            set { ViewState["imgUpdoad2"] = value; }
        }
        private int idItem
        {
            get { return ViewState["idItem"] != null ? (int)ViewState["idItem"] : 0; }
            set { ViewState["idItem"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Img0.ImageUrl = "https://i.pinimg.com/564x/22/cc/3e/22cc3e2fc96b3a65798348d313e99b4b.jpg";
                Img1.ImageUrl = "https://i.pinimg.com/564x/22/cc/3e/22cc3e2fc96b3a65798348d313e99b4b.jpg";
                Img2.ImageUrl = "https://i.pinimg.com/564x/22/cc/3e/22cc3e2fc96b3a65798348d313e99b4b.jpg";
            }
        }
       
        public void GetItem(int id)
        {
                idItem = id;
                string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(contro))
                {
                    string query = @"SELECT nameItem,price,promotion,totalQuantity,quantitySold,descs,weights,origin FROM ITEMS WHERE idItems=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txt_nameItem.Text = reader["nameItem"].ToString();
                        txt_price.Text = reader["price"].ToString();
                        txt_promotion.Text = reader["promotion"].ToString();
                        txt_totalQuantity.Text = reader["totalQuantity"].ToString();
                        txt_quantitySold.Text = reader["quantitySold"].ToString();
                        txt_descs.Text = reader["descs"].ToString();
                        txt_weights.Text = reader["weights"].ToString();
                        txt_origin.Text = reader["origin"].ToString();
                    }

                }
        }
        public void ClickLookPicture1(object sender, EventArgs e)
        {
            if (fu_img0.HasFile)
            {
                string fileName = Path.GetFileName(fu_img0.FileName);
                string savePath = Server.MapPath("../../picture/" + fileName);

                // Lưu ảnh vào thư mục trên server
                fu_img0.SaveAs(savePath);

                // Hiển thị ảnh lên giao diện
                Img0.ImageUrl = "../../../picture/" + fileName;
                imgUpdoad0 = "../../picture/" + fileName;
            }
        }
        public void ClickLookPicture2(object sender, EventArgs e)
        {
            if (fu_img1.HasFile)
            {
                string fileName = Path.GetFileName(fu_img1.FileName);
                string savePath = Server.MapPath("../../picture/" + fileName);

                // Lưu ảnh vào thư mục trên server
                fu_img1.SaveAs(savePath);

                // Hiển thị ảnh lên giao diện
                Img1.ImageUrl = "../../../picture/" + fileName;
                imgUpdoad1 = "../../picture/" + fileName;
            }
        }
        public void ClickLookPicture3(object sender, EventArgs e)
        {
            if (fu_img2.HasFile)
            {
                string fileName = Path.GetFileName(fu_img2.FileName);
                string savePath = Server.MapPath("../../picture/" + fileName);

                // Lưu ảnh vào thư mục trên server
                fu_img2.SaveAs(savePath);

                // Hiển thị ảnh lên giao diện
                Img2.ImageUrl = "../../../picture/" + fileName;
                imgUpdoad2 = "../../picture/" + fileName;
            }
        }
        public event EventHandler CancelClicked;

        // Gọi sự kiện khi click Cancel
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelClicked != null)
            {
                CancelClicked(this, EventArgs.Empty);
            }
        }
        
        public void OnclickUpdate(object sender, EventArgs e)
        {
            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using(SqlConnection con = new SqlConnection(contro))
            {
                string query = @"UPDATE ITEMS SET nameItem=@nameItem,price=@price,promotion=@promotion,totalQuantity=@totalQuantity,
                                quantitySold=@quantitySold,kindOfItem=@kindOfItem,descs=@descs,satus=@satus,weights=@weights,img0=@img0,
                                img1=@img1,img2=@img2,origin=@origin,dates=@dates WHERE idItems=@idItems";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@nameItem", txt_nameItem.Text);
                cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txt_price.Text));
                cmd.Parameters.AddWithValue("@promotion", Convert.ToInt32(txt_promotion.Text));
                cmd.Parameters.AddWithValue("@totalQuantity", Convert.ToInt32(txt_totalQuantity.Text));
                cmd.Parameters.AddWithValue("@quantitySold", Convert.ToInt32(txt_quantitySold.Text));
                cmd.Parameters.AddWithValue("@kindOfItem", d_kindOfItem.SelectedValue);
                cmd.Parameters.AddWithValue("@descs", txt_descs.Text);
                cmd.Parameters.AddWithValue("@satus", d_statusCreate.SelectedValue);
                cmd.Parameters.AddWithValue("@weights", txt_weights.Text);
                cmd.Parameters.AddWithValue("@img0", imgUpdoad0);
                cmd.Parameters.AddWithValue("@img1", imgUpdoad1);
                cmd.Parameters.AddWithValue("@img2", imgUpdoad2);
                cmd.Parameters.AddWithValue("@origin", txt_origin.Text);
                cmd.Parameters.AddWithValue("@dates", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@idItems", idItem);
                con.Open();
                cmd.ExecuteNonQuery();
                btnCancel_Click(null,EventArgs.Empty);
            }
        }
    }
}