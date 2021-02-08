using Asteroids.Command;
using Asteroids.Interpreter;
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
            float lifeTime,
            InterpreterWindow interpreterWindow,
            InfoWindow infoWindow)
        {
            player.AddInteractable(new DamageController(player, hp));
            
            var moveTransform = new AccelerationMove(player.transform, speed, acceleration);
            var rotation = new RotationShip(player.transform);
            var ship = new Ship(moveTransform, rotation);

            var userInterface = new UserInterface(interpreterWindow, infoWindow);
            
            var inputController = new InputController(camera, player.gameObject);
            inputController.OnAxisInput += ship.Move;
            inputController.OnLeftShiftDown += ship.AddAcceleration;
            inputController.OnLeftShiftUp += ship.RemoveAcceleration;

            FireController fireController = new FireController(barrel, player.GetForce, lifeTime);
            UnlockWeapon unlockWeapon = new UnlockWeapon(true);
            FireControllerProxy fireControllerProxy = new FireControllerProxy(fireController, unlockWeapon);
            inputController.OnFire1 += fireControllerProxy.Fire;
            inputController.OnFire2 += unlockWeapon.UnlockWeaponAction;
            
            inputController.OnRotate += ship.Rotation;
            player.AddUpdatables(inputController);

            inputController.OnX += userInterface.RestoreStep;

            inputController.OnC += () =>
            {
                userInterface.Execute(StateUI.InfoPanel);
            };

            inputController.OnV += () =>
            {
                userInterface.Execute(StateUI.InterpreterPanel);
            };
            
            inputController.OnZ += () =>
            {
                interpreterWindow.gameObject.SetActive(!interpreterWindow.gameObject.activeSelf);
            };
        }
        
        #endregion
    }

}