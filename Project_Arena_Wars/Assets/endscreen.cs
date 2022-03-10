using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endscreen : MonoBehaviour
{
    public saveObject so;
    Animator animator;
    public Text scoreText;
    public Text prevScore;
    private void Start()
    {
        so = SaveManager.load();
        scoreText.text = "Score: " + so.score.ToString();
        prevScore.text = "Prev Score: " + so.score.ToString();
        StartCoroutine(Endscreen());
    }

    


    IEnumerator Endscreen()
    {
        yield return new WaitForSeconds(16.0f);
        SceneManager.LoadScene("Menu");

    }

}