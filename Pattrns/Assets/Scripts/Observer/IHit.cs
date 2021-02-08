using System;


namespace Asteroids.Observer
{
    public interface IHit
    {
        event Action<string, float> OnHitChange;
        void Hit(float damage);
    }
}
