using System;
using System.Linq;
using ENode.Commanding;
using ENode.Configurations;
using ENode.EQueue;
using ENode.EQueue.Commanding;
using ENode.Infrastructure;
//using EQueue.Clients.Consumers;
using EQueue.Configurations;
using ECommon.Components;
using ECommon.Logging;
using ECommon.Scheduling;
using System.Threading;
using Int.MobileUI.Providers;

namespace Int.MobileUI
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

            WaitAllConsumerLoadBalanceComplete();
            return enodeConfiguration;
        }
        public static ENodeConfiguration ShutdownEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _commandResultProcessor.Shutdown();
            _commandService.Shutdown();

            return enodeConfiguration;
        }
        private static void WaitAllConsumerLoadBalanceComplete()
        {
            var logger = ObjectContainer.Resolve<ILoggerFactory>().Create(typeof(ENodeExtensions).Name);
            var scheduleService = ObjectContainer.Resolve<IScheduleService>();
            var waitHandle = new ManualResetEvent(false);
            logger.Info("Waiting for all consumer load balance complete, please wait for a moment...");
            var taskId = scheduleService.ScheduleTask("WaitAllConsumerLoadBalanceComplete", () =>
                {
                    var commandExecutedMessageConsumerAllocatedQueues = _commandResultProcessor.CommandExecutedMessageConsumer.GetCurrentQueues();
                    var domainEventHandledMessageConsumerAllocatedQueues = _commandResultProcessor.DomainEventHandledMessageConsumer.GetCurrentQueues();
                    if (commandExecutedMessageConsumerAllocatedQueues.Count()==4&&
                        domainEventHandledMessageConsumerAllocatedQueues.Count() == 4)
                    {
                        waitHandle.Set();
                    }
                }, 1000, 1000);
            waitHandle.WaitOne();
            scheduleService.ShutdownTask(taskId);
            logger.Info("All consumer load balance completed.");
        }
    }
}