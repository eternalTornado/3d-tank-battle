using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileExplosion : MonoBehaviour
{
    public ParticleSystem particle;
    public float lifeTime;

    private PoolManager pool => PoolManager.instance;
    private float count;

    private void Update()
    {
        count += Time.deltaTime;
        if (count >= lifeTime)
            pool.ReturnShellExplosionToPool(this);
    }
}
