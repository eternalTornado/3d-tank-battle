using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour, IDie
{
    public Health health;

    // Start is called before the first frame update
    void Start()
    {
        //for init purpose. Use scriptable object to store config
        health.Init(100);
    }

    public void Die()
    {
        
    }
}
