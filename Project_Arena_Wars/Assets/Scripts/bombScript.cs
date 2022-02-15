using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public GameObject player;

    bool collidedPickup = false;


    private void FixedUpdate()
    {
        //If pickup == true and player presses E, then the player will pickup the bomb.
        if(collidedPickup == true && Input.GetKey(KeyCode.E))
        {
            gameObject.transform.SetParent(player.transform);
            gameObject.transform.position = player.transform.position + new Vector3(-0.5f, -0.6f, 0f);

            player.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        }

        if(Input.GetKey(KeyCode.F))
        {
            collidedPickup = false;
            transform.parent = null;
            CheckWithinRadius();
        }


    }

    //Checking if the player has collided with the 'Bomb' object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //setting pickup to true
            collidedPickup = true;
            
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
