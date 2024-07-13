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
        Vector3 dashDirection = rb.velocity.normalized; // Obtener la dirección del movimiento actual
        if (dashDirection == Vector3.zero) // Si no hay movimiento, dashear hacia la derecha como por defecto
        {
            dashDirection = Vector3.right;
        }

        rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
        canDash = false;
        Invoke("ResetDash", 2f); // Cooldown de 2 segundos
    }

    private void ResetDash()
    {
        canDash = true;
    }
}
