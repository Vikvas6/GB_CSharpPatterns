using Asteroids.Object_Pool;
using UnityEngine;


namespace Asteroids
{

    internal sealed class InitializeController
    {
        #region Contructor
        
        public InitializeController(
            Player player,
            float hp,
            Camera camera,
            float speed,
            float acceleration,
            int poolsCapacity,
            Bullet bullet,
            Transform barrel,
            float force,
            float lifeTime)
        {
            player.AddInteractable(new DamageController(player, hp));
            
            var moveTransform = new AccelerationMove(player.transform, speed, acceleration);
            var rotation = new RotationShip(player.transform);
            var ship = new Ship(moveTransform, rotation);
            var inputController = new InputController(camera, player.gameObject);
            inputController.OnAxisInput += ship.Move;
            inputController.OnLeftShiftDown += ship.AddAcceleration;
            inputController.OnLeftShiftUp += ship.RemoveAcceleration;
            inputController.OnFire1 += new FireController(new BulletPool(poolsCapacity, bullet), barrel, force, lifeTime).Fire;
            inputController.OnRotate += ship.Rotation;
            player.AddUpdatables(inputController);
        }
        
        #endregion
    }

}