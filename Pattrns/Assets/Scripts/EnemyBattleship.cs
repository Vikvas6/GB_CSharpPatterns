using Asteroids.Iterator;

namespace Asteroids
{
    public class EnemyBattleship : Enemy
    {
        public override float Speed => 2;
        
        public void SetHealth(Health hp)
        {
            Health = hp;
        }

        protected override void ProduceDestroyMessage()
        {
            _messageBroker.ProduceMessage("Battleship was destroyed!");
        }

        protected override void Init()
        {
            base.Init();
            _abilities.Add(new Ability("Blaster Strike", 100, Target.Unit, DamageType.Magical));
            _abilities.Add(new Ability("Energy Shield", 250, Target.Passive, DamageType.None));
            _abilities.Add(new Ability("Stasis Field", 50, Target.Autocast, DamageType.Magical));
            _abilities.Add(new Ability("Ram", 500, Target.Unit, DamageType.Pure));
        }

        public override string ToString()
        {
            return "Battleship";
        }
    }
}
