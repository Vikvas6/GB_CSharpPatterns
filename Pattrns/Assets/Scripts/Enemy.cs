using System;
using Asteroids.Object_Pool;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour, IUpdatable, IMove
    {
        public static IEnemyFactory Factory;
        private Transform _rotPool;
        private Health _health;
        private Vector3 _move;
        private int _angle;

        public virtual float Speed => 0;

        private void Start()
        {
            _angle = Random.Range(0, 90);
        }

        public Health Health
        {
            get
            {
                if (_health.Current <= 0.0f)
                {
                    ReturnToPool();
                }

                return _health;
            }
            protected set => _health = value;
        }

        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_ENEMIES);
                    _rotPool = find == null ? null : find.transform;
                }

                return _rotPool;
            }
        }

        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.Health = hp;
            return enemy;
        }

        public static EnemyBattleship CreateBattleshipEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<EnemyBattleship>("Enemy/Battleship"));
            enemy.SetHealth(hp);
            return enemy;
        }

        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);

            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }

        public void UpdateTick()
        {
            Move((float)Math.Cos(_angle), (float)Math.Sin(_angle), Time.deltaTime);
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            transform.localPosition += _move;
        }
    }
}
