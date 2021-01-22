using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Asteroids.Object_Pool
{
    public class BulletPool
    {
        private readonly HashSet<Bullet> _bulletPool;
        private readonly int _capacityPool;
        private Transform _rootPool;
        private Bullet _bulletPrefab;

        public BulletPool(int capacityPool, Bullet bulletPrefab)
        {
            _bulletPool = new HashSet<Bullet>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_BULLETS).transform;
            }

            _bulletPrefab = bulletPrefab;
        }

        public Bullet GetBullet()
        {
            var bullet = _bulletPool.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (bullet == null)
            {
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = GameObject.Instantiate(_bulletPrefab);
                    ReturnToPool(instantiate.transform);
                    _bulletPool.Add(instantiate);
                }
            }
            bullet = _bulletPool.FirstOrDefault(a => !a.gameObject.activeSelf);
            return bullet;
        }

        public void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}
