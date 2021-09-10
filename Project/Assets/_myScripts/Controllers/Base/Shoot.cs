using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootOutput;

    public KeyCode FireKey = KeyCode.Space;

    private ProjectileType type;
    private string ownerTag;

    private PoolManager pool => PoolManager.instance;

    public void Init(ProjectileType _type, Transform shootPos)
    {
        type = _type;
        shootOutput = shootPos;
    }

    public void SetOwnerTag(string ownerTag)
    {
        this.ownerTag = ownerTag;
    }

    public void DoShoot(Vector3 gunDirection)
    {
        var projectile = pool.GetProjectileByType(type, shootOutput.transform.position, shootOutput.transform.rotation);
        projectile.SetData(ownerTag, gunDirection);
    }
}
