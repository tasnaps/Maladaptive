using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterSoitinScriptBase : MonoBehaviour
{
    private Transform tyhja;
    private Transform taysi;
    private Transform kela;
    private bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        tyhja = this.transform.Find("Tyhja");
        taysi = this.transform.Find("Taysi");
        kela = this.transform.Find("Kela C");

        taysi.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == kela && !activated)
        {
            activated = true;
            taysi.gameObject.SetActive(true);
            MainHomma();
        }
    }

    // Here you will write all the specific code 
    void MainHomma()
    {

    }
}
