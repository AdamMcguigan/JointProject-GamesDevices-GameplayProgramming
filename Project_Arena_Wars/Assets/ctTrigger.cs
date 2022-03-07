using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctTrigger : MonoBehaviour
{
    public bool trigger = false;

    public GameObject ct;
    public GameObject ctwallObj;

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
            ct.SetActive(true);
            ctwallObj.SetActive(false);
        }
        else if (trigger == false)
        { ct.SetActive(false);
            ctwallObj.SetActive(true);
        }
    }
}
