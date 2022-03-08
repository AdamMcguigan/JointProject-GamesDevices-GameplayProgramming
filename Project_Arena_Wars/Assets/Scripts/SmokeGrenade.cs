using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeGrenade : MonoBehaviour
{
    public float delayBeforeExplosion = 3f;
    float countDown;
    bool hasExploded = false;
    public GameObject effectExplosion;
    // Start is called before the first frame update
    void Start()
    {
        countDown = delayBeforeExplosion;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0f && !hasExploded)
        {
            hasExploded = true;
            Explode();
        }
    }


    void Explode()
    {
        Destroy(gameObject);

        Instantiate(effectExplosion, transform.position, transform.rotation);

 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("walls"))
        { countDown += 0.1f; }
    }
}
