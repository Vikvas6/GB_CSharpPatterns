using System.Collections.Generic;
using UnityEngine;


namespace Asteroids.Memnto
{
    public class TimeBody
    {
        private List<PointInTime> _pointsInTime;
        private Transform _transform;
        private Rigidbody _rb;
        
        private float _recordTime;
        private bool _isRewinding;

        public TimeBody(Transform transform, float recordTime)
        {
            _transform = transform;
            _pointsInTime = new List<PointInTime>();
            _rb = _transform.GetComponent<Rigidbody>();
            _recordTime = recordTime;
        }

        public void FixedUpdateTick()
        {
            if (_isRewinding)
            {
                Rewind();
            }
            else
            {
                Record();
            }
        }

        private void Rewind()
        {
            if (_pointsInTime.Count > 1)
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                _pointsInTime.RemoveAt(0);
            }
            else
            {
                PointInTime pointInTime = _pointsInTime[0];
                _transform.position = pointInTime.Position;
                _transform.rotation = pointInTime.Rotation;
                StopRewind();
            }
        }

        private void Record()
        {
            if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedTime))
            {
                _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            }
            
            _pointsInTime.Insert(0, new PointInTime(_transform.position, _transform.rotation, _rb.velocity, _rb.angularVelocity));
        }

        public void StartRewind()
        {
            _isRewinding = true;
            _rb.isKinematic = true;
        }

        public void StopRewind()
        {
            _isRewinding = false;
            _rb.isKinematic = false;
            _rb.velocity = _pointsInTime[0].Velocity;
            _rb.angularVelocity = _pointsInTime[0].AngularVelocity;
        }
    }
}
