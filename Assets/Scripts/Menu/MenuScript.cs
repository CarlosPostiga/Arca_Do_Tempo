using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public TMP_Text playButton;
    public TMP_Text optionsButton;
    public TMP_Text HowtoPlayButton;
    public TMP_Text exitButton;
    public TMP_Text Optiontitel;
    public TMP_Text OptionLinguagem;
    public TMP_Text OptionGraficos;
    public TMP_Text OptionFullscrren;
    public TMP_Text OptionVolume;
    public TMP_Text HowToPlaytitel;

    void Update()
    {
        playButton.text = Lang.Fields["start"];
        optionsButton.text = Lang.Fields["options"];
        HowtoPlayButton.text = Lang.Fields["HowtoPlay"];
        exitButton.text = Lang.Fields["exit"];
        Optiontitel.text = Lang.Fields["OptionsTitel"];
        OptionLinguagem.text = Lang.Fields["language"];
        OptionGraficos.text = Lang.Fields["Graphics"];
        OptionFullscrren.text = Lang.Fields["FullScreen"];
        OptionVolume.text = Lang.Fields["Volume"];
        HowToPlaytitel.text = Lang.Fields["HowToPlayTitel"];
    }
}
