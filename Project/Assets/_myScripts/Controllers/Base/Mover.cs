using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Rigidbody rigidBody;

    private void Start()
    {
        SetSpeed(0);
    }

    public void SetSpeed(float speed)
    {
        if (rigidBody.velocity == Vector3.forward * speed)
            return;
        //Does not need to be implemented in Update
        //Once the velocity is set, it will just keep moving
        rigidBody.velocity = this.transform.forward * speed;
    }
}
