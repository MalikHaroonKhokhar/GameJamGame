using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedBloodCellsGroup : MonoBehaviour
{
    public float speed = 4f;
    

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.y < 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-transform.up * speed * Time.deltaTime);
        }
       
    }
}