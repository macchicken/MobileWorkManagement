using ECommon.Components;
using ECommon.Extensions;
using ENode.Commanding;
using ENode.Configurations;
using ENode.Domain;
using ENode.EQueue;
using ENode.Eventing;
using ENode.Infrastructure;
using EQueue.Configurations;
using Int.CommandService.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.CommandService
{
    public static class ENodeExtensions
    {
        private static CommandConsumer _commandConsumer;
        private static EventPublisher _eventPublisher;

        public static ENodeConfiguration SetProviders(this ENodeConfiguration enodeConfiguration)
        {
            var configuration = enodeConfiguration.GetCommonConfiguration();
            configuration.SetDefault<ITopicProvider<ICommand>, CommandTopicProvider>();
            configuration.SetDefault<ITypeCodeProvider<ICommand>, CommandTypeCodeProvider>();
            configuration.SetDefault<ITypeCodeProvider<IAggregateRoot>, AggregateRootTypeCodeProvider>();
            configuration.SetDefault<ITopicProvider<IEvent>, EventTopicProvider>();
            return enodeConfiguration;
        }

        public static ENodeConfiguration UseEQueue(this ENodeConfiguration enodeConfiguration)
        {
            var configuration = enodeConfiguration.GetCommonConfiguration();

            configuration.RegisterEQueueComponents();

            _eventPublisher = new EventPublisher();

            configuration.SetDefault<IPublisher<EventStream>, EventPublisher>(_eventPublisher);
            configuration.SetDefault<IPublisher<DomainEventStream>, EventPublisher>(_eventPublisher);
            configuration.SetDefault<IPublisher<IEvent>, EventPublisher>(_eventPublisher);

            _commandConsumer = new CommandConsumer();
            ObjectContainer.Resolve<ITopicProvider<ICommand>>().GetAllTopics().ForEach(topic => _commandConsumer.Subscribe(topic));

            return enodeConfiguration;
        }
        public static ENodeConfiguration StartEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _commandConsumer.Start();
            _eventPublisher.Start();
            return enodeConfiguration;
        }
        public static ENodeConfiguration ShutdownEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _commandConsumer.Shutdown();
            _eventPublisher.Shutdown();
            return enodeConfiguration;
        }
    }
}
