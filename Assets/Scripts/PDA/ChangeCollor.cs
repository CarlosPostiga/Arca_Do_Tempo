using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCollor : MonoBehaviour
{
    private Image image;
    private float rand;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    private void ChangeImage()
    {
        rand = Random.Range(1, 3);
        if (rand <= 1)
        {
            image.color = Color.gray;
        }
        else
        {
            image.color = Color.green;
        }
    }
    public void TurnOnAllColors()
    {
        if (image.transform.name == "TurnOnImage2")
        {
            ChangeImage();
        }
        if (image.transform.name == "TurnOnImage1")
        {
            image.color = Color.green;
        }
        if (image.transform.name == "ScreenImage")
        {
            image.transform.gameObject.SetActive(true);
        }
    }
    public void TurnOffAllColors()
    {
        if (image.transform.name == "TurnOnImage2")
        {
            image.color = Color.gray;
        }
        if (image.transform.name == "TurnOnImage1")
        {
            image.color = Color.gray;
        }
        if (image.transform.name == "ScreenImage")
        {
            image.transform.gameObject.SetActive(false);
        }
    }
}
