using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;
using Miam.Web.Controllers;
using Miam.Web.Services;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Miam.Web.MVC5.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Miam.Web.MVC5.App_Start.NinjectWebCommon), "Stop")]

namespace Miam.Web.MVC5.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
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
            //repositories
            kernel.Bind<IEntityRepository<Restaurant>>().To<EfEntityRepository<Restaurant>>().InRequestScope();
            kernel.Bind<IEntityRepository<Writer>>().To<EfEntityRepository<Writer>>().InRequestScope();
            kernel.Bind<IEntityRepository<ApplicationUser>>().To<EfEntityRepository<ApplicationUser>>().InRequestScope();
            kernel.Bind<IEntityRepository<Review>>().To<EfEntityRepository<Review>>().InRequestScope();

            //services
            kernel.Bind<IHttpContextService>().To<HttpContextService>().InRequestScope();
            kernel.Bind<ILoginService>().To<LoginService>().InRequestScope();

            //database
            kernel.Bind<IDatabaseHelper>().To<EfDatabaseHelper>().InRequestScope();
        }        
    }
}
