using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;

public class bombScript : MonoBehaviour
{
    public GameObject player;
    public GameObject BombsiteA;
    public GameObject BombsiteB;

    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI plantText;
    public TextMeshProUGUI bombPickupText;
    public TextMeshProUGUI plantingBombText;


    float counter = 0.0f;
    float timer = 10.0f;
    float plantTimer = 3.0f;
    bool collidedPickup = false;
    bool planting = false;
    bool startTimer = false;
    bool planted = false;
    bool boomTimer = false;


    private void FixedUpdate()
    {
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
        if(Input.GetKey(KeyCode.F))
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
        
    }
    void startBoomTimer()
    {
        counter += Time.deltaTime;
        if (counter > timer)
        {
            Debug.Log("Add explosion shtuff");
            boomTimer = false;
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
