using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private ProjectileType type;

    public void SetProjectile(ProjectileType _type)
    {
        type = _type;
    }

    public void DoShoot()
    {
        //Maybe get from pool
    }
}
