using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player stuff")]
    public Rigidbody2D rb = new Rigidbody2D();          //<-- specifying rb as usual
    public Animator animator;
    public Animator animatorFeet;
    public Transform firePoint;
    public GameObject bullet;
    public TextMeshProUGUI restart;

    public float h;     //horizontal float
    public float v;     //vertical float
    public float moveSpeed = 5f;        //speed
    public static short lives = 5;

 
    [Header("Gun stuff")]
    public float speed = 10f;
    public Transform firepoint;
    public GameObject bulletPrefab;
    public GameObject shellCasing;
    public GameObject muzzleFlash;
    public float fireRate;
    private float shotCounter;

    public int ammo;
    public bool isFiring;
    public Text ammoDislay;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip audioClip;



    void Start()
    {
        muzzleFlash.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        lives = 5;
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");     //checking input
        v = Input.GetAxisRaw("Vertical");       //checking input

        if (lives <= 0)
        {
            restart.gameObject.SetActive(true);
        }
        


        ammoDislay.text = ammo.ToString();
        ////////////////////////////////////////Shooting
        if(Input.GetMouseButton(0) && !isFiring && ammo > 0)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                //CameraShake.instance.shakeCamera(0.2f); ///<---------------- comment this out (left it in for now)
                shotCounter = fireRate;
                audioSource.PlayOneShot(audioClip, 0.5f);
                animator.SetBool("shoot", true);
                GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firepoint.up * speed, ForceMode2D.Impulse);
                ejectShell();
                muzzleFlash.gameObject.SetActive(true);
                isFiring = true;
                ammo--;
                isFiring = false;
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("shoot", false);
            muzzleFlash.gameObject.SetActive(false);
        }
        else
        {
            shotCounter = 0;
        }



        //////////////////////////////////////// ////////////////////////////////////////
        ///

        //if (Input.GetMouseButton(0) && !isFiring && ammo > 0)
        //{
        //    animator.SetBool("shoot", true);
        //    GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        //    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //    rb.AddForce(firepoint.up * speed, ForceMode2D.Impulse);
        //    ejectShell();
        //    muzzleFlash.gameObject.SetActive(true);
        //    isFiring = true;
        //    ammo--;
        //    isFiring = false;

        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    animator.SetBool("shoot", false);
        //    muzzleFlash.gameObject.SetActive(false);
        //}
        ////////////////////////////////////////// ////////////////////////////////////////





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
            ammo = 30;
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

    private void ejectShell()
    {
        GameObject ejectShell = Instantiate(shellCasing, transform.position, Quaternion.identity);
        float xVnot = Random.Range(5f, 10f);
        float yVnot = Random.Range(5f, 10f);
        if (!(firepoint.rotation.eulerAngles.z >= 90f && firepoint.rotation.eulerAngles.z < 270f))
        {
            xVnot *= -1;
        }
        ejectShell.GetComponent<ShellCase>().xVnot = xVnot;
        ejectShell.GetComponent<ShellCase>().yVnot = yVnot;
    }

}
