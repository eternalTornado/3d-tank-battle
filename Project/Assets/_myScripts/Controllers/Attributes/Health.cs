using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Heath. I just assume anything with health can be a target
public class Health : MonoBehaviour
{
    public int maxHealth { get; private set; }
    public int currentHealth { get; private set; }

    public void Init(int initHealth)
    {
        maxHealth = initHealth;
        currentHealth = initHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
