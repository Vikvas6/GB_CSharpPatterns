using UnityEngine;


namespace Asteroids
{
    public class ModificationScope : ModificationWeapon
    {
        private readonly IScope _scope;
        private readonly Vector3 _scopePosition;
        private Transform _barrelPositionOld;
        private GameObject _scopeGO;

        public ModificationScope(IScope scope, Vector3 scopePosition)
        {
            _scope = scope;
            _scopePosition = scopePosition;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            _scopeGO = Object.Instantiate(_scope.ScopeInstance, _scopePosition, Quaternion.identity);
            _barrelPositionOld = weapon.GetBarrelPosition();
            weapon.SetBarrelPosition(_scope.BarrelPositionScope);
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon)
        {
            weapon.SetBarrelPosition(_barrelPositionOld);
            GameObject.Destroy(_scopeGO);
            return weapon;
        }
    }
}
