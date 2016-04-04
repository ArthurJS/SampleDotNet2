using System.Diagnostics.CodeAnalysis;
using Groep8DotNetProjectenII.Models.DAL;
using Groep8DotNetProjectenII.Models.Domain;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Groep8DotNetProjectenII.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Groep8DotNetProjectenII.App_Start.NinjectWebCommon), "Stop")]

namespace Groep8DotNetProjectenII.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    [ExcludeFromCodeCoverage]
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

            kernel.Bind<ILandRepository>().To<LandRepository>().InRequestScope();
            kernel.Bind<IContinentRepository>().To<ContinentRepository>().InRequestScope();
            kernel.Bind<IKlimatogramRepository>().To<KlimatogramRepository>().InRequestScope();
            kernel.Bind<ILocatieRepository>().To<LocatieRepository>().InRequestScope();
            kernel.Bind<IDeterminatieTabelRepository>().To<DeterminatieTabelRepository>().InRequestScope();
            kernel.Bind<KlimatogramContext>().ToSelf().InRequestScope();
            kernel.Bind<IGradenRepository>().To<GradenRepository>().InRequestScope();

        }        
    }
}
