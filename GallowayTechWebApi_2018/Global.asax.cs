using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Reflection;
using System.IO;

namespace GallowayTechWebApi_2018
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static string AssemblyVersionString;
        public static string AssemblyBuildDateTimeString;

        protected void Application_Start()
        {
            Assembly web = Assembly.Load("GallowayTechWebApi_2018");
            AssemblyName webName = web.GetName();
            AssemblyVersionString = webName.Version.ToString();
            FileInfo fi = new FileInfo(web.Location);
            AssemblyBuildDateTimeString = fi.CreationTime.ToString();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SiteContentContext>());
        }
    }
}
