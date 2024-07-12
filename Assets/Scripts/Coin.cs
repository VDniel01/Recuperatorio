using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10; // Valor de la moneda

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.AddScore(scoreValue); // Asumiendo que GameManager tiene una función AddScore
            Destroy(gameObject);
        }
    }
}
