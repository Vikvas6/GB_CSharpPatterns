namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
    }
}
