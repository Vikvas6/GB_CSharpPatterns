using System;
using System.Dynamic;
using System.Threading.Tasks;
using Asteroids;
using Asteroids.Object_Pool;
using UnityEngine;


public class FireController : IFire
{
    #region Fields

    private Transform _barrel;

    private Func<float> _getCurrentForceFromPlayer;
    private float _lifeTime;

    #endregion

    #region Contructor

    public FireController(Transform barrel, Func<float> getForce, float lifeTime)
    {
        _barrel = barrel;
        _lifeTime = lifeTime;
        _getCurrentForceFromPlayer = getForce;
    }

    #endregion

    #region Methods

    public void Fire()
    {
        var temAmmunition = ServiceLocator.Resolve<BulletPool>().GetBullet();
        temAmmunition.transform.localPosition = _barrel.position;
        temAmmunition.transform.localRotation = _barrel.rotation;
        temAmmunition.transform.gameObject.SetActive(true);
        temAmmunition.GetComponent<Rigidbody2D>().AddForce(_barrel.up * _getCurrentForceFromPlayer());
        temAmmunition.InvokeReturnToPool(_lifeTime);
    }

    #endregion
}