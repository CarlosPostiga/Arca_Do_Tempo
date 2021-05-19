using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public Transform motor;
    public float steerPower = 500f;
    public float power = 5f;
    public float maxSpeed = 10f;
    public float drag = 0.1f;

    protected Rigidbody rigidbody;
    protected Quaternion startRotation;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        startRotation = motor.localRotation;
    }

    private void FixedUpdate()
    {
        Vector3 forceDirection = transform.forward;
        float steer = 0f;


        if (Input.GetKey(KeyCode.RightArrow))
            steer = -0.5f;
        if (Input.GetKey(KeyCode.LeftArrow))
            steer = 0.5f;

        rigidbody.AddForceAtPosition(steer * transform.right * steerPower / 100, motor.position);

        Vector3 foward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
        Vector3 targuetvelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            PhysicsHelper.ApplyForceToReachVelocity(rigidbody, foward * maxSpeed, power);
        if (Input.GetKey(KeyCode.DownArrow))
            PhysicsHelper.ApplyForceToReachVelocity(rigidbody, foward * -maxSpeed, power);
    }
}
