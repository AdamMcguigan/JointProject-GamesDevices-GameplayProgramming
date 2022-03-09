using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerDust2 : MonoBehaviour
{
    public bombScript bomb;
    public GameObject shootingEnemy;
    public Transform SpawnpointBomb;
    //Location 25,62

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //This Instantiates 5 enemies but completely locks up the game - 
        //leaving it commented out someone else can instantiate new enemies when bomb is planted 

        //if(bomb.startTimer == true)
        //{
        //    Instantiate(shootingEnemy, SpawnpointBomb.position, SpawnpointBomb.rotation);
        //}


    }
}
