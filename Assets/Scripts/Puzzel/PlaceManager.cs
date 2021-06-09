using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    public List<GameObject> InPlace;
    public int numberOfPieces;


    private void Start()
    {
        numberOfPieces = FindObjectsOfType<Part>().Length;
    }
    public bool CheckWin()
    {
        if (numberOfPieces == InPlace.Count)
        {
            return true;
        }
        return false;
    }
    public void AddInplace(GameObject objectToAdd)
    {
        if (!InPlace.Contains(objectToAdd))
        {
            InPlace.Add(objectToAdd);
        }
    }

}
