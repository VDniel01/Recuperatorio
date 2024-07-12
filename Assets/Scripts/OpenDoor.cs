using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform door; // Transform de la puerta
    public float openHeight = 3f; // Altura a la que se abrirá la puerta
    public float openSpeed = 2f; // Velocidad de apertura de la puerta

    private Vector3 closedPosition;
    private Vector3 openPosition;

    void Start()
    {
        closedPosition = door.position;
        openPosition = new Vector3(door.position.x, door.position.y + openHeight, door.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(Open());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(Close());
        }
    }

    IEnumerator Open()
    {
        while (Vector3.Distance(door.position, openPosition) > 0.01f)
        {
            door.position = Vector3.MoveTowards(door.position, openPosition, openSpeed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator Close()
    {
        while (Vector3.Distance(door.position, closedPosition) > 0.01f)
        {
            door.position = Vector3.MoveTowards(door.position, closedPosition, openSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
