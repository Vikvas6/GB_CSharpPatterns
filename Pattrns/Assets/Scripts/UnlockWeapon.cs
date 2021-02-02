namespace Asteroids
{
    public class UnlockWeapon
    {
        public bool IsUnlock { get; set; }

        public UnlockWeapon(bool isUnlock)
        {
            IsUnlock = isUnlock;
        }

        public void UnlockWeaponAction()
        {
            IsUnlock = true;
        }
    }
}
