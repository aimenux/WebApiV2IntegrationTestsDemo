using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;
using Example02.Services;
using Unity;

namespace Example02
{
    public class IocConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IProductService, ProductService>(TypeLifetime.Singleton);
            config.DependencyResolver = new UnityDependencyResolver(container);
        }

        private class UnityDependencyResolver : UnityDependencyScope, IDependencyResolver
        {
            public UnityDependencyResolver(IUnityContainer container) : base(container)
            {
            }

            public IDependencyScope BeginScope()
            {
                var childContainer = Container.CreateChildContainer();
                return new UnityDependencyScope(childContainer);
            }
        }

        private class UnityDependencyScope : IDependencyScope
        {
            public UnityDependencyScope(IUnityContainer container)
            {
                Container = container;
            }

            protected IUnityContainer Container { get; }

            public object GetService(Type serviceType)
            {
                if (typeof(IHttpController).IsAssignableFrom(serviceType)) return Container.Resolve(serviceType);

                try
                {
                    return Container.Resolve(serviceType);
                }
                catch
                {
                    return null;
                }
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return Container.ResolveAll(serviceType);
            }

            public void Dispose()
            {
                Container.Dispose();
            }
        }
    }
}