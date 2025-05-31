using DA_Web_Nang_Cao.src.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.admin.pageUser
{
    public partial class pageUser : System.Web.UI.Page
    {
        public List<modelItems> listProductItem = new List<modelItems>();
        public List<PageData> totalPage = new List<PageData>();
        private int indexToStyle = 0;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            update.CancelClicked += UpdateItemControl_CancelClicked;
            detail.CancelClickedDetail += DetailItemControl_CancelClick;
            if (!IsPostBack)
            {
                pageLoad();
                Img0.ImageUrl = "https://i.pinimg.com/564x/22/cc/3e/22cc3e2fc96b3a65798348d313e99b4b.jpg";
                Img1.ImageUrl = "https://i.pinimg.com/564x/22/cc/3e/22cc3e2fc96b3a65798348d313e99b4b.jpg";
                Img2.ImageUrl = "https://i.pinimg.com/564x/22/cc/3e/22cc3e2fc96b3a65798348d313e99b4b.jpg";
                p_CreateItem.Visible = false;
                p_UpdateItem.Visible = false;
                p_DetailItem.Visible = false;
            }
        }

        public class PageData
        {
            public int past { get; set; }
        }
        public void pageLoad()
        {
            listProductItem = GetProductItems(indexToStyle, "", "", "", "");
            rpt_ListItemsPageAdmin.DataSource = listProductItem;
            rpt_ListItemsPageAdmin.DataBind();
            totalPage = GetTotalRows("", "", "");
            rpt_totalPage.DataSource = totalPage;
            rpt_totalPage.DataBind();



        }
        public void OnclickSubmitCreate(object sender, EventArgs e)
        {
            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contro))
            {

                string query = "INSERT INTO ITEMS(nameItem,price,promotion,totalQuantity,quantitySold,kindOfItem,descs,satus,weights,img0,img1,img2,origin,dates)VALUES" +
                "(@nameItem,@price,@promotion,@totalQuantity,@quantitySold,@kindOfItem,@descs,@satus,@weights,@img0,@img1,@img2,@origin,@dates)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
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
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                pageLoad();
                p_CreateItem.Visible = false;
                p_listItem.Visible = true;
                p_UpdateItem.Visible = false;
                p_DetailItem.Visible = false;
            }
        }
        public List<PageData> GetTotalRows(string search, string status, string kindOf)
        {
            List<PageData> list = new List<PageData>();
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string query = "SELECT COUNT(*) FROM ITEMS WHERE 1=1";


                if (!string.IsNullOrWhiteSpace(search))
                {
                    query += " AND LOWER(nameItem) LIKE @searchFor";
                    cmd.Parameters.AddWithValue("@searchFor", "%" + search + "%");

                }
                if (!string.IsNullOrWhiteSpace(status))
                {
                    query += " AND satus=@status ";
                    cmd.Parameters.AddWithValue("@status", status);
                }
                if (!string.IsNullOrWhiteSpace(kindOf))
                {
                    query += "AND kindOfItem=@kindOf ";
                    cmd.Parameters.AddWithValue("@kindOf", kindOf);
                }
                cmd.CommandText = query;
                con.Open();
                int totalRows = (int)cmd.ExecuteScalar();
                int totalPages = (int)Math.Ceiling((double)totalRows / 9);
                for (int i = 1; i <= totalPages; i++)
                {
                    PageData pageData = new PageData
                    {
                        past = i
                    };
                    list.Add(pageData);

                }
            }
            return list;
        }
        public void rptButtons_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btn = (Button)e.Item.FindControl("btn_page");

                if (e.Item.ItemIndex == indexToStyle)
                {
                    // Cách 1: Thêm class CSS
                    btn.CssClass = "buttonChoose";
                }


            }
        }
        protected void rpt_pastPage(object source, RepeaterCommandEventArgs e)
        {
            int past = Convert.ToInt32(e.CommandArgument);
            indexToStyle = past - 1;
            pageLoad();
        }
        public void btnPageFirst(object sender, EventArgs e)
        {
            pageLoad();

        }
        public void btnPageLast(object sender, EventArgs e)
        {
            pageLoad();
            indexToStyle = totalPage.Count - 1;
            pageLoad();

        }
        public List<modelItems> GetProductItems(int skip, string search, string status, string arrange, string kindOf)
        {
            indexToStyle = skip;
            List<modelItems> modelItems = new List<modelItems>();
            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(contro))
            {
                HttpCookie cookie = Request.Cookies["admin"];
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string query = @"
                                IF EXISTS (SELECT 1 FROM USERS WHERE idUsers = @idUser AND roles = @roles)";
                query += "BEGIN\n";

                query += "SELECT idItems, img0, img1, img2, price, promotion, nameItem, satus, totalQuantity, quantitySold, kindOfItem FROM ITEMS WHERE 1=1 ";
                if (!string.IsNullOrWhiteSpace(search))
                {
                    query += " AND  LOWER(nameItem) LIKE @searchFor ";
                    cmd.Parameters.AddWithValue("@searchFor", "%" + search + "%");

                }
                if (!string.IsNullOrWhiteSpace(status))
                {
                    query += "AND satus=@status ";
                    cmd.Parameters.AddWithValue("@status", status);
                }
                if (!string.IsNullOrWhiteSpace(kindOf))
                {
                    query += "AND kindOfItem=@kindOf ";
                    cmd.Parameters.AddWithValue("@kindOf", kindOf);
                }
                if (string.IsNullOrWhiteSpace(arrange))
                {
                    query += " ORDER BY dates DESC , idItems DESC ";
                }
                else
                {
                    // Giả sử kindOf = "ASC" hoặc "DESC"
                    arrange = arrange.ToUpper() == "ASC" ? "ASC " : "DESC ";
                    query += $" ORDER BY dates {arrange}, idItems {arrange}";
                }
                query += " OFFSET @skip ROWS FETCH NEXT 9 ROWS ONLY;\n";
                query += "END\n";
                query += "ELSE\n";
                query += "BEGIN\n";

                query += "SELECT TOP 0 * FROM ITEMS;\n";
                query += "END";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@skip", skip * 9);
                cmd.Parameters.AddWithValue("@idUser", Convert.ToInt32(cookie["idUsers"]));
                cmd.Parameters.AddWithValue("@roles", cookie["roles"]);
                cmd.Parameters.AddWithValue("@like", search);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        modelItems item = new modelItems
                        {
                            idItem = reader["idItems"].ToString(),
                            nameItem = reader["nameItem"].ToString(),
                            price = Convert.ToInt32(reader["price"]),
                            promotion = Convert.ToInt32(reader["promotion"]),
                            totalQuantity = Convert.ToInt32(reader["totalQuantity"]),
                            quantitySold = Convert.ToInt32(reader["quantitySold"]),
                            kindOfItem = reader["kindOfItem"].ToString(),
                            satus = reader["satus"].ToString(),
                            img0 = reader["img0"].ToString(),
                            img1 = reader["img1"].ToString(),
                            img2 = reader["img2"].ToString()
                        };
                        modelItems.Add(item);

                    }
                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        pageLoad();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("loi:" + ex.Message);
                }
            }
            return modelItems;
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
                Img0.ImageUrl = "../../picture/" + fileName;
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
                Img1.ImageUrl = "../../picture/" + fileName;
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
                Img2.ImageUrl = "../../picture/" + fileName;
                imgUpdoad2 = "../../picture/" + fileName;
            }
        }
        public void OnclickButtonAddItem(object sender, EventArgs e)
        {
            p_CreateItem.Visible = true;
            p_listItem.Visible = false;
            p_UpdateItem.Visible = false;
            p_DetailItem.Visible = false;
        }
        public void OnclickCancel(object sender, EventArgs e)
        {
            p_CreateItem.Visible = false;
            p_listItem.Visible = true;
            p_UpdateItem.Visible = false;
            p_DetailItem.Visible = false;
        }
        private void UpdateItemControl_CancelClicked(object sender, EventArgs e)
        {
            p_CreateItem.Visible = false;
            p_listItem.Visible = true;
            p_UpdateItem.Visible = false;
            p_DetailItem.Visible = false;
            pageLoad();
        }
        public void DetailItemControl_CancelClick(object sender, EventArgs e)
        {
            p_CreateItem.Visible = false;
            p_listItem.Visible = true;
            p_UpdateItem.Visible = false;
            p_DetailItem.Visible = false;

        }

        public void OnclickUpdateItem(object sender, CommandEventArgs e)
        {
            p_CreateItem.Visible = false;
            p_listItem.Visible = false;
            p_UpdateItem.Visible = true;
            p_DetailItem.Visible = false;
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            update.GetItem(id);
        }
        public void OnclickDetailItem(object sender, CommandEventArgs e)
        {
            p_CreateItem.Visible = false;
            p_listItem.Visible = false;
            p_UpdateItem.Visible = false;
            p_DetailItem.Visible = true;
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            detail.GetDetailItem(id);
        }
        public void OnclickDelete(object sender, CommandEventArgs e)
        {
            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contro))
            {
                string query = @"DELETE FROM ITEMS WHERE idItems = @idItems";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idItems", Convert.ToInt32(e.CommandArgument));
                con.Open();
                cmd.ExecuteNonQuery();
                pageLoad();
            }
        }
        public void OnchangeListItem(object sender, EventArgs e)
        {

            listProductItem = GetProductItems(0, txt_searchItem.Text, d_status.SelectedValue, d_arrange.SelectedValue, d_kindOf.SelectedValue);
            rpt_ListItemsPageAdmin.DataSource = listProductItem;
            rpt_ListItemsPageAdmin.DataBind();

            totalPage = GetTotalRows(txt_searchItem.Text, d_status.SelectedValue, d_kindOf.SelectedValue);
            rpt_totalPage.DataSource = totalPage;
            rpt_totalPage.DataBind();
        }

    }
    
}

