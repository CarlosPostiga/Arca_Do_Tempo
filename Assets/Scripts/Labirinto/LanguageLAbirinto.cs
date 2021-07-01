using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageLAbirinto : MonoBehaviour
{
    public TextMeshProUGUI Ineract;
    public TextMeshProUGUI Entertext;
    public TextMeshProUGUI Entertext2;
    public TextMeshProUGUI Option;
    public TextMeshProUGUI Continuar;
    public TextMeshProUGUI Sair;
    public TextMeshProUGUI PerguntaSair;
    public TextMeshProUGUI Sim;
    public TextMeshProUGUI Nao;
    public GameObject pausemenu;

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

        Option.text = Lang.Fields["pauseText"];
        Continuar.text = Lang.Fields["continiuText"];
        Sair.text = Lang.Fields["exitext"];
        PerguntaSair.text = Lang.Fields["SecurityQuestios"];
        Sim.text = Lang.Fields["yesText"];
        Nao.text = Lang.Fields["NaoText"];
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausemenu.SetActive(true);
        }
    }
}
