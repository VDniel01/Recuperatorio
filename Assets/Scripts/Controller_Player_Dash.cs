using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Dash : Controller_Player
{
    public float dashForce = 20f;
    private bool canDash = true;

    public override void Jump()
    {
        base.Jump();
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            Dash();
        }
    }

    private void Dash()
    {
        rb.AddForce(new Vector3(speed * dashForce, 0, 0), ForceMode.Impulse);
        canDash = false;
        Invoke("ResetDash", 2f); // Cooldown de 2 segundos
    }

    private void ResetDash()
    {
        canDash = true;
    }
}
