using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Observer;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;


namespace Asteroids.Object_Pool
{
    public class EnemyPool
    {
        private readonly Dictionary<string, HashSet<Enemy>> _enemyPool;
        private readonly MessageBroker.MessageBroker _messageBroker;
        private readonly HitListener _messageBrokerHitListener;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public EnemyPool(int capacityPool, MessageBroker.MessageBroker messageBroker)
        {
            _enemyPool = new Dictionary<string, HashSet<Enemy>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_ENEMIES).transform;
            }

            _messageBroker = messageBroker;
            _messageBrokerHitListener = new HitListener(_messageBroker);
        }

        public Enemy GetEnemy(string type)
        {
            Enemy result;
            switch (type)
            {
                case "Asteroid":
                    result = GetAsteroid(GetListEnemies(type));
                    break;
                case "Battleship":
                    result = GetBattleship(GetListEnemies(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }

            return result;
        }

        public Enemy GetRandomEnemy()
        {
            return GetEnemy(new Random().Next(1, 3) == 1 ? "Asteroid" : "Battleship");
        }

        private HashSet<Enemy> GetListEnemies(string type)
        {
            return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<Enemy>();
        }

        private Enemy GetAsteroid(HashSet<Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null)
            {
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Enemy.CreateAsteroidEnemy(new Health(2.0f, 2.0f), _messageBroker, _messageBrokerHitListener);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }

                GetAsteroid(enemies);
            }
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }

        private Enemy GetBattleship(HashSet<Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null)
            {
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Enemy.CreateBattleshipEnemy(new Health(1.0f, 1.0f), _messageBroker, _messageBrokerHitListener);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }

                GetBattleship(enemies);
            }
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }

        private void ReturnToPool(Transform transform)
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
