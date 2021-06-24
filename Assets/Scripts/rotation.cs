using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class rotation : MonoBehaviour
{
    public float rotationSpeed;
    public Transform objects;
    public bool startAnimation = false;
    public Animator firstGate;
    public Animator secondGate;
    public AudioSource openGate;
    public AudioSource openlock;

    void Update()
    {

        if (startAnimation)
        {
            if (objects.rotation.z > -.23)
            {
                objects.rotation = Quaternion.Euler(0, 90, objects.rotation.z - rotationSpeed * Time.time);
            }
            else
            {
                openlock.Play();
                openGate.Play();

                firstGate.SetBool("rigt anser", true);
                secondGate.SetBool("dooroppend", true);
                startAnimation = false;
            }


        }
    }
}
