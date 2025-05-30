using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.admin.pageUser
{
    public partial class pageUser : System.Web.UI.Page
    {
        private DataTable UserList
        {
            get
            {
                if (ViewState["UserList"] == null)
                    ViewState["UserList"] = GetUserData();
                return (DataTable)ViewState["UserList"];
            }
            set
            {
                ViewState["UserList"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private DataTable GetUserData()
        {
            DataTable dt = new DataTable();
            string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT 
                        idUsers AS ID,
                        names AS Name,
                        phones AS Phone,
                        emails AS Email,
                        userNames AS Username,
                        passwords AS Password,
                        roles AS Role,
                        addresss AS Address,
                        moneys AS Money,
                        createDate AS CreateDate,
                        lastLogin AS LastLogin
                    FROM USERS";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        private void BindGrid()
        {
            gvUser.DataSource = UserList;
            gvUser.DataBind();
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("pageUserAddEdit.aspx");
        }

        protected void txtSearchUser_ServerChange(object sender, EventArgs e)
        {
            string keyword = txtSearchUser.Value.Trim().ToLower();
            DataTable dtFilter = UserList.Clone();

            foreach (DataRow row in UserList.Rows)
            {
                if (
                    row["Name"].ToString().ToLower().Contains(keyword) ||
                    row["Phone"].ToString().ToLower().Contains(keyword) ||
                    row["Email"].ToString().ToLower().Contains(keyword) ||
                    row["Username"].ToString().ToLower().Contains(keyword) ||
                    row["Address"].ToString().ToLower().Contains(keyword))
                {
                    dtFilter.ImportRow(row);
                }
            }

            gvUser.DataSource = dtFilter;
            gvUser.DataBind();
        }

        protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUser.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string userId = e.CommandArgument.ToString();
            lblMessage.Text = "";

            if (e.CommandName == "Edit")
            {
                Response.Redirect($"pageUserAddEdit.aspx?id={userId}");
            }
            else if (e.CommandName == "Delete")
            {
                string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Kiểm tra khóa ngoại (đơn hàng)
                    string checkQuery = "SELECT COUNT(*) FROM ORDERS WHERE idUsers = @id";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@id", userId);
                    int orderCount = (int)checkCmd.ExecuteScalar();

                    if (orderCount > 0)
                    {
                        lblMessage.Text = "Không thể xoá người dùng vì đã phát sinh đơn hàng.";
                        return;
                    }

                    string query = "DELETE FROM USERS WHERE idUsers = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();
                }

                ViewState["UserList"] = null; // Reset cache
                BindGrid();
            }


        }
    }
}

