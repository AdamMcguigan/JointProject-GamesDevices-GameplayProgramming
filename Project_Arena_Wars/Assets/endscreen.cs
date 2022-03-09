using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class endscreen : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        
        StartCoroutine(Endscreen());
    }


    IEnumerator Endscreen()
    {
        yield return new WaitForSeconds(16.0f);
        SceneManager.LoadScene("Menu");

    }

}