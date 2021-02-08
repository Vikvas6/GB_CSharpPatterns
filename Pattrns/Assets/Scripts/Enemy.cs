using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Asteroids.Iterator;
using Asteroids.Object_Pool;
using Asteroids.Observer;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour, IUpdatable, IMove, IDestroyable, IEnemy
    {
        public static IEnemyFactory Factory;
        
        protected MessageBroker.MessageBroker _messageBroker;
        protected List<IAbility> _abilities;
        
        private Transform _rotPool;
        private Health _health;
        private Vector3 _move;
        private int _angle;

        public virtual float Speed => 0;

        private List<IInteractable> _interactables = new List<IInteractable>();

        private void Start()
        {
            Init();
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

        public static Asteroid CreateAsteroidEnemy(Health hp, MessageBroker.MessageBroker messageBroker, HitListener hitListener)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.SetUpCommonEnemy(hp, messageBroker, hitListener);
            return enemy;
        }

        public static EnemyBattleship CreateBattleshipEnemy(Health hp, MessageBroker.MessageBroker messageBroker, HitListener hitListener)
        {
            var enemy = Instantiate(Resources.Load<EnemyBattleship>("Enemy/Battleship"));
            enemy.SetUpCommonEnemy(hp, messageBroker, hitListener);
            return enemy;
        }

        private void SetUpCommonEnemy(Health hp, MessageBroker.MessageBroker messageBroker, HitListener hitListener)
        {
            Health = hp;
            _messageBroker = messageBroker;
            DamageController damageController = new DamageController(this, this.Health.Max);
            hitListener.Add(damageController);
            AddInteractable(damageController);
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

        //NOT DRY - TOO WET
        public void AddInteractable(IInteractable interactable)
        {
            _interactables.Add(interactable);
        }

        
        private void OnCollisionEnter2D(Collision2D other)
        {
            for (int i = 0; i < _interactables.Count; i++)
            {
                _interactables[i].Interact();
            }
        }

        public void SelfDestroy()
        {
            foreach (var onDeathAbility in this.GetAbility().Take(1))
            {
                _messageBroker.ProduceMessage("On death: " + onDeathAbility.ToString());
            }
            ProduceDestroyMessage();
            ReturnToPool();
        }

        protected virtual void ProduceDestroyMessage()
        {
            _messageBroker.ProduceMessage("Enemy was destroyed");
        }

        public IAbility this[int index] => _abilities[index];

        public string this[Target index]
        {
            get
            {
                var ability = _abilities.FirstOrDefault(a => a.Target == index);
                return ability == null ? "Not supported" : ability.ToString();
            }
        }

        public int MaxDamage => _abilities.Select(a => a.Damage).Max();
        
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _abilities.Count; i++)
            {
                yield return _abilities[i];
            }
        }

        public IEnumerable<IAbility> GetAbility()
        {
            while (true)
            {
                yield return _abilities[Random.Range(0, _abilities.Count)];
            }
        }

        public IEnumerable<IAbility> GetAbility(DamageType index)
        {
            foreach (IAbility ability in _abilities)
            {
                if (ability.DamageType == index)
                {
                    yield return ability;
                }
            }
        }

        protected virtual void Init()
        {
            _angle = Random.Range(0, 90);
            _abilities = new List<IAbility>();
        }
    }
}
