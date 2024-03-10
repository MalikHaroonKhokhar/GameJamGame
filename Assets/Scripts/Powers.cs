using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    public static bool hasSpreadBullet = false;
    private bool powerUpClicked = false;
    public static bool areRedBloodCellsAttacking = false;
    private float powerUpTimer = 4f;
    private float timer = 0f;


    private void Update()
    {
        if(powerUpClicked)
        {
            if(timer > powerUpTimer)
            {
                hasSpreadBullet = false;
                powerUpClicked = false;
                timer = 0f;

            }
            else
            {
                timer += Time.deltaTime;

            }
        }

    }
    public void SpreadPower()
    {
        if (powerUpClicked) return;

        powerUpClicked = true;
        hasSpreadBullet = true;
    }


    public void RedBloodCellsAttack()
    {
        if (powerUpClicked) return;

        powerUpClicked = true;
        areRedBloodCellsAttacking = true;
    }



}
