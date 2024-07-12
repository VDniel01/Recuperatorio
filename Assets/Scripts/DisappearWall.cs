using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearWall : MonoBehaviour
{
    public float disappearTime = 2f; // Tiempo que la pared estará desaparecida

    private Renderer rend;
    private Collider col;

    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameManager.actualPlayer == 0) // Solo el jugador 0 puede interactuar
        {
            StartCoroutine(Disappear());
        }
    }

    IEnumerator Disappear()
    {
        rend.enabled = false;
        col.enabled = false;
        yield return new WaitForSeconds(disappearTime);
        rend.enabled = true;
        col.enabled = true;
    }
}
