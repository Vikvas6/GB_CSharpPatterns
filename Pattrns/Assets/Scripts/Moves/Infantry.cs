using UnityEngine;


namespace Asteroids
{
    public class Infantry : IMove
    {
        public float Speed { get; }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            Debug.Log("Infantry");
        }
    }
}
