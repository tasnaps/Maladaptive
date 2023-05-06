using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilmaTriggerScript : MonoBehaviour
{
    private Transform auki;
    private Transform kiinni;
    private bool done = false;

    void Start()
    {
        auki = this.transform.parent.gameObject.transform.Find("moe");
        kiinni = this.transform.parent.gameObject.transform.Find("mce");
        auki.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && !done)
        {
            auki.gameObject.SetActive(true);
            kiinni.gameObject.SetActive(false);
            done = true;
        }
    }
}
