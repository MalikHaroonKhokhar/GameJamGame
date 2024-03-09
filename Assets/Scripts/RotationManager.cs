using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public Joystick joystick;
    public float rotation;
    

     private void FixedUpdate() {
        rotation=joystick.Horizontal*-1f;
        transform.Rotate(0,0,rotation);
        
    }
        
}
