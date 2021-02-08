using UnityEngine;


namespace Asteroids.Observer
{
    public class HitListener
    {
        private MessageBroker.MessageBroker _messageBroker;

        public HitListener(MessageBroker.MessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
        }
        
        public void Add(IHit value)
        {
            value.OnHitChange += ActionOnHit;
        }

        public void Remove(IHit value)
        {
            value.OnHitChange -= ActionOnHit;
        }

        private void ActionOnHit(string name, float damage)
        {
            _messageBroker.ProduceMessage($"{name} was damaged by {damage}");
        }
    }
}
