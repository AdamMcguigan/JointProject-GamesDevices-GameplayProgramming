using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public static DestroyByContact instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "props")
        {
            Debug.Log("Collided with props ");
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "walls")
        {
            Debug.Log("Collided with walls ");
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("HiT ThE EnEmY MaN ");
            enemy1Script.lives--;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Knife Enemy")
        {
            Debug.Log("HiT The Knife man ");
            enemy2Scrpit.lives--;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Shotgun Enemy")
        {
            Debug.Log("HiT The shotgun man ");
            ShotgunEnemy.lives--;
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with the player");
            Destroy(gameObject);
        }

        if (enemy1Script.lives <= 0)
        {
            //Destroy(collision.gameObject);
            collision.gameObject.transform.position = new Vector3(1000, 1000, 1000);
        }

        if (enemy2Scrpit.lives <= 0)
        {
            Destroy(collision.gameObject);
        }

        if (ShotgunEnemy.lives <= 0)
        {
            Destroy(collision.gameObject);
        }
    }
}
