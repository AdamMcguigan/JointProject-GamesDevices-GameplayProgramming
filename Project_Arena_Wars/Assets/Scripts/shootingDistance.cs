using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingDistance : MonoBehaviour
{
    public enemy1Script enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.allowShot = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.allowShot = false;
        }
    }


}
