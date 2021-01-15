using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public class Player : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private float _force;
        
        private DamageController _damageController;
        private FireController _fireController;
        private InputController _inputController;

        private List<IUpdatable> _updatables = new List<IUpdatable>();
        private List<IInteractable> _interactables = new List<IInteractable>();

        #endregion

        #region UnityMethods

        private void Start()
        {
            new InitializeController(this, _hp, Camera.main, _speed, _acceleration, _bullet, _barrel, _force);
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

        #endregion
        
    }
    
}