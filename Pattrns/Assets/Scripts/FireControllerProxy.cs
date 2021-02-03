using UnityEngine;
using Random = UnityEngine.Random;


namespace Asteroids
{
    public class FireControllerProxy : IFire
    {
        private readonly IFire _fireController;
        private readonly UnlockWeapon _unlockWeapon;

        public FireControllerProxy(IFire fireController, UnlockWeapon unlockWeapon)
        {
            _fireController = fireController;
            _unlockWeapon = unlockWeapon;
        }
        
        public void Fire()
        {
            if (_unlockWeapon.IsUnlock)
            {
                _fireController.Fire();
                if (Random.Range(0, 4) == 1)
                {
                    _unlockWeapon.IsUnlock = false;
                }
            }
            else
            {
                Debug.Log("Weapon is locked");
            }
        }
    }
}
