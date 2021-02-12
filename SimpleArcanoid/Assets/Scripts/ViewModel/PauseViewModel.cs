using System;
using SimpleArcanoid.Model;


namespace SimpleArcanoid.ViewModel
{
    public class PauseViewModel : IPauseViewModel
    {
        private IPauseModel _pauseModel;

        public PauseViewModel(IPauseModel pauseModel)
        {
            _pauseModel = pauseModel;
        }
        
        public void SetPause(bool pause)
        {
            _pauseModel.OnPause = pause;
            OnPauseChange?.Invoke(pause);
        }

        public void Pause()
        {
            _pauseModel.OnPause = !_pauseModel.OnPause;
            OnPauseChange?.Invoke(_pauseModel.OnPause);
        }

        public event Action<bool> OnPauseChange;
    }
}
