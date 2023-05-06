using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotatingScript : MonoBehaviour
{
    // Raycast
    private RaycastHit hit;
    // Objects    
    private GameObject grabbedObject;
    private RotatingRestriction grabbedRestriction;
    private GameObject player;
    // Grab
    private Transform grabPos;
    [SerializeField] private bool release = true;
    // Angles
    private Vector3 positionDifference;
    private double angle;
    private double tangent;
    private double radians;
    private bool xPositive;
    private bool yPositive;

    // EXPERIMENTAL
    private double rotationRestrictionSmaller = 0;
    private double rotationRestrictionBigger = 360;

    void Start()
    {
        player = this.gameObject;
        grabPos = GameObject.Find("GrabPos").GetComponent<Transform>();
    }

    void Update()
    {
        Grab();
        HandleObject();        
    }

    void Grab()
    {
        if (Input.GetButton("Fire1") && Physics.Raycast(transform.position, transform.forward, out hit, 5) &&
            hit.transform.GetComponent<Rigidbody>() && hit.transform.tag == "Rotatable")
        {
            grabbedObject = hit.transform.gameObject;
            grabbedRestriction = grabbedObject.GetComponent<RotatingRestriction>();
            rotationRestrictionBigger = grabbedRestriction.restrictionMax;
            rotationRestrictionSmaller = grabbedRestriction.restrictionMin;
        }
        else if (release) // Release object when mouse released, if release == true;
        {
            grabbedObject = null;
        }
        else if(Input.GetButton("Fire2")) // Release object on right-mouse
        {
            grabbedObject = null;
        }
    }
    
    void HandleObject()
    {
        if (grabbedObject != null) // If the object is grabbed
        {
            positionDifference = grabPos.position - grabbedObject.transform.position; // Calculate a distance vector
            // From distance, check relative location of grabPos
            xPositive = positionDifference[0] > 0 ? true : false;
            yPositive = positionDifference[2] > 0 ? true : false;

            angle = NewAngle(); // New angle to be set
            
            grabbedObject.transform.eulerAngles = new Vector3(0, (float)angle, 0); // Set new angle
        }
    }

    double NewAngle()
    {
        tangent = DifferenceTangent();
        angle = xPositive ? (yPositive ? 360 -tangent : -tangent) : 180 - tangent;
        //Debug.Log(angle);
        return CheckNewAngle();
        //return angle;
    }

    double DifferenceTangent()
    {
        radians = Math.Atan(positionDifference[2] / positionDifference[0]);
        return radians * (180 / Math.PI);
    }

    // BUGALERT: When rotation gets over the limit from either side (0 or 360) the value "jumps" (e.g. 1 -> 0 -> 360)
    // This activates the checker below, but the chosen restriction is wrong. (It was "the second if" on 1, 0, but now it jumps to "the first if" on 360)
    double CheckNewAngle()
    {
        if (angle > rotationRestrictionBigger)
        {
            return rotationRestrictionBigger - 1;
        }
        else if (angle < rotationRestrictionSmaller)
        {
            return rotationRestrictionSmaller + 1;
        }
        return angle;
    }
}
