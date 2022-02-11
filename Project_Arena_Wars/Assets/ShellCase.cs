using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellCase : MonoBehaviour
{
    public float startYpos;
    public float yVnot;
    public float xVnot;
    public float acceleration = -9.8f;

    public Rigidbody2D rig;

    private float velocityTime;
    private float rotationSpeed = 400f;
    private float offset = -2f;//-8.3f;

    // Start is called before the first frame update
    void Start()
    {
        startYpos = transform.position.y;
        rig.velocity = new Vector2(xVnot, yVnot);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Acceleration();
    }

    private void Acceleration()
    {
        velocityTime += Time.fixedDeltaTime;

        if (rig.velocity.magnitude < 0.5)
        {
            rig.velocity = Vector2.zero;
            return;
        }

        transform.Rotate(0f, 0f, rotationSpeed * Time.fixedDeltaTime);

        //Below if statement will handle the bullet falling to the ground and moving
        if (transform.position.y <= startYpos + offset && rig.velocity.y < 0)
        {
            float yVelocity = -rig.velocity.y * 0.25f;
            float xVelocity = rig.velocity.x * 0.25f;

            rig.velocity = new Vector2(xVelocity, yVelocity);
            velocityTime = 0;
        }
        else
        {
            float yVelocity = rig.velocity.y + acceleration * velocityTime;
            rig.velocity = new Vector2(rig.velocity.x, yVelocity);
        }
    }
}
