using System;
using System.Collections.Generic;
using Asteroids.ChainOfResponsibility;
using Asteroids.Command;
using Asteroids.Interpreter;
using Asteroids.Memnto;
using Asteroids.MessageBroker;
using Asteroids.Object_Pool;
using UnityEngine;
using UnityEngine.UI;


namespace Asteroids
{
    public class Player : MonoBehaviour, ISerializationCallbackReceiver, IDestroyable
    {
        #region Fields

        [SerializeField] private Bullet _bullet = null;
        [SerializeField] private Transform _barrel = null;

        [SerializeField] private InterpreterWindow _interpreterWindow = null;
        [SerializeField] private InfoWindow _infoWindow = null;
        [SerializeField] private Text _messagesText = null;
        
        [SerializeField] private float _speed = 5;
        [SerializeField] private float _acceleration = 10;
        [SerializeField] private float _hp = 5;
        [SerializeField] private float _force = 100;
        [SerializeField] private float _lifeTime = 2;
        [SerializeField] private int _poolsCapacity = 10;
        [SerializeField] private int _spawnTime = 3;
        [SerializeField] private int _enemyDistance = 3;

        private MessageBroker.MessageBroker _messageBroker;
        private List<IUpdatable> _updatables = new List<IUpdatable>();
        private List<IInteractable> _interactables = new List<IInteractable>();
        private List<IFixedUpdatable> _fixedUpdatables = new List<IFixedUpdatable>();

        //https://docs.unity3d.com/ScriptReference/ISerializationCallbackReceiver.html
        public Dictionary<int, string> DictionaryToShowInUnity = new Dictionary<int, string>();
        
        public List<int> _keys = new List<int> { 3, 4, 5 };
        public List<string> _values = new List<string> { "I", "Love", "Unity" };

        private CreateEnemyFacade _enemyFacade;

        #endregion

        #region Properties

        public float Hp
        {
            get => _hp;
            set => _hp = value;
        }

        #endregion

        #region UnityMethods

        private void Start()
        {
            _messageBroker = new MessageBroker.MessageBroker();
            _messageBroker.AddConsumer(new ScreenMessagesConsumer(_messagesText));
            
            ServiceLocator.SetService(new EnemyPool(_poolsCapacity, _messageBroker));
            ServiceLocator.SetService(new BulletPool(_poolsCapacity, _bullet));
            
            new InitializeController(this, _hp, Camera.main, _speed, _acceleration, _barrel, _lifeTime, _interpreterWindow, _infoWindow);

            InvokeRepeating(nameof(CreateEnemy), 0.0f, _spawnTime);

            _enemyFacade = new CreateEnemyFacade();

            var root = new PlayerModifier(this);
            root.Add(new BulletForceModifier(this, 5));
            root.Add(new HPModifier(this, 50));
            root.Handle();
        }

        private void Update()
        {
            for (int i = 0; i < _updatables.Count; i++)
            {
                _updatables[i].UpdateTick();
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdatables.Count; i++)
            {
                _fixedUpdatables[i].FixedUpdateTick();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
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

        public void AddFixedUpdatables(IFixedUpdatable fixedUpdatable)
        {
            _fixedUpdatables.Add(fixedUpdatable);
        }

        public void AddInteractable(IInteractable interactable)
        {
            _interactables.Add(interactable);
        }

        private void CreateEnemy()
        {
            var enemy = _enemyFacade.CreateEnemy(transform, _enemyDistance);
            AddUpdatables(enemy);
        }

        #endregion

        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();

            foreach (var kvp in DictionaryToShowInUnity)
            {
                _keys.Add(kvp.Key);
                _values.Add(kvp.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            DictionaryToShowInUnity = new Dictionary<int, string>();

            for (int i = 0; i < Math.Max(_keys.Count, _values.Count); i++)
            {
                int newKey = 0;
                string newValue = "";
                if (i < _keys.Count)
                {
                    newKey = _keys[i];
                }

                if (i < _values.Count)
                {
                    newValue = _values[i];
                }
                DictionaryToShowInUnity.Add(newKey, newValue);
            }
        }

        private void OnGUI()
        {
            foreach (var kvp in DictionaryToShowInUnity)
                GUILayout.Label("Key: " + kvp.Key + " value: " + kvp.Value);
        }

        public void SelfDestroy()
        {
            Destroy(gameObject);
        }

        public float GetForce()
        {
            return _force;
        }

        public void MultiplyForce(int multiplier)
        {
            _force *= multiplier;
        }
    }
    
}