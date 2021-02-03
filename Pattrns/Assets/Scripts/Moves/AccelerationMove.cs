using UnityEngine;


namespace Asteroids
{
    internal sealed class AccelerationMove : MoveTransform
    {

        #region Fields

        private readonly float _acceleration;

        #endregion

        #region Contructor

        public AccelerationMove(Transform transform, float speed, float acceleration) : base(transform, speed)
        {
            _acceleration = acceleration;
        }

        #endregion

        #region Methods

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }

        #endregion
    }
}