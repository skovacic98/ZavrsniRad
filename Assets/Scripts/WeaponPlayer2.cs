using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPlayer2 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject[] bulletPrefab = new GameObject[5];
    public Bullet[] bullet = new Bullet[5];
    public Text powerLabel;
    public Text[] bulletCount = new Text[5];
    public int[] Bullets = {99999, 10, 2, 7, 1 };
    public float minPower = 0f, maxPower = 100f;
    public float currPower = 0f;
    int number = 0;


    void Shoot(int number)
    {
        Instantiate(bulletPrefab[number], firePoint.position, firePoint.rotation);
        SoundManger.PlaySound("shootSound");
    }

    void Start()
    {
        bulletCount[0].text = "99999";
        bulletCount[1].text = "10";
        bulletCount[2].text = "2";
        bulletCount[3].text = "7";
        bulletCount[4].text = "1";
    }

    public void AddBullets()
    {
        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    Bullets[i] += 0;
                    bulletCount[i].text = "" + Bullets[i].ToString();
                    break;
                case 1:
                    Bullets[i] += 10;
                    bulletCount[i].text = "" + Bullets[i].ToString();
                    break;
                case 2:
                    Bullets[i] += 4;
                    bulletCount[i].text = "" + Bullets[i].ToString();
                    break;
                case 3:
                    Bullets[i] += 5;
                    bulletCount[i].text = "" + Bullets[i].ToString();
                    break;
                case 4:
                    Bullets[i] += 2;
                    bulletCount[i].text = "" + Bullets[i].ToString();
                    break;
            }
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SoundManger.PlaySound("reload");
            number++;
            if (number >= 5)
            {
                number = 0;
            }
        }
        if (Bullets[number] > 0)
        {
            if (Input.GetButton("Fire1"))
            {
                currPower += Time.deltaTime * 1 * 30;
                powerLabel.text = "POWER: " + (int)Mathf.Clamp(currPower, minPower, maxPower);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                if (number == 4)
                {
                    bullet[number].speed = Mathf.Clamp(currPower - 15, minPower, maxPower);
                }
                else
                {
                    bullet[number].speed = Mathf.Clamp(currPower, minPower, maxPower);
                }
                Shoot(number);
                Bullets[number]--;
                bulletCount[number].text = "" + Bullets[number].ToString();
                currPower = 0;
            }
        }
    }
}
