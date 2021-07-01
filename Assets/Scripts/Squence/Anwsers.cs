using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anwsers : MonoBehaviour
{
    public List<int> Ansers;
    public List<int> Squence;
    bool WinGame = false;
    bool TryAgain = false;
    bool WaterLevel = false;
    public GameObject wingameView;
    public GameObject tryAgainView;
    public GameObject door;
    public GameObject triger;
    public GameObject doorFrame;
    public GameObject water;
    public float waterHight;
    public GameObject placeObject;
    public GameObject Winingtext;
    public GameObject otherText;

    private void Start()
    {
        Squence = new List<int>();
        Ansers = new List<int>();
        Ansers.Add(4);
        Ansers.Add(3);
        Ansers.Add(6);
        Ansers.Add(5);
        Ansers.Add(2);
        Ansers.Add(1);
        waterHight = water.transform.position.y;
    }
    private void Update()
    {
        if (Squence.Count == Ansers.Count)
        {
            CheckAwnser();
            if (WinGame)
            {
                StartCoroutine(winText());
                WaterLevel = true;
                Destroy(triger.GetComponent<BoxCollider>());
                Destroy(doorFrame.GetComponent<BoxCollider>());
                WinGame = false;

            }
            else if(TryAgain)
            {
                StartCoroutine(TryAgainText());
            }


            if (WaterLevel)
            {
                waterHight -= 0.002f;
                water.transform.position = new Vector3(water.transform.position.x, waterHight, water.transform.position.z);
            }
        }
    }
    public void AddToSquence(IdAwser id)
    {
        Squence.Add(id.id);
    }
    public void CheckAwnser()
    {
        for (int i = 0; i < Ansers.Count; i++)
        {
            if (Ansers[i] != Squence[i])
            {
                TryAgain = true;
                break;
            }
            else
            {
                WinGame = true;
            }
        }
    }
    IEnumerator DrainWater()
    {
        waterHight -= 0.02f;
        water.transform.position = new Vector3(water.transform.position.x, waterHight, water.transform.position.z);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator winText()
    {
        wingameView.SetActive(true);
        yield return new WaitForSeconds(5f);
        Destroy(door);
        Squence.Clear();
        wingameView.SetActive(false);
        placeObject.SetActive(true);
        Winingtext.SetActive(true);
        otherText.SetActive(false);
        WaterLevel = false;
    }
    IEnumerator TryAgainText()
    {
        tryAgainView.SetActive(true);
        Squence.Clear();
        yield return new WaitForSeconds(5f);
        TryAgain = false;
        tryAgainView.SetActive(false);
    }

}
