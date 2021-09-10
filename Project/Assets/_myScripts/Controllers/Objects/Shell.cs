using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : Projectile
{
    public float flyingSpeed;

    private PoolManager pool => PoolManager.instance;

    private Rigidbody _rigidBody;
    private Rigidbody Rigidbody
    {
        get
        {
            if (_rigidBody == null)
                _rigidBody = this.GetComponent<Rigidbody>();

            return _rigidBody;
        }
    }

    public Shell(ProjectileType _type, float _speed) : base(_type)
    {
        flyingSpeed = _speed;
    }

    private void OnEnable()
    {
        Move();
    }

    private void Move()
    {
        //transform.position += this.transform.forward * flyingSpeed * Time.deltaTime;
        Rigidbody.velocity = forwardDirection * flyingSpeed;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        //pool.GetShellExplosion(this.transform.position, Quaternion.identity);
        //pool.ReturnProjectileToQueue(this);
    }
}
