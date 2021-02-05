using System.Collections.Generic;


namespace Asteroids.MessageBroker
{
    public class MessageBroker
    {
        private List<IConsumer> _consumers = new List<IConsumer>();

        public void AddConsumer(IConsumer consumer)
        {
            _consumers.Add(consumer);
        }

        public void ProduceMessage(string message)
        {
            foreach (var consumer in _consumers)
            {
                consumer.ConsumeMessage(message);
            }
        }
    }
}
