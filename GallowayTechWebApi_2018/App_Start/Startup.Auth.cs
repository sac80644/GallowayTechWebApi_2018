using System;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using GallowayTechWebApi_2018.Providers;
using GallowayTechWebApi_2018.Models;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace GallowayTechWebApi_2018
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            //Set Token expiration from Web.config
            var isNumeric = int.TryParse(WebConfigurationManager.AppSettings["TokenExpireTimeSpanFromMinutes"], out int tokenExpireTimeSpanFromMinutes);
            if(!isNumeric) { tokenExpireTimeSpanFromMinutes = 20; }

            //AllowInsecureHttp from Web.config
            var isBoolean = bool.TryParse(WebConfigurationManager.AppSettings["AllowInsecureHttp"], out bool allowInsecureHttp);
            if(!isBoolean) { allowInsecureHttp = true; }

            //TokenEndpointPath from Web.config - default is Token
            var tokenEndpointPath = WebConfigurationManager.AppSettings["TokenEndpointPath"];
            if (!Regex.IsMatch(tokenEndpointPath, @"^[a-zA-Z]+$")) { tokenEndpointPath = "Token"; }
            
            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/" + tokenEndpointPath),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(tokenExpireTimeSpanFromMinutes),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = allowInsecureHttp
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}