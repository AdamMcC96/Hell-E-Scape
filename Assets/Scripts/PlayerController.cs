using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 leftStick;
    private Vector2 rightStick;
    public GameObject laserPrefab;
    public Transform firePoint1;
    public Transform firePoint2;
    public float timeBetweenShots;
    private bool canShoot1;
    private bool canShoot2;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Grabs the rigidbody2D from the player
        canShoot1 = true;
        canShoot2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.gamePlaying)
        {
            GetPlayerInput();
        }
        else
        {
            leftStick = Vector2.zero;
            rightStick = Vector2.zero;
        }
        
    }

    private void GetPlayerInput()
    {
        leftStick = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rightStick = new Vector2(Input.GetAxis("R_Horizontal"), Input.GetAxis("R_Vertical"));

        if (Input.GetButton("Shoot") && canShoot1)
        {
            ShootR();
        }
        if (Input.GetButton("Shoot1") && canShoot2)
        {
            ShootL();
        }
    }
    private void ShootR()
    {
        canShoot1 = false;
        Instantiate(laserPrefab, firePoint1.position, transform.rotation);
        StartCoroutine(ShotCooldown1());
    }
    private void ShootL()
    {
        canShoot2 = false;
        Instantiate(laserPrefab, firePoint2.position, transform.rotation);
        StartCoroutine(ShotCooldown2());
    }

    IEnumerator ShotCooldown1()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot1 = true;
    }
    IEnumerator ShotCooldown2()
    {
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot2 = true;
    }
    private void FixedUpdate()
    {

            Vector2 curMove = leftStick * speed * Time.deltaTime; // calculates how the player moves based on their input, the set speed and is then normalized by multiplying by the time between FixedUpdates 
            rb.MovePosition(rb.position + curMove);

        if (rightStick.magnitude > 0f) {
            Vector3 curRotation = Vector3.left * rightStick.x + Vector3.up * rightStick.y;
            Quaternion playerRotation = Quaternion.LookRotation(curRotation, Vector3.forward);
            rb.SetRotation(playerRotation);
        }
        
    }
}
/*
 * private Vector2 still = new Vector2 (0, 0);
    private Vector2 lastMove;
    private Vector2 drift;
 * if (leftStick == still ) {
            Debug.Log(rb.position);
            if (rb.position.x < 0)
            {
                drift.x = 1 * Time.deltaTime;
            
            }if (rb.position.x > 0)
            {
                drift.x = -1 * Time.deltaTime;
            }
            if (rb.position.y < 0)
            {
                drift.y = 1 * Time.deltaTime;
            }
            if (rb.position.y > 0)
            {
                drift.y = -1 * Time.deltaTime;
            }
            else
            {
                drift = new Vector2(0,0);
            }
            //drift = lastMove * -1 * Time.deltaTime;
            rb.MovePosition(rb.position + drift);
        }*/