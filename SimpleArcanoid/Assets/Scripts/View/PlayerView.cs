using SimpleArcanoid.ViewModel;
using UnityEngine;


namespace SimpleArcanoid.View
{
    public class PlayerView : MonoBehaviour
    {
        private IPlayerViewModel _player;
        
        public void Init(IPlayerViewModel player)
        {
            _player = player;
            _player.OnMove += Move;
        }

        private void Move(Vector3 position)
        {
            gameObject.transform.position = position;
        }
    }
}
