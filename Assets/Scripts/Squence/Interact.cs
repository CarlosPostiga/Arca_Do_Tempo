using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Image InteractImage;
    public bool interaction = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Interaction>().interactionPossible = true;
           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
         interaction = other.GetComponent<Interaction>().interact;
            if (interaction)
            {
                InteractImage.enabled = true;
                other.GetComponent<Interaction>().interactionPossible = false;
                other.GetComponent<Interaction>().interectionText.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InteractImage.enabled = false;
            interaction = false;
            other.GetComponent<Interaction>().interact = interaction;
        }
    }
    public void interact()
    {
        interaction = true;
    }
}
