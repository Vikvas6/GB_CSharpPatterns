using SimpleArcanoid.ViewModel;
using UnityEngine;


namespace SimpleArcanoid.View
{
    public class PauseView : MonoBehaviour
    {
        private IPauseViewModel _pauseViewModel;

        public void Init(IPauseViewModel pauseViewModel)
        {
            _pauseViewModel = pauseViewModel;
            _pauseViewModel.OnPauseChange += OnPauseChange;
        }

        public void HidePauseMenu()
        {
            _pauseViewModel.Pause();
        }

        public void OnPauseChange(bool pause)
        {
            Pause(pause);
            gameObject.SetActive(pause);
        }

        public void Pause(bool pause)
        {
            if (pause)
            {
                Time.timeScale = 0;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.visible = false;
            }
        }
    }
}
