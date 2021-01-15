using UnityEngine;


public class FireController
{
    #region Fields

    private Rigidbody2D _bullet;
    private Transform _barrel;

    private float _force;

    #endregion

    #region Contructor

    public FireController(Rigidbody2D bullet, Transform barrel, float force)
    {
        _bullet = bullet;
        _barrel = barrel;
        _force = force;
    }

    #endregion

    #region Methods

    public void Fire()
    {
        var temAmmunition = GameObject.Instantiate(_bullet, _barrel.position, _barrel.rotation);
        temAmmunition.AddForce(_barrel.up * _force);
    }

    #endregion
}