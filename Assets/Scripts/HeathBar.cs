using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth;
    private Slider slider;

    private Coroutine healthReductionCoroutine;
    private float reductionInterval = 5f;
    private float reductionAmount = 10f;

    void Start()
    {
        currentHealth = maxHealth;
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        
    }

    public void ReduceHealth(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        slider.value = currentHealth / maxHealth;

        // Stop the health reduction coroutine if it's running
        if (healthReductionCoroutine != null)
        {
            StopCoroutine(healthReductionCoroutine);
        }

        // Restart the health reduction coroutine
        healthReductionCoroutine = StartCoroutine(ReduceHealthOverTime());
    }

    private IEnumerator ReduceHealthOverTime()
    {
        while (currentHealth > 0)
        {
            yield return new WaitForSeconds(reductionInterval);
            currentHealth -= reductionAmount;
            currentHealth = Mathf.Max(currentHealth, 0);
            slider.value = currentHealth / maxHealth;
        }
    }
}
