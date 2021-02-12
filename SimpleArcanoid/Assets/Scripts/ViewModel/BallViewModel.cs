using System;
using SimpleArcanoid.Model;
using UnityEngine;


namespace SimpleArcanoid.ViewModel
{
    public class BallViewModel : IBallViewModel
    {
        private IBallModel _ballModel;
        private Vector3 _ballInitialForce;
        private IPlayerViewModel _playerViewModel;

        public event Action<Vector3> OnActivate;
        public event Action<Vector3> OnMove;
        public event Action OnBallFall;

        public BallViewModel(IBallModel ballModel, Vector3 ballInitialForce, IPlayerViewModel playerViewModel)
        {
            _ballModel = ballModel;
            _ballInitialForce = ballInitialForce;
            _playerViewModel = playerViewModel;
            _playerViewModel.OnMove += MoveWithPlayer;
        }

        public void Activate()
        {
            if (!_ballModel.Active)
            {
                _playerViewModel.OnMove -= MoveWithPlayer;
                _ballModel.Active = !_ballModel.Active;
                OnActivate?.Invoke(_ballInitialForce);
            }
        }

        public void Interact(Collision2D other)
        {
            
        }

        private void MoveWithPlayer(Vector3 playerPosition)
        {
            playerPosition.y += 0.5f;
            OnMove?.Invoke(playerPosition);
        }

        public void Move(Vector3 position)
        {
            _ballModel.Position = position;
        }

        public void CheckBallFall()
        {
            if (_ballModel.Active && _ballModel.Position.y < -5)
            {
                OnBallFall?.Invoke();
            }
        }
    }
}
