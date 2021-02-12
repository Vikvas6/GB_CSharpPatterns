using SimpleArcanoid.Model;
using UnityEngine;


public class BallModel : IBallModel
{
    public Vector3 Position { get; set; }
    public float Velocity { get; }
    public bool Active { get; set; }
}
