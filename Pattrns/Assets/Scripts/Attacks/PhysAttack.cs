using UnityEngine;

namespace Asteroids
{
    public class PhysAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Physical attack");
        }
    }
}