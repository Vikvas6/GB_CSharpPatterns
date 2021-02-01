using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class BridgeExample : MonoBehaviour
    {
        private void Start()
        {
            var enemy1 = new EnemyBridge(new MagicalAttack(), new Infantry());
            var enemy2 = new EnemyBridge(new MagicalAttack(), new StayMove());
            var enemy3 = new EnemyBridge(new PhysAttack(), new Infantry());
            var enemy4 = new EnemyBridge(new PhysAttack(), new StayMove());
            var enemy5 = new EnemyBridge(new PhysAttack(), new MoveTransform(transform, 0.0f));
            var enemy6 = new EnemyBridge(new PhysAttack(), new AccelerationMove(transform, 0.0f, 1.0f));
        }
    }
}
