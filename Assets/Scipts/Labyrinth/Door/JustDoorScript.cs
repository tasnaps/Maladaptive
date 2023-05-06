using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustDoorScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grabbable")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
