using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private GameObject component; 

    public void SetComponent(GameObject _comp)
    {
        component = _comp;
    }

    public GameObject GetComponent()
    {
        return component;

    }


    public void Rotate(float speed)
    {
        if (component == null)
            return;

        component.transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
