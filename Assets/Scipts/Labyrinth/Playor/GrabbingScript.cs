using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code is based on a video by Mohammad Baydoun (https://www.youtube.com/watch?v=XpFjnd83eu0&t=478s&ab_channel=MohammadBaydoun)
// Implemented by Aleksei Pankov, 20.02.2023
public class GrabbingScript : MonoBehaviour
{
    // Raycast
    private RaycastHit hit;
    // Object to be grabbed
    private GameObject grabbedObject;
    private Rigidbody grabbedRigidbody;
    private float grabbedMass;
    // Rotation
    private float grabbedRotation = 0;
    [SerializeField] float grabbedRotationSpeed = 1;
    // Position of empty "GrabPos" object on PlayerCamera
    private Transform grabPos;
    [SerializeField] private bool release = true;
    
    void Start()
    {
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
            hit.transform.GetComponent<Rigidbody>() && hit.transform.tag == "Grabbable")
        {
            grabbedObject = hit.transform.gameObject;   // Selected object is locked to player == grabbed
            grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
            grabbedMass = grabbedRigidbody.mass;
        }
        else if(release)               // Right-mouse pressed. Change to any random text, to get "only dragging" effect
        {
            grabbedObject = null;                       // Unselect grabbed object == release
        }
        else if(Input.GetButton("Fire2"))
        {
            grabbedObject = null;
        }
    }

    void HandleObject()
    {
        if (grabbedObject != null)                      // If an object is grabbed
        {
            if (Input.GetKey("q"))
            {
                grabbedRotation -= grabbedRotationSpeed;
            }
            if (Input.GetKey("e"))
            {
                grabbedRotation += grabbedRotationSpeed;
            }
            grabbedObject.transform.eulerAngles = new Vector3(0, grabbedRotation, 0);
            // Change position of grabbed object: reduce residual between center and object positions
            grabbedRigidbody.velocity = (11 - grabbedMass) * (grabPos.position - grabbedObject.transform.position);
        }
    }
}

