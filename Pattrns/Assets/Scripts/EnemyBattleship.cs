namespace Asteroids
{
    public class EnemyBattleship : Enemy
    {
        public override float Speed => 2;
        
        public void SetHealth(Health hp)
        {
            Health = hp;
        }
    }
}
