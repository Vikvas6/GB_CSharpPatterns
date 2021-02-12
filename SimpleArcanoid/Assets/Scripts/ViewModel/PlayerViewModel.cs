using System;
using SimpleArcanoid.Model;
using UnityEngine;


namespace SimpleArcanoid.ViewModel
{
    public class PlayerViewModel : IPlayerViewModel
    {
        private IPlayerModel _playerModel;
        private float _boundries;

        public event Action<Vector3> OnMove;

        public PlayerViewModel(IPlayerModel playerModel, float boundries)
        {
            _playerModel = playerModel;
            _boundries = boundries;
        }
        
        public void Move(float horizontal)
        {
            var position = _playerModel.Position;
            position.x += horizontal * _playerModel.Velocity;
            if (position.x > _boundries)
            {
                position.x = _boundries;
            }

            if (position.x < -_boundries)
            {
                position.x = -_boundries;
            }
            _playerModel.Position = position;
            OnMove?.Invoke(_playerModel.Position);
        }
    }
}
