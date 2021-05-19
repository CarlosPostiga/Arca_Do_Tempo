using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFloat : MonoBehaviour
{
    public float airDrag = 1;
    public float waterDrag = 10;
    public Transform[] floatPoints;

    protected Rigidbody rigidbody;
    protected Waves waves;

    protected float waterLine;
    protected Vector3[] waterLinePoints;

    protected Vector3 centerOffset;
    protected Vector3 smoothVectorRotation;
    protected Vector3 TarguetUp;


    public Vector3 Center { get { return transform.position + centerOffset; } }

    public bool AttachToSurface;

    private void Awake()
    {
        waves = FindObjectOfType<Waves>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;

        waterLinePoints = new Vector3[floatPoints.Length];
        for (int i = 0; i < floatPoints.Length; i++)
        {
            waterLinePoints[i] = floatPoints[i].position;
        }
        centerOffset = PhysicsHelper.GetCenter(waterLinePoints) - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newWaterLine = 0f;
        bool poitUnderWater = false;

        for (int i = 0; i < floatPoints.Length; i++)
        {
            waterLinePoints[i] = floatPoints[i].position;
            waterLinePoints[i].y = waves.GetHeight(floatPoints[i].position);
            newWaterLine += waterLinePoints[i].y / floatPoints.Length;
            if (waterLinePoints[i].y> floatPoints[i].position.y)
            {
                poitUnderWater = true;
            }
        }
        float waterLineDelta = newWaterLine - waterLine;
        waterLine = newWaterLine;

        Vector3 gravity = Physics.gravity;

        rigidbody.drag = airDrag;
        if (waterLine>Center.y)
        {
            rigidbody.drag = waterDrag;
            if (AttachToSurface)
            {
                //attach to water surface
                rigidbody.position = new Vector3(rigidbody.position.x, waterLine - centerOffset.y, rigidbody.position.z);
            }
            else
            {
                //go up
                gravity = -Physics.gravity;
                transform.Translate(Vector3.up * waterLineDelta * 0.9f);
            }
            gravity = -Physics.gravity;
            transform.Translate(Vector3.up * waterLineDelta * 0.9f);

        }
        rigidbody.AddForce(gravity * Mathf.Clamp(Mathf.Abs(waterLine - Center.y), 0, 1));

        TarguetUp = PhysicsHelper.GetNormal(waterLinePoints);

        if (poitUnderWater)
        {
            TarguetUp = Vector3.SmoothDamp(transform.up, TarguetUp, ref smoothVectorRotation, 0.2f);
            rigidbody.rotation = Quaternion.FromToRotation(transform.up, TarguetUp) * rigidbody.rotation;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (floatPoints == null)
            return;

        for (int i = 0; i < floatPoints.Length; i++)
        {
            if (floatPoints[i] == null)
                continue;

            if (waves != null)
            {

                //draw cube
                Gizmos.color = Color.red;
                Gizmos.DrawCube(waterLinePoints[i], Vector3.one * 0.3f);
            }

            //draw sphere
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(floatPoints[i].position, 0.1f);

        }

        //draw center
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(new Vector3(Center.x, waterLine, Center.z), Vector3.one * 1f);
            //Gizmos.DrawRay(new Vector3(Center.x, waterLine, Center.z), TargetUp * 1f);
        }
    }
}
