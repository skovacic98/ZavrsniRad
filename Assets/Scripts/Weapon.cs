using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject[] bulletPrefab = new GameObject[5];
    public Bullet[] bullet = new Bullet[5];
    public Text powerLabel;
    public int[] Bullets = {99999, 10, 2, 7, 1};
    public float minPower = 0f, maxPower = 100f;
    public float currPower = 0f;
    int number = 0;

    void Shoot(int number)
    {
        Instantiate(bulletPrefab[number], firePoint.position, firePoint.rotation);
        SoundManger.PlaySound("shootSound");
    }

    public void AddBullets()
    {
        for (int i = 0; i < 5; i++)
        {
            switch(i)
            {
                case 0:
                    Bullets[i] += 0;
                    break;
                case 1:
                    Bullets[i] += 10;
                    break;
                case 2:
                    Bullets[i] += 4;
                    break;
                case 3:
                    Bullets[i] += 5;
                    break;
                case 4:
                    Bullets[i] += 2;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            SoundManger.PlaySound("reload");
            number++;
            if(number >= 5)
            {
                number = 0;
            }
        }
        if (Bullets[number] > 0)
        {
            if (Input.GetButton("Fire2"))
            {
                currPower += Time.deltaTime * 1 * 30;
                powerLabel.text = "POWER: " + (int)Mathf.Clamp(currPower, minPower, maxPower);
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                bullet[number].speed = Mathf.Clamp(currPower, minPower, maxPower);
                Shoot(number);
                Bullets[number]--;
                currPower = 0;
            }
        }
    }
}
