using DA_Web_Nang_Cao.src.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DA_Web_Nang_Cao.src.component.header.headerHome;

namespace DA_Web_Nang_Cao.src.pages.product
{
    public partial class product : System.Web.UI.Page
    {
        public List<modelItems> getearlyProduct = new List<modelItems>();
        public List<modelItems> getProductItem = new List<modelItems>();
        public List<PageData> totalPage = new List<PageData>();
        private int indexToStyle = 0;
        private string category
        {
            get { return ViewState["category"] as string ?? ""; }
            set { ViewState["category"] = value; }
        }
        private List<string> selectedValuesProduct
        {
            get { return ViewState["selectedValuesProduct"] as List<string> ?? new List<string>(); }
            set { ViewState["selectedValuesProduct"] = value; }
        }
        private List<string> selectedValuesWeightProduct
        {
            get { return ViewState["selectedValuesWeightProduct"] as List<string> ?? new List<string>(); }
            set { ViewState["selectedValuesWeightProduct"] = value; }
        }
        private string search
        {
            get { return ViewState["search"] as string ?? ""; }
            set { ViewState["search"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            headerHome1.categoryProduct += categoryControl_ClickCategory;
            headerHome1.searchProduct += searchControl_ClickSearch;
            if (!IsPostBack)
            {
                pageLoad();
            }
        }
        public void pageLoad()
        {
            totalPage = GetTotalRows(selectedValuesProduct, selectedValuesWeightProduct, category, search);
            rpt_totalPages.DataSource = totalPage;
            rpt_totalPages.DataBind();
            getearlyProduct = GetEarlyProduct();
            rptListEarlyProduct.DataSource = getearlyProduct;
            rptListEarlyProduct.DataBind();
            getProductItem = GetProductItem(indexToStyle, selectedValuesProduct, selectedValuesWeightProduct, category, search);
            rptProductsItem.DataSource = getProductItem;
            rptProductsItem.DataBind();
        }
        public class PageData
        {
            public int past { get; set; }
        }
        
        public void searchControl_ClickSearch(object sender, SearchEventArgs e)
        {
            search = e.search;
            pageLoad();
        }
        public void categoryControl_ClickCategory(object sender, SearchEventArgsCategory e)
        {
            category = e.category;
            pageLoad();
        }
        public List<modelItems> GetEarlyProduct()
        {
            List<modelItems> product = new List<modelItems>();
            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contro))
            {
                try
                {
                    string query = @"SELECT idItems,img0, nameItem, promotion,price FROM ITEMS ORDER BY dates DESC OFFSET 0 ROWS FETCH NEXT 3 ROWS ONLY ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
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
                            modelItems productItems = new modelItems
                            {
                                idItem = reader["idItems"].ToString(),
                                nameItem = reader["nameItem"].ToString(),
                                price = Convert.ToInt32(reader["price"]),
                                promotion = Convert.ToInt32(pricePromotion),
                                img0 = reader["img0"].ToString()
                            };
                            product.Add(productItems);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Response.Write("Lỗi: " + ex.Message);
                }
            }
            return product;
        }
        public List<modelItems> GetProductItem(int skip, List<string> origins, List<string> weight, string category, string search)
        {
            indexToStyle = skip;
            List<modelItems> product = new List<modelItems>();
            try
            {
                string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(contro))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    string query = @"SELECT idItems, img0, price, promotion, nameItem 
                             FROM ITEMS WHERE 1=1";

                    if (origins != null && origins.Count > 0)
                    {
                        List<string> parameters = new List<string>();
                        for (int i = 0; i < origins.Count; i++)
                        {
                            string paramName = "@origin" + i;
                            parameters.Add(paramName);
                            cmd.Parameters.AddWithValue(paramName, origins[i]);
                        }
                        query += " AND origin IN (" + string.Join(",", parameters) + ")";
                    }
                    if (weight != null && weight.Count > 0)
                    {
                        List<string> parametersWeight = new List<string>();
                        for (int i = 0; i < weight.Count; i++)
                        {
                            string paramName = "@weight" + i;
                            parametersWeight.Add(paramName);
                            cmd.Parameters.AddWithValue(paramName, weight[i]);
                        }
                        query += " AND weights IN (" + string.Join(",", parametersWeight) + ")";
                    }
                    if (!string.IsNullOrWhiteSpace(category))
                    {
                        query += " AND kindOfItem = @kindOfItem";
                        cmd.Parameters.AddWithValue("@kindOfItem", category);
                    }
                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        query += " AND LOWER(nameItem) LIKE @searchFor";
                        cmd.Parameters.AddWithValue("@searchFor", "%" + search + "%");
                    }
                    query += " ORDER BY dates DESC, idItems DESC OFFSET @skip ROWS FETCH NEXT 15 ROWS ONLY";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@skip", indexToStyle * 15);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int pri = Convert.ToInt32(reader["price"]);
                        int pro = Convert.ToInt32(reader["promotion"]);
                        int pricePromotion = (pro > 0) ? (pri - (pri * pro) / 100) : 0;

                        modelItems modelItem = new modelItems
                        {
                            idItem = reader["idItems"].ToString(),
                            nameItem = reader["nameItem"].ToString(),
                            price = pri,
                            promotion = pricePromotion,
                            img0 = reader["img0"].ToString(),
                            percentPromotion = pro
                        };
                        product.Add(modelItem);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("Lỗi: " + ex.Message);
            }

            return product;
        }

        public void rptButtons_ItemDataBounds(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btn = (Button)e.Item.FindControl("btn_pages");

                if (e.Item.ItemIndex == indexToStyle)
                {
                    // Cách 1: Thêm class CSS
                    btn.CssClass = "buttonChoose";
                }


            }
        }
        public void btnPageFirsts(object sender, EventArgs e)
        {
            pageLoad();

        }
        public void btnPageLasts(object sender, EventArgs e)
        {
            pageLoad();
            indexToStyle = totalPage.Count - 1;
            pageLoad();

        }
        protected void rpt_pastPages(object source, RepeaterCommandEventArgs e)
        {
            int past = Convert.ToInt32(e.CommandArgument);
            indexToStyle = past - 1;

            pageLoad();
        }
        public List<PageData> GetTotalRows(List<string> origins, List<string> weight, string category, string search)
        {
            List<PageData> list = new List<PageData>();
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                string query = "SELECT COUNT(*) FROM ITEMS WHERE 1=1";


                if (origins != null && origins.Count > 0)
                {
                    List<string> parameters = new List<string>();
                    for (int i = 0; i < origins.Count; i++)
                    {
                        string paramName = "@origin" + i;
                        parameters.Add(paramName);
                        cmd.Parameters.AddWithValue(paramName, origins[i]);
                    }
                    query += " AND origin IN (" + string.Join(",", parameters) + ")";
                }
                if (weight != null && weight.Count > 0)
                {
                    List<string> parametersWeight = new List<string>();
                    for (int i = 0; i < weight.Count; i++)
                    {
                        string paramName = "@weight" + i;
                        parametersWeight.Add(paramName);
                        cmd.Parameters.AddWithValue(paramName, weight[i]);
                    }
                    query += " AND weights IN (" + string.Join(",", parametersWeight) + ")";
                }
                if (!string.IsNullOrWhiteSpace(category))
                {
                    query += " AND kindOfItem = @kindOfItem";
                    cmd.Parameters.AddWithValue("@kindOfItem", category);
                }
                if (!string.IsNullOrWhiteSpace(search))
                {
                    query += " AND LOWER(nameItem) LIKE @searchFor";
                    cmd.Parameters.AddWithValue("@searchFor", "%" + search + "%");
                }
                cmd.CommandText = query;
                con.Open();
                int totalRows = (int)cmd.ExecuteScalar();
                int totalPages = (int)Math.Ceiling((double)totalRows / 15);
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
        public void OnCommentCategory(object sender, CommandEventArgs e)
        {
            category = e.CommandArgument.ToString();
            List<string> categories = new List<string>
            {
                "Bột, Ngũ cốc",
                "Rau củ quả",
                "Hải Sản",
                "Thực Phẩm Đông Lạnh",
                "Sushi & Sashimi Deli",
                "Thịt - Cá"
            };


            List<Label> titles = new List<Label>
            {
                titleCategoryProduct1,
                titleCategoryProduct2,
                titleCategoryProduct3,
                titleCategoryProduct4,
                titleCategoryProduct5,
                titleCategoryProduct6
            };

            for (int i = 0; i < categories.Count; i++)
            {
                if (category == categories[i])
                {
                    titles[i].CssClass = "titleCategoryMainProductHover";
                }
                else
                {
                    titles[i].CssClass = "titleCategoryMainProduct";
                }
            }
            pageLoad();
        }

        protected void cbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> selectedValues = new List<string>();
            foreach (ListItem item in checkBocListOrigin.Items)
            {
                if (item.Selected)
                {
                    selectedValues.Add(item.Value);
                }
            }
            List<string> selectedValuesWeight = new List<string>();
            foreach (ListItem item in checkBocListWeight.Items)
            {
                if (item.Selected)
                {
                    selectedValuesWeight.Add(item.Value);
                }
            }
            selectedValuesProduct = selectedValues;
            selectedValuesWeightProduct = selectedValuesWeight;
            getProductItem = GetProductItem(0, selectedValues, selectedValuesWeight, category, search);
            rptProductsItem.DataSource = getProductItem;
            rptProductsItem.DataBind();
            totalPage = GetTotalRows(selectedValues, selectedValuesWeight, category, search);
            rpt_totalPages.DataSource = totalPage;
            rpt_totalPages.DataBind();
        }
        public void OnClickDetail(object sender, CommandEventArgs e)
        {

        }
    }
}