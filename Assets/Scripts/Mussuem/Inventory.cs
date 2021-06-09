using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public List<GameObject> slots;
    public GameObject inventory;

    private void Start()
    {
        for (int i = 0; i < inventory.transform.childCount; i++)
        {
            slots.Add(inventory.transform.GetChild(i).gameObject);
        }
    }
}
