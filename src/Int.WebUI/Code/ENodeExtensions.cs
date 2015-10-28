using System;
using ENode.Commanding;
using ENode.Configurations;
using ENode.EQueue;
using ENode.EQueue.Commanding;
using ENode.Infrastructure;
using EQueue.Clients.Consumers;
using EQueue.Configurations;
using Int.WebUI.Providers;

namespace Int.WebUI
{
    public static class ENodeExtensions
    {
        private static CommandService _commandService;
        private static CommandResultProcessor _commandResultProcessor;

        public static ENodeConfiguration SetProviders(this ENodeConfiguration enodeConfiguration)
        {
            var configuration = enodeConfiguration.GetCommonConfiguration();
            configuration.SetDefault<ITopicProvider<ICommand>, CommandTopicProvider>();
            configuration.SetDefault<ITypeCodeProvider<ICommand>, CommandTypeCodeProvider>();
            return enodeConfiguration;
        }
        public static ENodeConfiguration UseEQueue(this ENodeConfiguration enodeConfiguration)
        {
            var configuration = enodeConfiguration.GetCommonConfiguration();

            configuration.RegisterEQueueComponents();

            _commandResultProcessor = new CommandResultProcessor();
            _commandService = new CommandService(_commandResultProcessor);

            configuration.SetDefault<ICommandService, CommandService>(_commandService);

            return enodeConfiguration;
        }
        public static ENodeConfiguration StartEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _commandService.Start();
            _commandResultProcessor.Start();
            return enodeConfiguration;
        }
    }
}