using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteLoader : MonoBehaviour
{
    public Animator animator;
    public void LoadNextImage(GameObject ActualSprite, GameObject NewSprite)
    {
        StartCoroutine(LoadImage(ActualSprite,NewSprite));
    }
    IEnumerator LoadImage(GameObject ActualSprite, GameObject NewSprite)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        ActualSprite.SetActive(false);
        NewSprite.SetActive(true);
    }
}
