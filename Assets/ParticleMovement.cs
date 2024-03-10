using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ParticleMovement : MonoBehaviour
{

    [SerializeField] private GameObject particlePrefab;
    [SerializeField] private GameObject particle2Prefab;

    private Vector3 randomDir;

    private void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            // Generate random position within the boundaries of the background
            randomDir = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
            if(i % 2 == 0)
            {
                GameObject particle = Instantiate(particlePrefab, randomDir, Quaternion.identity);
                particle.GetComponent<Particle>().setIniitalDirection(randomDir);
                // Apply random rotation to the particle
                particle.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            }
            else
            {
                GameObject particle2 = Instantiate(particle2Prefab, randomDir, Quaternion.identity);
                particle2.GetComponent<Particle>().setIniitalDirection(randomDir);

                particle2.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            }
            // Instantiate particle with random position and rotation
           
        }
    }

    private void Update()
    {
        // Move particles based on their current direction
       
    }

   
}
