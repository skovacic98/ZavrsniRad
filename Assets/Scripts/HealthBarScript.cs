using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    Image healthBar;
    public Enemy enemy;
    float maxHealth = 150f;
    void Start()
    {
        healthBar = GetComponent<Image>();
    }
    void Update()
    {
        healthBar.fillAmount = enemy.health / maxHealth;
    }
}
