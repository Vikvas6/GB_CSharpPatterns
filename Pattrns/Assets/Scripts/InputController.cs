using UnityEngine;


namespace Asteroids
{
    public class InputController : IUpdatable
    {
        #region Delegates

        public delegate void InputAction();
        public delegate void RotateInputAction(Vector3 direction);
        public delegate void AxisInputAction(float horizontal, float vertical, float deltaTime);

        #endregion

        #region Events

        public event InputAction OnFire1;
        public event InputAction OnLeftShiftDown;
        public event InputAction OnLeftShiftUp;
        public event AxisInputAction OnAxisInput;
        public event RotateInputAction OnRotate;

        #endregion

        #region Fields

        private Camera _camera;
        private GameObject _player;

        #endregion

        #region Contructor

        public InputController(Camera camera, GameObject player)
        {
            _camera = camera;
            _player = player;
        }

        #endregion

        #region IUpdatable

        public void UpdateTick()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_player.transform.position);
            OnRotate(direction);
            
            OnAxisInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                OnLeftShiftDown?.Invoke();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                OnLeftShiftUp?.Invoke();
            }
            
            if (Input.GetButtonDown("Fire1"))
            {
                OnFire1?.Invoke();
            }
        }

        #endregion
    }
}