using System.Web.Http;
using System.Web.Mvc;
using WebApplication8.App_Start;

namespace WebApplication8
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
