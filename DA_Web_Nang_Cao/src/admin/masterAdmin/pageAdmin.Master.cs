using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DA_Web_Nang_Cao.src.admin.masterAdmin
{
    public partial class pageAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.Url.AbsolutePath;
            if (url == "/src/admin/pageUser/pageUser")
            {
                p_boxNavigationBar1.CssClass = "boxNavigationChoose";
            }
            else if(url == "/src/admin/pageItems/pageItem"){
                p_boxNavigationBar2.CssClass = "boxNavigationChoose";
            }
            
            else if (url == "/src/admin/pageContact/pageContact")
            {
                p_boxNavigationBar4.CssClass = "boxNavigationChoose";
            }

        }
        public void OnclickButtonNavigate(object sender, EventArgs e)
        {
            Response.Redirect("/src/admin/pageUser/pageUser");
        }
        public void OnclickButtonNavigate1(object sender, EventArgs e)
        {
            Response.Redirect("/src/admin/pageItems/pageItem");
        }
      
        public void OnclickButtonNavigate3(object sender, EventArgs e)
        {
            Response.Redirect("/src/admin/pageContact/pageContact");
        }
    }
}