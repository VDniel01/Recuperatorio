using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Inverted : Controller_Player
{
    protected override void Start()
    {
        base.Start();
        Physics.gravity = new Vector3(0, 30, 0); // Invertir la gravedad
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (canJump)
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse); // Invertir la dirección del salto
            }
        }
    }
}