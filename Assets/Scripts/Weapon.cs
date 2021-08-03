using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Bullet bullet;
    public Text powerLabel;

    public float minPower = 0f, maxPower = 100f;
    public float currPower = 0f;



    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            currPower += Time.deltaTime * 1 * 30;
            powerLabel.text = "SNAGA: " + (int)Mathf.Clamp(currPower, minPower, maxPower);
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            bullet.speed = Mathf.Clamp(currPower, minPower, maxPower);
            Shoot();
            currPower = 0;
        }
    }
}
