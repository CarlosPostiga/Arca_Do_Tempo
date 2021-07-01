using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LAnguagePuzzel : MonoBehaviour
{
    public TextMeshProUGUI Entertext;
    public TextMeshProUGUI Entertext2;
    public TextMeshProUGUI Entertext3;
    public TextMeshProUGUI Wintext;


    // Start is called before the first frame update
    void Start()
    {
        Entertext.text = Lang.Fields["PuzzelENtrence"];
        Entertext2.text = Lang.Fields["InteractText"];
        Entertext3.text = Lang.Fields["WiningPuzzelText"];
        Wintext.text = Lang.Fields["WinText"];
    }
}
