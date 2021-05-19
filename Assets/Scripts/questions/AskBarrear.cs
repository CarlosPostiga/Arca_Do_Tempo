using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AskBarrear : MonoBehaviour
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
            Awnser temp;
            isInRange = true;
            temp = collider.GetComponent<Awnser>();
            temp.enterd = true;
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Awnser temp;
            isInRange = false;
            temp = collider.GetComponent<Awnser>();
            temp.enterd = false;
        }
    }
}
