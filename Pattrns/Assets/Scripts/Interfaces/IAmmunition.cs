using UnityEngine;


namespace Asteroids
{
    
    public interface IAmmunition
    {
        Rigidbody BulletInstance { get; }
        float TimeToDestroy { get; }
    }
}
