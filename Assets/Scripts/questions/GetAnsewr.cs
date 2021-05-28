using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetAnsewr : MonoBehaviour
{
    public string anwser;

    public void getAnwser()
    {
        anwser = GetComponentInChildren<TextMeshProUGUI>().text.ToString();
    }
}
