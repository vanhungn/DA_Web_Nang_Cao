using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Facebook;
using System.Security.Claims;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(DA_Web_Nang_Cao.src.dangkygangnhap.Starup))]

namespace DA_Web_Nang_Cao.src.dangkygangnhap
{
    public class Starup

    {
        public void Configuration(IAppBuilder app)
        {
            // Sử dụng Cookie để lưu trạng thái đăng nhập
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/src/dangkygangnhap/login.aspx")
            });

            // Cấu hình Google OAuth
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "21417729216-u8et5bdb7cv8lpuut3om9q9kukcuapkv.apps.googleusercontent.com",
                ClientSecret = "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",
                CallbackPath = new PathString("/ExternalCallback.aspx")
            });
            app.UseFacebookAuthentication(new FacebookAuthenticationOptions
            {
                AppId = "1211001333765184",
                AppSecret = "febcaf306833ba6850bf1d4b25da7abf",
                CallbackPath = new PathString("/ExternalCallback.aspx"), // hoặc /signin-facebook nếu dùng mặc định
                Scope = { "email" },
                Fields = { "email", "name" },
                Provider = new FacebookAuthenticationProvider
                {
                    OnAuthenticated = context =>
                    {
                        // Thêm email vào Claims
                        context.Identity.AddClaim(new Claim(ClaimTypes.Email, context.Email));
                        return Task.FromResult(0);
                    }
                }
            });
        }
    }
}