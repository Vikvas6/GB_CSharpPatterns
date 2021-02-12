using UnityEngine;


namespace SimpleArcanoid.Model
{
    public class PlayerModel : IPlayerModel
    {
        public Vector3 Position { get; set; }
        public float Velocity { get; }

        public PlayerModel(float velocity)
        {
            Velocity = velocity;
            Position = new Vector3(0.0f, -4.67f, 0.0f);
        }
    }
}
