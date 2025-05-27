using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security;

namespace DA_Web_Nang_Cao.src.dangkygangnhap
{
    public partial class ExternalLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string provider = Request.QueryString["provider"];
            if (!string.IsNullOrEmpty(provider))
            {
                var properties = new AuthenticationProperties
                {
                    // ✅ Dùng chung callback cho cả Google và Facebook
                    RedirectUri = "/ExternalCallback.aspx"
                };

                Context.GetOwinContext().Authentication.Challenge(properties, provider);
                Response.StatusCode = 401;
                Response.End();
            }
            else
            {
                Response.Redirect("~/src/dangkygangnhap/login.aspx");
            }
        }
    }
}