using System;
using Asteroids.Observer;


namespace Asteroids
{
    internal class DamageController : IInteractable, IHit
    {
        private IDestroyable _target;
        private float _hp;

        public event Action<string, float> OnHitChange = delegate(string s, float f) {  };
        
        public DamageController(IDestroyable target, float hp)
        {
            _target = target;
            _hp = hp;
        }

        public void Interact()
        {
            Hit(1.0f);
        }
        
        public void Hit(float damage)
        {
            OnHitChange.Invoke(_target.ToString(), damage);
            _hp -= damage;
            
            if (_hp <= 0)
            {
                _target.SelfDestroy();
            }
        }
    }
}