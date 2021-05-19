using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject me;

    public float turnSpeed;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        me = this.gameObject;
        turnSpeed = 30;
    }
    private void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    GameObject temp;
                    inventory.isFull[i] = true;

                    temp = Instantiate(me,inventory.slots[i].transform,false);
                    temp.transform.localScale *= 100;
                    temp.transform.localPosition *= 0;
                    temp.transform.localPosition = new Vector3(3.3f,-3.9f,-15);

                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
