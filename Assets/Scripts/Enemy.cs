using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;
    public GameObject panel;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Destroy(gameObject);
            panel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
