using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory
{
    public Projectile GenerateProjectilebyType(ProjectileType type)
    {
        switch (type)
        {
            case ProjectileType.SHELL:
                return new Shell(type, 10f);
            default:
                return new Shell(type, 10f);
        }
    }
}
