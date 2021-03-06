using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerMovement : MonoBehaviour
{
    public float speed;
    public WeaponPlayer2 weapon;
    public Enemy enemy;


    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("PlayerTwo");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "AmmoCrate")
        {
            SoundManger.PlaySound("nice, bonus ammo");
            weapon.AddBullets();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "HealthCrate")
        {
            SoundManger.PlaySound("nice, bonus health");
            enemy.AddHealth();
            Destroy(collision.gameObject);
        }
    }
}