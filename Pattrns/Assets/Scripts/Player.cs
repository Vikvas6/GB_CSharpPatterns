using System;
using System.Collections.Generic;
using Asteroids.Object_Pool;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Asteroids
{
    public class Player : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _speed = 5;
        [SerializeField] private float _acceleration = 10;
        [SerializeField] private float _hp = 100;
        [SerializeField] private float _force = 100;
        [SerializeField] private float _lifeTime = 2;
        [SerializeField] private int _poolsCapacity = 10;
        [SerializeField] private int _spawnTime = 3;
        [SerializeField] private int _enemyDistance = 3;

        private List<IUpdatable> _updatables = new List<IUpdatable>();
        private List<IInteractable> _interactables = new List<IInteractable>();

        #endregion

        #region UnityMethods

        private void Start()
        {
            ServiceLocator.SetService(new EnemyPool(_poolsCapacity));
            ServiceLocator.SetService(new BulletPool(_poolsCapacity, _bullet));
            
            new InitializeController(this, _hp, Camera.main, _speed, _acceleration, _barrel, _force, _lifeTime);

            InvokeRepeating(nameof(CreateEnemy), 0.0f, _spawnTime);
        }

        private void Update()
        {
            for (int i = 0; i < _updatables.Count; i++)
            {
                _updatables[i].UpdateTick();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            print("asdf");
            for (int i = 0; i < _interactables.Count; i++)
            {
                _interactables[i].Interact();
            }
        }

        #endregion

        #region Methods

        public void AddUpdatables(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void AddInteractable(IInteractable interactable)
        {
            _interactables.Add(interactable);
        }

        private void CreateEnemy()
        {
            var enemy = ServiceLocator.Resolve<EnemyPool>().GetRandomEnemy();
            var angle = Random.Range(0, 90);
            Vector3 direction3D = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0.0f);
            enemy.transform.position = transform.localPosition + direction3D * _enemyDistance;
            enemy.gameObject.SetActive(true);
            AddUpdatables(enemy);
        }

        #endregion
        
    }
    
}