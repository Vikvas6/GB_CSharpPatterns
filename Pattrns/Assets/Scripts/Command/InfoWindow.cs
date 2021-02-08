using UnityEngine;

namespace Asteroids.Command
{
    public class InfoWindow : MonoBehaviour, IBaseUI
    {
        public void Execute()
        {
            gameObject.SetActive(true);
        }

        public void Cancel()
        {
            gameObject.SetActive(false);
        }
    }
}
