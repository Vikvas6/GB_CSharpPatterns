using System;
using UnityEngine;


namespace SimpleArcanoid.ViewModel
{
    public interface IBallViewModel
    {
        void Interact(Collision2D other);
        void Activate();
        void CheckBallFall();
        void Move(Vector3 position);

        event Action<Vector3> OnMove;
        event Action<Vector3> OnActivate;
        event Action OnBallFall;
    }
}
