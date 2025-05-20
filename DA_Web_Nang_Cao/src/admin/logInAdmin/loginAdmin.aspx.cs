using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using DA_Web_Nang_Cao.src.model;

namespace DA_Web_Nang_Cao.src.admin.logInAdmin
{
    public partial class loginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void OnclickLoginAdmin(object sender, EventArgs e)
        {
            List<modelUsers> modelLogin = new List<modelUsers>();
            string contro = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(contro))
            {
                string query = @"SELECT idUsers FROM USERS WHERE userNames=@userNames AND   passwords=@passwords AND roles='admin'";
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    cmd.Parameters.AddWithValue("@userNames", txt_userNameAdmin.Text);
                    cmd.Parameters.AddWithValue("@passwords", txt_passwordAdmin.Text);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        modelUsers login = new modelUsers
                        {
                            idUsers = Convert.ToInt32(reader["idUsers"])
                        };
                        modelLogin.Add(login);

                    }
                }
            }
            if (modelLogin.Count == 0)
            {
                lbl_errorUnsuccessful.Text = "⚠️ Tk hoặc Mk không đúng vui lòng nhập lại!";
               
            }
            else
            {
                Response.Redirect("/src/home/home.aspx");
            }
        }
    }
}