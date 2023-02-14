using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Example03.Services;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;

namespace Example03
{
    public class IocConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IProductService>().To<ProductService>().InSingletonScope();
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
        
        private class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
        {
            private readonly IKernel _kernel;

            public NinjectDependencyResolver(IKernel kernel) : base(kernel)
            {
                _kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
            }

            public IDependencyScope BeginScope()
            {
                return new NinjectDependencyScope(_kernel.BeginBlock());
            }
        }
        
        private class NinjectDependencyScope : IDependencyScope
        {
            private IResolutionRoot _resolutionRoot;

            public NinjectDependencyScope(IResolutionRoot resolutionRoot)
            {
                _resolutionRoot = resolutionRoot ?? throw new ArgumentNullException(nameof(resolutionRoot));
            }

            public object GetService(Type serviceType)
            {
                return ResolveService(serviceType).SingleOrDefault();
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return ResolveService(serviceType).ToList();
            }

            private IEnumerable<object> ResolveService(Type serviceType)
            {
                var request = _resolutionRoot.CreateRequest(serviceType, null, Array.Empty<Parameter>(), true, true);
                return _resolutionRoot.Resolve(request);
            }

            public void Dispose()
            {
                var disposable = (IDisposable)_resolutionRoot;
                disposable?.Dispose();
                _resolutionRoot = null;
            }
        }
    }
}