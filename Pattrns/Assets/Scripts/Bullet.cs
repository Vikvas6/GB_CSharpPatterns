using System.Collections;
using System.Collections.Generic;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    public class Bullet : MonoBehaviour
    {
        private BulletPool _bulletPool;
        
        public void InvokeReturnToPool(float lifeTime, BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
            Invoke(nameof(ReturnToPool), lifeTime);
        }

        private void ReturnToPool()
        {
            _bulletPool.ReturnToPool(transform);
        }
    }
}
