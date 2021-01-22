using System;
using System.Dynamic;
using System.Threading.Tasks;
using Asteroids;
using Asteroids.Object_Pool;
using UnityEngine;


public class FireController
{
    #region Fields

    private Transform _barrel;

    private float _force;
    private float _lifeTime;

    #endregion

    #region Contructor

    public FireController(Transform barrel, float force, float lifeTime)
    {
        _barrel = barrel;
        _force = force;
        _lifeTime = lifeTime;
    }

    #endregion

    #region Methods

    public void Fire()
    {
        var temAmmunition = ServiceLocator.Resolve<BulletPool>().GetBullet();
        temAmmunition.transform.localPosition = _barrel.position;
        temAmmunition.transform.localRotation = _barrel.rotation;
        temAmmunition.transform.gameObject.SetActive(true);
        temAmmunition.GetComponent<Rigidbody2D>().AddForce(_barrel.up * _force);
        temAmmunition.InvokeReturnToPool(_lifeTime);
    }

    #endregion
}