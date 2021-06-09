using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indexBarrear : MonoBehaviour
{
    public int Index;
    public GameObject IteractionText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IteractionText.SetActive(true);
        }
    }
}
