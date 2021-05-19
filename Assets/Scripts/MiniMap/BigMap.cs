using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMap : MonoBehaviour
{
    public Transform Player;

    private void LateUpdate()
    {
        Vector3 newPosition = Player.position;

        newPosition.z = transform.position.z;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}