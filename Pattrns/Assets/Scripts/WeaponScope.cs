using UnityEngine;


namespace Asteroids
{
    public class WeaponScope : IScope
    {
        public float ZoomWithScope { get; }
        public Transform BarrelPositionScope { get; }
        public GameObject ScopeInstance { get; }
        
        public WeaponScope(float zoomWithScope, Transform barrelPositionScope, GameObject scopeInstance)
        {
            ZoomWithScope = zoomWithScope;
            BarrelPositionScope = barrelPositionScope;
            ScopeInstance = scopeInstance;
        }
    }
}
