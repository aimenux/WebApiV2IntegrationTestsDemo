using System.Web;
using System.Web.Http;

namespace Example03
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            IocConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
