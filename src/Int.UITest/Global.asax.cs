using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using ECommon.Autofac;
using ECommon.Components;
using ECommon.JsonNet;
using ECommon.Log4Net;
using ECommon.Logging;
using ENode.Configurations;
using ECommonConfiguration = ECommon.Configurations.Configuration;
using System.Web.Optimization;
using Int.UITest.Extensions;

namespace Int.UITest
{
    public class MvcApplication : HttpApplication
    {
        private ILogger _logger;
        private ECommonConfiguration _ecommonConfiguration;
        private ENodeConfiguration _enodeConfiguration;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeECommon();
            InitializeENode();
        }

        private void InitializeECommon()
        {
            _ecommonConfiguration = ECommonConfiguration
                .Create()
                .UseAutofac()
                .RegisterCommonComponents()
                .UseLog4Net()
                .UseJsonNet();

            _logger = ObjectContainer.Resolve<ILoggerFactory>().Create(GetType().FullName);
            _logger.Info("ECommon initialized.");
        }
        private void InitializeENode()
        {
            var assemblies = new[]
            {
                Assembly.Load("Int.AC"),
                Assembly.Load("Int.AC.CommandHandlers"),
                Assembly.Load("Int.AC.ReadModel"),
                Assembly.Load("Int.UITest")
            };
            string dbConfig = System.Configuration.ConfigurationManager.ConnectionStrings["IntDbConn"].ConnectionString;
            var setting = new ConfigurationSetting { SqlServerDefaultConnectionString = dbConfig };
            _enodeConfiguration = _ecommonConfiguration
                .CreateENode(setting)
                .RegisterENodeComponents()
                .RegisterBusinessComponents(assemblies)
                .UseSqlServerCommandStore()
                .UseSqlServerEventStore()
                .UseEQueue()
                .InitializeBusinessAssemblies(assemblies)
                .StartENode(NodeType.CommandProcessor | NodeType.EventProcessor | NodeType.ExceptionProcessor)
                .StartEQueue();

            RegisterControllers();
            _logger.Info("ENode initialized.");
        }
        private void RegisterControllers()
        {
            var webAssembly = Assembly.GetExecutingAssembly();
            var container = (ObjectContainer.Current as AutofacObjectContainer).Container;
            var builder = new ContainerBuilder();
            builder.RegisterControllers(webAssembly);
            builder.Update(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
