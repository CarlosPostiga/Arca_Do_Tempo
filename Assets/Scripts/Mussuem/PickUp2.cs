using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp2 : MonoBehaviour
{
    public Inventory inventory;
    public GameObject me;
    public GameObject interactionText;
    private LevelLoader nextLevel;
    public GameManager thisG;

    public float turnSpeed;

    private void Start()
    {
        //inventory = FindObjectOfType<Inventory>();
        me = this.gameObject;
        turnSpeed = 30;
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interactionText.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int i = 0; i < inventory.slots.Count; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        GameObject temp;
                        inventory.isFull[i] = true;

                        temp = Instantiate(me, inventory.slots[i].transform, false);
                        temp.transform.localScale *= 100;
                        temp.transform.localScale = new Vector3(temp.transform.localScale.x, temp.transform.localScale.y, temp.transform.localScale.z * 2);
                        temp.transform.localPosition *= 0;
                        temp.transform.localPosition = new Vector3(3.3f, -3.9f, -15);
                        thisG.truewin = true;
                        Destroy(gameObject);
                        break;
                    }
                }
                interactionText.SetActive(false);
            }
        }
    }
}
