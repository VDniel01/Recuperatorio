using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float duration = 5f;

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
            // Aumentar la velocidad
            controller.speed *= 2;
            yield return new WaitForSeconds(duration);
            // Restaurar la velocidad
            controller.speed /= 2;
        }
        Destroy(gameObject);
    }
}
