using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingDistance : MonoBehaviour
{
    public enemy1Script enemy;
    public ShotgunEnemy shotgunEnemy1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.allowShot = true;
            shotgunEnemy1.allowShot = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.allowShot = false;
            shotgunEnemy1.allowShot = false;
        }
    }


}
