using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideToAttack : MonoBehaviour
{
    public enemy2Scrpit enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.animator.SetBool("attack", true);
            Debug.Log("collided");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.animator.SetBool("attack", false);
        }
    }
}
