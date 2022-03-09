using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using System;

public class bombScript : MonoBehaviour
{
    public GameObject player;
    public GameObject BombsiteA;
    public GameObject BombsiteB;
    public GameObject effectExplosion;
    public EnemyInstantiation EI;



    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI plantText;
    public TextMeshProUGUI bombPickupText;
    public TextMeshProUGUI plantingBombText;

    float newCounter = 0.0f;
    float counter = 0.0f;
    float timer = 46.5f;
    float anotherTimer = 5.0f;
    float plantTimer = 3.0f;
    bool collidedPickup = false;
    bool planting = false;
    public bool startTimer = false;
    bool planted = false;
    bool boomTimer = false;
    bool triggerNewSceneTimer = false;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip audioClip;



    private void FixedUpdate()
    {
        if (planted)
        {
            objectiveText.SetText("Objective: \n" +
                "   Defend the Bomb!");
            EI.gameObject.SetActive(true);
          

            planted = false;
        }
        //If pickup == true and player presses E, then the player will pickup the bomb.
        if (collidedPickup == true && Input.GetKey(KeyCode.E) && planted == false)
        {

            gameObject.transform.SetParent(player.transform);
            gameObject.transform.position = player.transform.position + new Vector3(-0.5f, -0.6f, 0f);
            bombPickupText.gameObject.SetActive(false);
            objectiveText.SetText("Objective: \n" +
                "   Plant the Bomb!");

            player.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        }
        if (Input.GetKey(KeyCode.E) && planting == true)
        {
            startTimer = true;
          

        }
        if (Input.GetKey(KeyCode.F))
        {
            bombPickupText.gameObject.SetActive(true);
            objectiveText.SetText("Objective: \n" +
                "   Pick up the Bomb!");
            collidedPickup = false;
            transform.parent = null;
            CheckWithinRadius();
        }
        if (startTimer)
        {
            startPlantTimer();
        }
        if (boomTimer)
        {
            startBoomTimer();
        }
        if (triggerNewSceneTimer)
        {
            newTimerForEndScene();
        }
        
    }
    void newTimerForEndScene()
    {

        newCounter += Time.deltaTime;
        if (newCounter > anotherTimer)
        {
            triggerNewSceneTimer = false;
            SceneManager.LoadScene("EndScreen");       
        }
    }

    void startBoomTimer()
    {
       
        counter += Time.deltaTime;
        if (counter > timer)
        {
            Debug.Log("Add explosion shtuff");
            Instantiate(effectExplosion, transform.position, transform.rotation);
            CameraShake.instance.shakeCamera(1.8f);
            boomTimer = false;
            triggerNewSceneTimer = true;
        }
    }
    void startPlantTimer()
    {
        counter += Time.deltaTime;
        plantingBombText.gameObject.SetActive(true);
        plantTimer -= counter;
        //Debug.Log("I'm inside planting if");
        if (plantTimer < 0.0f)
        {
            planted = true;
            plantingBombText.gameObject.SetActive(false);
            collidedPickup = false;
            transform.parent = null;
            plantText.SetText("Bomb Planted!");
            audioSource.PlayOneShot(audioClip, 0.8f);
            startTimer = false;
            boomTimer = true;
        }
    }

    //Checking if the player has collided with the 'Bomb' object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && planted == false)
        {
            //setting pickup to true
            collidedPickup = true;
            bombPickupText.gameObject.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Bombsite"))
        {
            planting = true;
            Debug.Log("You can plant the bomb!");
            if (bombPickupText.IsActive() == true && collidedPickup == false)
            {
                plantText.gameObject.SetActive(false);
            }
            if (bombPickupText.IsActive() == false && collidedPickup == true)
            {
                plantText.gameObject.SetActive(true);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        planting = false;
        if (other.gameObject.CompareTag("Bombsite"))
        {
            Debug.Log("You can no longer plant!, get onto a bombsite!");
            plantText.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            bombPickupText.gameObject.SetActive(false);
        }
    }

    //This Function is basically checking for colliders that have the components we chose
    //aka if it has enemy2Script (melee enemy) it will deal damage to him.
    void CheckWithinRadius()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,5.0f);

        foreach(Collider2D c in colliders)
        {
            if(c.GetComponent<enemy2Scrpit>()  || c.GetComponent<rotateTowardsPlayer>())
            {
                Debug.Log("can call death Animation here or something else ");
                
            }
        }
    }

}
