using UnityEngine;


namespace Asteroids
{
    internal sealed class Ship : IMove, IRotation
    {
        #region Fields

        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;

        #endregion

        #region Properties

        public float Speed => _moveImplementation.Speed;

        #endregion

        #region Contructor

        public Ship(IMove moveImplementation, IRotation rotationImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
        }

        #endregion

        #region Methods

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

        #endregion
    }
}