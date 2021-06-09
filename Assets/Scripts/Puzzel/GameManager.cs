using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool truewin = false;
    public LevelLoader levelLoader;

    void Update()
    {
        if (truewin)
        {
           StartCoroutine(nextlevel());
        }
    }
    IEnumerator nextlevel()
    {
        yield return new WaitForSeconds(1f);
        levelLoader.LoadNextLevel();
    }

}
