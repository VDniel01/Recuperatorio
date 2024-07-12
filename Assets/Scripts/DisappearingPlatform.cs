using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float visibleTime = 2f;
    public float invisibleTime = 2f;

    private Renderer rend;
    private Collider col;

    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        StartCoroutine(TogglePlatform());
    }

    IEnumerator TogglePlatform()
    {
        while (true)
        {
            rend.enabled = true;
            col.enabled = true;
            yield return new WaitForSeconds(visibleTime);
            rend.enabled = false;
            col.enabled = false;
            yield return new WaitForSeconds(invisibleTime);
        }
    }
}

