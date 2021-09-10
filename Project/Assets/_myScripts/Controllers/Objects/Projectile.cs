using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class of projectile
[System.Serializable]
[RequireComponent(typeof(Collider))]
public abstract class Projectile : MonoBehaviour
{
    //Intentionally left public for debug purpose
    public ProjectileType type { get; set; }
    public float lifeTime;
    public Vector3 forwardDirection;

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
            PoolManager.instance.ReturnProjectileToQueue(this);

    }

    public void ResetData()
    {
        this.gameObject.SetActive(true);
        existTime = 0;
        this.transform.localPosition = Vector3.zero;
        this.transform.localRotation = Quaternion.identity;
        this.transform.localScale = Vector3.one;
    }

    public void SetData(string ownerTag, Vector3 _forward)
    {
        this.tag = ownerTag;
        this.forwardDirection = _forward;
    }

    public virtual void DoExplode() { }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (this.tag == collision.collider.tag)
            Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.collider);
    }
}

[System.Serializable]
public enum ProjectileType
{
    SHELL
}
