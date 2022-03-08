using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunnelTrigger : MonoBehaviour
{

    public GameObject tunnel;
    public bool trigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        { 
            trigger ^= true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trigger ^= true;
        }
    }

    private void Update()
    {
        if (trigger == true)
        {
            tunnel.SetActive(true);
        }
        else if (trigger == false)
        { tunnel.SetActive(false);}
    }
}
