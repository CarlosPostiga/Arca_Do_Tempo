using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractItem : MonoBehaviour
{

    public GameObject notification;
    public bool enterd;

    private Inventory inventory;

    private void Start()
    {
        notification.SetActive(false);
        inventory = FindObjectOfType<Inventory>();
    }
    private void Update()
    {
        if (enterd)
        {
            notification.SetActive(true);
        }
        else
        {
            notification.SetActive(false);
        }
    }
    
    public void Interaction()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.isFull[i])
            {
                GameObject temp = inventory.slots[i].transform.GetChild(0).gameObject;
                if (temp.CompareTag("Drawer"))
                {
                    inventory.isFull[i] = false;
                    Debug.Log("use item");
                    Destroy(temp);
                    break;
                }
            }
        }
    }
}
