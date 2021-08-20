using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    [System.Serializable]
    public class ProjectilePool
    {
        public ProjectileType tag;
        public Projectile prefab;
        public int initSize;
    }

    public List<ProjectilePool> projectilePools;

    private Dictionary<ProjectileType, Queue<Projectile>> dictProjectile; // tag - Quere containing actual objects

    private void Awake()
    {
        dictProjectile = new Dictionary<ProjectileType, Queue<Projectile>>();
    }

    private void Start()
    {
        foreach (var pool in projectilePools)
        {
            var queue = new Queue<Projectile>();
            for (int i = 0; i < pool.initSize; i++)
            {
                var instance = GameObject.Instantiate(pool.prefab, Vector3.zero, Quaternion.identity);
                instance.gameObject.SetActive(false);

                queue.Enqueue(instance);
            }
            dictProjectile[pool.tag] = queue;
        }
    }

    //Brackey's tutorial would straght up re-use the instance, even if it's still in used
    //I dont want that so dequeueing will take place in somewhere else
    //And it will generate new instance if not enough
    //Note: maybe set data outside ?
    public Projectile GetProjectileByType(ProjectileType type, Vector3 position, Quaternion rotation)
    {
        if (!dictProjectile.ContainsKey(type))
            return null;

        Projectile instance = null;

        if (dictProjectile[type].Count < 1)
        {
            Projectile prefab = null;
            foreach (var pool in projectilePools)
            {
                if (pool.tag == type)
                    prefab = pool.prefab;
            }

            if (prefab != null)
                instance = GameObject.Instantiate(prefab);
        }
        else
            instance = dictProjectile[type].Dequeue();

        instance.transform.position = position;
        instance.transform.rotation = rotation;

        instance.gameObject.SetActive(true);

        return instance;
    }

    public void ReturnProjectileToQueue(Projectile instance)
    {
        if (!dictProjectile.ContainsKey(instance.type))
            dictProjectile[instance.type] = new Queue<Projectile>();

        instance.gameObject.SetActive(false);

        dictProjectile[instance.type].Enqueue(instance);
    }
}