using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class UseItems : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactButton;
    public UnityEvent interactAction;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactButton))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            InteractItem temp;
            isInRange = true;
            temp = collider.GetComponent<InteractItem>();
            temp.enterd = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            InteractItem temp;
            isInRange = false;
            temp = collider.GetComponent<InteractItem>();
            temp.enterd = false;
        }
    }
}
