using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 10f; // Duración de la invulnerabilidad

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ApplyPowerUp(other));
        }
    }

    IEnumerator ApplyPowerUp(Collider player)
    {
        Controller_Player controller = player.GetComponent<Controller_Player>();
        if (controller != null)
        {
            // Hacer al jugador invulnerable
            controller.isInvulnerable = true;
            yield return new WaitForSeconds(duration);
            // Restaurar la vulnerabilidad
            controller.isInvulnerable = false;
        }
        Destroy(gameObject);
    }
}
