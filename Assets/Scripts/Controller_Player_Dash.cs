using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Dash : Controller_Player
{
    public float dashForce = 20f; // Fuerza del dash
    public float dashDuration = 0.2f; // Duración del dash
    private bool isDashing = false; // Indicador de si se está haciendo dash
    private Vector3 dashDirection; // Dirección del dash

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        dashDirection = new Vector3(rb.velocity.x, 0, 0).normalized; // Dirección horizontal del dash
        rb.AddForce(dashDirection * dashForce, ForceMode.Impulse); // Aplica una fuerza de impulso en la dirección del dash
        yield return new WaitForSeconds(dashDuration); // Espera el tiempo de duración del dash
        rb.velocity = new Vector3(0, rb.velocity.y, 0); // Detiene el movimiento horizontal después del dash

        // Verificar si el personaje está dentro de una pared
        if (IsInsideWall())
        {
            Destroy(this.gameObject); // Destruir el objeto del jugador
            GameManager.gameOver = true; // Activar el estado de Game Over
        }

        isDashing = false;
    }

    private bool IsInsideWall()
    {
        // Utilizar Physics.CheckBox para verificar colisiones con la capa de paredes
        Collider[] colliders = Physics.OverlapBox(transform.position, col.size / 2, transform.rotation, LayerMask.GetMask("Wall"));
        return colliders.Length > 0;
    }
}
