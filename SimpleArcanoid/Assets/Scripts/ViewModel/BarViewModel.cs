using System;
using SimpleArcanoid.Model;
using UnityEngine;


namespace SimpleArcanoid.ViewModel
{
    public class BarViewModel : IBarViewModel
    {
        private readonly IBarModel _barModel;
        
        public event Action OnInteract;
        public Vector3 GetPosition()
        {
            return _barModel.Position;
        }

        public BarViewModel(IBarModel barModel)
        {
            _barModel = barModel;
        }
        
        public void Interact()
        {
            _barModel.Active = false;
            OnInteract?.Invoke();
        }
    }
}
