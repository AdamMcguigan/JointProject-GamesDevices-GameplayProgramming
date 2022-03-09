using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageHandler : MonoBehaviour
{
    public movement mvmt;
    public GameObject hostage;
    public bool onHostage = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onHostage == true)
        {
            hostage.transform.SetParent(this.gameObject.transform);
            hostage.transform.position = this.transform.position + new Vector3(-0.5f, -0.5f, 0);
            mvmt.hostageTaken = true;
            Debug.Log("I have attached the enemy");
            onHostage = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hostage"))
        {
            onHostage = true;          
        }
        else
        {
            onHostage = false;
        }
    }
}
