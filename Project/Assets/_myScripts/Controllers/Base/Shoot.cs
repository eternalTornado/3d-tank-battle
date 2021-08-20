using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootOutput;

    public KeyCode FireKey = KeyCode.Space;
    public KeyboardHandler input;

    private ProjectileType type;

    private PoolManager pool => PoolManager.instance;

    private void Start()
    {
        input.RegisterAction(FireKey, DoShoot);
    }

    public void SetProjectile(ProjectileType _type)
    {
        type = _type;
    }

    public void DoShoot()
    {
        var projectile = PoolManager.instance.GetProjectileByType(type, shootOutput.transform.position, shootOutput.transform.rotation);
    }
}
