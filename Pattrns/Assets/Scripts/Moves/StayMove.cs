using UnityEngine;


namespace Asteroids
{
    public class StayMove : IMove
    {
        public float Speed { get; }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            Debug.Log("Stay!");
        }
    }
}