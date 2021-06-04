using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public bool interactionPossible;
    public GameObject interectionText;
    public KeyCode interactButton;
    public bool interact = false;

    private void Update()
    {
        if (interactionPossible)
        {
            interectionText.SetActive(true);
            if (Input.GetKeyDown(interactButton))
            {
                interact = true;
            }
        }
        else
        {
            interectionText.SetActive(false);
        }
    }
}
