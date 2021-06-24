using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class playSound : MonoBehaviour
{
    public float percentage;
    public AudioSource seaguls;

    private float rand;


    void Update()
    {
        rand = Random.Range(0, 100);
        if (!seaguls.isPlaying)
        {
            if (rand > percentage)
            {
                seaguls.Play();
            }

        }

    }
}
