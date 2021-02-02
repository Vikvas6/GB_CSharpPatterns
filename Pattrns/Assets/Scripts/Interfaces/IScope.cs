using UnityEngine;


namespace Asteroids
{
    public interface IScope
    {
        float ZoomWithScope { get; }
        Transform BarrelPositionScope { get; }
        GameObject ScopeInstance { get; }
    }
}