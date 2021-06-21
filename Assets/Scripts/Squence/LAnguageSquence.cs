using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LAnguageSquence : MonoBehaviour
{
    public TextMeshProUGUI Entertext;
    public TextMeshProUGUI Entertext2;
    public TextMeshProUGUI Entertext3;
    public TextMeshProUGUI Wintext;
    public TextMeshProUGUI TryAgaintext;


    // Start is called before the first frame update
    void Start()
    {
        Entertext.text = Lang.Fields["squenceEntrence"];
        Entertext2.text = Lang.Fields["InteractText"];
        Entertext3.text = Lang.Fields["InteractText"];
        Wintext.text = Lang.Fields["WinText"];
        TryAgaintext.text = Lang.Fields["TryAgainText"];

    }
}
