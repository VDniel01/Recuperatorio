using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Dash : Controller_Player
{
    public float dashForce = 20f; // Fuerza del dash
    private bool isDashing = false; // Booleano para verificar si está haciendo dash
    private float dashCooldown = 2f; // Tiempo de enfriamiento del dash
    private float dashCooldownTimer = 0f; // Temporizador del enfriamiento

    protected override void Update()
    {
        base.Update();

        if (GameManager.actualPlayer == playerNumber)
        {
            Dash();
        }

        if (isDashing)
        {
            dashCooldownTimer -= Time.deltaTime;
            if (dashCooldownTimer <= 0)
            {
                isDashing = false;
                dashCooldownTimer = dashCooldown;
            }
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            isDashing = true;
            rb.AddForce(new Vector3(rb.velocity.x * dashForce, 0, 0), ForceMode.Impulse);
        }
    }
}
