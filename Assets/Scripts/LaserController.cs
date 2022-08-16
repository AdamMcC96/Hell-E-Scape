using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed;
    public float liveTime;
    Vector3 moveVector;

    private void Start()
    {
        moveVector = Vector3.up * speed * Time.fixedDeltaTime;
        StartCoroutine(DestroyBullet());
        
    }

    private void FixedUpdate()
    {
        transform.Translate(moveVector);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject); // Destroy bullet after hitting something
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(liveTime);
        Destroy(gameObject); // Destroy bullet after live time is up
    }
}
