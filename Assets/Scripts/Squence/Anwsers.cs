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
    }
    private void Update()
    {
        if (Squence.Count == Ansers.Count)
        {
            CheckAwnser();
            if (WinGame)
            {
                wingameView.SetActive(true);
                door.SetActive(false);
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
}
