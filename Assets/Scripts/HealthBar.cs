using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Slider healthBar;
    private float maxHealth = 100f; // Maximum health value
    private float currentHealth; // Current health value


    private void Start()
    {
        currentHealth = maxHealth; // Set current health to max health at the start
        healthBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(float amount)
    {
        currentHealth -= amount; // Decrease current health by the given amount

        // Ensure health doesn't go below zero
        currentHealth = Mathf.Max(currentHealth, 0);

        // Update the slider value
        healthBar.value = currentHealth / maxHealth;
    }


}
