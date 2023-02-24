using Microsoft.Owin.Diagnostics;
using Owin;
using System.Web.Http;

namespace Example06
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var errorOptions = new ErrorPageOptions
            {
                ShowExceptionDetails = true
            };

            appBuilder.UseErrorPage(errorOptions);
            appBuilder.UseWelcomePage("/welcome.html");

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
