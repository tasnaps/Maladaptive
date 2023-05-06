using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWieFloorScript : MonoBehaviour
{
    [SerializeField] private int viewAngle = 90;
    private float thisRotation;
    private float angleRight;
    private float angleLeft;

    [SerializeField] private bool toggleRender;
    [SerializeField] private bool toggleCollider;

    private GameObject playerObj;
    private MeshRenderer thisRender;
    private Collider thisCollider;
    private bool rightIsBigger;
    private float thisYPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj == null) 
        { 
            Debug.Log("Player not found, wall will not work."); 
        }

        thisRender = gameObject.GetComponentInChildren<MeshRenderer>();
        thisCollider = gameObject.GetComponentInChildren<Collider>();
        thisRotation = this.gameObject.transform.rotation.eulerAngles[1];
        thisYPosition = this.gameObject.transform.position[1] + 0.9F;
        Calculate();

        if (!toggleRender)
        {
            thisRender.enabled = false;
        }
    }
    
    void Calculate()
    {
        // Recalculate view angles
        angleRight = thisRotation + viewAngle;  
        angleLeft = thisRotation - viewAngle;
        // Ensure that both angles in ragne 0 - 360
        if (angleRight >= 360) 
        { 
            angleRight -= 360;
        }
        if (angleLeft <= 0) 
        { 
            angleLeft += 360;
        }
        if (angleRight > angleLeft) { rightIsBigger = true; } else { rightIsBigger = false; }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj.transform.position[1] < thisYPosition) {
            thisRender.enabled = false;
            thisCollider.enabled = false;
        }
        else {
            if (rightIsBigger) {
                if (playerObj.transform.rotation.eulerAngles[1] < angleRight && playerObj.transform.rotation.eulerAngles[1] > angleLeft)
                {   
                    // Show the wall
                    if (toggleRender) { thisRender.enabled = true; }
                    if (toggleCollider) { thisCollider.enabled = true; }
                }
                else
                {   // Remove the wall
                    if (toggleRender) { thisRender.enabled = false; }
                    if (toggleCollider) { thisCollider.enabled = false; }
                }
            }
            else {
                if (playerObj.transform.rotation.eulerAngles[1] < angleRight || playerObj.transform.rotation.eulerAngles[1] > angleLeft)
                {   
                    // Show the wall
                    if (toggleRender) { thisRender.enabled = true; }
                    if (toggleCollider) { thisCollider.enabled = true; }
                }
                else
                {   // Remove the wall
                    if (toggleRender) { thisRender.enabled = false; }
                    if (toggleCollider) { thisCollider.enabled = false; }
                }
            }
        }
    }
}
