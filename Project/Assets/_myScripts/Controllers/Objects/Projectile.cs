using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class of projectile
public abstract class Projectile : MonoBehaviour, IPoolElement
{
    [HideInInspector] public ProjectileType type { get; set; }
    [HideInInspector] public float lifeTime;

    private float existTime;
    public Projectile(ProjectileType _type)
    {
        type = _type;
    }

    private void Update()
    {
        CheckReturnToPool();
    }

    private void CheckReturnToPool()
    {
        if (lifeTime <= 0) return;

        existTime += Time.deltaTime;

        if (existTime >= lifeTime)
            PoolManager.instance.ReturnProjectileToPool(this);

    }

    public void ResetData()
    {
        this.gameObject.SetActive(true);
        existTime = 0;
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
        this.transform.localScale = Vector3.one;
    }
}

public enum ProjectileType
{
    SHELL
}
