using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExitGame : MonoBehaviour
{
    public GameObject titulo;
    public GameObject thanks;
    public TextMeshProUGUI thanksText;

    // Start is called before the first frame update
    void Start()
    {
        thanksText.text = Lang.Fields["ThanksText"];
        StartCoroutine(exitCourotine());
    }

    IEnumerator exitCourotine()
    {
        yield return new WaitForSeconds(21);
        titulo.SetActive(false);
        thanks.SetActive(true);
        yield return new WaitForSeconds(5);
        Application.Quit();
    }
}
