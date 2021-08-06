using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public WeaponPlayer2 weapon;
    public Enemy enemy;


    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("PlayerTwo");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "AmmoCrate")
        {
            weapon.AddBullets();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "HealthCrate")
        {
            enemy.AddHealth();
            Destroy(collision.gameObject);
        }
    }
}