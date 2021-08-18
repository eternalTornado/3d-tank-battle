using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    private ProjectileFactory projectileFactory;
    private List<Projectile> listProjectiles;

    private void Start()
    {
        projectileFactory = new ProjectileFactory();
        listProjectiles = new List<Projectile>();
    }

    private Projectile GetProjectileByType(ProjectileType type)
    {
        foreach (var p in listProjectiles)
            if (p.type == type)
                return p;

        var _p = GameObject.Instantiate(projectileFactory.GenerateProjectilebyType(type));
        _p.gameObject.SetActive(false);
        listProjectiles.Add(_p);
        return _p;
    }

    public void GetProjectileFromPool(ProjectileType type)
    {
        var p = GetProjectileByType(type);

        p.gameObject.SetActive(true);
        p.ResetData();
    }

    public void ReturnProjectileToPool(Projectile p)
    {
        p.gameObject.SetActive(false);
        p.transform.parent = this.transform;
    }
}

public interface IPoolElement
{

}
