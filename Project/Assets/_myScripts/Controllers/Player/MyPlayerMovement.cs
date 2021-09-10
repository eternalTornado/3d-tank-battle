using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;

    //Move these into scriptable object
    [Header("Movement KeyCode")]
    public KeyCode KeyForward = KeyCode.W;
    public KeyCode KeyBackward = KeyCode.S;
    public KeyCode KeyLeft = KeyCode.A;
    public KeyCode KeyRight = KeyCode.D;

    [Space]
    public Mover mover;

    private Rotator bodyRotator;

    private KeyboardHandler input;

    private float horizontal;
    private float vertical;

    private void Awake()
    {
        input = new KeyboardHandler();
        bodyRotator = new Rotator();
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal1");
        vertical = Input.GetAxisRaw("Vertical1");

        if (Input.anyKey)
        {
            input.GetKeysPressed().ForEach(k =>
            {
                input.TriggerAction(k);
            });
        }
    }

    public void Init()
    {
        //By default. Maybe I would never implement the keybind feature hehe. Who knows
        input.RegisterAction(KeyCode.W, Move);
        input.RegisterAction(KeyCode.S, Move);
        input.RegisterAction(KeyCode.A, Rotate);
        input.RegisterAction(KeyCode.D, Rotate);

        //Init rotation
        bodyRotator.SetComponent(this.transform.gameObject);
    }

    private void Move()
    {
        mover.SetSpeed(vertical * moveSpeed);
    }

    private void Rotate()
    {
        bodyRotator.Rotate(horizontal * rotateSpeed);
    }
}
