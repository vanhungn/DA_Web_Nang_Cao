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
     
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra quyền admin
            if (Request.Cookies["admin"] == null)
            {
                p_accessDenied.Visible = true;
                up_main.Visible = false;
                return;
            }

            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        // Load tất cả người dùng hoặc theo từ khóa tìm kiếm
        private void LoadUsers(string keyword = "")
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT * FROM USERS 
                    WHERE names LIKE @kw OR userNames LIKE @kw OR emails LIKE @kw OR phones LIKE @kw
                    ORDER BY idUsers DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rpt_users.DataSource = dt;
                rpt_users.DataBind();
            }
        }

        // Sự kiện tìm kiếm
        protected void btn_search_Click(object sender, EventArgs e)
        {
            string keyword = txt_search.Text.Trim();
            LoadUsers(keyword);
        }


        protected void btn_addUser_Click(object sender, EventArgs e)
        {
            p_update.Visible = true;
            uc_updateUser.ClearForm(); // Hàm Clear dùng để xóa dữ liệu cũ
        }

       
        // Sự kiện sửa
        protected void lnk_edit_Click(object sender, EventArgs e)
        {
            string idStr = ((System.Web.UI.WebControls.LinkButton)sender).CommandArgument;
            int id = int.Parse(idStr);

            p_update.Visible = true;
            uc_updateUser.GetUser(id); // Tải dữ liệu người dùng lên form update
        }

        // Sự kiện xóa
        protected void lnk_delete_Click(object sender, EventArgs e)
        {
            string idStr = ((System.Web.UI.WebControls.LinkButton)sender).CommandArgument;
            int id = int.Parse(idStr);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM USERS WHERE idUsers=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadUsers();
        }

        // Khi nhấn nút Cancel trong updateUser.ascx
        protected void uc_updateUser_CancelClicked(object sender, EventArgs e)
        {
            p_update.Visible = false;
            LoadUsers();
        }


    }
    
}

