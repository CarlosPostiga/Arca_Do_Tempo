using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public Rigidbody rb;
    public GameObject youWin;
    public Part objectPart;
    public PlaceManager listOfPlaced;

    private void Start()
    {
        objectPart = this.GetComponent<Part>();
    }

    void OnMouseDown()
    {

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

        rb.useGravity = false;


    }
    void OnMouseDrag()
    {
        if (!objectPart.inplace)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
            rb.freezeRotation = true;
        }
    }
    private void OnMouseUp()
    {
        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Part>() != null)
        {
            if (objectPart.AskNeighboor(collision.gameObject))
            {
                listOfPlaced.AddInplace(collision.gameObject);
                listOfPlaced.AddInplace(this.gameObject);
            }
            if (listOfPlaced.CheckWin())
            {
                youWin.SetActive(true);
            }
        }
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }
}