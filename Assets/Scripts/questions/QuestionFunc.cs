using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionFunc : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI Ansewr1;
    public TextMeshProUGUI Ansewr2;
    public TextMeshProUGUI Ansewr3;
    public string[] sentences;
    public string[] awnsers;
    public int index;
    public float typingSpeed;
    public GameObject PlaceHolder;
    public GameObject InteractText;
    public GameObject tryAgainText;
    public GameObject[] Barrears;
    string anwserGiven;
    public GameObject[] Gates;

    private void Start()
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            sentences[i] = Lang.Fields[i.ToString()];
        }
        for (int i = 0; i < awnsers.Length; i++)
        {
            awnsers[i] = Lang.Fields[(i+32).ToString()];
        }

    }
    public void StartDialog()
    {
        InteractText.SetActive(false);
        PlaceHolder.SetActive(true);
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index+3].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        foreach (char letter in sentences[index + 1].ToCharArray())
        {
            Ansewr1.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        foreach (char letter in sentences[index + 2].ToCharArray())
        {
            Ansewr2.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        foreach (char letter in sentences[index].ToCharArray())
        {
            Ansewr3.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }
    public void CheckAnwser(GetAnsewr anwersplace)
    {
        
        anwersplace.getAnwser();
        anwserGiven = anwersplace.anwser;
        if (anwserGiven == awnsers[index / 4])
        {
            textDisplay.text = "";
            Ansewr1.text = "";
            Ansewr2.text = "";
            Ansewr3.text = "";
            PlaceHolder.SetActive(false);
            Gates[index / 4].transform.GetComponentInChildren<rotation>().startAnimation = true;
            Barrears[index / 4].SetActive(false);
            index += 4;
        }
        else
        {
            StartCoroutine(TryAgainCourotine());
        }
        
    }
    IEnumerator TryAgainCourotine()
    {
        tryAgainText.SetActive(true);
        yield return new WaitForSeconds(1f);
        tryAgainText.SetActive(false);
    }
}
