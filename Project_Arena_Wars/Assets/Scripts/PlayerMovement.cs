using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb = new Rigidbody2D();          //<-- specifying rb as usual
    public Animator animator;
    public Animator animatorFeet;
    public Transform firePoint;
    public GameObject bullet;

    public float h;     //horizontal float
    public float v;     //vertical float
    public float moveSpeed = 5f;        //speed
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");     //checking input
        v = Input.GetAxisRaw("Vertical");       //checking input





        ////////////////////////////////////////Shooting
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("shoot", true);

            //make move bullet 
            Instantiate(bullet, firePoint.position, firePoint.rotation);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("shoot", false);
        }
        //////////////////////////////////////// ////////////////////////////////////////





        //////////////////////////////////////// walking
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetFloat("speed", Mathf.Abs(moveSpeed));
            animatorFeet.SetFloat("speed", Mathf.Abs(moveSpeed));
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {                   
           animator.SetFloat("speed", Mathf.Abs(0));
           animatorFeet.SetFloat("speed", Mathf.Abs(0));
        }



        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetFloat("speed", Mathf.Abs(moveSpeed));
            animatorFeet.SetFloat("speed", Mathf.Abs(moveSpeed));
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetFloat("speed", Mathf.Abs(0));
            animatorFeet.SetFloat("speed", Mathf.Abs(0));
        }




        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetFloat("speed", Mathf.Abs(moveSpeed));
            animatorFeet.SetFloat("speed", Mathf.Abs(moveSpeed));
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetFloat("speed", Mathf.Abs(0));
            animatorFeet.SetFloat("speed", Mathf.Abs(0));
        }




        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetFloat("speed", Mathf.Abs(moveSpeed));
            animatorFeet.SetFloat("speed", Mathf.Abs(moveSpeed));
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetFloat("speed", Mathf.Abs(0));
            animatorFeet.SetFloat("speed", Mathf.Abs(0));
        }
        //////////////////////////////////////// ////////////////////////////////////////


        //////////////////////////////////////// Shooting

        if (Input.GetKey(KeyCode.R) && animator.GetBool("Reload") == false)
        {
            animator.SetBool("Reload", true);
            StartCoroutine(reload());
        }







    }
    private void FixedUpdate()
    {

     
        rb.velocity = new Vector2(h * moveSpeed, v * moveSpeed);    //making character move
    }


    IEnumerator reload()
    {

        yield return new WaitForSeconds(1.0f);
        animator.SetBool("Reload", false);
    }

 
}
