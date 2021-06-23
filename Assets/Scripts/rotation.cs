using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public float rotationSpeed;
    public Transform objects;
    public bool startAnimation = false;
    public Animator firstGate;
    public Animator secondGate;

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
                firstGate.SetBool("rigt anser", true);
                secondGate.SetBool("dooroppend", true);
            }


        }
    }
}
