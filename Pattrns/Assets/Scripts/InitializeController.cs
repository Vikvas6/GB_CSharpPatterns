using UnityEngine;


namespace Asteroids
{
    #region Contructor

    internal sealed class InitializeController
    {
        public InitializeController(Player player, float hp, Camera camera, float speed, float acceleration, Rigidbody2D bullet, Transform barrel, float force)
        {
            player.AddInteractable(new DamageController(player, hp));
            
            var moveTransform = new AccelerationMove(player.transform, speed, acceleration);
            var rotation = new RotationShip(player.transform);
            var ship = new Ship(moveTransform, rotation);
            var inputController = new InputController(camera, player.gameObject);
            inputController.OnAxisInput += ship.Move;
            inputController.OnLeftShiftDown += ship.AddAcceleration;
            inputController.OnLeftShiftUp += ship.RemoveAcceleration;
            inputController.OnFire1 += new FireController(bullet, barrel, force).Fire;
            inputController.OnRotate += ship.Rotation;
            player.AddUpdatables(inputController);
        }
    }

    #endregion
}