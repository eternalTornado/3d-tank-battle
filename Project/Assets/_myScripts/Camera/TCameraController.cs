using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCameraController : MonoBehaviour
{
    public GameObject target;

    private Vector3 offset;

    void Start()
    {
        offset = target.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.transform.position - offset;
    }
}
