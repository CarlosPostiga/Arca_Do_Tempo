using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awnser : MonoBehaviour
{
    public bool enterd = false;
    public GameObject notification;


    private void Update()
    {
        if (enterd)
        {
            notification.SetActive(true);
        }
        else
        {
            notification.SetActive(false);
        }
    }
}
