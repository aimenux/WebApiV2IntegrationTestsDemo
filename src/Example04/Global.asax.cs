using System.Web;
using System.Web.Http;

namespace Example04
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
