using UnityEngine;


namespace Asteroids
{
    public class ExampleWeapon : MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet = null;
        [SerializeField] private Transform _barrelPosition = null;
        [SerializeField] private AudioSource _audioSource = null;
        [SerializeField] private AudioClip _audioClip = null;

        [Header("Muffler Gun")] 
        [SerializeField] private AudioClip _audioClipMuffler = null;
        [SerializeField] private float _volumeFireOnMuffler = 0.0f;
        [SerializeField] private Transform _barrelPositionMuffler = null;
        [SerializeField] private GameObject _muffler = null;

        [Header("Scope Gun")] 
        [SerializeField] private float _zoomWithScope = 2.0f;
        [SerializeField] private Transform _barrelPositionScope = null;
        [SerializeField] private GameObject _scope = null;

        private void Start()
        {
            IAmmunition ammunition = new Ammo(_bullet, 3.0f);
            var weapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);

            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPosition, _muffler);
            ModificationWeapon modificationWeapon = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            modificationWeapon.ApplyModification(weapon);

            var scope = new WeaponScope(_zoomWithScope, _barrelPosition, _scope);
            ModificationWeapon modificationScope = new ModificationScope(scope, _barrelPositionScope.position);
            modificationScope.ApplyModification(weapon);

            _fire = modificationWeapon;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                
            }
        }
    }
}
