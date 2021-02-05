using UnityEngine;


namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        #region Fields

        private readonly Transform _transform;

        #endregion

        #region Properties

        public float Speed { get; protected set; }

        #endregion

        #region Contructor

        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }

        #endregion

        #region Methods

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _transform.position += _transform.up * (vertical * speed) + _transform.right * (horizontal * speed);
        }

        #endregion
    }
}