using Asteroids.Iterator;

namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        protected override void ProduceDestroyMessage()
        {
            _messageBroker.ProduceMessage("Asteroid was destroyed!");
        }

        protected override void Init()
        {
            base.Init();
            _abilities.Add(new Ability("Stone Punch", 500, Target.Unit, DamageType.Pure));
        }
    }
}
