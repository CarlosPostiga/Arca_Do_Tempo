using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionFunc : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public string[] awnsers;
    public int index;
    public float typingSpeed;
    public GameObject PlaceHolder;
    public GameObject InteractText;
    public GameObject[] Barrears;
    string anwserGiven; 

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
    public void CheckAnwser(GetAnsewr anwersplace)
    {
        anwersplace.getAnwser();
        anwserGiven = anwersplace.anwser;
        if (anwserGiven == awnsers[index])
        {
            PlaceHolder.SetActive(false);
            InteractText.SetActive(false);
            foreach (GameObject barrear in Barrears)
            {
                if (barrear.GetComponent<indexBarrear>().Index == index)
                {
                    barrear.SetActive(false);
                    break;  
                }
            }
            index++;
        }
        
    }


}
