using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public GameObject panel;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        SoundManger.PlaySound("playerHit");
        if(health <= 0)
        {
            Destroy(gameObject);
            StartCoroutine(DieSound());
            SoundManger.PlaySound("DieSound");
            panel.SetActive(true);
        }
    }

    public void AddHealth()
    {
        health += 50;
    }

    IEnumerator DieSound()
    {
        yield return new WaitForSecondsRealtime(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
