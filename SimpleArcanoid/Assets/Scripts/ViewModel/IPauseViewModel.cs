using System;


namespace SimpleArcanoid.ViewModel
{
    public interface IPauseViewModel
    {
        void SetPause(bool pause);
        void Pause();
        event Action<bool> OnPauseChange;
    }
}
