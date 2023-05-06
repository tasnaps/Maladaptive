using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsteTriggeriScript : MonoBehaviour
{
    private Transform este;
    // Start is called before the first frame update
    void Start()
    {
        este = this.transform.Find("Este");
        este.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            este.gameObject.SetActive(true);
        }
    }
}
