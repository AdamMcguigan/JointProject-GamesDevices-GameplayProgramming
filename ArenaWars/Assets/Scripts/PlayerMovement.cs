using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public Rigidbody2D rb = new Rigidbody2D();          //<-- specifying rb as usual

   
    public float h;     //horizontal float
    public float v;     //vertical float
    public float moveSpeed = 5f;        //speed
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");     //checking input
        v = Input.GetAxisRaw("Vertical");       //checking input
    }   
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(h * moveSpeed, v * moveSpeed);    //making character move
    }
}
