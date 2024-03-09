using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
        
    }
}
