using SimpleArcanoid.ViewModel;
using UnityEngine;


namespace SimpleArcanoid.View
{
    public class BallView : MonoBehaviour, IUpdatable
    {
        private IBallViewModel _ballViewModel;
        private Vector3 _ballInitialForce;

        public void Init(IBallViewModel ballViewModel)
        {
            _ballViewModel = ballViewModel;
            
            _ballViewModel.OnMove += Move;
            _ballViewModel.OnActivate += AddInitialForce;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _ballViewModel.Interact(other);
        }

        private void Move(Vector3 position)
        {
            gameObject.transform.position = position;
            _ballViewModel.Move(position);
        }

        private void AddInitialForce(Vector3 ballInitialForce)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
        }

        public void UpdateTick()
        {
            _ballViewModel.Move(gameObject.transform.position);
            _ballViewModel.CheckBallFall();
        }
    }
}
