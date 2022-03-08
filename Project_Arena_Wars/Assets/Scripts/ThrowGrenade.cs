using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public float forceToThrow = 600f;
    public Transform firePoint;
    public GameObject grenadePrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            throwGrenade();

        }
    }

    void throwGrenade()
    {
        
        GameObject grenade = Instantiate(grenadePrefab, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right* forceToThrow , ForceMode2D.Force);
    }
}
