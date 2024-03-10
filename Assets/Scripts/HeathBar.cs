using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    // Start is called before the first frame update
    private float maxHealth = 100;
    private float currentHealth;
    private Slider slider;
    void Start()
    {
        currentHealth = maxHealth;
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(float amount)
    {
        currentHealth -= amount;

        currentHealth = Mathf.Max(currentHealth, 0);

        slider.value = currentHealth / maxHealth;
    }
}
