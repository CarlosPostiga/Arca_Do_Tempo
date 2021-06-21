using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Language : MonoBehaviour
{
    public TMP_Text EntranceButon;
    public Text EntranceWallButon;
    public TMP_Text EntranceWallText;
    public Text stairsButon;
    public TMP_Text stairsText;
    public Text BoimbosButon;
    public TMP_Text BoimbosText;

    private void Start()
    {
        EntranceButon.text = Lang.Fields["EntrasMenuBotao"];
        EntranceWallButon.text = Lang.Fields["EntrasHallMenuBotao"];
        EntranceWallText.text = Lang.Fields["EntrasHallMenutexto"];
        stairsButon.text = Lang.Fields["StairsMenuBotao"];
        stairsText.text = Lang.Fields["StairsMenuText"];
        BoimbosButon.text = Lang.Fields["BiombosMenuBotao"];
        BoimbosText.text = Lang.Fields["BiombosMenuTexto"];
    }

}
