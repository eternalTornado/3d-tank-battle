using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : Projectile
{
    public float flyingSpeed;
    public Shell(ProjectileType _type, float _speed) : base(_type)
    {
        flyingSpeed = _speed;
    }

    public void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void Move()
    {
        transform.position += this.transform.forward * flyingSpeed * Time.deltaTime;
    }
}
