using System;
using UnityEngine;


namespace SimpleArcanoid.ViewModel
{
    public interface IBarViewModel
    {
        void Interact();
        event Action OnInteract;
        Vector3 GetPosition();
    }
}
