using UnityEngine;


namespace Asteroids
{
    public class Ammo : IAmmunition
    {
        public Rigidbody BulletInstance { get; }
        public float TimeToDestroy { get; }

        public Ammo(Rigidbody bulletInstance, float timeToDestroy)
        {
            BulletInstance = bulletInstance;
            TimeToDestroy = timeToDestroy;
        }
    }
}
