using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public void Rotate(float speed)
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
