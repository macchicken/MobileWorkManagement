using System;
using System.ServiceProcess;
using ECommon.Autofac;
using ECommon.Components;
using ECommon.Configurations;
using ECommon.JsonNet;
using ECommon.Log4Net;
using ECommon.Logging;
using EQueue.Broker;
using EQueue.Configurations;

namespace Int.BrokerService
{
    public partial class Service1 : ServiceBase
    {
        private ILogger _logger;
        private Configuration _ecommonConfiguration;
        private BrokerController _broker;

        public Service1()
        {
            InitializeComponent();
            InitializeECommon();

            _logger = ObjectContainer.Resolve<ILoggerFactory>().Create(GetType().FullName);
            _logger.Info("ECommon initialized.");

            try
            {
                InitializeEQueue();
                _logger.Info("EQueue initialized.");
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
                _broker.Start();
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
                if (_broker != null)
                {
                    _broker.Shutdown();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        private void InitializeECommon()
        {
            _ecommonConfiguration = Configuration
                .Create()
                .UseAutofac()
                .RegisterCommonComponents()
                .UseLog4Net()
                .UseJsonNet();
        }
        private void InitializeEQueue()
        {
            string dbConfig = System.Configuration.ConfigurationManager.ConnectionStrings["IntDbConn"].ConnectionString;

            var messageStoreSetting = new SqlServerMessageStoreSetting
            {
                ConnectionString = dbConfig,
                DeleteMessageHourOfDay = -1
            };
            var offsetManagerSetting = new SqlServerOffsetManagerSetting
            {
                ConnectionString = dbConfig
            };

            _ecommonConfiguration
                .RegisterEQueueComponents()
                .UseSqlServerMessageStore(messageStoreSetting)
                .UseSqlServerOffsetManager(offsetManagerSetting);

            _broker = new BrokerController();
        }
    }
}
