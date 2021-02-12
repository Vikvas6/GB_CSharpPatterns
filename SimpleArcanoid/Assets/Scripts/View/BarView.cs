using SimpleArcanoid.ViewModel;
using UnityEngine;


namespace SimpleArcanoid.View
{
    public class BarView : MonoBehaviour
    {
        private IBarViewModel _barViewModel;

        public void Init(IBarViewModel barViewModel)
        {
            _barViewModel = barViewModel;
            gameObject.transform.position = _barViewModel.GetPosition();
            _barViewModel.OnInteract += OnInteract;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            _barViewModel.Interact();
        }

        private void OnInteract()
        {
            gameObject.SetActive(false);
        }
    }
}
