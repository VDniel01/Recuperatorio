using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player_Crush : Controller_Player
{
    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.contacts[0].normal.y > 0.5f) // Colisión desde arriba
        {
            if (collision.gameObject.CompareTag("Crushable"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}

