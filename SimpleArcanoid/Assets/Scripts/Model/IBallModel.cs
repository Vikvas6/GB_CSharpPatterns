using UnityEngine;

namespace SimpleArcanoid.Model
{
    public interface IBallModel
    {
        Vector3 Position { get; set; }
        float Velocity { get; }
        bool Active { get; set; }
    }
}
