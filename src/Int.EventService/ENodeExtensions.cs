using ECommon.Components;
using ECommon.Extensions;
using ENode.Configurations;
using ENode.EQueue;
using ENode.Eventing;
using ENode.Infrastructure;
using EQueue.Configurations;
using Int.EventService.Providers;

namespace Int.EventService
{
    public static class ENodeExtensions
    {
        private static EventConsumer _eventConsumer;

        public static ENodeConfiguration SetProviders(this ENodeConfiguration enodeConfiguration)
        {
            var configuration = enodeConfiguration.GetCommonConfiguration();
            configuration.SetDefault<ITopicProvider<IEvent>, EventTopicProvider>();
            configuration.SetDefault<ITypeCodeProvider<IEvent>, EventTypeCodeProvider>();
            configuration.SetDefault<ITypeCodeProvider<IEventHandler>, EventHandlerTypeCodeProvider>();
            return enodeConfiguration;
        }
        public static ENodeConfiguration UseEQueue(this ENodeConfiguration enodeConfiguration)
        {

            var configuration = enodeConfiguration.GetCommonConfiguration();

            configuration.RegisterEQueueComponents();

            _eventConsumer = new EventConsumer();

            ObjectContainer.Resolve<ITopicProvider<IEvent>>().GetAllTopics().ForEach(topic => _eventConsumer.Subscribe(topic));

            return enodeConfiguration;
        }
        public static ENodeConfiguration StartEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _eventConsumer.Start();
            return enodeConfiguration;
        }
        public static ENodeConfiguration ShutdownEQueue(this ENodeConfiguration enodeConfiguration)
        {
            _eventConsumer.Shutdown();
            return enodeConfiguration;
        }
    }
}
