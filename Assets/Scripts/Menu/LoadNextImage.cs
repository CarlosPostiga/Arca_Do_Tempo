using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextImage : MonoBehaviour
{
    public Animator transaction;
    public GameObject transaction1;
    public GameObject transaction2;

    private void Start()
    {
        StartCoroutine(transactionCourotine());
    }
    IEnumerator transactionCourotine()
    {
        yield return new WaitForSeconds(5f);
        transaction.SetBool("start", true);
        yield return new WaitForSeconds(2f);
        transaction1.SetActive(false);
        transaction2.SetActive(true);
    }

}
