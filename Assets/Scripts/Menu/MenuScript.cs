using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public TMP_Text playButton;
    public TMP_Text optionsButton;
    public TMP_Text exitButton;

    void Start()
    {
        playButton.text = Lang.Fields["start"];
        optionsButton.text = Lang.Fields["options"];
        exitButton.text = Lang.Fields["exit"];
    }
}
