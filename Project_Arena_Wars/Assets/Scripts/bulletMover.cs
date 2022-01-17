using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMover : MonoBehaviour
{
    //public Vector2 bulletSpeed = new Vector2(0.0f, 10.0f);
    public Rigidbody2D rb;

 //   float speed = 20f;
 //   public Transform firepoint;
  //  public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(rb.transform.forward * speed);
      //  rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(firepoint.forward * speed, ForceMode2D.Impulse);
        // transform.Translate(transform.forward * speed * Time.deltaTime);
        // rb.GetComponent<Rigidbody2D>().velocity = transform.forward * speed;
        //GetComponent<Rigidbody2D>().position += bulletSpeed * Time.deltaTime;
        //GetComponent<Rigidbody2D>().AddForce(Vector2.right * 100);

    //    GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
     //   Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
      //  rb.AddForce(firepoint.up * speed, ForceMode2D.Impulse);
    }
}
