using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform Player;
    public GameObject miniMap;

    private void Start()
    {
        StartCoroutine(LoadLevel());

    }
    private void LateUpdate()
    {
        Vector3 newPosition = Player.position;

        newPosition.y = transform.position.y;
        transform.position = newPosition;


        transform.rotation = Quaternion.Euler(90f, Player.eulerAngles.y, 0f);
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1);
        if (miniMap != null)
        {
            miniMap.SetActive(true);
        }
    }
}
