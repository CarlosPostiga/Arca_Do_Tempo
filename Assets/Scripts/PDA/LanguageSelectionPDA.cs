using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanguageSelectionPDA : MonoBehaviour
{
    public Text descritionButtonText;
    public Text inventoryButtonText;
    public Text mapButtonText;
    public TextMeshProUGUI Tittel1;
    public TextMeshProUGUI Tittel2;
    public TextMeshProUGUI Tittel3;
    public TextMeshProUGUI description1;
    public TextMeshProUGUI description2;
    public TextMeshProUGUI   description3;
    // Start is called before the first frame update
    void Start()
    {
        descritionButtonText.text = Lang.Fields["descricaoBotao"];
        inventoryButtonText.text = Lang.Fields["inventario"];
        
        Tittel1.text = Lang.Fields["titulo1"];
        Tittel2.text = Lang.Fields["titulo2"];
        if (mapButtonText != null)
        {
            mapButtonText.text = Lang.Fields["mapa"];

        }
        Tittel3.text = Lang.Fields["titulo3"];
        description1.text = Lang.Fields["Descricao1"];
        description2.text = Lang.Fields["Descricao2"];
        description3.text = Lang.Fields["Descricao3"];
    }
}
