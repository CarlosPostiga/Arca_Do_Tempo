using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LanguageSelect : MonoBehaviour
{
    public TMP_Text portuguese;
    public TMP_Text english;


    public void Update()
    {
        portuguese.text = Lang.Fields["portuguese"];
        english.text = Lang.Fields["english"];
    }

    public void SelectPT()
    {
        Lang.LoadLanguage("PT");
    }
    
    public void SelectEN()
    {
        Lang.LoadLanguage("EN");
    }
}
