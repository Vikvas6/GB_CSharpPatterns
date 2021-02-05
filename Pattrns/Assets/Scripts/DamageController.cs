using UnityEngine;

namespace Asteroids
{
    internal class DamageController : IInteractable
    {
        private IDestroyable _target;
        private float _hp;

        public DamageController(IDestroyable target, float hp)
        {
            _target = target;
            _hp = hp;
        }

        public void Interact()
        {
            if (_hp <= 0)
            {
                _target.SelfDestroy();
            }

            _hp--;
        }
    }
}