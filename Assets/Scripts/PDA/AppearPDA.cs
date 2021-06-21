using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AppearPDA : MonoBehaviour
{
    public Image PDA;
    public ChangeCollor turnOnOff1;
    public ChangeCollor turnOnOff2;
    public ChangeCollor turnOnOff3;
    public GameObject[] Pecas;

    float speed = 50.0f;

    public bool show;
    public bool hide;

    private void Start()
    {
        PDA = GetComponent<Image>();
        show = false;
        hide = true;
        PDA.rectTransform.anchoredPosition = new Vector2(0, -Screen.height);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (show == false)
            {
                show = true;
                hide = false;
            }
            else
            {
                show = false;
                hide = true;
            }
        }
        UsePDA();
    }
    private void UsePDA()
    {
        if (show)
        {
            turnOnOff1.TurnOnAllColors();
            turnOnOff2.TurnOnAllColors();
            turnOnOff3.TurnOnAllColors();
            PDA.rectTransform.anchoredPosition = Vector2.MoveTowards(PDA.rectTransform.anchoredPosition, Vector2.zero, speed);
            for (int i = 0; i < Pecas.Length; i++)
            {
                if (Pecas[i] != null)
                {
                    Pecas[i].SetActive(false);
                }
            }


        }
        if (hide)
        {
            turnOnOff1.TurnOffAllColors();
            turnOnOff2.TurnOffAllColors();
            turnOnOff3.TurnOffAllColors();
            PDA.rectTransform.anchoredPosition = Vector2.MoveTowards(PDA.rectTransform.anchoredPosition, new Vector2(0, -Screen.height - 250), speed);
            for (int i = 0; i < Pecas.Length; i++)
            {
                if (Pecas[i] != null)
                {
                    Pecas[i].SetActive(true);
                }
            }

        }
    }

}
