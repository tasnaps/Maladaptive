using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoppupulmaSoitinA : MonoBehaviour
{
    private Transform tyhja;
    private Transform taysi;
    private Transform kela;
    private Transform third;
    private bool activated = false;

    private Transform lattia;

    // Start is called before the first frame update
    void Start()
    {
        tyhja = this.transform.Find("Tyhja");
        taysi = this.transform.Find("Taysi");
        kela = this.transform.Find("Kela C");
        third = this.transform.Find("Third Wheel");

        taysi.gameObject.SetActive(false);

        lattia = this.transform.Find("Lattia");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == kela.gameObject && !activated)
        {
            activated = true;
            taysi.gameObject.SetActive(true);
            kela.gameObject.SetActive(false);
            third.gameObject.SetActive(false);
            MainHomma();
        }
    }

    // Here you will write all the specific code 
    void MainHomma()
    {
        StartCoroutine(SlideCoroutine());
    }

    IEnumerator SlideCoroutine()
    {
        for(int i = 0; i < 100; i++)
        {
            lattia.position += new Vector3(0, 0, -0.1F);
            yield return new WaitForSeconds(0.02F);
        }
    }
}
