using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Controller_Player controller = collision.gameObject.GetComponent<Controller_Player>();
            if (controller != null && !controller.isInvulnerable)
            {
                Destroy(collision.gameObject);
                GameManager.gameOver = true; // Acceso correcto al campo estático
            }
        }
    }
}
