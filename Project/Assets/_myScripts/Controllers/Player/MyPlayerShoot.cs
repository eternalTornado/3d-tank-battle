using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerShoot : MonoBehaviour
{
    public Transform gunTransform;

    public KeyCode ShootKey = KeyCode.Space;
    public ProjectileType projectileType = ProjectileType.SHELL;

    private KeyboardHandler input;
    private Shoot shoot;

    private void Awake()
    {
        input = new KeyboardHandler();
        shoot = new Shoot();

        shoot.Init(projectileType, gunTransform);

        shoot.SetOwnerTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        input.RegisterAction(ShootKey, ()=> { shoot.DoShoot(gunTransform.forward); });
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleRotatingGunAccordingToMousePos();
    }

    private void HandleInput()
    {
        if (input.IsAnyKeyDown())
        {
            if (input.GetKeyDown() == ShootKey)
            {
                input.TriggerAction(ShootKey);
            }
        }
    }

    private void HandleRotatingGunAccordingToMousePos()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);
        
        foreach(var hit in hits)
        {
            if(hit.collider.tag == "Ground")
            {
                gunTransform.LookAt(new Vector3(hit.point.x, gunTransform.position.y, hit.point.z));
            }
        }
    }
}
