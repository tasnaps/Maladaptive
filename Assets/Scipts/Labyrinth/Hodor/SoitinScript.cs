using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoitinScript : MonoBehaviour
{
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject interactionObject;

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject == key)
        {
            interactionObject.GetComponent<FloorTestScript>().access = true;
            Debug.Log("Access Granted");
        }
        else
        {
            Debug.Log("Not the key");
        }
    }
}
