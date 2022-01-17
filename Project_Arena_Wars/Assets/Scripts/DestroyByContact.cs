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
    }
}
