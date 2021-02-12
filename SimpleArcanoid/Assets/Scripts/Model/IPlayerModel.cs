using UnityEngine;

namespace SimpleArcanoid.Model
{
    public interface IPlayerModel
    {
        Vector3 Position { get; set; }
        float Velocity { get; }
    }
}
