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
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }  
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
    }
}
