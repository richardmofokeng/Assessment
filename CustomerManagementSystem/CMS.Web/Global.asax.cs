using CMS.Business;
using CMS.Services;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly StandardKernel _kernel = new StandardKernel();
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            bootstrapper.Initialize(CreateKernel); 
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        /// <summary>  
        /// Creates the kernel that will manage your application.  
        /// </summary>  
        /// <returns>The created kernel.</returns>  
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
        /// <summary>  
        /// Load your modules or register your services here!  
        /// </summary>  
        /// <param name="kernel">The kernel.</param>  
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICustomerService>().To<CustomerBO>().InRequestScope();

        }
    }
}
