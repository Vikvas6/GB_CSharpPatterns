using Asteroids.Object_Pool;
using UnityEngine;


namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        public void InvokeReturnToPool(float lifeTime)
        {
            Invoke(nameof(ReturnToPool), lifeTime);
        }

        private void ReturnToPool()
        {
            ServiceLocator.Resolve<BulletPool>().ReturnToPool(transform);
        }
    }
}
