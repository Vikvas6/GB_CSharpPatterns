using UnityEngine;

namespace Asteroids
{
    internal sealed class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Vector3 _mufflerPosition;

        private GameObject _mufflerGO; 

        private float _volumeOld;
        private AudioClip _audioClipOld;
        private Transform _barrelPositionOld;

        public ModificationMuffler(AudioSource audioSource, IMuffler muffler, Vector3 mufflerPosition)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
        }
        
        protected override Weapon AddModification(Weapon weapon)
        {
            _mufflerGO = Object.Instantiate(_muffler.MufflerInstance, _mufflerPosition, Quaternion.identity);
            _volumeOld = _audioSource.volume;
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            
            _audioClipOld = weapon.GetAudioClip();
            weapon.SetAudioClip(_muffler.AudioClipMuffler);

            _barrelPositionOld = weapon.GetBarrelPosition();
            weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon)
        {
            _audioSource.volume = _volumeOld;
            weapon.SetAudioClip(_audioClipOld);
            weapon.SetBarrelPosition(_barrelPositionOld);
            GameObject.Destroy(_mufflerGO);
            return weapon;
        }
    }
}