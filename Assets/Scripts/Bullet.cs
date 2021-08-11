using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float dmg;
    public float speed;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(impactEffect);
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(dmg);
            Destroy(gameObject);
            Destroy(impactEffect);
        }

        if (collision.CompareTag("Terrain"))
        {
            SoundManger.PlaySound("missSound");
            Destroy(gameObject);
            Destroy(impactEffect);
        }
    }*/
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(dmg);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Terrain")
        {
            SoundManger.PlaySound("missSound");
        }
        /*
        if(collision.collider.CompareTag("Terrain"))
        {
            SoundManger.PlaySound("missSound");
            Destroy(gameObject);
            Destroy(impactEffect);
        }*/
        
    }
}
