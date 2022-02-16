using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class enemy1Script : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject directionCircle;
    public Transform leftPosition;
    public Transform rightPosition;
    public GameObject player;
    public PlayerMovement playerSpeed;
    public Transform firePoint;
    public GameObject bullet;
    public float speed = 18.0f;
    float shootingTime;
    float gameTime = 10.0f;
    float theta;
    public bool allowShot = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    

    }


    // Update is called once per frame
    void Update()
    {



     
        if (rb.position.x >= 17)
        {
            rb.MovePosition(new Vector2(-18, 7));
        }

            Vector3 dir = player.transform.position - firePoint.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            firePoint.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        


        angleVisionCone();
  
    }
    void shoot()
    {
        if (shootingTime <= 0)
        {
            shootingTime = 2.0f;



            GameObject bulletspawn = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rbBullet = bulletspawn.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
            Destroy(bulletspawn, 2.0f);



        }
        shootingTime -= Time.deltaTime;
    }


    void angleVisionCone()
    {
        Vector2 enemyDirection = directionCircle.transform.position - this.transform.position;
        Vector2 playerDirection = player.transform.position - this.transform.position;
        

        Vector2 firstNormal = new Vector2(rb.position.x - leftPosition.transform.position.x, rb.position.y - leftPosition.transform.position.y);
        Vector2 secondNormal = new Vector2(rb.position.x - rightPosition.transform.position.x, rb.position.y - rightPosition.transform.position.y);
        float FOV = Mathf.Acos(Vector2.Dot(firstNormal, secondNormal) /
                                            (firstNormal.magnitude * secondNormal.magnitude));

        FOV *= Mathf.Rad2Deg;
        if (gameTime > 0)
        {
            theta = Vector2.Angle(playerDirection, enemyDirection);
            if (theta < FOV / 2)
            {
                if (allowShot == true)
                {
                    rb.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
                    shoot();
                }
            }
            else
            {
                 rb.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
            }
            
  
        }

    }
}