using UnityEngine;

namespace Asteroids
{
    internal class DamageController : IInteractable
    {
        private Player _player;
        private float _hp;

        public DamageController(Player player, float hp)
        {
            _player = player;
            _hp = hp;
        }

        public void Interact()
        {
            if (_hp <= 0)
            {
                GameObject.Destroy(_player.gameObject);
            }

            _hp--;
        }
    }
}