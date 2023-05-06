using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// DEPRECATED
// This script has been replaced by RotatingScript.
// This script is still needed for future development
public class RotationDoorScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 positionDifference;
    private double angle;
    private double tangent;
    private double radians;
    private bool xPositive;
    private bool yPositive;

    // Update is called once per frame
    void Update()
    {
        positionDifference = player.transform.position - this.gameObject.transform.position;
        xPositive = positionDifference[0] > 0 ? true : false;
        yPositive = positionDifference[2] > 0 ? true : false;

        angle = NewAngle();
        
        this.gameObject.transform.eulerAngles = new Vector3(0, (float)angle, 0);
    }

    double NewAngle()
    {
        tangent = DifferenceTangent();
        /* if (xPositive) 
        {
            if (yPositive) 
            {
                return -tangent;
            }
            else
            {
                return 360 - tangent;
            }
        }
        else
        {
            return 180 - tangent;
        } */

        return xPositive ? (yPositive ? -tangent : 360 - tangent) : 180 - tangent;
    }

    double DifferenceTangent()
    {
        radians = Math.Atan(positionDifference[2] / positionDifference[0]);
        return radians * (180 / Math.PI);
    }
}
