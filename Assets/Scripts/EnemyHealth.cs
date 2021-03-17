using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // For beefy boy og heath bar
    public float health;
    private float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        // For beefy boy og health bar
        if (gameObject.tag == "Enemy")
        {
            maxHealth = 100;
        }

        health = maxHealth;
        slider.value = CalculateHealth();
        healthBarUI.SetActive(true);
    }

    void Update()
    {
        // Here we calcualte
        slider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }
}
