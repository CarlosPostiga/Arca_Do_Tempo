using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anwsers : MonoBehaviour
{
    public List<int> Ansers;
    public List<int> Squence;
    bool WinGame = true;
    public GameObject wingameView;
    public GameObject tryAgainView;
    public GameObject door;
    public GameObject triger;
    public GameObject doorFrame;
    public GameObject water;
    public float waterHight;

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
                if (waterHight > -50)
                {
                    StartCoroutine(DrainWater());
                }
                Destroy(triger.GetComponent<BoxCollider>());
                Destroy(doorFrame.GetComponent<BoxCollider>());

            }
            else
            {
                tryAgainView.SetActive(true);
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
                WinGame = false;
                break;
            }
        }
    }
    IEnumerator DrainWater ()
    {
        waterHight-= .002f;
        water.transform.position = new Vector3(water.transform.position.x,waterHight, water.transform.position.z );
        yield return new WaitForSeconds(1f);
    }
    IEnumerator winText()
    {
        wingameView.SetActive(true);
        yield return new WaitForSeconds(5f);
        Ansers.Clear();
        door.SetActive(false);
        wingameView.SetActive(false);
        WinGame = false;

    }

}
