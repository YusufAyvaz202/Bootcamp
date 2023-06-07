using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar1 : MonoBehaviour
{
    public static healthBar1 instance;

    public Image healthBar;

    float health, maxHealth = 100f;
    float lerpSpeed;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health > maxHealth)
            health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health < 0)
            health = 0;

        HealthBarFiller();
        ColorChanger();
    }

    public void RefreshHealth(float collectedAmount)
    {
        health += collectedAmount;
        if (health > 100)
            health = 100;

        HealthBarFiller();
        ColorChanger();
    }
    
    public void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }

    public void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));

        healthBar.color = healthColor;
    } 
    
}


