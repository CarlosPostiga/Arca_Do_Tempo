using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionFunc : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject PlaceHolder;

    public void StartDialog()
    {
        PlaceHolder.SetActive(true);
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }
}
