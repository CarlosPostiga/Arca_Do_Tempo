using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GrabObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public Rigidbody rb;
    public GameObject youWin;
    public Part objectPart;
    public PlaceManager listOfPlaced;
    public GameObject PoteFinal;
    public GameObject[] pecas;
    public bool win = false;
    public AudioSource hitSound;
    public GameObject placeHolder;
    public GameObject text1;
    public GameObject text2;

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
                hitSound.Play();
            }
            if (listOfPlaced.CheckWin())
            {
                StartCoroutine(Win());
                listOfPlaced.numberOfPieces = 100;
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
    IEnumerator Win()
    {
        youWin.SetActive(true);
        win = false;
        yield return new WaitForSeconds(1f);
        PoteFinal.SetActive(true);
        youWin.SetActive(false);
        placeHolder.SetActive(true);
        text2.SetActive(true);
        text1.SetActive(false);


        for (int i = 0; i < pecas.Length; i++)
        {
            pecas[i].SetActive(false);
        }

    }
}