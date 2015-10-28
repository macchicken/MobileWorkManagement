using System;
using System.Reflection;
using System.ServiceProcess;
using ECommon.Autofac;
using ECommon.Components;
using ECommon.Configurations;
using ECommon.JsonNet;
using ECommon.Log4Net;
using ECommon.Logging;
using ENode.Configurations;

namespace Int.EventService
{
    public partial class Service1 : ServiceBase
    {
        private ILogger _logger;
        private Configuration _baseConfiguration;
        private ENodeConfiguration _enodeConfiguration;

        public Service1()
        {
            InitializeComponent();
            CreateECommonConfiguration();

            _logger = ObjectContainer.Resolve<ILoggerFactory>().Create(GetType().FullName);
            _logger.Info("Service initialized.");

            try
            {
                InitializeENode();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _enodeConfiguration.StartENode(NodeType.EventProcessor).StartEQueue();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        protected override void OnStop()
        {
            try
            {
                _enodeConfiguration.ShutdownEQueue();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
        private void CreateECommonConfiguration()
        {
            _baseConfiguration = Configuration
                .Create()
                .UseAutofac()
                .RegisterCommonComponents()
                .UseLog4Net()
                .UseJsonNet();
        }
        private void InitializeENode()
        {
            string dbConfig = System.Configuration.ConfigurationManager.ConnectionStrings["IntDbConn"].ConnectionString;

            var assemblies = new[]
            {
                Assembly.Load("Int.AC"),
                Assembly.Load("Int.AC.ReadModel"),
                Assembly.Load("Int.PM"),
                Assembly.Load("Int.PM.ReadModel")
            };

            var setting = new ConfigurationSetting()
            {
                SqlServerDefaultConnectionString = dbConfig
            };

            _enodeConfiguration = _baseConfiguration
                .CreateENode(setting)
                .RegisterENodeComponents()
                .RegisterBusinessComponents(assemblies)
                .UseSqlServerEventPublishInfoStore()
                .UseSqlServerEventHandleInfoStore()
                .SetProviders()
                .UseEQueue()
                .InitializeBusinessAssemblies(assemblies);
        }
    }
}
