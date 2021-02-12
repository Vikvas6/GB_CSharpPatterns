using System;
using UnityEngine;


namespace SimpleArcanoid.ViewModel
{
    public interface IPlayerViewModel
    {
        void Move(float horizontal);
        event Action<Vector3> OnMove;
    }
}