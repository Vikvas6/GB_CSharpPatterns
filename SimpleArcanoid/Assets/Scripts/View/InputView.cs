using SimpleArcanoid.ViewModel;
using UnityEngine;


namespace SimpleArcanoid.View
{
    public class InputView : IUpdatable
    {
        private IPlayerViewModel _playerViewModel;
        private IBallViewModel _ballViewModel;
        private IPauseViewModel _pauseViewModel;

        public InputView(IPlayerViewModel playerViewModel, IBallViewModel ballViewModel, IPauseViewModel pauseViewModel)
        {
            _playerViewModel = playerViewModel;
            _ballViewModel = ballViewModel;
            _pauseViewModel = pauseViewModel;
        }

        public void UpdateTick()
        {
            _playerViewModel.Move(Input.GetAxis("Horizontal"));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _ballViewModel.Activate();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pauseViewModel.Pause();
            }
        }
    }
}
