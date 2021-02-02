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

            FireController fireController = new FireController(barrel, force, lifeTime);
            UnlockWeapon unlockWeapon = new UnlockWeapon(true);
            FireControllerProxy fireControllerProxy = new FireControllerProxy(fireController, unlockWeapon);
            inputController.OnFire1 += fireControllerProxy.Fire;
            inputController.OnFire2 += unlockWeapon.UnlockWeaponAction;
            
            
            inputController.OnRotate += ship.Rotation;
            player.AddUpdatables(inputController);
        }
        
        #endregion
    }

}