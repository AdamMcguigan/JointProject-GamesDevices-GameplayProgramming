using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpFromCt : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            player.transform.position += new Vector3(12,0, 0);
        }


    }
}
