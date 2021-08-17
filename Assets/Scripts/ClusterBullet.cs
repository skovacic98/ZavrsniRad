using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterBullet : MonoBehaviour
{
    [SerializeField] float dmg;
    public float speed;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public Bullet bullet;
    public float y_max = 0.0f;
    public float y_current = 0.0f;
    public int explosionCounter = 0;
    void Start()
    {
        speed = bullet.speed;
        rb.velocity = transform.right * speed;
        y_current = transform.position.y;
    }

    private void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        y_current = transform.position.y;
        if (y_current > y_max)
        {
            y_max = y_current;
        }
        if (y_max > y_current + 1 && explosionCounter == 0)
        {
            explosionCounter++;
            Destroy(gameObject);
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z + 1.0f), transform.rotation);
            Instantiate(bullet, new Vector3(transform.position.x + 1.0f, transform.position.y + 1.0f, transform.position.z - 0.5f), transform.rotation);
            Instantiate(bullet, new Vector3(transform.position.x + 1.0f, transform.position.y - 1.0f, transform.position.z - 0.5f), transform.rotation);
        }
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
        if (collision.gameObject.tag == "Terrain")
        {
            SoundManger.PlaySound("missSound");
        }
    }
}

