using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Example04.Services;

namespace Example04
{
    public class IocConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(IocConfig).Assembly);
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}