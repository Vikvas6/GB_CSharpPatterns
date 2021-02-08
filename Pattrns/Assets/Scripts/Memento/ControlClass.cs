using UnityEngine;


namespace Asteroids.Memnto
{
    public class ControlClass : MonoBehaviour, IUpdatable, IFixedUpdatable
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _recordTime;

        private TimeBody _timeBody;
        
        public void Start()
        {
            _timeBody = new TimeBody(transform, _recordTime);
            _player.AddUpdatables(this);
            _player.AddFixedUpdatables(this);
        }

        public void FixedUpdateTick()
        {
            _timeBody.FixedUpdateTick();
        }

        public void UpdateTick()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _timeBody.StartRewind();
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                _timeBody.StopRewind();
            }
        }
    }
}
