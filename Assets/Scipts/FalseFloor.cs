using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseFloor : MonoBehaviour
{
    bool isFalling = false;
    float downSpeed = 0;

    // Triggers the object when player touch and destroy it after
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            isFalling = true;
            Destroy(gameObject, 1);
        }
    }

    // Activates the falling
    void Update()
    {
        if(isFalling)
        {
            downSpeed += Time.deltaTime/30;
            transform.position=new Vector3(transform.position.x, transform.position.y-downSpeed,transform.position.z);
        }
    }

    
}
