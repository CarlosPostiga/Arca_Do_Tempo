using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageLAbirinto : MonoBehaviour
{
    public TextMeshProUGUI Ineract;
    public TextMeshProUGUI Entertext;
    public TextMeshProUGUI Entertext2;

    private void Start()
    {
        Ineract.text = Lang.Fields["InteractText"];
        if (Entertext != null)
        {
            Entertext.text = Lang.Fields["LAbirintoENtrence"];
            
        }
        if (Entertext2 != null)
        {
            Entertext2.text = Lang.Fields["LAbirintoENtrence2"];

        }
        

    }
}
